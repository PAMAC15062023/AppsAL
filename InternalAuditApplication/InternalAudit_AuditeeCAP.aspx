<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/InternalAudit.Master" CodeBehind="InternalAudit_AuditeeCAP.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_AuditeeCAP" %>

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
                <span style="font-size: 13pt; font-weight: bold;">Auditee CAP</span>
            </td>
        </tr>
    </table>

    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlSearchForAssessmentDetails" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsFromAssessment" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="ID">
                        <Columns>
                            <asp:BoundField DataField="SrNO" HeaderText="Sr. No." ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Branch" HeaderText="Branch" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DateOfAudit" HeaderText="Date Of Audit" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="GAP_ID" HeaderText="GAP ID" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ClauseOrControlName" HeaderText="Weakness/Area of Concern/Flaw (Auditor Report)" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="EvidenceDetailsForWeekness" HeaderText="Evidence details for weakness/area of concern/flaw" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AuditDecision" HeaderText="Audit Decision" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditor" HeaderText="Name Of Auditor" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditee" HeaderText="Name Of Auditee" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ToAuditee" HeaderText="Point Address To Auditee" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbox" runat="server" onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnEdit" Text="Edit" runat="server" OnClick="lkbtnEdit_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlAuditeeCAPDetails" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Gap - ID</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtGAPID" runat="server" Width="240px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Weakness/Area of Concern/Flaw (Auditor Report)</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtClauseOrControl" runat="server" Width="240px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <tr>
                    <td class="TableTitle" colspan="8" style="height: 27px">
                        <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Evidence details for weakness/area of concern/flaw</asp:Label>
                    </td>
                    <td class="TableTitle" colspan="8" style="height: 27px">
                        <asp:TextBox ID="txtEvidenceDetails" runat="server" Width="240px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Audit Decision</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtAuditDecision" runat="server" Width="240px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Point Address To Auditee</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtToAuditee" runat="server" Width="240px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Correction With Reference to Evidence</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtCorrectionWithReferenceToEvidence" runat="server" Width="240px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Root Cause Analysis</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtRootCauseAnalysis" runat="server" Width="240px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Corrective Action</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtAction" runat="server" Width="240px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Responsibility</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtResponse" runat="server" Width="240px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Targate Date</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtTargateDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="240px"
                        autocomplete="off" oncopy="return false" onpaste="return false"></asp:TextBox>
                    <img id="ImgTargateDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtTargateDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
               <%-- <td class="TableTitle" style="width: 100px; height: 20px"></td>--%>
                <%--<td style="width: 100px; height: 20px"></td>--%>
            </tr>
        </table>
        <table style="width: 691px;">
            <tr>
                <td class="TableTitle" style="width: 115px;"><strong>Evidence Attached</strong> </td>
                <td class="TableGrid" style="width: 100px;">
                    <asp:FileUpload ID="FUEvidenceAttached" runat="server" />
                    <asp:Label ID="lblEvidenceAttached" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnAssessmentID" runat="server" />
    </asp:Panel>
    <table style="width: 691px;">
        <tr>
            <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                <asp:Button ID="BtnSave" runat="server" Text="Save"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnSave_Click" Style="left: 0px; top: -2px; width: 200px" />
            </td>
            <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="BtnBack_Click"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Style="left: 0px; top: -2px; width: 200px" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HdnGAPID" runat="server" />

</asp:Content>
