<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/InternalAudit.Master" CodeBehind="InternalAudit_Assessment.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_Assessment" %>

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
    <table style="width: 900px;">
        <tr>
            <td class="TableTitle" style="height: 40px" colspan="8">
                <span style="font-size: 13pt; font-weight: bold;">Assessment</span>
            </td>
        </tr>
    </table>

    <%-- panel1 --%>

    <table>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
    <asp:Panel ID="PnlAssessment1" runat="server">
        <table style="width: 688px;">


            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="gvAssessmentdata" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="ID">
                        <Columns>
                            <asp:TemplateField HeaderText="SrNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Branch" HeaderText="Branch/Location" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AuditScheduleDate" HeaderText="Audit Schedule Date" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DateOfAuditConducted" HeaderText="Date Of Audit Conducted" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CapSharedWithAuditee" HeaderText="CAP shared with Auditee" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FollowUpEmails" HeaderText="Follow Up Emails" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CapRevertStatus" HeaderText="CAP Revert Status" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AuditStatus" HeaderText="Audit Status" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remark" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Auditor" HeaderText="Auditor" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ScopeORNonscope" HeaderText="Scope/Nonscope" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbox" runat="server" onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnAssessment" Text="Assessment" runat="server" OnClick="lkbtnAssessment_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="PnlAssessmentData1" runat="server">
        <table style="width: 900px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Year</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtYear" runat="server" Width="200px"></asp:TextBox>
                </td>

                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Quarter</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtQuarter" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Location</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtLocation" runat="server" Width="220px"></asp:TextBox>
                </td>

                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Date Of Audit</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtDateOfAudit" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" Width="220px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="ImgAuditDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateOfAudit.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Name Of Auditor</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtNameOfAuditor" runat="server" Width="220px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="BtnSave1" runat="server" Text="Save"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnSave1_Click" Style="left: 0px; top: -2px; width: 200px" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="PnlAssessment2" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Name Of Auditee</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtNameOfAuditee" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Vertical</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtVertical" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Unit</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Clause/Control/name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlClauseOrControl" runat="server" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="300px" Font-Size="10" Height="20" Style="text-align: center;">Evidence details for weaknes/ area of concern/ flaw</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtEvidenceDetails" runat="server" Width="220px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Audit Decision</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlAuditDecision" runat="server" Width="225px"></asp:DropDownList>
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
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Point Address To Auditee</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="DDLPointAddresstoAuditee" runat="server" Width="225px"></asp:DropDownList>
                </td>
            </tr>

            <%--<tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">GAP - ID</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtGapID" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
            </tr>--%>
        </table>
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                    <asp:Button ID="BtnAdd" runat="server" Text="Add"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnAdd_Click" Style="left: 0px; top: -2px; width: 200px" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="PNLAddAssessment" runat="server">
        <table style="width: 688px;">

            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVAddAssessment" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="ID">
                        <Columns>
                            <asp:BoundField DataField="SrNO" HeaderText="Sr. No." ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ClauseOrControlName" HeaderText="Clause or Control Name" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="EvidenceDetailsForWeekness" HeaderText="Evidence Details For Weekness" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AuditDecision" HeaderText="Audit Decision" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FinalStatus" HeaderText="Final Status" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="GAP_ID" HeaderText="GAP_ID" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ToAuditee" HeaderText="Point Address To Auditee" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DateOfAuditConducted" HeaderText="Date Of Audit Conducted" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbox" runat="server" onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnRemove" Text="Remove" runat="server" OnClick="lkbtnRemove_Click"></asp:LinkButton>
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


    <table>
        <tr>
            <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                <asp:Button ID="BtnSaveAndContinue" runat="server" Text="Save And Submit"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnSaveAndContinue_Click1" Style="left: 0px; top: -2px; width: 200px" />
            </td>

            <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                <asp:Button ID="BtnBack" runat="server" Text="Back"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnBack_Click" Style="left: 0px; top: -2px; width: 200px" />
            </td>

        </tr>
    </table>
    <asp:HiddenField ID="hdnAuditID" runat="server" />
    <asp:HiddenField ID="hdnAssessmentID" runat="server" />
    <asp:HiddenField ID="hdnGAPID" runat="server" />

</asp:Content>
