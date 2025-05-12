<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DedupSearch.aspx.cs" Inherits="HR_HR_DedupSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Dedup Search</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width ="100%">
            <tr>
                <td align="center" >
                    <strong><span style="font-family:Frutiger 47LightCn,Arial ">Dedup Search</span></strong></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td >
                    <asp:GridView ID="gvDedup" runat="server" BackColor="White" BorderColor="Transparent"
    BorderWidth="1px" CellPadding="1" CellSpacing="1"
    ForeColor="Black" GridLines="None" BorderStyle="Solid" Font-Bold="False" Font-Names="Arial" Font-Size="8pt" Width="100%" AutoGenerateColumns="False">
                    
    <FooterStyle BackColor="#D0D5D8" Height="20px"  ForeColor="White" />
    <RowStyle BackColor="#E5E5E5"  />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#D0D5D8" ForeColor="Black" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#D0D5D8" Font-Bold="True" ForeColor="Black" Height="20px" Font-Names="Arial" Font-Size="8pt" />
    <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Empname" HeaderText="PAMACian" />
                            <asp:BoundField DataField="DOB" HeaderText="DOB" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="DOJ" HeaderText="DOJ" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="DOL" HeaderText="DOL" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="Dol_reason" HeaderText="DOL Reason" />
                             <asp:BoundField DataField="CLUSTER_NAME" HeaderText="Cluster Name" />
                            <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                            <asp:BoundField DataField="SubCentreName" HeaderText="Sub Centre Name" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
