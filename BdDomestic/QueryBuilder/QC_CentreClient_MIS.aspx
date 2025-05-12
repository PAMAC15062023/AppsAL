<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="QC_CentreClient_MIS.aspx.cs" Inherits="QueryBuilder_QC_CentreClient_MIS" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
</script>
<%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px">--%>
<fieldset><legend class="FormHeading">QC Centre and Client Wise MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td valign="top" style="width: 256px">
    From Date: &nbsp;<asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                    <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
           <td  valign="top" style="width: 244px">
               To Date:
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox>&nbsp;
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
<td style="width: 297px; height: 38px;">
    <strong>Report Type</strong><asp:DropDownList ID="ddlCenter" runat="server" 
        DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" Width="102px">
        <asp:ListItem>(Select)</asp:ListItem>
        <asp:ListItem>Centre</asp:ListItem>
        <asp:ListItem>Client</asp:ListItem>
    </asp:DropDownList>&nbsp;&nbsp;&nbsp; 
    </td>
<td style="width: 244px; height: 38px;"><asp:Button ID="Button1" Text="Search" runat="server" OnClick="btnsearch_Click" />
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" Width="110px" />
    </td>
</tr>
<tr> <td style="width: 256px"><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label></td></tr>
    <tr>
        <td style="width: 256px">
        </td>
    </tr>
</table>

<asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grValidateDate" />
    &nbsp;&nbsp;
</fieldset>

<table border="0" id="tblExport" cellpadding="0" cellspacing="0" runat="server"  visible="false" width="100%">
<tr><td>
    &nbsp;&nbsp;
    <asp:GridView ID="grdvw" runat="server" AutoGenerateColumns="True" SkinID="gridviewNoSort"
        Width="99%">
    </asp:GridView>
</td>
</tr>
</table>
</asp:Content>

