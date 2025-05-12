<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/InternalAudit.Master" CodeBehind="InternalAudit_Report1.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_Report1" %>

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
    <script language="javascript" type="text/javascript">
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 40px" colspan="8">
                <span style="font-size: 13pt; font-weight: bold;">MIS</span>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlSearchForReport1Details" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Financial Year
                        <span style="color: red;">*</span>
                    </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlFinancialYear" runat="server" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Quarter
                        <span style="color: red;">*</span>
                    </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlQuarter" runat="server" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Vertical</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlVertical" runat="server" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Branch</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="225px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Unit</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlUnit" runat="server" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Scope/NonScope</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlScopeNonScope" runat="server" Width="225px"></asp:DropDownList>
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

    <asp:Panel ID="pnlGridForReport1" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsFromReport1" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true">
                        <Columns>

                            <asp:BoundField DataField="Branch" HeaderText="Location/Branch" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditor" HeaderText="Auditor" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditee" HeaderText="Auditee" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Observation_Findings" HeaderText="Observation Findings" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="OFI_Findings" HeaderText="OFI Findings" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NC_Findings" HeaderText="NC Findings" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Observation_Closed" HeaderText="Observation Closed" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="OFI_Closed" HeaderText="OFI Closed" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NC_Closed" HeaderText="NC Closed" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Observation_Open" HeaderText="Observation Open" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="OFI_Open" HeaderText="OFI Open" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NC_Open" HeaderText="NC Open" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Pending_Ratio" HeaderText="Pending Ratio" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ScopeNonScope" HeaderText="Scope/NonScope Ratio" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
