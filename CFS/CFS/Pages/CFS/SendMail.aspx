<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="SendMail.aspx.cs" Inherits="Pages_CFS_SendMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlproduct" runat="server">
        <table style="width: 688px; height: 40px;">
            <tr>
                <td class="TableHeader" colspan="4" style="width: 690px;">&nbsp;Send &nbsp; Mail
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px; height: 123px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg1" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 71px;">
                    <strong>Select Customer Type</strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:DropDownList ID="ddlcustomerType" runat="server" OnSelectedIndexChanged="ddlcustomerType_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--Selete--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Specific Customer" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Vertical,  Customer" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Centre Customer" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td class="TableGrid" style="width: 95px;">
                    <asp:DropDownList ID="ddlCustomerList" runat="server" OnSelectedIndexChanged="ddlCustomerList_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvcustomerDetails" runat="server" AutoGenerateColumns="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chb" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <table>
        <tr>
            <td class="TableTitle" colspan="4">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnCalcel" runat="server" Text="Cancel" BorderColor="#400000" BorderWidth="1px"
                        Font-Bold="False" Width="105px" OnClick="btnCalcel_Click" />
            </td>
        </tr>
    </table>

    <asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="validdata" />

   
</asp:Content>

