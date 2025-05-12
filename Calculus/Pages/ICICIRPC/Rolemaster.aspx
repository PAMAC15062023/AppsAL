<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Rolemaster.aspx.cs" Inherits="Pages_ICICIRPC_Rolemaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="grdrole" runat="server" AutoGenerateColumns="False"
                    Height="100px" Width="900px" CssClass="mGrid" OnRowDataBound="grdrole_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkSelectAll" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserID" HeaderText="Employee Code" />
                        <asp:BoundField DataField="username" HeaderText="Employee Name" />
                        <asp:BoundField DataField="DefaultRole" HeaderText="Default Role" />
                        <asp:BoundField DataField="Role" HeaderText="Assigned Role" />
                        <asp:TemplateField HeaderText="Change Role">
                            <ItemTemplate>
                                <asp:UpdatePanel ID="UP_ddlrole" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="ddlrole" runat="server" SkinID="ddlSkin"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlrole_SelectedIndexChanged">
                                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Text="BDE" Value="bdeicici_rpc"></asp:ListItem>
                                    <asp:ListItem Text="CAM" Value="camicici_rpc"></asp:ListItem>
                                    <asp:ListItem Text="CPV" Value="CPUICICI_RPC"></asp:ListItem>
                                    <asp:ListItem Text="Bank Calculation" Value="bnk_calcu_icici"></asp:ListItem>
                                    <asp:ListItem Text="Doc Upload" Value="Doc_help_icici"></asp:ListItem>--%>
                                </asp:DropDownList>
                                        </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlrole" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    </asp:UpdatePanel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DefaultProduct" HeaderText="Default Product" />
                        <asp:BoundField DataField="AssignedProduct" HeaderText="Assigned Product" />
                        <asp:TemplateField HeaderText="Change Product">
                            <ItemTemplate>
                                <asp:UpdatePanel ID="UP_ddlproduct" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="ddlproduct" runat="server" SkinID="ddlSkin"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged">
                                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="AL" Text="AL"></asp:ListItem>
                                    <asp:ListItem Value="HL" Text="HL"></asp:ListItem>
                                    <asp:ListItem Value="PL" Text="PL"></asp:ListItem>--%>
                                </asp:DropDownList>
                                        </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlproduct" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    </asp:UpdatePanel>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;<asp:Button ID="BtnCancel" runat="server" Text="Cancel"
                OnClick="BtnCancel_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>

