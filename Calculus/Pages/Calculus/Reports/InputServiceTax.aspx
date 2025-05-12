<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="InputServiceTax.aspx.cs" Inherits="InputServiceTax" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js" >

</script>
    <table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label><br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValGenReport" />
            </td>
        </tr>
        <tr>
            <td colspan="7" class="TableHeader">
                &nbsp; Input Service Tax Report</td>
        </tr>
        <tr>
            <td style="width: 11px; height: 16px;">
            </td>
            <td class="TableTitle" style="width: 122px; height: 16px">
                &nbsp;Branch Name</td>
            <td style="width: 100px; height: 16px;">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
                </td>
            <td style="width: 109px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 122px" class="TableTitle">
                &nbsp;Request From Date</td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px; height: 20px">
                            <asp:RequiredFieldValidator ID="rq_FromDate" runat="server" ControlToValidate="txtFromDate"
                                ErrorMessage="Please From Date to continue...." SetFocusOnError="True" ValidationGroup="ValGenReport">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 109px" class="TableTitle">
                &nbsp;Request To Date</td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox></td>
                        <td style="width: 100px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px">
                            <asp:RequiredFieldValidator ID="rq_toDate" runat="server" ControlToValidate="txtToDate"
                                ErrorMessage="Please ToDate to continue...." SetFocusOnError="True" ValidationGroup="ValGenReport">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnReportType" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 30px;" class="TableTitle" colspan="7">
                &nbsp;
                <asp:Button ID="BtnGenerate" runat="server" AccessKey="G" BorderWidth="1px" OnClick="BtnGenerate_Click"
                    Text="Generate" ValidationGroup="ValGenReport" />&nbsp;<asp:Button ID="btnReset" runat="server" AccessKey="R" BorderWidth="1px"
                        Text="Reset" Width="70px" /></td>
        </tr>
        <tr>
            <td colspan="7">
            <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
                <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                    width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvExportReport" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None" Height="100px" Width="98%">
                                <RowStyle BackColor="#FFFBD6" CssClass="GridViewRowStyle" ForeColor="#333333" />
                                <FooterStyle BackColor="#990000" CssClass="GridViewFooterStyle" Font-Bold="True"
                                    ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" CssClass="GridViewPagerStyle" ForeColor="#333333"
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#FFCC66" CssClass="GridViewSelectedRowStyle" Font-Bold="True"
                                    ForeColor="Navy" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" CssClass="GridViewAlternatingRowStyle" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 122px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 109px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 36px">
                &nbsp;&nbsp;
                <asp:Button ID="btnExport" runat="server" AccessKey="E" BorderWidth="1px" OnClick="btnExport_Click"
                    Text="Export" Width="67px" />&nbsp;<asp:Button ID="btnCancel" runat="server" AccessKey="C"
                        BorderWidth="1px" Text="Cancel" Width="72px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 122px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 109px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

