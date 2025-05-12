<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="supervisor.aspx.cs" Inherits="Pages_JFS_supervisor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td class="TableHeader" colspan="9" style="height: 22px">
                &nbsp;Super Admin Form
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
                        <td class="Masterbody" align="center" colspan="2">
                            <strong>SEARCH BY CENTRE/PRIORITY</strong>
                        </td>
                        <td align="center" class="Masterbody" colspan="3">
                            <strong>ASSIGN DDE/INDEXER</strong>
                        </td>
                        <td align="center" class="Masterbody" colspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">
                            JSF Location
                        </td>
                        <td style="width: 233px" class="TableGrid">
                            <asp:DropDownList ID="ddlrpclocation" runat="server" Width="100px" SkinID="ddlSkin"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlrpclocation_SelectedIndexChanged">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="40">Lucknow</asp:ListItem>
                                <asp:ListItem Value="11">Kolkata </asp:ListItem>
                                <asp:ListItem Value="1">Mumbai</asp:ListItem>
                                <asp:ListItem Value="34">Indore</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="TableTitle">
                            Change LOCATION
                        </td>
                        <td class="TableGrid" style="width: 211px">
                            <asp:DropDownList ID="ddlchngrpc" runat="server" Width="102px" SkinID="ddlSkin">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="40">Lucknow</asp:ListItem>
                                <asp:ListItem Value="11">Kolkata </asp:ListItem>
                                <asp:ListItem Value="1">Mumbai</asp:ListItem>
                                <asp:ListItem Value="34">Indore</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="Btnchangerpc" runat="server" BorderWidth="1px" Text="Change Location"
                                Width="88px" OnClick="Btnchangerpc_Click" />
                        </td>
                        <td align="center" class="TableTitle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">
                            DE/DA
                        </td>
                        <td style="width: 233px" class="TableGrid">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltype" CssClass="dropdown" runat="server" AutoPostBack="True"
                                        Style="margin-left: 0px" Width="100px" SkinID="ddlSkin" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                        <asp:ListItem Value="getdate_forDE">DE</asp:ListItem>
                                        <asp:ListItem Value="JFSCompleteMISDA">DA</asp:ListItem>
                                        <asp:ListItem Value="getdate_forQR">Query Resolved</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="TableTitle">
                            DA/DE
                        </td>
                        <td class="TableGrid" style="width: 211px">
                            <asp:UpdatePanel ID="UpdatePanelNEW" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="dropdown"
                                        SkinID="ddlSkin" Style="margin-left: 0px" Width="100px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem>DE</asp:ListItem>
                                        <asp:ListItem>DA</asp:ListItem>
                                        <asp:ListItem>Query Resolved</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="BtnAssign" runat="server" BorderWidth="1px" Text="Assign" Width="88px"
                                OnClick="BtnAssign_Click" />
                        </td>
                        <td align="center" class="TableTitle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">
                            &nbsp;
                        </td>
                        <td style="width: 233px" class="TableGrid">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            </asp:UpdatePanel>
                        </td>
                        <td class="TableTitle">
                            User Name
                        </td>
                        <td class="TableGrid" style="width: 211px">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown" SkinID="ddlSkin"
                                        Width="100px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="btncancel" runat="server" BorderWidth="1px" Text="Cancel" Width="88px"
                                OnClick="btncancel_Click" />
                        </td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="btndiscripant" BorderWidth="1px" runat="server" Visible="false" Text="Discripant" />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server" Height="313px" ScrollBars="Both" Width="1000px">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdlos" runat="server" CssClass="mGrid" Height="16px" 
                                Width="1000px" onrowdatabound="grdlos_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input id="chkSelectAll" type="checkbox" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 25px">
                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HdnUID" runat="server" />
                &nbsp;
                <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
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
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <meta http-equiv="refresh" content="180" />
</asp:Content>
