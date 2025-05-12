<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/InternalAudit.Master" CodeBehind="InternalAudit_StatusUpdate.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_StatusUpdate" %>

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
                <span style="font-size: 13pt; font-weight: bold;">Status Update</span>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlSearchForAuditeeCapDetails" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Quarter</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlQuarter" runat="server" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>

                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Branch</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="225px"></asp:DropDownList>
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
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlGridForAssessmentDetails" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsFromAssessment" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="ID">
                        <Columns>

                            <asp:BoundField DataField="SrNO" HeaderText="Sr. No." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Branch" HeaderText="Branch" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DateOfAudit" HeaderText="Date Of Audit" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="GAP_ID" HeaderText="GAP ID" ItemStyle-Width="350px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ClauseOrControlName" HeaderText="Weakness/Area of Concern/Flaw (Auditor Report)" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="EvidenceDetailsForWeekness" HeaderText="Evidence details for weakness/area of concern/flaw" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AuditDecision" HeaderText="Audit Decision" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditor" HeaderText="Name Of Auditor" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditee" HeaderText="Name Of Auditee" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NameOfAuditee" HeaderText="Name Of Auditee" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ToAuditee" HeaderText="Assigned To Auditee" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ScopeORNonscope" HeaderText="Scope/NonScope" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
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


    <asp:Panel ID="pnlStatusUpdate" runat="server">
        <table style="width: 688px;">
            <tr>
                <%--add on 31/08/2024--%>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Evidence details for weakness/area of concern/flaw</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtEvidencedetailsforweakness" runat="server" Width="225px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Correction With Reference to Evidence</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtCorrectionWithReferenceToEvidence" runat="server" Width="225px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Root Cause Analysis</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtRootCauseAnalysis" runat="server" Width="225px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Corrective Action Taken</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtAction" runat="server" Width="225px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Response</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtResponse" runat="server" Width="225px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Targate Date</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtTargateDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="width: 100px; height: 20px">
                    <img id="ImgTargateDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtTargateDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Download Evidence</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtViewAndDownload" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px" TextMode="MultiLine"></asp:TextBox>

                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:LinkButton ID="btnViewAndDownLoad" runat="server" OnClick="btnViewAndDownLoad_Click">Download</asp:LinkButton>
                </td>
            </tr>

            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Verification Remark By Auditor</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtVerificationOfCAPByAuditor" runat="server" Width="225px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">CAP verticiation date</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:TextBox ID="txtCAPVerticiationDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="width: 100px; height: 20px">
                    <img id="ImgCAPverticiationdate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCAPVerticiationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:Label runat="server" Font-Size="10" Height="20" Style="text-align: center;" Width="200px">Final Status</asp:Label>
                </td>
                <td class="TableTitle" colspan="8" style="height: 27px">
                    <asp:DropDownList ID="ddlFinalStatus" runat="server" Width="225px" OnSelectedIndexChanged="ddlFinalStatus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="PnlButtons" runat="server">
        <table>
            <tr>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnClose" runat="server" Text="Close"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnClose_Click" Style="left: 0px; top: -2px; width: 200px" />
                </td>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnReturn" runat="server" Text="Return"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnReturn_Click" Style="left: 0px; top: -2px; width: 200px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table>
        <tr>
            <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                <asp:Button ID="BtnBack1" runat="server" Text="Back"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnBack1_Click" Style="left: 0px; top: -2px; width: 200px" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnIDForStatusUpdate" runat="server" />
    <asp:HiddenField ID="HdnGAPID" runat="server" />
    <asp:HiddenField ID="hdnFileName" runat="server" />
    <asp:HiddenField ID="hdnGridviewRowCount" runat="server" />
    <asp:HiddenField ID="hdnAuditorEmailId" runat="server" />
    <asp:HiddenField ID="hdnNameOfAuditor" runat="server" />
    <asp:HiddenField ID="hdnAuditeeEmailId" runat="server" />
    <asp:HiddenField ID="hdnNameOfAuditee" runat="server" />
</asp:Content>
