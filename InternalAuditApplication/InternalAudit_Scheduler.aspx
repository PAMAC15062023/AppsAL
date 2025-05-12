<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/InternalAudit.Master" CodeBehind="InternalAudit_Scheduler.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_Scheduler" %>

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
                <span style="font-size: 13pt; font-weight: bold;">Scheduler</span>
            </td>
        </tr>
    </table>

    <%-- panel1 --%>

    <asp:Panel ID="PnlScheduler1" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblAuditor" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlAuditor" runat="server" Width="150px" AutoPostBack="true"></asp:DropDownList>
                </td>

                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnSearch" runat="server" Text="Search"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSearch_Click" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="BtnBackFromSearch" runat="server" Text="Back"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="BtnBackFromSearch_Click" />
                </td>
            </tr>
        </table>
         </asp:Panel>
         
     <asp:Panel ID="PnlSchedulerGrid2" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="gvschedulerdata" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="ID">
                        <Columns>
                            <asp:TemplateField HeaderText="SrNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Quarter_HalfYear" HeaderText="Quarter Half Year" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Branch" HeaderText="Branch" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical" HeaderText="Vertical" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ScheduleDate" HeaderText="Schedule Month" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Auditor" HeaderText="Auditor" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Auditee" HeaderText="Auditee" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AuditStatus" HeaderText="Audit Status" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ScopeORNonscope" HeaderText="Scope/Nonscope" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbox" runat="server" onclick ="CheckSingleCheckbox(this)"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnEdit" Text="Edit" runat="server" OnClick="lkbtnEdit_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnDelete" Text="Delete" runat="server" OnClick="lkbtnDelete_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
   </asp:Panel>

    <%-- panel2 --%>

    <asp:Panel ID="PnlScheduler2" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Quarter</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtQuarter" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Location/Branch</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtBranch" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Vertical</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtVertical" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Unit</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtUnit" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Schedule Month</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtScheduleDate" runat="server" BorderWidth="1px" SkinID="txtSkin" 
                     autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Auditor</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtAuditor" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Auditee</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtAuditee" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Audit Schedule Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtAuditScheduleDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="ImgAuditScheduleDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAuditScheduleDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
                <td style="width: 100px; height: 20px"></td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10pt" Height="20px" Style="text-align: center;">Date of Audit conducted</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtDateOfAuditConducted" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Cap shared with auditee</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCapSharedWithAuditee" runat="server" BorderWidth="1px" SkinID="txtSkin" 
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="ImgCapSharedWithAuditee" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCapSharedWithAuditee.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
                <td style="width: 100px; height: 20px"></td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Follow Up Emails</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtFollowUpEmails" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="ImgFollowUpEmails" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFollowUpEmails.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
                <td style="width: 100px; height: 20px"></td>
            </tr>

            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Cap Revert Status</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCapRevertStatus" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="220px"></asp:TextBox></td>
              </tr>
            <tr>
                <td class="TableTitle" style="height: 27px;" colspan="8">
                    <asp:Label runat="server" Width="184px" Font-Size="10pt" Height="20px" Style="text-align: center;">Remarks</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtRemarks" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="220px" Style="margin-left: 0px"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>          
            <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="200px" Font-Size="10" Height="20" Style="text-align: center;">Audit Status</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:DropDownList ID="ddlAduditStatus" runat="server" Width="225px" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlButtons" runat="server">
    <table>
        <tr>
            <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                <asp:Button ID="BtnSave" runat="server" Text="Save"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnSave_Click" Style="left: 0px; top: -2px; width: 200px" />
            </td>

            <td class="TableTitle" style="height: 27px; width: 220px;" colspan="4">
                <asp:Button ID="BtnBack" runat="server" Text="Back"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" OnClick="BtnBack_Click" Style="left: 12px; top: -1px; width: 208px; margin-bottom: 0" />
            </td>

        </tr>
    </table>
        </asp:Panel>
    <asp:HiddenField ID="HdnID" runat="server" />
</asp:Content>
