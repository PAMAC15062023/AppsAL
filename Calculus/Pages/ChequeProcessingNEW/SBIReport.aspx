<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="SBIReport.aspx.cs" Inherits="Pages_ChequeProcessingNEW_SBIReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>


    <table style="width: 100%">
        <tr>
            <td class="TableGrid" colspan="8">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
            <td class="TableGrid" colspan="8">
                <asp:Label ID="lblLocation" runat="server" CssClass="TableHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="16">All MIS Reports</td>
        </tr>
        <tr>
            <td style="width: 1px">&nbsp;</td>
            <td class="TableTitle">
                <strong>Client</strong></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlClientList" runat="server"
                    OnSelectedIndexChanged="ddlClientList_SelectedIndexChanged"
                    CssClass="dropdown">
                </asp:DropDownList>
            </td>
            <td class="TableTitle">
                <strong>Select MIS</strong></td>
            <td class="TableGrid">
                <asp:UpdatePanel ID="UP_ddlMIStype" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlMIStype" runat="server" CssClass="dropdown"
                    OnSelectedIndexChanged="ddlMISList_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Get_DropBoxMIS">DropBox MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DataForInvalidChqs">Invalid Cheque MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DataForSuspenseChqs">Suspense Cheque MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DataForForeclosureChqs">Foreclosure Cheque MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DataForOtherChqs">OtherBank Cheque MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DataForInwardBTChqs">InwardsBT Cheque MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DataForReturnChqs">Return Cheque MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DataForUpcountryChqs">Upcountry Cheque MIS</asp:ListItem>
                    <asp:ListItem Value="Get_DailyEntryData">Daily Cheque Summary</asp:ListItem>
                    <asp:ListItem Value="GetDataForTextReportSBI">Text Report</asp:ListItem>
                </asp:DropDownList>
                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMIStype" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1px">&nbsp;</td>
            <td class="TableTitle">
                <strong>From Date</strong></td>
            <td class="TableGrid">
                <table style="width: 155px">
                    <tr>
                        <td style="width: 128px">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="TEXTBOX"></asp:TextBox>
                        </td>
                        <td style="width: 17px">
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                <strong>To Date</strong></td>
            <td class="TableGrid">
                <table style="width: 155px">
                    <tr>
                        <td style="width: 128px">
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="TEXTBOX"></asp:TextBox>
                        </td>
                        <td style="width: 17px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TableGrid" colspan="16">&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" CssClass="button"
                    OnClick="btnSearch_Click" Text="Search" />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="16">
                <asp:Label ID="lblReportHeader" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 1px">&nbsp;</td>
            <td colspan="15">
                <div style="overflow: scroll; width: 840px; height: 199px">
                    <%--   <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" 
                    Width="850px" Visible="False" CssClass="TableGrid">--%>
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="grvMISdata" runat="server" Height="100px" Width="98%"
                                    OnRowDataBound="grvMISdata_RowDataBound" Visible="False" PageSize="100">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                </asp:GridView>

                            </td>
                        </tr>
                    </table>
                    <%-- </asp:Panel>--%>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 1px">&nbsp;</td>
            <td colspan="15">
                <asp:Panel runat="server" ID="btmPanel" Visible="False" CssClass="TableGrid">
                    <asp:Button ID="btnExport" runat="server" CssClass="button"
                        OnClick="btnExport_Click" Text="Export To Excel" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        Text="Cancel" />
                </asp:Panel>
            </td>

        </tr>
        <tr>
            <td style="width: 1px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
</asp:Content>

