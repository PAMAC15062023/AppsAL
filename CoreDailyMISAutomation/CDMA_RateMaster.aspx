<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="CDMA_RateMaster.aspx.cs" Inherits="CoreDailyMISAutomation.CDMA_RateMaster" %>

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
            <td class="TableTitle" style="height: 40px" colspan="8" align="center">
                <span style="font-size: 13pt; font-weight: bold;">Rate Master</span>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <asp:Panel ID="pnlRadioButton" runat="server">
            <tr>
                <td align="center" class="TableTitle" style="height: 40px" colspan="8">
                    <asp:RadioButtonList ID="rdFreshEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdFreshEdit_SelectedIndexChanged" RepeatDirection="Horizontal" Font-Bold="true">
                        <asp:ListItem Text="EDIT" Value="EDIT"></asp:ListItem>
                        <asp:ListItem Text="Download" Value="Download"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </asp:Panel>
    </table>
    <table style="width: 800px;">
        <asp:Panel ID="PnlInsertRateMaster" runat="server">
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
                    <asp:Label ID="lblClientContactPerson" runat="server">Client Contact Person Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtClientContactPerson" runat="server" Enabled="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblClientContactNo" runat="server">Client Contact Number</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtClientContactNo" runat="server" Enabled="true"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblClientEmail" runat="server">Client Email</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtClientEmail" runat="server" Enabled="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblClientAddress" runat="server">Client Address</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtClientAddress" runat="server" Enabled="true"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblClientGSTNo" runat="server">Client GST No</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtClientGSTNo" runat="server" Enabled="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblTANNo" runat="server">TAN No</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtTANNo" runat="server" Enabled="true"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label runat="server">Agreement Execution Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtAgreementExeDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                    <img id="ImgAgreementExeDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAgreementExeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label runat="server">Agreement Expiry Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtAgreementExpiryDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                    <img id="ImgAgreementExpiryDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAgreementExpiryDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
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
                    <asp:Label ID="lblStatus" runat="server">Active /closed Status</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblCoreStaffing" runat="server">CORE/Staffing</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlCoreStaffing" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblCentralLocalActivity" runat="server">Central / Local Activity</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlCentralLocalActivity" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblBillingProcess" runat="server">Billing Process</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlBillingProcess" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblPenaltyClause" runat="server">Penalty clause (YES/NO)</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlPenaltyClause" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblMGV" runat="server">MGV (YES/NO)</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlMGV" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblICLOCL" runat="server">ICL/OCL (Only in PD)</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlICLOCL" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblBillingMode" runat="server">Billing Mode</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlBillingMode" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblRatePerFile" runat="server">Rate Per File/Case (Rs.)</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtRatePerFile" runat="server" Enabled="true" TextMode="Number"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblClientCRM" runat="server">Client CRM </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlClientCRM" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblRemarks" runat="server">Remarks</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="12">
                    <asp:TextBox ID="txtRemarks" runat="server" Enabled="true" Width="595px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="Save"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSave_Click" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnUpdate_Click" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="BtnBack" runat="server" Text="Back"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="BtnBack_Click" />
                </td>
            </tr>
        </asp:Panel>
    </table>
    <table style="width: 800px;">
        <asp:Panel ID="pnlRateMasterGrid" runat="server">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblVerticalEdit" runat="server">Vertical</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtVerticalEdit" runat="server" Text="CPA" Enabled="false"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblSubVerticalEdit" runat="server">Sub Vertical</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlSubVerticalEdit" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlSubVerticalEdit_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblClientNameEdit" runat="server">Client Name</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlClientNameEdit" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientNameEdit_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblActivityEdit" runat="server">Activity</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlActivityEdit" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>    <%-- OnSelectedIndexChanged="ddlActivityEdit_SelectedIndexChanged"--%>
            </td>
        </tr>

        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblProductEdit" runat="server">Product</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlProductEdit" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlProductEdit_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblSubProductEdit" runat="server">Sub Product/process</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlSubProductEdit" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Button ID="btnSearch" runat="server" Text="Search"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSearch_Click1" />
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Button ID="btnBackEdit" runat="server" Text="Back"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnBackEdit_Click" />
            </td>
        </tr>
    </table>
    <table style="width: 800px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:GridView ID="gvRateMaster" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SubVertical" HeaderText="Sub Vertical" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ClientName" HeaderText="Client Name" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Activity" HeaderText="Activity" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Product" HeaderText="Product" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="SubProduct" HeaderText="Sub Product" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="CoreorStaffing" HeaderText="Core/Staffing" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="CentralorLocalActivity" HeaderText="Central/Local Activity" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="BillingProcess" HeaderText="Billing Process" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ClientAddress" HeaderText="Client Address" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ClientContactPersonName" HeaderText="Client Contact Person Name" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ClientcontactNo" HeaderText="Client contact No" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ClientEmail" HeaderText="Client Email" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ClientGSTNo" HeaderText="Client GST No" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="TANNo" HeaderText="TAN No" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="AgreementExeDate" HeaderText="Agreement Execution Date" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="AgreementExpiryDate" HeaderText="Agreement Expiry Date" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PenaltyClause" HeaderText="Penalty Clause" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="MGV" HeaderText="MGV" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ICLorOCL" HeaderText="ICL/OCL" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="BillingMode" HeaderText="Billing Mode" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="RatePerFile" HeaderText="Rate Per File" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ClientCRM" HeaderText="Client CRM" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PANorITNo" HeaderText="PAN/IT No" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
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
        </asp:Panel>
    </table>
    <asp:HiddenField ID="HdnID" runat="server" />


    <asp:Panel ID="pnlDownloadRateMaster" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnDownloadRateMaster" runat="server" Text="Download Rate Master"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnDownloadRateMaster_Click" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnBack1" runat="server" Text="Back"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnBack1_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="GridForMIS" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="gvData" runat="server" Height="16px" Width="1200px" CssClass="mGrid" >
                        <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />--%>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
