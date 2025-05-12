<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/FETracking/FETracking.master"  CodeFile="FEWise_Report.aspx.cs" Theme="SkinFile" Inherits="FETracking_FEWise_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <fieldset>
        <legend class="FormHeading">FE-Wise Report</legend>
        <table align="center" width="100%">
            <tr>
                <td align="right" >
                    From Date</td>
                <td s>
                    :</td>
                <td style="width: 254px" >
                    <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                     <img id="imgDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../Images/SmallCalendar.gif" />
                    [dd/mm/yyyy]<asp:RegularExpressionValidator ID="reFromDate" runat="server" ControlToValidate="txtFromDate"
                        CssClass="txtError" Display="None" ErrorMessage="Enter valid date format " SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpvalDate"></asp:RegularExpressionValidator>
                    </td>
                <td align="right">
                    To Date</td>
                <td style="width: 2px">
                    :</td>
                <td >
                    <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../Images/SmallCalendar.gif" />
                    [dd/mm/yyyy]<asp:RegularExpressionValidator ID="reToDate" runat="server" ControlToValidate="txtToDate"
                        CssClass="txtError" Display="None" ErrorMessage="Enter valid date format " SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpvalDate"></asp:RegularExpressionValidator>
                    </td>
            </tr>
            <tr>
                <td align="right" >
                    FE-Code</td>
                <td >
                    :</td>
                <td style="width: 254px" >
                    <asp:TextBox ID="txtFECode" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                <td>
                </td>
                <td style="width: 2px" >
                </td>
                <td >
                    <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" SkinID="btn" Text="Show" ValidationGroup="grpvalDate" />
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin" Visible="False" /></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 122px">
                    <asp:GridView ID="gvShow" runat="server" SkinID="gridviewNoSort" EnableViewState="False">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="btnExport2" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin" Visible="False" /></td>
            </tr>
            <tr>
                <td colspan="6" >
                    &nbsp;<asp:ValidationSummary ID="valDate" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="grpvalDate" />
                    </td>
            </tr>
        </table>
     </fieldset>
</asp:Content>