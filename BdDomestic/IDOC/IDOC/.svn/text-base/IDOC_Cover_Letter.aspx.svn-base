<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_Cover_Letter.aspx.cs" Inherits="IDOC_IDOC_IDOC_Cover_Letter" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<div>
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Covering Letter</legend>
        <table align="center" width="100%">
            <tr>
                <td colspan="7">
                </td>
            </tr>
            <tr>
                <td >
                     From Date<font color="red"> *</font></td>
                <td >
                    :</td>
                <td >
                    <asp:TextBox ID="txtDateFrom" runat="server" Width="155px" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img alt="" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtDateFrom.ClientID %>,'dd/mm/yyyy',0,0);" />
                    [dd/MM/yyyy]</td>
                
                <td >
                    To Date<font color="red"> *</font><font color="red"></font></td>
                <td >
                    :</td>
                <td >
                    <asp:TextBox ID="txtDateTo" runat="server" Width="155px" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img alt="" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtDateTo.ClientID %>,'dd/mm/yyyy',0,0)";/>
                    [dd/MM/yyyy]</td>
                <td >
                <asp:Button ID="btnSubmit" runat="server" SkinID="btnReportSkin" ValidationGroup="grValidateDate"
                        OnClick="btnSubmit_Click" /></td>
                
            </tr>
            <tr>
                <td style="height: 40px">
                    Verification Type</td>
                <td style="height: 40px">
                    :</td>
                <td style="height: 40px">
                    <asp:DropDownList ID="ddlVeriTypeID" runat="server" SkinID="ddlSkin" DataSourceID="sdsddlVeriType" DataTextField="VERIFICATION_TYPE" DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlVeriTypeID_DataBound">
                    </asp:DropDownList>
                </td>
                <td style="height: 40px">
                </td>
                <td style="height: 40px">
                </td>
                <td style="height: 40px">
                    <asp:SqlDataSource ID="sdsddlVeriType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT VERIFICATION_TYPE,VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER WHERE (ACTIVITY_ID = '1012') AND (PARENT_TYPE_CODE = 'DV') order by  VERIFICATION_TYPE"></asp:SqlDataSource>
                </td>
                <td style="height: 40px">
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
            <tr>
            <td colspan="7"><asp:Label ID="lblMessage" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label> </td>
            </tr>
            <tr>
                <td colspan="7">
                    &nbsp;</td>
            </tr>
        </table>
   </fieldset> 
   </td></tr></table>
    </div>
    &nbsp;
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtDateFrom"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtDateTo"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter From Date" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter To Date" Width="4px" Display="None"></asp:RequiredFieldValidator>

        <asp:ValidationSummary ID="vsum" runat="server" ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" Width="205px" />
</asp:Content>

