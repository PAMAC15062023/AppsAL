<%@ Page Language="C#" MasterPageFile="~/Pages/LNT_CommonMaster.Master" AutoEventWireup="true" CodeBehind="LNT_LTFS_IP.aspx.cs" Inherits="LNTFinance.Pages.LNT_LTFS_IP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script language="javascript" type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode; YBL_Amended_Applications_Tracking
            where LoanApplicationID = '2307070813'
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

    <style type="text/css">
        .TableTitle {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            border-right: #660000 1px solid;
            border-top: #660000 1px solid;
            border-left: #660000 1px solid;
            border-bottom: #660000 1px solid;
            border-color: #808080;
        }
    </style>


    <table style="width: 850px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">
                    <asp:Label ID="lblheader" runat="server"></asp:Label></span>
            </td>
        </tr>
    </table>
    <table style="width: 850px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>

    <table style="width: 688px;">
        <tr>
            <td>
                <asp:Label ID="lblFreshCount" runat="server" ForeColor="Blue" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblResendCount" runat="server" ForeColor="Chocolate" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSaleQueCount" runat="server" ForeColor="Magenta" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApproveCount" runat="server" ForeColor="GrayText" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalCount" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalDuration" runat="server" ForeColor="BlueViolet" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
        </tr>
    </table>

    <asp:UpdatePanel ID="UP_ddlUserName" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table style="width: 850px;">
                <tr>
                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="99px" Font-Size="10" Height="20" Style="text-align: center;">APP DATE</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:TextBox ID="txtAppDate" runat="server" Style="width: 144px;"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="99px" Font-Size="10" Height="20" Style="text-align: center;">APP ID</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:TextBox ID="txtAPPLICATIONID" runat="server" Width="144px" OnTextChanged="txtAPPLICATIONID_TextChanged1" AutoPostBack="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="99px" Font-Size="10" Height="20" Style="text-align: center;">APP Status</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:DropDownList ID="ddlClientCaseStatus" runat="server" Width="150px"></asp:DropDownList>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="99px" Font-Size="10" Height="20" Style="text-align: center;">OPS Status</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:DropDownList ID="ddlSTATUS" runat="server" Width="150px"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table style="width: 850px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <tr>
                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="99px" Font-Size="10" Height="20" Style="text-align: center;">Remark</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:TextBox ID="txtRemark" runat="server" MaxLength="500" Width="144px"></asp:TextBox>
                    </td>

                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="99px" Font-Size="10" Height="20" Style="text-align: center;">User ID</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:TextBox ID="txtUserID" runat="server" ReadOnly="true" Style="width: 144px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="99px" Font-Size="10" Height="20" Style="text-align: center;">Date</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="true" Style="width: 144px;"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px"></td>
                    <td class="TableTitle" style="height: 27px"></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <table style="width: 850px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save And Continue"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSaveAndContinue_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSaveAndExit" runat="server" Text="Save And Exit" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnSaveAndExit_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000"
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnBack_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
