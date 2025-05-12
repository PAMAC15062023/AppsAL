<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewOpeningBalancePetty.aspx.cs" Inherits="Pages_Calculus_ViewOpeningBalancePetty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Opening Balance By Month</title>
    <link href="../../StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
<script language="javascript" type="text/javascript">
    function switchViews(obj, row) {
        ////debugger;
        var div = document.getElementById(obj);
        var img = document.getElementById('img' + obj);

        if (div.style.display == "none") {
            div.style.display = "inline";
            if (row == 'alt') {
                img.src = "Images/close.png";
                mce_src = "Images/close.png";
            }
            else {
                img.src = "Images/close.png";
                mce_src = "Images/close.png";
            }
            img.alt = "Close to view other customers";
        }
        else {
            div.style.display = "none";
            if (row == 'alt') {

                img.src = "Images/open.png";
                mce_src = "Images/open.png";
            }
            else {
                img.src = "Images/open.png";
                mce_src = "Images/open.png";

            }
            img.alt = "Expand to show Transactions";
        }
    }

</script>
    <form id="form1" runat="server">
        <div>
            <table style="width: 611px">
                <tr>
                    <td colspan="10" style="height: 20px">
                        <asp:Label ID="lblError" runat="server" CssClass="ErrorMessage"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TableHeader" colspan="10" style="height: 20px">
                        &nbsp;Branchwise Opening Balance&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 6px; height: 20px">
                    </td>
                    <td class="TableTitle" style="width: 90px; height: 20px">
                        &nbsp;Centre</td>
                    <td class="TableGrid" colspan="2" style="height: 20px">
                        <asp:Label ID="lblbranch" runat="server" Font-Bold="False" SkinID="LabelSkin" Width="130px"></asp:Label></td>
                    <td colspan="2" style="height: 20px">
                        &nbsp;<%--Request Type--%></td>
                    <td style="height: 20px" colspan="3">
                        <asp:DropDownList ID="ddlRequestType" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged"
                            SkinID="ddlSkin">
                            <asp:ListItem Value="1">Petty Cash Voucher</asp:ListItem>
                            <asp:ListItem Value="2">Vender Payment</asp:ListItem>
                            <asp:ListItem Value="3">OtherThan Petty Cash</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                        <%--<asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                        </asp:DropDownList>--%>
                    </td>
                    <td style="width: 100px; height: 20px">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="height: 20px">
                        <div style="border-right: darkgray thin solid; border-top: darkgray thin solid; overflow: scroll;
                            border-left: darkgray thin solid; width: 700px; border-bottom: darkgray thin solid;
                            height: 200px">
                            <asp:GridView ID="grvTransactionInfo" runat="server" 
                                AutoGenerateColumns="False" DataKeyNames="YearMonth" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                                PageSize="20" CssClass="mGrid">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'one');" style="border-top-style: none;
                                                border-right-style: none; border-left-style: none; background-color: #ffffff;
                                                border-bottom-style: none">
                                                <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                                    src="Images/open.png" style="border-top-style: none; border-right-style: none;
                                                    border-left-style: none; border-bottom-style: none" /></a>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'alt');">
                                                <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                                    src="Images/open.png" style="border-top-style: none; border-right-style: none;
                                                    border-left-style: none; border-bottom-style: none" />
                                            </a>
                                        </AlternatingItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="YearMonth" HeaderText="Year Month" SortExpression="YearMonth" />
                                    <asp:BoundField DataField="OpeningAmount" HeaderText="Opening Amount" SortExpression="OpeningAmount" />
                                    <asp:BoundField DataField="HOAmount" HeaderText="Transfer From HO" SortExpression="HOAmount" />
                                    <asp:BoundField DataField="TotalBalanceAmount" HeaderText="Total Balance Amt" SortExpression="TotalBalanceAmount" />
                                    <asp:BoundField DataField="BalHOAmount" HeaderText="Withdrawal Amt" SortExpression="BalHOAmount" />
                                    <asp:BoundField DataField="BankBalanceAmount" HeaderText="Bank Balance Amount" SortExpression="BankBalanceAmount" />
                                    <asp:BoundField DataField="nYearMonth" HeaderText="Year Month" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            </td></tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <div id='div<%# Eval("AutoNo") %>' style="display: none; position: relative; left: 15px;">
                                                        <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  
                                                            EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                            GridLines="Horizontal" Width="80%">
                                                            <Columns>
                                                                <asp:BoundField DataField="RequestedAmount" HeaderText="RequestedAmount" />
                                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                                                <asp:BoundField DataField="RequestedBy" HeaderText="RequestedBy" />
                                                                <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" />
                                                                <asp:BoundField DataField="Remark" HeaderText="Remark" /> 
                                                            </Columns>
                                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                                                                Font-Overline="False" Font-Size="7.5pt" Font-Underline="False" ForeColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle Font-Names="Tahoma" Font-Size="8pt" />
                                <HeaderStyle Font-Names="Tahoma" Font-Size="8pt" />
                            </asp:GridView>
                            <br />
        <asp:GridView ID="grdtest" runat="server">
        </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height: 36px" class="TableTitle" colspan="10">
                        &nbsp;
                        <asp:Button ID="btnExporttoExcel" runat="server" BorderColor="Black" 
                            BorderWidth="1px" OnClick="btnExporttoExcel_Click" Text="Export" Width="94px" />
&nbsp;&nbsp;
                        <asp:Button ID="btnClose" runat="server" BorderWidth="1px" Height="26px" OnClientClick="window.close();"
                            Text="Close" Width="55px" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
