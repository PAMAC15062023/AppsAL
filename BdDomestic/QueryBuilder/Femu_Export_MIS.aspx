<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="~/QueryBuilder/Femu_Export_MIS.aspx.cs" Inherits="Femu_Export_MIS" Title="Femu Export MIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
</script>
<%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px">--%>
<fieldset><legend class="FormHeading">Femu Export MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td valign="top" style="width: 281px; height: 44px;">
    <br />
    From Date: &nbsp;<asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="112px"></asp:TextBox>
                    <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
           <td  valign="top" style="width: 244px; height: 44px;">
               <br />
               To Date:
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="105px"></asp:TextBox>&nbsp;
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
<td style="width: 636px; height: 44px;">
    <strong>Product Type</strong><asp:DropDownList ID="ddlprduct1" runat="server" SkinID="ddlSkin" Width="102px">
        <asp:ListItem>(Select)</asp:ListItem>
        <asp:ListItem>CC</asp:ListItem>
        <asp:ListItem>KYC</asp:ListItem>
        <asp:ListItem>RL</asp:ListItem>
        <asp:ListItem Value="CEL">CELLULAR</asp:ListItem>
    </asp:DropDownList>&nbsp;&nbsp;&nbsp; <strong>Veri</strong> <strong>Type</strong><asp:DropDownList ID="ddlVeriType" runat="server" SkinID="ddlSkin" Width="102px">
        <asp:ListItem>(Select)</asp:ListItem>
        <asp:ListItem>RV</asp:ListItem>
        <asp:ListItem>BV</asp:ListItem>
    </asp:DropDownList></td>
<td style="width: 244px; height: 44px;"><asp:Button ID="btnsearch" Text="Search" runat="server" OnClick="btnsearch_Click"/>
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Width="110px" OnClick="btnExport_Click"/>
    </td>
</tr>
<tr> <td style="width: 281px"><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label></td></tr>
    <tr>
        <td style="width: 281px">
        </td>
    </tr>
</table>

<asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grValidateDate" />
    &nbsp;&nbsp;
</fieldset>

    <asp:Panel ID="Panel1" runat="server" Height="300px" Width="930px" ScrollBars="Auto">

<table border="0" id="tblExport" cellpadding="0" cellspacing="0" runat="server"  visible="false" width="100%">
<tr><td>
    &nbsp;&nbsp;
    <asp:GridView ID="grdvw" runat="server" AutoGenerateColumns="True" SkinID="gridviewNoSort"
        Width="99%">
    </asp:GridView>
</td>
</tr>
</table>
    </asp:Panel>
</asp:Content>

