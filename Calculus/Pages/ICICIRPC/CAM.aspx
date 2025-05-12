<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CAM.aspx.cs" Inherits="Pages_ICICIRPC_CAM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="TableHeader" colspan="6" style="height: 22px">CAM Form </td>
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
                                <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" Width="52px"
                                    OnClick="lnkWIP_Click1">Start</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="camstatus" HeaderText="Status" />

                        <asp:BoundField DataField="LOSNO" HeaderText="ApplicationNo" />
                        <asp:BoundField DataField="scan_date" HeaderText="Scan Date" />
                        <asp:BoundField DataField="cus_name" HeaderText="Customer Name" />
                        <asp:BoundField DataField="aps_id" HeaderText="APS ID" />
                        <asp:BoundField DataField="rt_no" HeaderText="RT NO" />
                        <asp:BoundField DataField="location" HeaderText="location" />

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin">
                                    <%--<asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>completed</asp:ListItem>

                                    <asp:ListItem>Incompleted</asp:ListItem>
                                    <asp:ListItem>Hold</asp:ListItem>
                                    <asp:ListItem>CAM Prepared By Bank</asp:ListItem>--%>
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
                                <asp:LinkButton ID="lnkCompleted" OnClick="lnkCompleted_Click" runat="server" Font-Bold="True" Width="40px">Complete & New Assign</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleteExit" runat="server" Font-Bold="True"
                                    Width="40px" OnClick="lnkCompleteExit_Click1">Complete & Exit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 25px">
                <asp:Button ID="btncancel" runat="server"
                    Text="Cancel" OnClick="btncancel_Click" />
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

