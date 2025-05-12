<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="CDMA_ReportExtract.aspx.cs" Inherits="CoreDailyMISAutomation.CDMA_ReportExtract" %>

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
    <table style="width: 800px;">
        <tr>
            <td class="TableTitle" style="height: 40px" colspan="8">
                <span style="font-size: 13pt; font-weight: bold;">Report Extract</span>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlFieldSelection" runat="server">
        <table style="width: 800px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblVertical" runat="server">Vertical</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtVertical" runat="server" Text="CPA" Enabled="false"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblSubVertical" runat="server">Sub Vertical</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlSubVertical" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlSubVertical_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblClientName" runat="server">Client Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlClientName" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged"></asp:DropDownList>
                </td>

                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblActivity" runat="server">Activity</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlActivity" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>     <%--OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged"--%>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblProduct" runat="server">Product</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlProduct" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblSubProduct" runat="server">Sub Product/process</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlSubProduct" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblMonthYear" runat="server">Month and Year</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtMonthYear" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                    <img id="ImgAgreementExeDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtMonthYear.ClientID%>, 'mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblMIS" runat="server">Select MIS</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlMIS" runat="server" Width="175px" AutoPostBack="true">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Monthly Volume MIS</asp:ListItem>
                        <asp:ListItem>Billing MIS</asp:ListItem>
                        <asp:ListItem>Manual Update MIS</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnSearch" runat="server" Text="Search"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnSearch_Click" Style="left: 0px; top: -2px; width: 200px" />
                </td>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnBack" runat="server" Text="Back"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnBack_Click" Style="left: 0px; top: -2px; width: 200px" />
                </td>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnExport" runat="server" Text="Export"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnExport_Click" Style="left: 0px; top: -2px; width: 200px" />
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
