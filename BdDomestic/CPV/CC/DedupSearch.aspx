<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" CodeFile="DedupSearch.aspx.cs" Inherits="DedupSearch" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Internal Dedup Search</legend>
  <asp:Panel ID="pnlDedup" runat="server" Visible="true" Width="100%">
      <table Width="100%" align="center">
          <tr>
              <td style="width: 16px" >
                  &nbsp;Date&nbsp;<span class="txtRed">*</span></td>
              <td style="width: 246px" >
                      <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin"></asp:TextBox>&nbsp<img alt="" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                          src="../../Images/SmallCalendar.gif" /> [dd/mm/yyyy]</td>
              <td style="width: 25px" >
                  Time</td>
              <td style="width: 140px">
                         <asp:TextBox ID="txtTime" runat="server" MaxLength="5"
                 Width="40px" SkinID="txtSkin"></asp:TextBox>
                <asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                <asp:ListItem Selected="True">AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
                 </asp:DropDownList>
                  [hh:mm]</td>
              <td  >
                  &nbsp;<asp:Button ID="btnDedupSearch" runat="server" OnClick="btnDedupSearch_Click" Text="GO" SkinID="btn" ValidationGroup="grpDedup" />
            </td>
              </tr>
          <tr>
              <td colspan="5">
                  <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
          </tr>
          <tr>
              <td colspan="5">
            <asp:Label ID="lblDedupMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
          </tr>
          <tr>
              <td colspan="5">
                 
                    <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin" Visible="False" /></td>
          </tr>
              </table>
      <table width="100%">
          <tr>
              <td colspan="5">
    <asp:PlaceHolder ID="plhDedupe" runat="server" EnableViewState="false">
                                    
            </asp:PlaceHolder>
              </td>
          </tr>
          </table>
          <table width="100%">
          <tr>
              <td colspan="5" >
                      <asp:Button ID="btnExport2" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin" Visible="False" /></td>
          </tr>
      </table>
         
            </asp:Panel>
     
    <asp:RequiredFieldValidator ID="reDate" runat="server" ControlToValidate="txtDate"
        Display="None" ErrorMessage="Received Date should not be blank" SetFocusOnError="True"
        ValidationGroup="grpDedup"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regDate" runat="server" ControlToValidate="txtDate"
        Display="None" ErrorMessage="Enter valid date format for Received Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="grpDedup"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="valDedup" runat="server" DisplayMode="List" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="grpDedup" />
    <asp:RegularExpressionValidator ID="regTime" runat="server" ControlToValidate="txtTime"
        Display="None" ErrorMessage="Enter valid Received Time" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpDedup"></asp:RegularExpressionValidator>
    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<span class="txtRed"> </span></fieldset>
    </td></tr>
</table>
</asp:Content>