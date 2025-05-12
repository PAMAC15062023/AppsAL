<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizationTree.aspx.cs" Inherits="OrganizationTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PMS</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%"><tr><td>
    <fieldset><legend class="FormHeading">My PMS</legend>
    <table width="90%">
    <tr><td>
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label></td></tr>
    <tr><td>
        <asp:TreeView Runat="Server" ID="tvOrganization" ShowLines="True" OnSelectedNodeChanged="tvOrganization_SelectedNodeChanged">
            <LeafNodeStyle BackColor="White" />
            <NodeStyle BackColor="White" />
        </asp:TreeView>
        </td><td valign="top" align="right">
        <table>
        <tr><td style="height: 18px"><asp:LinkButton ID="lnkAdmin" runat="server" PostBackUrl="~/Administrator/Default.aspx">[Admin]</asp:LinkButton>
            </td>
            <td style="height: 18px; width: 99px;"><asp:LinkButton ID="lnkChangePassword" runat="server" PostBackUrl="~/ChangePassword.aspx">[Change Password]</asp:LinkButton></td>
            <td style="height: 18px">
                <asp:LinkButton ID="lnkFETracking" Visible="true" runat="server" PostBackUrl="~/FETracking/FECheckOut.aspx">[FE Tracking]</asp:LinkButton>
            </td>
            <td style="height: 18px">
                <asp:LinkButton ID="LnkbtnQueryBuilder" runat="server" PostBackUrl="~/QueryBuilder/Default.aspx" Visible="False">[Query Builder]</asp:LinkButton>
            </td>
            <td style="height: 18px">
                <asp:LinkButton ID="lnkDedupSearch" runat="server" PostBackUrl="~/NegativeDedup/Default_NegativeDedup.aspx" Visible="false">[Negative Dedup]</asp:LinkButton>
            </td>
            <td style ="height:18px">
            <asp:LinkButton id="lnkAssets" runat="server" PostBackUrl="~/Assets/Default.aspx" Visible="False">[Assets Summary]</asp:LinkButton>
            </td>
            <td style="height: 18px"><a href="Logout.aspx">[Sign Out]</a></td>
            </tr></table>
        </td></tr></table>
        </fieldset>
        </td></tr></table>
        <!--
        <asp:DataList ID="MyDataList" runat="server">
            <HeaderTemplate>
              The following nodes are checked:
            </HeaderTemplate>
            <ItemTemplate>
              <%# Eval("Text") %>
            </ItemTemplate>
        </asp:DataList>
        -->
    </div>
    </form>
</body>
</html>
