<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true"  Theme="SkinFile" CodeFile="IDOC_LabelPrinting.aspx.cs" Inherits="IDOC_LabelPrinting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>

    <fieldset>
        <legend class="FormHeading">Label Printing</legend>
        <table>
        <tr>
            <td align="left" style="width: 137px; height: 1px;" valign="top">
            </td>
            <td align="left" valign="top" style="height: 1px">
            </td>
            <td align="left" colspan="3" valign="top" style="height: 1px">
            </td>
            <td align="left" valign="top" style="height: 1px">
            </td>
            <td align="left" style="width: 100px; height: 1px;" valign="top">
            </td>
            <td align="left" style="width: 23px; height: 1px;" valign="top">
            </td>
            <td align="left" style="width: 83px; height: 1px;" valign="top">
            </td>
            <td align="left" style="width: 100px; height: 1px" valign="top">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 137px" valign="top">
                From Date<span style="color: red">*</span></td>
            <td align="left" valign="top">
                :</td>
            <td align="left" style="width: 11px" valign="top">
                <asp:TextBox ID="txtfrom" runat="server" Width="100px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>&nbsp;</td>
            <td align="left" style="width: 98px" valign="top">
            <img id="imgfrom" alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtfrom.ClientID%>, 'dd/mm/yyyy', 0, 0);" />&nbsp;[dd/mm/yyyy]</td>
            <td align="left" style="width: 45px" valign="top">
                To Date<span style="color: red">*</span></td>
            <td align="left" valign="top">
                :</td>
            <td align="left" style="width: 100px" valign="top">
                <asp:TextBox ID="txtto" runat="server" Width="100px" SkinID="txtSkin" MaxLength="10"></asp:TextBox></td>
            <td align="left" valign="top" colspan="2">
                <img id="imgto" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtto.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/mm/yyyy]</td>
            <td align="left" colspan="1" valign="top">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" Width="85px" OnClick="btnsearch_Click" SkinID="btnSearchSkin" ValidationGroup="Search_Validation" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 137px" valign="top">
                Verification Type<span style="color: red">*</span></td>
            <td align="left" valign="top">
                :</td>
            <td align="left" colspan="2" valign="top">
                    <asp:DropDownList ID="ddlverify" runat="server" OnDataBound="ddlverify_DataBound" Width="191px" SkinID="ddlSkin">
                    </asp:DropDownList></td>
            <td align="left" colspan="3" valign="top">
                </td>
            <td align="left" style="width: 23px" valign="top">
            </td>
            <td align="left" style="width: 83px" valign="top">
                    </td>
            <td align="left" style="width: 100px" valign="top">
                    <asp:Button ID="Button1" runat="server" Text="Generate Label" Width="120px" OnClick="Button1_Click" SkinID="btnGenrateLabel" ValidationGroup="dateValidation" /></td>
        </tr>
            <tr>
                <td align="left" colspan="10" valign="top">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
        <tr>
            <td align="left" colspan="10" valign="top">
            <asp:Label ID="lblMsg" runat="server" Width="237px" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="9">
                    <asp:GridView ID="GV" runat="server" Width="100%" SkinID="gridviewSkin">
                    </asp:GridView>
                    <asp:Label ID="lbltvefify" runat="server" Text="Verification Type" Width="125px" Visible="False"></asp:Label>
            </td>
            <td align="center" colspan="1">
            </td>
        </tr>
    </table>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_FromDate" runat="server"
            ErrorMessage="Please enter valid date format for From Date." ControlToValidate="txtfrom" Display="None" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="dateValidation"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorToDate" runat="server"
            ControlToValidate="txtto" Display="None" ErrorMessage="Please enter valid date format for To Date."
            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="dateValidation"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFrom_Date" runat="server" ControlToValidate="txtfrom"
            ErrorMessage="Please Enter From Date" SetFocusOnError="True" ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTo_date" runat="server" ControlToValidate="txtto"
            ErrorMessage="Please Enter To Date" SetFocusOnError="True" ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary_Date" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="dateValidation" />
        &nbsp;
        <asp:CompareValidator ID="CompareValidator_ddl" runat="server" ControlToValidate="ddlverify"
            Display="None" ErrorMessage="Please Select Verification Type." Operator="GreaterThan"
            ValidationGroup="dateValidation" ValueToCompare="0"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom"
            Display="None" ErrorMessage="Please enter From Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
            Display="None" ErrorMessage="Please enter To Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="Search_Validation" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtfrom"
            Display="None" ErrorMessage="Please enter Valid Date !!" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="Search_Validation"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtto"
            Display="None" ErrorMessage="Please enter Valid Date." ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="Search_Validation"></asp:RegularExpressionValidator></fieldset>
            </td>
            </tr></table>
</asp:Content>

