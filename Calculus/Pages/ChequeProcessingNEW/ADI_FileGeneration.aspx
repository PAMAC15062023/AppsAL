<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ADI_FileGeneration.aspx.cs" Inherits="Pages_ChequeProcessingNEW_ADI_FileGeneration" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"> 

    </script>
    <table style="width: 857px">
        <tr>
            <td colspan="7" style="height: 60px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label><br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValGenReport" />
            </td>
        </tr>
        <tr>
            <td colspan="7" class="TableHeader">&nbsp;ADI File Generation</td>
        </tr>
        <tr>
            <td style="width: 10px; height: 16px;"></td>
            <td class="TableTitle" style="width: 135px; height: 16px">&nbsp;<strong>Branch Name</strong></td>
            <td style="width: 272px; height: 16px;">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin"
                    CssClass="dropdown">
                </asp:DropDownList>
            </td>
            <td style="width: 117px; height: 16px;" class="TableTitle">&nbsp;<strong>Client Type</strong>&nbsp;</td>
            <td style="height: 16px;" colspan="3">
                <asp:DropDownList ID="ddlClientList" runat="server" CssClass="dropdown"
                    SkinID="ddlSkin">
                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                    <asp:ListItem Value="1">SBI</asp:ListItem>
                    <asp:ListItem Value="2">Non SBI</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="ddlClientList" ErrorMessage="Select Type"
                    InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
            <td style="width: 135px" class="TableTitle">&nbsp; <strong>Format Type</strong></td>
            <td style="width: 272px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:DropDownList ID="ddlFormatType" runat="server" CssClass="dropdown"
                                SkinID="ddlSkin">
                                <asp:ListItem Value="0">-Select-</asp:ListItem>
                                <asp:ListItem Value="1">Excel Report</asp:ListItem>
                                <asp:ListItem Value="2">Text Report</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px; height: 20px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="ddlFormatType"
                                ErrorMessage="Select Format Type" InitialValue="0">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 100px; height: 20px">&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td style="width: 117px" class="TableTitle">&nbsp;<strong>Pickup Date</strong></td>
            <td colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtPickupDate" runat="server" BorderWidth="1px"
                                SkinID="txtSkin" Width="73px" Height="16px"></asp:TextBox></td>
                        <td style="width: 100px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px">
                            <asp:RequiredFieldValidator ID="rq_toDate" runat="server" ControlToValidate="txtPickupDate"
                                ErrorMessage="Please Enter Date to continue...." SetFocusOnError="True"
                                ValidationGroup="ValGenReport">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnReportType" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 30px;" class="TableTitle" colspan="7">&nbsp;
                <asp:Button ID="BtnGenerate" runat="server" AccessKey="G" BorderWidth="1px" OnClick="BtnGenerate_Click"
                    Text="Generate" ValidationGroup="ValGenReport" />&nbsp;<asp:Button
                        ID="btnReset" runat="server" AccessKey="R" BorderWidth="1px"
                        Text="Reset" Width="70px" OnClick="btnReset_Click"
                        CausesValidation="False" /></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvExportReport" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" Height="100px" Width="98%" PageSize="20">
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
            <td style="width: 10px"></td>
            <td style="width: 137px"></td>
            <td style="width: 272px"></td>
            <td style="width: 119px"></td>
            <td style="width: 96px"></td>
            <td style="width: 96px"></td>
            <td style="width: 97px"></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 36px">&nbsp;&nbsp;
                <asp:Button ID="btnExport" runat="server" AccessKey="E" BorderWidth="1px" OnClick="btnExport_Click"
                    Text="Export" Width="67px" />&nbsp;<asp:Button ID="btnCancel" runat="server" AccessKey="C"
                        BorderWidth="1px" Text="Cancel" Width="72px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
            <td style="width: 137px"></td>
            <td style="width: 272px"></td>
            <td style="width: 119px"></td>
            <td style="width: 96px"></td>
            <td style="width: 96px"></td>
            <td style="width: 97px"></td>
        </tr>
    </table>
</asp:Content>

