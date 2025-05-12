<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="did_edit.aspx.cs" Inherits="Pages_RPC_OP_did_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 22px">CAM&nbsp; EDIT Form</td>
        </tr>
        <tr>

            <td>

                <asp:Label ID="lbllosno" runat="server" Text="Los No"></asp:Label>
                :</td>

            <td style="width: 29px">

                <asp:TextBox ID="txtlosno" runat="server" Style="margin-left: 0px"></asp:TextBox>
            </td>

            <td style="width: 339px">

                <asp:Button ID="btnsearch" runat="server" Text="Search"
                    OnClick="btnsearch_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
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
                        <asp:BoundField DataField="Los No" HeaderText="Los No" />
                        <asp:BoundField DataField="Upload Date & Time" HeaderText="Upload Date & Time" />
                        <asp:BoundField DataField="centre" HeaderText="Centre" />
                        <asp:TemplateField HeaderText="CAM STATUS">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlstatus" runat="server">
                                    <%--<asp:ListItem>HOLD</asp:ListItem>
                                    <asp:ListItem>DID</asp:ListItem>--%>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkedit" runat="server" Text="Edit" OnClick="lnkedit_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btncancel" runat="server"
                    Text="Cancel" OnClick="btncancel_Click" />
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
            <td style="width: 29px">&nbsp;</td>
            <td style="width: 339px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>

