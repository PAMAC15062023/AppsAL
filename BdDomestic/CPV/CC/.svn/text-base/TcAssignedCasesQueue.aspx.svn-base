<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" CodeFile="TcAssignedCasesQueue.aspx.cs" Inherits="CPV_CC_TcAssignedCasesQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
<script language="javascript" type="text/javascript">
</script>
<%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px">--%>
<fieldset><legend class="FormHeading">Tc Assigned Cases Queue</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td> From Date:</td><td><asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]
</td><td>To Date: </td>
<td><asp:TextBox ID="txttodate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txttodate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]
</td>
<td><asp:Button ID="btnsearch" Text="Search" SkinID="btnSearchSkin" runat="server" OnClick="btnsearch_Click" /></td>
<td><asp:Button ID="btnExport" runat="server" SkinID="btnGenerateExcelReportSkin" Text="Export To Excel" OnClick="btnExport_Click" /></td>
</tr>
<tr> <td><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label></td></tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td>

<asp:GridView ID="gvtc" runat="server" SkinID="gridviewSkin" Width="99%" AutoGenerateColumns="false" OnRowDataBound="gvtc_RowDataBound">
<Columns>
<asp:BoundField HeaderText="Case ID" DataField="case_id" />
<asp:BoundField HeaderText ="Ref No" DataField ="ref_no" />
<asp:BoundField HeaderText="Client Name" DataField="client_name" />
<asp:BoundField HeaderText="Centre Name" DataField="Centre_name" />
<asp:BoundField HeaderText="Applicant Name" DataField="applicant_name" />
<asp:BoundField HeaderText="Case_status" DataField="status_code" />
<asp:BoundField HeaderText="Verification Type" DataField="verification_type_code" />
<asp:TemplateField HeaderText="Verification Code">
            <ItemTemplate>
             
             <asp:Label ID="lblRT" runat="server" Text="RT" Visible="false"  />
             
             <asp:Label ID="lblSlashRT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
           <asp:Label ID="lblBT" runat="server" Text="BT" Visible="false"  />
           
           <asp:Label ID="lblSlashBT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
            </ItemTemplate>
          <ItemStyle Width="8%" />
            </asp:TemplateField>
</Columns>
</asp:GridView>

</td>
</tr>
</table>


 <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grValidateDate" />
</fieldset>
<%--</td></tr>
</table>--%>
</asp:Content>