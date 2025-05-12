<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AUMVD_Master.Master" CodeBehind="AUMVD_Reports.aspx.cs" Inherits="AUMVD.AUMVD_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script language="javascript" type="text/javascript" src="App_Assets/js/popcalendar.js"></script>
    <script language="javascript" type="text/javascript">
        function DisableDelete(e) {
            var code;
            if (!e) var e = window.event; // some browsers don't pass e, so get it from the window
            if (e.keyCode) code = e.keyCode; // some browsers use e.keyCode
            else if (e.which) code = e.which;  // others use e.which

            if (code == 8 || code == 46)
                return false;
        }
        function disallowDelete(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            alert(charCode);
            // return true;

        };

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <table style="width: 900px;">
        <tr>
            <td class="TableTitle" style="height: 40px" colspan="8">
                <span style="font-size: 13pt; font-weight: bold;">Active User MIS</span>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlDateSelection" runat="server">
    <table runat="server" style="width: 900px;">
            <tr>
                <td runat="server" colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblMIS" runat="server">Select Report</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlMISType" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlMISType_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Active User List</asp:ListItem>
                        <asp:ListItem>Volume Data</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblMISName" runat="server">MIS For :</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlMISName" runat="server" Width="175px" >
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_Calculus">Calculus</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_TCFSL">TCFSL</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_SBI">SBI</asp:ListItem>
                        <%--<asp:ListItem Value="ActiveUserMIS_SBI">PMS_BVU</asp:ListItem>--%>
                        <asp:ListItem Value="ActiveUserMIS_PMSEast">PMS_East</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_PMSNorth">PMS_North</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_PMSSouth">PMS_South</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_PMSWest">PMS_West</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_Core">Core - Daily MIS Automation</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_InternalAudit">Internal Audit</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_LNTFinance">LNT Finance</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_YBL_OPS">YBL OPS</asp:ListItem>
                        <asp:ListItem Value="ActiveUserMIS_YBL_SFDC">YBL SFDC</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        <tr>
                <td runat="server" class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblFromDate" runat="server">From Date</asp:Label>
                </td>
                <td runat="server" class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                    <img id="ImgFromDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>

                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblToDate" runat="server">To Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                    <img id="ImgToDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
        </tr>
        <tr>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Style="left: 0px; top: -2px; width: 200px" />
                </td>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnBack" runat="server" Text="Clear" OnClick="BtnBack_Click"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Style="left: 0px; top: -2px; width: 200px" />
                </td>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnExport" runat="server" Text="Export" OnClick="BtnExport_Click"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Style="left: 0px; top: -2px; width: 200px" />
                </td>
            </tr>
        </table>
        </asp:Panel>
    <asp:Panel ID="GridForMIS" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="gvData" runat="server" Height="16px" Width="1200px" CssClass="mGrid">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    </asp:Content>
