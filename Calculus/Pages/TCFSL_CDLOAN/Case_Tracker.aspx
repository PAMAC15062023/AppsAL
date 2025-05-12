<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master"
    AutoEventWireup="true" CodeFile="Case_Tracker.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_Case_Tracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <table style="width: 1100px; height: 92px;">
        <tr>
            <td colspan="5" style="height: 18px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td style="width: 319px; height: 30px;" class="TableTitle">&nbsp;<b>Webtop Id </b>/ <b>FinnOneApplication Number</b>
            </td>
            <td style="width: 100px; height: 30px;" class="TableGrid">
                <asp:TextBox ID="txtWebtopId" runat="server" autocomplete="off" MaxLength="200" OnKeyup="UpperLetter(this);"
                    SkinID="txtSkin" Width="115px"></asp:TextBox>
            </td>
            <td style="height: 30px;" class="TableTitle">&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    Style="font-weight: 700; background-color: #009999; color: #FFFFFF;" Height="30px"
                    Width="72px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButnCancel0" runat="server" Text="Cancel" Style="font-weight: 700; background-color: #009999; color: #FFFFFF;"
                    Height="30px" Width="72px" OnClick="ButnCancel0_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
    </table>
    <asp:Panel ID="pnlmain" runat="server">
        <asp:GridView ID="grdScreen" runat="server" AutoGenerateColumns="False" GridLines="None"
            CellPadding="2" CellSpacing="2">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Panel ID="pnlGrd" runat="server" BorderColor="#009688" BorderStyle="Solid" BorderWidth="1px">
                            <table style="width: 100%; background-color: #00877a; border: 1px solid #009688">
                                <tr style="height: 20px">
                                    <td style="width: 441px; height: 23px" colspan="1">
                                        <asp:Label ID="lblCaseNo" runat="server" CssClass="ErrorMessage"></asp:Label></td>
                                    <td style="width: 441px; height: 23px" colspan="1">
                                        <asp:Label ID="lblWebtopId" runat="server" CssClass="ErrorMessage"></asp:Label></td>
                                    <td style="width: 441px; height: 23px" colspan="1">
                                        <asp:Label ID="lblApplicationNo" runat="server" CssClass="ErrorMessage"></asp:Label></td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnldisplay" ScrollBars="Both" runat="server">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="TableHeader" colspan="9">
                                            <b>&nbsp;Sreening</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: xx-small; width: 261px; height: 23px; font-weight: bold;" class="TableTitle">&nbsp;
                                        </td>
                                        <td style="width: 441px; height: 23px" class="TableTitle" colspan="1">
                                            <b>User</b>
                                        </td>
                                        <td style="width: 335px; height: 23px; font-weight: 700;" class="TableTitle">Inprocess&nbsp; Date
                                        </td>
                                        <td style="width: 272px; height: 23px; font-weight: 700;" class="TableTitle">Completed Status
                                        </td>
                                        <td style="width: 406px; height: 23px; font-weight: 700;" class="TableTitle">Completed DateTime
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableTitle" style="font-size: xx-small; width: 261px; font-weight: bold;">
                                            <%--  Pre Trans--%>
                                        </td>
                                        <td class="TableGrid" style="width: 441px">
                                            <asp:Label ID="lblSreeningUser" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 196px">
                                            <asp:Label ID="lblSreeningInprocessDate" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 156px">
                                            <asp:Label ID="lblSreeningStatus" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 453px">
                                            <asp:Label ID="lblSreeningDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                            </asp:Panel>
                            <asp:Panel ID="panelQCScreen" ScrollBars="Both" runat="server">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="TableHeader" colspan="9">
                                            <b>&nbsp;QC Screen</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: xx-small; width: 261px; height: 23px; font-weight: bold;" class="TableTitle">&nbsp;
                                        </td>
                                        <td style="width: 441px; height: 23px" class="TableTitle" colspan="1">
                                            <b>User</b>
                                        </td>
                                        <td style="width: 335px; height: 23px; font-weight: 700;" class="TableTitle">Inprocess&nbsp; Date
                                        </td>
                                        <td style="width: 272px; height: 23px; font-weight: 700;" class="TableTitle">Completed Status
                                        </td>
                                        <td style="width: 406px; height: 23px; font-weight: 700;" class="TableTitle">Completed DateTime
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableTitle" style="font-size: xx-small; width: 261px; font-weight: bold;">
                                            <%-- D1--%>
                                        </td>
                                        <td class="TableGrid" style="width: 441px">
                                            <asp:Label ID="lblQCscreenUser" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 196px">
                                            <asp:Label ID="lblQCscreenInprocessTime" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 156px">
                                            <asp:Label ID="lblQCscreenStatus" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 453px">
                                            <asp:Label ID="lblQCscreenDateTime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="panelMaker" ScrollBars="Both" runat="server">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="TableHeader" colspan="9">
                                            <b>&nbsp;Maker</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: xx-small; width: 261px; height: 23px; font-weight: bold;" class="TableTitle">&nbsp;
                                        </td>
                                        <td style="width: 441px; height: 23px" class="TableTitle" colspan="1">
                                            <b>User</b>
                                        </td>
                                        <td style="width: 335px; height: 23px; font-weight: 700;" class="TableTitle">Inprocess&nbsp; Date
                                        </td>
                                        <td style="width: 272px; height: 23px; font-weight: 700;" class="TableTitle">Completed Status
                                        </td>
                                        <td style="width: 406px; height: 23px; font-weight: 700;" class="TableTitle">Completed DateTime
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableTitle" style="font-size: xx-small; width: 261px; font-weight: bold;">
                                            <%--D2--%>
                                        </td>
                                        <td class="TableGrid" style="width: 441px">
                                            <asp:Label ID="lblMakerUser" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 196px">
                                            <asp:Label ID="lblMakerInprocessDate" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 156px">
                                            <asp:Label ID="lblMakerStatus" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 453px">
                                            <asp:Label ID="lblMakerDateTime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelAuthor" ScrollBars="Both" runat="server">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="TableHeader" colspan="9">
                                            <b>&nbsp;AUTHOR</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: xx-small; width: 261px; height: 23px; font-weight: bold;" class="TableTitle">&nbsp;
                                        </td>
                                        <td style="width: 441px; height: 23px" class="TableTitle" colspan="1">
                                            <b>User</b>
                                        </td>
                                        <td style="width: 335px; height: 23px; font-weight: 700;" class="TableTitle">Inprocess&nbsp; Date
                                        </td>
                                        <td style="width: 272px; height: 23px; font-weight: 700;" class="TableTitle">Completed Status
                                        </td>
                                        <td style="width: 406px; height: 23px; font-weight: 700;" class="TableTitle">Completed DateTime
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableTitle" style="font-size: xx-small; width: 261px; font-weight: bold;">
                                            <%--QC--%>
                                        </td>
                                        <td class="TableGrid" style="width: 441px">
                                            <asp:Label ID="lblAuthor" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 196px">
                                            <asp:Label ID="lblAuthorDate" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 156px">
                                            <asp:Label ID="llblAuthorStatus" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableGrid" style="width: 453px">
                                            <asp:Label ID="lblAuthorDateTime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
