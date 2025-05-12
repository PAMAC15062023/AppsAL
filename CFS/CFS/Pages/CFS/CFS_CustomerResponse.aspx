<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CFS_CustomerResponse.aspx.cs" Inherits="Pages_CFS_CFS_CustomerResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../popcalendar.js" type="text/javascript"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>

    <script type="text/javascript">  
        $(function () {
            $('[id*=lstEmployee]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>


    <asp:Panel ID="pnlproduct" runat="server">
        <table style="width: 688px; height: 40px;">
            <tr>
                <td class="TableHeader" colspan="4" style="width: 690px;">&nbsp;PAMAC Customer  &nbsp; Survey Report
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="SurveySubmitedPanel" runat="server">
        <table style="width: 688px; height: 123px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMessage2" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="SurveyPanel" runat="server">
        <table style="width: 688px; height: 123px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg1" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 71px;">
                    <strong>&nbsp; &nbsp;&nbsp;&nbsp;Client Name </strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:Label ID="lblClientName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 71px;">
                    <strong>&nbsp; &nbsp;&nbsp;&nbsp;Date </strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 71px;">
                    <strong>&nbsp; &nbsp;&nbsp;&nbsp;Cleint  Representative </strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:Label ID="lblCleintRepresentative" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 71px;">
                    <strong>&nbsp; &nbsp;&nbsp;&nbsp;PAMAC Center</strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:Label ID="lblPAMACCenter" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblque1" runat="server" Width="400px"></asp:Label>
                </td>
                &nbsp; &nbsp;&nbsp;&nbsp;
                <td>
                    <asp:RadioButton ID="rbtnYes" runat="server" Text="Yes" GroupName="ab" OnCheckedChanged="rbtnYes_CheckedChanged" AutoPostBack="true" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnNo" runat="server" Text="No" GroupName="ab" OnCheckedChanged="rbtnNo_CheckedChanged" AutoPostBack="true" />
                </td>
                <td>
                    <asp:ListBox ID="ddlAnw" runat="server" SelectionMode="Multiple" Width="200px" Visible="false"></asp:ListBox>
                </td>
                <%-- <td style="margin-left: 500px">
                    <asp:DropDownList ID="ddlAnw" runat="server" Width="400px" Visible="false">
                    </asp:DropDownList>
                </td>--%>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblque2" runat="server" Width="400px"></asp:Label>
                </td>
                &nbsp; &nbsp;&nbsp;&nbsp;
                <td>
                    <asp:RadioButton ID="rbtnYes2" runat="server" Text="Yes" GroupName="ac" AutoPostBack="true" OnCheckedChanged="rbtnYes2_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnNo2" runat="server" Text="No" GroupName="ac" AutoPostBack="true" OnCheckedChanged="rbtnNo2_CheckedChanged" />
                </td>
                <td>
                    <asp:ListBox ID="ddlAnw2" runat="server" SelectionMode="Multiple" Width="200px" Visible="false"></asp:ListBox>
                    <%--<asp:DropDownList ID="ddlAnw2" runat="server" Width="400px" Visible="false">
                    </asp:DropDownList>--%>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblque3" runat="server" Width="400px"></asp:Label>
                </td>
                &nbsp; &nbsp;&nbsp;&nbsp;
                <td>
                    <asp:RadioButton ID="rbtnYes3" runat="server" Text="Yes" GroupName="ad" AutoPostBack="true" OnCheckedChanged="rbtnYes3_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnNo3" runat="server" Text="No" GroupName="ad" AutoPostBack="true" OnCheckedChanged="rbtnNo3_CheckedChanged" />
                </td>
                <td>
                    <asp:ListBox ID="ddlAnw3" runat="server" SelectionMode="Multiple" Width="200px" Visible="false"></asp:ListBox>
                    <%--  <asp:DropDownList ID="ddlAnw3" runat="server" Width="400px" Visible="false">
                    </asp:DropDownList>--%>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblque4" runat="server" Width="400px"></asp:Label>
                </td>
                &nbsp; &nbsp;&nbsp;&nbsp;
                <td>
                    <asp:RadioButton ID="rbtnYes4" runat="server" Text="Yes" GroupName="ae" AutoPostBack="true" OnCheckedChanged="rbtnYes4_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnNo4" runat="server" Text="No" GroupName="ae" AutoPostBack="true" OnCheckedChanged="rbtnNo4_CheckedChanged" />
                </td>
                <td>
                    <asp:ListBox ID="ddlAnw4" runat="server" SelectionMode="Multiple" Width="200px" Visible="false"></asp:ListBox>
                    <%--<asp:DropDownList ID="ddlAnw4" runat="server" Width="400px" Visible="false">
                    </asp:DropDownList>--%>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblque5" runat="server" Width="470px"></asp:Label>
                </td>
                <%--  &nbsp; &nbsp;&nbsp;&nbsp;
                <td>
                    <asp:RadioButton ID="RadioButton7" runat="server" Text="Yes" GroupName="ab"  AutoPostBack="true" />
                </td>
                <td>
                    <asp:RadioButton ID="RadioButton8" runat="server" Text="No" GroupName="ab"    AutoPostBack="true" />
                </td>--%>
                <td>
                    <asp:DropDownList ID="ddlAnw5" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td class="TableTitle" colspan="4">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnCalcel" runat="server" Text="Cancel" BorderColor="#400000" BorderWidth="1px"
                        Font-Bold="False" Width="105px" Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="validdata" />
    <asp:HiddenField ID="hfCustomerId" runat="server" />
    <asp:HiddenField ID="hfemailId" runat="server" />
    <asp:HiddenField ID="hfDCHEmailId" runat="server" />
    <asp:HiddenField ID="hfDCHCorodinatorEmailId" runat="server" />
</asp:Content>

