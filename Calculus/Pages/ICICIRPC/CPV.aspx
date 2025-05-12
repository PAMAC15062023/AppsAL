<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CPV.aspx.cs" Inherits="Pages_ICICIRPC_CPV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <table style="width: 100%">
        <tr>
            <td class="TableHeader" colspan="6" style="height: 22px">&nbsp;CPV Form </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="grdlos" runat="server" AutoGenerateColumns="False"
                    Height="16px" Width="750px" CssClass="mGrid" OnRowDataBound="grdlos_RowDataBound">
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
                                <asp:LinkButton ID="lnkWIP" runat="server" OnClick="lnkWIP_Click1" Font-Bold="True" Width="52px">Start</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdiscripant" runat="server" OnClick="lnkdiscripant_Click" Font-Bold="True" Width="61px" Enabled="False">Discrepant</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CPVStartStatus" HeaderText="Status" />

                        <asp:BoundField DataField="LOSNO" HeaderText="ApplicationNo" />
                        <asp:BoundField DataField="scan_date" HeaderText="Scan Date" />
                        <asp:BoundField DataField="cus_name" HeaderText="Customer Name" />
                        <asp:BoundField DataField="aps_id" HeaderText="APS ID" />
                        <asp:BoundField DataField="location" HeaderText="location" />


                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin">
                                    <%--<asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                    <asp:ListItem>Rescan</asp:ListItem>
                                    <asp:ListItem>MDRReject</asp:ListItem>--%>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="30px" SkinID="txtSkin"
                                    TextMode="MultiLine" Width="217px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleted" runat="server" OnClick="lnkCompleted_Click" Font-Bold="True" Width="40px">Complete & New Assign</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompletedtobde" runat="server" OnClick="lnkCompletedtobde_Click" Font-Bold="True" Width="40px">Complete & Go to BDE</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkcompleted_cam" runat="server" Font-Bold="True"
                                    Width="40px" OnClick="lnkcompleted_cam_Click">Complete & Go to CAM</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleteExit" runat="server" OnClick="lnkCompleteExit_Click" Font-Bold="True" Width="40px">Complete & Exit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 25px">
                <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click"
                    Text="Cancel" />
                &nbsp;</td>
        </tr>
        <tr>
            <td>
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

