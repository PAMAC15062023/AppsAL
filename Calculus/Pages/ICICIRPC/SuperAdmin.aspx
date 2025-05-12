<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="SuperAdmin.aspx.cs" Inherits="Pages_LOSTracker_SuperAdmin" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <table style="width: 100%">

        <tr>
            <td class="TableHeader" colspan="9" style="height: 22px">&nbsp;Super Admin Form
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
                            <strong>SEARCH BY CENTRE/PRIORITY</strong></td>
                        <td align="center" class="Masterbody" colspan="3">
                            <strong>ASSIGN DDE/INDEXER</strong></td>
                        <td align="center" class="Masterbody" colspan="1"></td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">RPC Location </td>
                        <td style="width: 231px" class="TableGrid">
                            <asp:UpdatePanel ID="UP_ddlrpclocation" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="ddlrpclocation" runat="server" Width="100px"
                                SkinID="ddlSkin" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlrpclocation_SelectedIndexChanged">
                                <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="36">CHANDIGARH</asp:ListItem>
                                <asp:ListItem Value="37">JAIPUR</asp:ListItem>
                                <asp:ListItem Value="1">Mumbai</asp:ListItem>
                                <asp:ListItem Value="3">Delhi</asp:ListItem>--%>
                            </asp:DropDownList>
                                    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlrpclocation" EventName="SelectedIndexChanged" />
                                </Triggers>
                                </asp:UpdatePanel>
                        </td>
                        <td class="TableTitle">Product </td>

                        <td class="TableGrid">
                            <asp:UpdatePanel ID="UP_ddlproduct" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="ddlproduct" runat="server" AutoPostBack="true"
                                Width="134px" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged">
                                <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem>PL</asp:ListItem>
                                <asp:ListItem>AL</asp:ListItem>
                                <asp:ListItem>HL</asp:ListItem>--%>
                            </asp:DropDownList>
                                    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlproduct" EventName="SelectedIndexChanged" />
                                </Triggers>
                                </asp:UpdatePanel>
                        </td>

                        <td align="center" class="TableTitle">&nbsp;</td>
                        <td align="center" class="TableTitle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">BDE/CAM/CPV</td>
                        <td style="width: 231px" class="TableGrid">



                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltype" CssClass="dropdown" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddltype_SelectedIndexChanged"
                                        Style="margin-left: 0px" Width="100px" SkinID="ddlSkin">
                                        <asp:ListItem Value="Get_bdedata">BDE</asp:ListItem>
                                        <asp:ListItem Value="Get_CAMdata_super">CAM</asp:ListItem>
                                        <asp:ListItem Value="Get_Cpvdata_suer">CPV</asp:ListItem>
                                        <asp:ListItem Value="Get_BNKCALdata_super">Bank_calculation</asp:ListItem>
                                        <asp:ListItem Value="Get_doc_uploaddata">DOC_UPLOAD</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddltype" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </td>
                        <td class="TableTitle">Change
                            RPC LOCATION</td>

                        <td class="TableGrid">

                            <asp:UpdatePanel ID="UP_ddlchngrpc" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlchngrpc" runat="server" Width="102px" SkinID="ddlSkin">
                                       <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="36">CHANDIGARH</asp:ListItem>
                                        <asp:ListItem Value="37">JAIPUR</asp:ListItem>
                                        <asp:ListItem Value="1">Mumbai</asp:ListItem>
                                        <asp:ListItem Value="3">Delhi</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>

                        <td align="center" class="TableTitle">
                            <asp:Button ID="Btnchangerpc" runat="server" BorderWidth="1px" OnClick="Btnchangerpc_Click"
                                Text="Change RPC" Width="88px" /></td>
                        <td align="center" class="TableTitle">&nbsp;


                        </td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">Centre</td>
                        <td style="width: 231px" class="TableGrid">



                            <asp:UpdatePanel ID="UP_ddlBranchList" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlBranchList" runat="server" CssClass="dropdown"
                                        ValidationGroup="BranchENtry" SkinID="ddlSkin" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlBranchList_SelectedIndexChanged" Width="100px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlBranchList" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="TableTitle">BDE/CAM/CPV</td>
                        <td class="TableGrid">

                            <asp:UpdatePanel ID="UP_DropDownList1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList1" CssClass="dropdown" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                        Style="margin-left: 0px" Width="100px" SkinID="ddlSkin">
                                        <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem>BDE</asp:ListItem>
                                        <asp:ListItem>CAM</asp:ListItem>
                                        <asp:ListItem>CPV</asp:ListItem>
                                        <asp:ListItem>Bank_Calculation</asp:ListItem>
                                        <asp:ListItem>Doc_Upload</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td align="center" class="TableTitle">


                            <asp:Button ID="BtnAssign" runat="server" BorderWidth="1px" OnClick="BtnAssign_Click"
                                Text="Assign" Width="88px" /></td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="btndiscripant" BorderWidth="1px" runat="server" Visible="false"
                                OnClick="btndiscripant_Click" Text="Discripant" /></td>
                    </tr>
                    <tr>
                        <td style="width: 109px" class="TableTitle">Priority</td>
                        <td style="width: 231px" class="TableGrid">

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlPriority" CssClass="dropdown" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged" Width="100px" SkinID="ddlSkin">
                                    </asp:DropDownList>

                                </ContentTemplate>
                            </asp:UpdatePanel>




                        </td>
                        <td class="TableTitle">User Name</td>
                        <td class="TableGrid">
                            <asp:UpdatePanel ID="UP_DropDownList2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList2" CssClass="dropdown" runat="server" Width="100px" SkinID="ddlSkin">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td align="center" class="TableTitle">


                            <asp:Button ID="btncancel" runat="server" BorderWidth="1px" OnClick="btncancel_Click"
                                Text="Cancel" Width="88px" /></td>
                        <td align="center" class="TableTitle">
                            <asp:Button ID="btnExport" runat="server" BorderWidth="1px" OnClick="btnExport_Click"
                                Text="Export" Width="88px" /></td>
                    </tr>
                </table>

                <asp:Panel ID="Panel1" runat="server" Height="313px" ScrollBars="Both"
                    Width="1000px">

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <asp:GridView ID="grdlos" runat="server"
                                CssClass="mGrid" Height="16px" Width="1000px"
                                OnRowDataBound="grdlos_RowDataBound1">
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
            <td colspan="9" style="height: 25px">&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
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

