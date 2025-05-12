<%@ Page Title="" Language="C#" MasterPageFile="~/InternalAudit.Master" AutoEventWireup="true" CodeBehind="InternalAudit_AssessmentDetailsReport.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_AssessmentDetailsReport" %>

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
                <span style="font-size: 13pt; font-weight: bold;">Assessment Details Report</span>
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
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlreportDetails2" runat="server">
        <table style="width: 688px;">
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

        </table>
    </asp:Panel>

    <asp:Panel ID="pnlButtons" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnSearch" runat="server" Text="Search"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Style="left: 0px; top: -2px; width: 200px" OnClick="BtnSearch_Click" />
                </td>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnBack" runat="server" Text="Back"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Style="left: 0px; top: -2px; width: 200px" OnClick="BtnBack_Click" />
                </td>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnExport" runat="server" Text="Export"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Style="left: 0px; top: -2px; width: 200px" OnClick="BtnExport_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>


    <asp:Panel ID="pnlGridForReport1" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsReport" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true"
                        AllowPaging="True" OnPageIndexChanging="GVDetailsReport_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr.No" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quarter" HeaderText="Quarter" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Branch" HeaderText="Branch" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GAP_ID" HeaderText="GAP ID" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NameOfAuditor" HeaderText="Name Of Auditor" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DateOfAudit" HeaderText="DateOfAudit" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ClauseOrControlName" HeaderText="Clause Or Control Name" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EvidenceDetailsForWeekness" HeaderText="Evidence Details For Weekness" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditDecision" HeaderText="Audit Decision" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FinalStatus" HeaderText="Final Status" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AssessmentStatus" HeaderText="Assessment Status" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ScopeORNonscope" HeaderText="Scope/Nonscope" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ToAuditee" HeaderText="Assigne To Auditee" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CorrectionWithReferenceToEvidence" HeaderText="Correction With Reference To Evidence" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RootCauseAnalysis" HeaderText="Root Cause Analysis" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Action" HeaderText="Corrective Action Taken" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ScopeORNonscope" HeaderText="Scope/Nonscope" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="800px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
