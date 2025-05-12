<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="GroupRightsInfo.aspx.cs" Inherits="Pages_GroupRightsInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="BranchENtry" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;Group Info</td>
        </tr>
        <tr>
            <td class="TableTitle">
                &nbsp;Group Name</td>
            <td>
                <table border="0" cellspacing="0">
                    <tr>
                        <td>
                <asp:DropDownList ID="ddlGroupInfo" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupInfo_SelectedIndexChanged">
                </asp:DropDownList></td>
                        <td>
                <asp:LinkButton ID="lnkViewUsers" runat="server" Width="106px">View Users List</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;Group Description</td>
            <td>
                <asp:Label ID="lblGroupDesc" runat="server"></asp:Label></td>
            <td  >
            </td>
        </tr>
        <tr>
            <td class="TableTitle">
                &nbsp;Activate Status</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;">
            </td>
            <td style="width: 100px; height: 22px;">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5" style="height: 12px">
                &nbsp; Menu List</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Vertical" Width="800px">
                    <asp:TreeView ID="MenuTreeView" runat="server" DataSourceID="XmlDataSource1"  
                        ShowLines="True">
                        <DataBindings>
                            <asp:TreeNodeBinding DataMember="MenuItem" ShowCheckBox="True" TextField="Text" ToolTipField="Tooltip"
                                ValueField="Value" />
                        </DataBindings>
                    </asp:TreeView>
                </asp:Panel>
                <asp:XmlDataSource ID="XmlDataSource1" runat="server" TransformFile="~/Pages/TransformXSLT.xsl"
                    XPath="MenuItems/MenuItem"></asp:XmlDataSource>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                    ValidationGroup="BranchENtry" Width="68px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
    </table>
</asp:Content>

