<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Bank_Cal.aspx.cs" Inherits="Pages_ICICIRPC_Bank_Cal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="6" style="height: 22px">Back Calculation</td>
        </tr>
        <tr>

            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="grdlos" runat="server" AutoGenerateColumns="False"
                    Height="16px" Width="900" CssClass="mGrid" OnRowDataBound="grdlos_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkSelectAll" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True"
                                    OnClick="lnkWIP_Click">Start</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="bnkcalStartStatus" HeaderText="Start Status" />
                        <asp:BoundField DataField="LOSNO" HeaderText="LOSNO" />
                        <asp:BoundField DataField="aps_id" HeaderText="Application ID" />


                        <asp:BoundField DataField="location" HeaderText="Centre" />

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin">
                                    <%--<asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                    <asp:ListItem>HOLD</asp:ListItem>--%>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="30px" SkinID="txtSkin"
                                    TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkcompandnew" runat="server" OnClick="lnkcompandnew_Click">Completed &amp; New Assign</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkcompletedExit" runat="server"
                                    OnClick="lnkcompletedExit_Click">Completed &amp;Exit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click"
                    Text="Cancel" />
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

