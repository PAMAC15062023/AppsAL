<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CPRT_Report.aspx.cs" Inherits="Pages_ChequePrinting_CPRT_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td class="TableHeader" colspan="9" style="height: 22px">&nbsp;Report
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 22px" align="right">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 109px" class="TableTitle">From Date </td>
                        <td style="width: 231px" class="TableGrid">
                            <asp:TextBox ID="txtFromDate" runat="server" Width="125px"></asp:TextBox>
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="SmallCalendar.png" style="width: 17px; height: 16px" />
                        </td>
                        <td style="width: 109px" class="TableTitle">To Date </td>
                        <td style="width: 231px" class="TableGrid">
                            <asp:TextBox ID="txtToDate" runat="server" Width="125px"></asp:TextBox>
                            <img id="ImgDate3rdCall0" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="SmallCalendar.png"
                                style="width: 17px; height: 16px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">Bank Name</td>
                        <td style="width: 231px" class="TableGrid">
                            <asp:DropDownList ID="ddlBankName" runat="server"
                                Width="135px" SkinID="ddlSkin">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 109px" class="TableTitle">Branch Name</td>
                        <td style="width: 231px" class="TableGrid">
                            <asp:DropDownList ID="ddlBranchName" runat="server" Width="135px" SkinID="ddlSkin">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="btnSearch" runat="server" BorderWidth="1px"
                                Text="Search" Width="88px" OnClick="btnSearch_Click" /></td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="btncancel" runat="server" BorderWidth="1px"
                                Text="Cancel" Width="88px" OnClick="btncancel_Click" /></td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="btnExport" runat="server" BorderWidth="1px" Visible="false"
                                Text="Export" Width="88px" OnClick="btnExport_Click" /></td>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server" Height="313px" ScrollBars="Both"
                    Width="1000px">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdlos" runat="server"
                                CssClass="mGrid" Height="16px" Width="1000px">
                                <Columns>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 25px">&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HdnUID" runat="server" />
                &nbsp;
                <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px" Visible="false">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvExportReport" runat="server" Height="100px" Width="98%">
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <meta http-equiv="refresh" content="180" />
</asp:Content>