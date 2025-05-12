<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="TatAnalysisClient_MonthWise.aspx.cs" Inherits="QueryBuilder_TatAnalysisClient_MonthWise" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
        <legend class="FormHeading"><strong>TAT Analysis Client Wise(Mothly)</strong></legend>
        <table style="width: 719px">
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 108px" valign="top">
                </td>
                <td style="width: 3px" valign="top">
                </td>
                <td style="width: 131px">
                    &nbsp;</td>
                <td style="width: 131px">
                </td>
                <td style="width: 100px">
                </td>
                <td>
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 108px">
                    <asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="From Date" Width="74px"></asp:Label></td>
                <td style="width: 3px">
                    :</td>
                <td style="width: 131px">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 131px">
                <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.gif" /></td>
                <td style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="lblSkin" Text="ToDate" Width="56px"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    &nbsp;<asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 100px">
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.gif" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 108px">
                </td>
                <td style="width: 3px">
                </td>
                <td style="width: 131px">
                </td>
                <td style="width: 131px">
                </td>
                <td style="width: 100px">
                </td>
                <td>
                </td>
                <td style="width: 100px">
                <asp:Button ID="btnReport" runat="server" SkinID="btn" Text="Get Report" OnClick="btnReport_Click" /></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="9">
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                        Display="None" ErrorMessage="Please select From Date" Font-Size="9pt" SetFocusOnError="True"
                        ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator_ToDate"
                            runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please Select To Date"
                            Font-Size="9pt" SetFocusOnError="True" ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                                Display="None" ErrorMessage="Please enter valid From Date." Font-Names="Arial"
                                Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                ValidationGroup="Val"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator_ToDate" runat="server" ControlToValidate="txtToDate"
                                    Display="None" ErrorMessage="Please enter valid To Date." Font-Names="Arial"
                                    Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="Val"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidator_From_ToDate" runat="server" ClientValidationFunction="funValidateFromToDate"
                        Display="None" ErrorMessage="To Date should not be less then From Date" Font-Size="9pt"
                        SetFocusOnError="True" ValidationGroup="Val"></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Size="9pt" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="Val" />
                </td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp;
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorFrom_Date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter From date." ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTo_date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter To date."  ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        --%>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select From Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select To Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        --%>
        &nbsp; &nbsp; &nbsp; &nbsp;
    </fieldset>
</asp:Content>

