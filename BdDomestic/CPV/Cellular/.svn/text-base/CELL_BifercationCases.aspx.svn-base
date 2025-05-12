<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile" MasterPageFile="CEL_MasterPage.master" CodeFile="CELL_BifercationCases.aspx.cs" Inherits="CPV_Cellular_CELL_BifercationCases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<div>
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Daywise Breakup of cases</legend>
        <table align="center" width="100%">
            <tr>
                <td colspan="7"><asp:Label ID="lblMsg" runat="server" Visible="false" SkinID="lblErrorMsg"></asp:Label>
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
                <td>
                    Case Type</td>
                <td>
                    :</td>
                <td>
                    <asp:DropDownList ID="ddlCaseType" runat="server" DataSourceID="sdsCaseType" DataTextField="CASE_TYPE"
                        DataValueField="CASE_TYPE_ID" OnDataBound="ddlCaseType_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:SqlDataSource ID="sdsCaseType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [CASE_TYPE_ID], [CASE_TYPE] FROM [CPV_CELLULAR_CASE_TYPE_MASTER]">
                    </asp:SqlDataSource>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
            <tr>
            <td colspan="7"><asp:Label ID="lblMessage" runat="server" Visible="false" SkinID="lblErrorMsg"></asp:Label> </td>
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
      ErrorMessage="Please Select From Date" Display="None" ValidationGroup="ValidateDate"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtDateTo"
      ErrorMessage="Please Select To Date " Display="None" ValidationGroup="ValidateDate"></asp:RequiredFieldValidator>&nbsp;
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtDateFrom"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True" ValidationGroup="ValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtDateTo"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True" ValidationGroup="ValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="ValidateDate" />

        
</asp:Content>