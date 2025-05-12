<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile" MasterPageFile="CEL_MasterPage.master"  CodeFile="CC_Cellular_PendingList_Report.aspx.cs" Inherits="CPV_Cellular_CC_Cellular_PendingList_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Pending List</legend>
  <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

        <table align="center" width="100%">
            <tr>
                <td >
                    From Date <font color="red"> * </font></td>
                <td >
                    :</td>
                <td >
                  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="11" ></asp:TextBox>
                  <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
            
                </td>
                <td >
                    To Date <font color="red"> *</font></td>
                <td >
                    :</td>
                <td>
                  <asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="11"
                        Text=""></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />[dd/MM/yyyy]&nbsp;
                </td>
                <td><asp:DropDownList ID="ddlValue" runat="server" SkinID="ddlSkin" >
                <asp:ListItem Text="Actual" Value="true"></asp:ListItem>
                <asp:ListItem Text="Pending from FE" Value="false"></asp:ListItem>
                </asp:DropDownList>
                </td>
                <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btnReportSkin" /></td>
            </tr>
            <tr>
                <td>
                    Case Type</td>
                <td>
                    :</td>
                <td><asp:DropDownList ID="ddlCaseType" runat="server" SkinID="ddlSkin" DataSourceID="sdsCaseType" DataValueField="CASE_TYPE_ID" DataTextField="CASE_TYPE" OnDataBound="ddlCaseType_DataBound" > </asp:DropDownList>
                </td>
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
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
        </table>
         <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" SkinID="lblErrorMsg"></asp:Label>
        <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtFromDate"
            ErrorMessage="Please enter From Date" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtToDate"
            ErrorMessage="Please enter To Date" Width="4px" Display="None"></asp:RequiredFieldValidator>

        <asp:ValidationSummary ID="vsum" runat="server" ShowMessageBox="True" ShowSummary="False" Width="205px" />

                   
        </fieldset>
        </td></tr></table>
        </asp:Content>
