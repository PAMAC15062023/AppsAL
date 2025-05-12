<%@ Page Language="C#" MasterPageFile="CEL_MasterPage.master" AutoEventWireup="true" CodeFile="CEL_ExportExcel.aspx.cs" Inherits="CPV_Cellular_CEL_ExportExcel" Theme="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Export</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr><td>&nbsp;
    </td></tr>
<tr><td>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
    <tr><td align="left" valign="top">&nbsp;From</td><td align="left" valign="top">:</td>
    <td align="left" valign="top" >
    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]</td>
    <td align="left" valign="top" >To</td><td align="left" valign="top">:</td>
    <td align="left" valign="top">
    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>       
    <td align="left" valign="top">
        
        </td>
    <td align="left" valign="top" style="width: 19px"> &nbsp;</td>
    </tr> 
    <tr>
        <td align="left" valign="top">
            Case</td>
        <td align="left" valign="top">
            :</td>
        <td align="left" valign="top" >
            <asp:DropDownList ID="ddlCaseType" runat="server" DataSourceID="sdsCaseType" DataTextField="CASE_TYPE"
                DataValueField="CASE_TYPE_ID" SkinID="ddlSkin">
            </asp:DropDownList></td>
        <td align="left"  valign="top">
            Based On</td>
        <td align="left" valign="top">
            :</td>
        <td align="left" valign="top" >
        <asp:DropDownList ID="ddlBasedOn" runat="server" SkinID="ddlSkin">
        <asp:ListItem>Received Date</asp:ListItem>
        <asp:ListItem>Send Date</asp:ListItem>
        </asp:DropDownList></td>
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top" style="width: 19px">
        </td>
    </tr>
    <tr>
        <td colspan="8">
            <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
    </tr>
    <tr><td colspan="8" ><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label>
    <asp:Button ID="btnExcelReport" runat="server" Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnExcelReport_Click"  ValidationGroup="grValidateDate"/>
        
        <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="grValidateDate" /></td></tr>  
    <tr>
        <td colspan="8">
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="8" align="center">
        <asp:Panel ID="pnlExport" runat="server" Height="50px" Width="99%" Visible="false" BorderWidth="1px">
                    <div id="dvExport" style="overflow:scroll;  width:980px; height:200px;"> 
                        <asp:GridView ID="gvExport" runat="server" SkinID="gridviewSkin" Width="745px" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvExport_PageIndexChanging" OnSorting="gvExport_Sorting" >
                        </asp:GridView>
                    </div>
                    </asp:Panel>
            </td>
    </tr>
    <tr><td colspan="8"><br /></td></tr>
    <tr>
        <td colspan="8" >
            <asp:SqlDataSource ID="sdsTemplate" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsCaseType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [CASE_TYPE_ID], [CASE_TYPE] FROM [CPV_CELLULAR_CASE_TYPE_MASTER]">
            </asp:SqlDataSource>
            &nbsp;
        </td>
    </tr>
    <tr>
    <td colspan="8">
        <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
                    Display="None" ErrorMessage="Please enter valid date format for From date."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtToDate"
                    Display="None" ErrorMessage="Please enter valid date format for To date."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator>
       <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtFromDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please enter From Date" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtToDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please enter To Date" Width="4px" Display="None"></asp:RequiredFieldValidator>

       <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grValidateDate" />
    </td>
    </tr>
    </table>
    </td></tr>
    
     </table>
     </fieldset></td></tr></table>   
   </asp:Content>
        

