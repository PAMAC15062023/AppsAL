<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpeningBalanceBranchwise.aspx.cs"
    Inherits="Pages_Calculus_OpeningBalanceBranchwise" StylesheetTheme="SkinFile" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Branchwise Opening Balance view</title>
    <link href="../../StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 1px; height: 23px;">
                <tbody>
                    <tr>
                        <td style="height: 20px" colspan="10">
                            <asp:Label ID="lblError" runat="server" CssClass="ErrorMessage"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 22px" class="TableHeader" colspan="10">
                            &nbsp;Branch Monthwise Opening Balance&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 6px; height: 20px">
                        </td>
                        <td style="width: 15px; height: 20px" class="TableTitle">
                            &nbsp;Centre</td>
                        <td style="height: 20px" class="TableGrid" colspan="2">
                            <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                            </asp:DropDownList></td>
                        <td style="height: 20px; width: 56px;" colspan="2">
                            &nbsp;</td>
                        <td style="width: 100px; height: 20px">
                        </td>
                        <td style="height: 20px" colspan="2">
                        </td>
                        <td style="width: 100px; height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 6px; height: 20px">
                        </td>
                        <td class="TableTitle" style="width: 15px; height: 20px">
                            &nbsp;Month</td>
                        <td class="TableGrid" colspan="2" style="height: 20px">
                            <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Value="0">-Select-</asp:ListItem>
                                <asp:ListItem Value="01">Jan</asp:ListItem>
                                <asp:ListItem Value="02">Feb</asp:ListItem>
                                <asp:ListItem Value="03">Mar</asp:ListItem>
                                <asp:ListItem Value="04">Apr</asp:ListItem>
                                <asp:ListItem Value="05">May</asp:ListItem>
                                <asp:ListItem Value="06">Jun</asp:ListItem>
                                <asp:ListItem Value="07">Jul</asp:ListItem>
                                <asp:ListItem Value="08">Aug</asp:ListItem>
                                <asp:ListItem Value="09">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="height: 20px; width: 56px;">
                        </td>
                        <td style="width: 100px; height: 20px">
                        </td>
                        <td colspan="2" style="height: 20px">
                        </td>
                        <td style="width: 100px; height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 6px;">
                        </td>
                        <td class="TableTitle" style="width: 15px;">
                            &nbsp;Year</td>
                        <td class="TableGrid" colspan="2">
                            <asp:DropDownList ID="ddlYear" runat="server" SkinID="ddlSkin">
                                <asp:ListItem>-Select-</asp:ListItem>
                                <asp:ListItem>2010</asp:ListItem>
                                <asp:ListItem>2011</asp:ListItem>
                                <asp:ListItem>2012</asp:ListItem>
                                <asp:ListItem>2013</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                                <asp:ListItem>2022</asp:ListItem>
                                <asp:ListItem>2023</asp:ListItem>
                                <asp:ListItem>2024</asp:ListItem>
                                <asp:ListItem>2025</asp:ListItem>
                            </asp:DropDownList></td>
                        <td colspan="2" class="TableTitle">
                            &nbsp;Request Type</td>
                        <td class="TableGrid">
                            <asp:DropDownList ID="ddlRequestType" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Value="1">Petty Cash Voucher</asp:ListItem>
                                <asp:ListItem Value="2">Vender Payment</asp:ListItem>
                                <asp:ListItem Value="3">OtherThan Petty Cash</asp:ListItem>
                            </asp:DropDownList></td>
                        <td colspan="2">
                        </td>
                        <td style="width: 100px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px" colspan="10" class="TableTitle">
                            &nbsp;
                            <asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Text="Search" OnClick="btnSearch_Click" />&nbsp;<asp:Button
                                ID="btnClose" runat="server" BorderWidth="1px" Text="Close" Width="52px" OnClientClick="window.close();" /></td>
                    </tr>
                    <tr>
                        <td style="height: 20px" colspan="10">
                            <div style="border: thin solid darkgray; overflow: scroll;
                                width: 700px; height: 285px">
                                <asp:GridView ID="gvOpeningBranchBalanace" runat="server" CssClass="mGrid">
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px" colspan="10">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
