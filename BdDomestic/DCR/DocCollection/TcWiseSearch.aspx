<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" Theme="SkinFile" CodeFile="~/DCR/DocCollection/TcWiseSearch.aspx.cs" Inherits="CPV_CC_TcWiseSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript" language="javascript"></script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style ="padding-left:10px">
<fieldset><legend class="FormHeading">TC Cases Assignment Tracking</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td style="width: 249px">
    <strong>From Date</strong>&nbsp;
    <asp:TextBox ID="txtFDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td style="width: 422px">
    &nbsp;&nbsp; <strong>To Date</strong>&nbsp;
    <asp:TextBox ID="txtTDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtTDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<strong>Centre &nbsp;
        <asp:DropDownList ID="ddlCenter" runat="server" DataSourceID="sdsCenter" DataTextField="CENTRE_NAME"
            DataValueField="CENTRE_ID" SkinID="ddlSkin">
        </asp:DropDownList></strong></td>
<td><asp:Button ID="btnsearch" Text="Search" SkinID="btnSearchSkin" runat="server" OnClick="btnsearch_Click"/></td>
<td><asp:Button ID="btnExport" runat="server" SkinID="btnGenerateExcelReportSkin" Text="Export To Excel" OnClick="btnExport_Click" /></td>
</tr>
<tr> <td style="width: 249px"><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label></td></tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td>

<asp:GridView ID="gvtc" runat="server" SkinID="gridviewSkin" Width="99%" AutoGenerateColumns="False">
<Columns>
<asp:BoundField HeaderText="Telecaller Name" DataField="TeleCallerName" />
<asp:BoundField HeaderText="Client Name" DataField="Client_name" />
<asp:BoundField HeaderText="Altc" DataField="Altc" />
<asp:BoundField HeaderText="PM" DataField="PM" />
<asp:BoundField HeaderText="Alop" DataField="Alop" />
<asp:BoundField HeaderText="Blop" DataField="Blop" />
<asp:BoundField HeaderText="Stock" DataField="Stock" />
<asp:BoundField HeaderText="TOTAL" DataField="TOTAL" />
</Columns>
</asp:GridView>


</td>
</tr>
</table>


 <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grValidateDate" />
    <asp:SqlDataSource ID="sdsCenter" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="System.Data.OleDb" SelectCommand="Select CENTRE_ID, CENTRE_NAME from centre_master order by CENTRE_NAME">
    </asp:SqlDataSource>
</fieldset>
</td>
</tr>
</table>
</asp:Content>

