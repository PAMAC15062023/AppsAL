<%@ Page Language="C#" Theme="SkinFile" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true" CodeFile="RejectCaseMIS.aspx.cs" Inherits="QueryBuilder_RejectCaseMIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px; height: 155px;">
<fieldset><legend  class="FormHeading">Reject Cases MIS</legend>

<table id="tblMain"  cellpadding="0" cellspacing="0" width="100%">
 <tr>   
<td style="width: 91px; height: 24px" >
<asp:Label SkinID="lblSkin"  ID="lblFromDate" runat="server" Text="From Date"></asp:Label></td>
<td style="width: 267px; height: 24px"><asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateFromDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td style="width: 65px; height: 24px"  >
<asp:Label SkinID="lblSkin"  ID="lblToDate" runat="server" Text="To Date"></asp:Label>
</td>
<td style="width: 259px; height: 24px"  ><asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgToDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateToDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td style="height: 24px"  > 
    <asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Product"></asp:Label>   
    <asp:DropDownList ID="ddlProduct" runat="server" AppendDataBoundItems="True" DataSourceID="sdsProduct"
        DataTextField="PRODUCT_NAME" DataValueField="PRODUCT_ID" SkinID="ddlSkin" Width="150px">
        <asp:ListItem Value="0">Select Product</asp:ListItem>
    </asp:DropDownList><asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [PRODUCT_MASTER] WHERE ([ACTIVITY_ID] IS NOT NULL)">
    </asp:SqlDataSource>
<asp:Button ID="btnSearch" runat="server" Text="Search" ValidationGroup="grpDates" OnClick="btnSearch_Click" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
    <asp:Button ID="Btnexport" runat="server" Text="Export Detail"
        Width="102px" OnClick="Btnexport_Click" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
</tr>
<tr>
<td colspan="5"><asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label></td>
</tr>
<tr>
    <td colspan="5" style="height: 14px">
        <asp:GridView ID="GridView1" runat="server" Width="928px">
        </asp:GridView>
    </td>
</tr>
 
</table>
 <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select From Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select To Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="vsValidateDate" runat="server" ShowMessageBox="True"
         ShowSummary="False" ValidationGroup="grpDates"/>
</fieldset>
      </td></tr>
</table>
</asp:Content>

