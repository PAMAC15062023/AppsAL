<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_DaywiseBreakupOfCases.aspx.cs" Inherits="IDOC_IDOC_IDOC_DaywiseBreakupOfCases" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<div>
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Daywise Breakup of cases</legend>
        <table align="center" width="100%">
            <tr>
                <td colspan="7" style="height: 16px"><asp:Label ID="lblMsg" runat="server" Visible="false" SkinID="lblErrorMsg"></asp:Label>
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
                <asp:Button ID="btnSubmit" runat="server" SkinID="btnReportSkin"
                        OnClick="btnSubmit_Click" ValidationGroup="ValidateDate"/></td>
                
            </tr>
            <tr>
                <td colspan="1">
                    Verification Type ID <font color="red">*</font></td>
                <td colspan="1">
                    :</td>
                <td colspan="1">
                    <asp:DropDownList ID="ddlVeriType" runat="server" DataSourceID="sdsVerifyType" DataTextField="VERIFICATION_TYPE" DataValueField="VERIFICATION_TYPE_ID"  OnDataBound="ddlVeriType_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td colspan="1">
                </td>
                <td colspan="1">
                </td>
                <td colspan="1">
                    <asp:SqlDataSource ID="sdsVerifyType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="Select [VERIFICATION_TYPE_ID],[VERIFICATION_TYPE], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER &#13;&#10; WHERE VERIFICATION_TYPE_ID IN(5,6,7,8,9,11) order by  VERIFICATION_TYPE">
                    </asp:SqlDataSource>
                </td>
                <td colspan="7">
                </td>
            </tr>
            
            <tr>
                <td colspan="7" style="height: 16px">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
            <tr>
            <td colspan="7" style="height: 16px"><asp:Label ID="lblMessage" runat="server" Visible="false" SkinID="lblErrorMsg"></asp:Label> </td>
            </tr>
            <tr>
                <td colspan="7">
                    &nbsp;</td>
            </tr>
        </table>
   </fieldset> 
   </td></tr></table>
    </div>
    <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom"
      ErrorMessage="Please enter From Date" Display="None" ValidationGroup="ValidateDate"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtDateTo"
      ErrorMessage="Please enter To Date " Display="None" ValidationGroup="ValidateDate"></asp:RequiredFieldValidator>&nbsp;
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtDateFrom"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True" ValidationGroup="ValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtDateTo"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True" ValidationGroup="ValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="ValidateDate" />

        
</asp:Content>



