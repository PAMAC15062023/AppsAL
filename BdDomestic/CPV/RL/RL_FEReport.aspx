<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/RL/RL_MasterPage.master" Theme="SkinFile" CodeFile="RL_FEReport.aspx.cs" Inherits="CPV_RL_RL_FEReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<fieldset><legend class="FormHeading">FE-Assignment Report</legend>
  <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

        <table align="center" width="100%">
            <tr>
                <td >
                    From Date <font color="red"> * </font></td>
                <td >
                    :</td>
                <td >
                  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10" ></asp:TextBox>
                  <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
            
                </td>
                <td >
                    To Date <font color="red"> *</font></td>
                <td >
                    :</td>
                <td>
                  <asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"
                        Text=""></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />[dd/MM/yyyy]
                </td>
                <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btnReportSkin" ValidationGroup="valgrp" /></td>
            </tr>
            <tr>
                <td colspan="7">
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red"></asp:Label>
        <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtFromDate"
            ErrorMessage="Please Enter From Date  Field !" Display="None" ValidationGroup="valgrp"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtToDate"
            ErrorMessage="Please Enter To Date Field" Width="4px" Display="None" ValidationGroup="valgrp"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revfrmdate" runat="server" ErrorMessage="Please enter valid date format for From Date" Display="None" SetFocusOnError="True" ValidationGroup="valgrp" ControlToValidate="txtFromDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revtodate" runat="server" ErrorMessage="Please enter valid date format for To Date" Display="None" SetFocusOnError="True" ValidationGroup="valgrp" ControlToValidate="txtToDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="vsum" runat="server" ShowMessageBox="True" ShowSummary="False" Width="205px" ValidationGroup="valgrp" />

                   
        </fieldset>
        </asp:Content>
