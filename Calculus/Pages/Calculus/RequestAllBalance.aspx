<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="RequestAllBalance.aspx.cs" Inherits="Pages_Calculus_RequestAllBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 858px; height: 59px">
        <tr>
            <td class="TableHeader" colspan="2" style="height: 27px">
                &nbsp;Request Opening Balance
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 268px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="857px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 218px; height: 38px;">
                Add Openening Balance:
            </td>
            <td class="TableGrid" style="height: 38px">
                &nbsp;<asp:DropDownList ID="ddlBalanceTyp" runat="server" SkinID="ddlSkin" Height="21px"
                    Width="154px" OnSelectedIndexChanged="ddlBalanceTyp_SelectedIndexChanged" AutoPostBack="true">
                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                    <%--<asp:ListItem Value="Petty">PettyCash Balance</asp:ListItem>--%>
                    <%--<asp:ListItem Value="HO">HO Balance</asp:ListItem>--%>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnHOTrnsfr" runat="server" Text="Download Ho Transfer" Visible="false"
                    Width="152px" OnClick="btnHOTrnsfr_Click" />
            </td>
        </tr>
        <td colspan="4" style="height: 26px">
        </td>
        <tr>
            <td class="TableTitle" style="width: 218px; height: 38px;">
                <asp:Label ID="Label1" runat="server" Text="PettyCash Sample:" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<%--<asp:Button
                    ID="btnPetty" runat="server" Text="Download" Width="82px" OnClick="btnPetty_Click" />--%>
            </td>
            <td class="TableTitle" style="width: 218px; height: 38px;">
                <asp:Label ID="Label2" runat="server" Text="HO Balance Sample:" Font-Bold="true"></asp:Label>&nbsp;<asp:Button
                    ID="btnHO" runat="server" Text="Download" Width="77px" OnClick="btnHO_Click" />
            </td>
        </tr>
        <td colspan="4" style="height: 26px">
        </td>
    </table>
    <%--<asp:Panel ID="PnlPetty" runat="server" Visible="false">
        <table style="width: 858px; height: 59px">
            <tr>
                <td class="TableHeader" colspan="4">
                    &nbsp;PettyCash/HO Bulk Upload&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;please download upload Sample file :&nbsp;&nbsp; 
                    &nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Download" />
                </td>
                <td style="width: 264px; height: 29px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px" class="TableTitle">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td style="width: 100px; height: 26px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnBalImport" runat="server" Text="Save" Height="24px" Width="52px" 
                        onclick="BtnBalImport_Click" />
                </td>
                <td style="width: 101px; height: 26px">
                    <asp:Button ID="btnCancel" runat="server" Height="24px" OnClick="btnCancel_Click"
                        Text="Cancel" Width="52px" />
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 26px">
                </td>
            </tr>
        </table>
    </asp:Panel>--%>
    <asp:Panel ID="PnlHO" runat="server" Visible="false">
        <table style="width: 858px; height: 59px">
            <tr>
                <td class="TableHeader" colspan="4">
                    &nbsp;PettyCash/HO Bulk Upload&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td style="width: 264px; height: 29px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px" class="TableTitle">
                    <asp:FileUpload ID="xslFileUpload" runat="server" />
                </td>
                <td style="width: 100px; height: 26px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBulkSave" runat="server" Text="Save" Height="24px" Width="52px"
                        OnClick="btnBulkSave_Click" />
                </td>
                <td style="width: 101px; height: 26px">
                    <asp:Button ID="btnCancel0" runat="server" Height="24px" OnClick="btnCancel_Click"
                        Text="Cancel" Width="52px" />
                </td>
                <td style="height: 26px">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlGrid" runat="server" Visible="false">
        <table style="width: 858px; height: 59px">
            <tr>
                <td style="height: 17px" colspan="4">
                    <asp:GridView ID="Gr_Ope_Bal" runat="server" AutoGenerateColumns="False" Height="131px"
                        Width="717px" CssClass="mGrid">
                        <Columns>
                            <asp:BoundField DataField="openingBalanceID">
                                <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                                <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BranchID">
                                <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                                <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                            <asp:BoundField DataField="openingBalanceYear" HeaderText="Year" />
                            <asp:BoundField DataField="openingBalanceMonth" HeaderText="Month" />
                            <asp:BoundField DataField="OpeningBalanceAmount" HeaderText="Amount" />
                            <asp:BoundField DataField="RequestType" HeaderText="RequestType" />
                            <%--<asp:BoundField DataField="Remark" HeaderText="Remark" />--%>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="HO_Amount" HeaderText="HO Amount" />
                            <asp:BoundField DataField="DateTransfer" HeaderText="Date Of Transfer" />
                            <asp:BoundField DataField="OTP_Amount" HeaderText="OTP Amount" />
                            <asp:BoundField DataField="OTPDateTransfer" HeaderText="OTP DateOf Transfer" />
                            <asp:BoundField DataField="MonthId">
                                <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                                <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReqType">
                                <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                                <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                    BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StatusID">
                                <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                    CssClass="grv_Column_hidden" />
                                <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
                        <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvExportReport" runat="server" Height="100px" Width="22%">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="height: 19px">
                    <asp:HiddenField ID="hdnReqBranch" runat="server" EnableViewState="False" />
                    <asp:HiddenField ID="hdnYrNMnth" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
