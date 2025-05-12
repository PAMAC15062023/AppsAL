<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/InternalAudit.Master" CodeBehind="InternalAudit_Report2.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_Report2" %>

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
                <span style="font-size: 13pt; font-weight: bold;">Details Report</span>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlSearchForReport2Details" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
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
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Final Status</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlFinalStatus" runat="server" Width="225px"></asp:DropDownList>
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

    <asp:Panel ID="pnlGridForReport2" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsFromReport2" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true">
                        <Columns>


                            <asp:BoundField DataField="Branch" HeaderText="Branch" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DateOfAudit" HeaderText="Date of Audit" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Gap_ID" HeaderText="Gap_ID" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ClauseOrControl" HeaderText="Weakness/Area of Concern/Flaw (Auditor Report)" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="EvidenceDetails" HeaderText="Evidence details for weakness/area of concern/flaw" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AuditDecision" HeaderText="Audit Decision" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CorrectionWithReferenceToEvidence" HeaderText="Correction with reference to evidence" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="RootCauseAnalysis" HeaderText="Root Cause Analysis" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CorrectiveActionTaken" HeaderText="Corrective Action Taken" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Response" HeaderText="Responsibility" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="TargetDate" HeaderText="TargetDate" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="VerificationRemarkByAuditor" HeaderText="Verification Remark By Auditor" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CAPVerticiationDate" HeaderText="CAP Verticiation Date" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FinalStatus" HeaderText="Final Status" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditor" HeaderText="Name Of Auditor" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditee" HeaderText="Name Of Auditee" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ScopeORNonscope" HeaderText="Scope NonScope" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
