<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LNT_CommonMaster.Master" AutoEventWireup="true" CodeBehind="LNT_FarmDigital.aspx.cs" Inherits="LNTFinance.Pages.LNT_FarmDigital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script language="javascript" type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
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
        .auto-style1 {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            white-space: no-wrap;
            height: 27px;
            width: 375px;
            border: 1px solid #808080;
            background-color: #C0C0C0;
        }
        .auto-style4 {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            white-space: no-wrap;
            height: 27px;
            width: 216px;
            border: 1px solid #808080;
            background-color: #C0C0C0;
        }
        .auto-style6 {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            white-space: no-wrap;
            height: 27px;
            width: 180px;
            border: 1px solid #808080;
            background-color: #C0C0C0;
        }
        .auto-style7 {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            white-space: no-wrap;
            height: 27px;
            border: 1px solid #808080;
            background-color: #C0C0C0;
        }
        .auto-style8 {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            white-space: no-wrap;
            height: 27px;
            width: 324px;
            border: 1px solid #808080;
            background-color: #C0C0C0;
        }
        .auto-style9 {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            white-space: no-wrap;
            height: 27px;
            width: 153px;
            border: 1px solid #808080;
            background-color: #C0C0C0;
        }
        </style>

    <%-- <style>
        table, th, td {
            border: 1px solid black;
        }
    </style>--%>

    <table style="width: 1200px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">Farm Digital &nbsp;DATA</span>
            </td>
        </tr>
    </table>
    <table style="width: 1200px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 1200px; border: 1px solid black;">
        <tr>
            <th style="border: 1px solid black;background-color:yellow">Tray</th>
            <th style="border: 1px solid black;background-color:yellow">App Status</th>
            <th style="border: 1px solid black;background-color:yellow">Ops Status</th>
            <th style="border: 1px solid black;background-color:yellow">Total Count</th>
            <th style="border: 1px solid black;background-color:yellow">Total Count & Time</th>
            <%--<th style="border: 1px solid black;background-color:yellow"></th>--%>
        </tr>
        <tr>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pre-Sanction</td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pending - <asp:Label ID="lblPreFresh" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label> | Resend - <asp:Label ID="lblPreResend" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Approved - <asp:Label ID="lblPreApproved" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label> | Sales Q - <asp:Label ID="lblPreSalesQ" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPreFreshResend" Text="3" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTotalCount" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
            <%--<td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Duration:-
                <asp:Label ID="lblTotalDuration" Text="01:30" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>--%>
        </tr>
        <tr>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Post-Sanction</td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pending - <asp:Label ID="lblPostFresh" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label> | Resend - <asp:Label ID="lblPostResend" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Approved - <asp:Label ID="lblPostApproved" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label> | Sales Q - <asp:Label ID="lblPostSalesQ" Text="2" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPostFreshResend" Text="8" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
            <td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTotalTime" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>
                 <%--<td style="border: 1px solid black;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Case Count:- 
                <asp:Label ID="lblTotalCaseCount" Text="19" runat="server" ForeColor="Black" Font-Bold="true" Font-Size="Small"></asp:Label></td>--%>
        </tr>
    </table>

    <asp:UpdatePanel ID="UP_ddlUserName" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table style="width: 1200px;">
                <tr>
                    <td class="TableTitle" style="height: 27px"colspan="2">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">APPLICATION ID</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px"colspan="2">
                        <asp:TextBox ID="txtAPPLICATIONID" runat="server" Width="150px" OnTextChanged="txtAPPLICATIONID_TextChanged" AutoPostBack="true" MaxLength="18" Font-Bold="True"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="2">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">App Status</asp:Label>
                    </td>
                    <td  class="TableTitle" style="height: 27px;" colspan="2" >
                        <asp:RadioButtonList ID="rdbAppStatus" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Height="16px" Width="182px" EnableTheming="True">
                       <%-- <asp:ListItem Text ="Fresh" Value="Fresh"></asp:ListItem>
                        <asp:ListItem Text="Resend" Value="Resend"></asp:ListItem>--%>
                    </asp:RadioButtonList>
                        <%--<asp:DropDownList ID="ddlClientCaseStatus" runat="server" Width="150px"></asp:DropDownList>--%>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">Ops Status</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:RadioButtonList ID="rdbOpsStatus" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Height="16px" Width="182px" EnableTheming="True">
                        <%--<asp:ListItem Text ="Approved" Value="Approved"></asp:ListItem>
                        <asp:ListItem Text="Sales Que" Value="SalesQ"></asp:ListItem>--%>
                    </asp:RadioButtonList>
                        <%--<asp:DropDownList ID="ddlSTATUS" runat="server" Width="150px"></asp:DropDownList>--%>
                    </td>
            </table>
            <table style="width: 1200px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <tr>
                    <td class="auto-style6">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">Type Of Case</asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:RadioButtonList ID="rdbTypeOfCase" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Height="16px" Width="350px" EnableTheming="True">
                       <%-- <asp:ListItem Text ="Pre Doc Verification" Value="Pre"></asp:ListItem>
                        <asp:ListItem Text="Post Doc Verification" Value="Post"></asp:ListItem>--%>
                    </asp:RadioButtonList>
                        <%--<asp:DropDownList ID="ddlTypeOfCase" runat="server" Width="150px"></asp:DropDownList>--%>
                    </td>     
                    <td class="auto-style4">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">Agency</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px">
                        <asp:RadioButtonList ID="rdbAgency" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Height="16px" Width="300px" EnableTheming="True">
                        <%--<asp:ListItem Text ="PAMAC" Value="PAMAC"></asp:ListItem>
                        <asp:ListItem Text="Vindhya" Value="Vindhya"></asp:ListItem>--%>
                    </asp:RadioButtonList>
                        <%--<asp:DropDownList ID="ddlTypeOfCase" runat="server" Width="150px"></asp:DropDownList>--%>
                    </td>  
                </tr>
            </table>
            <table style="width: 1200px;">
                    <tr>
                        <td class="auto-style9">
                            <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">Asset Type</asp:Label>
                        </td>
                        <td class="auto-style8">
                            <asp:DropDownList ID="ddlAssetType1" runat="server" Width="200px"></asp:DropDownList>
                        </td>
                        <td class="TableTitle" style="height: 27px" Width="530px"></td>
                        </tr>
                
                        </table>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <table style="width: 1200px;">
                    <tr>
                        <td class="TableTitle" style="height: 27px">
                            <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Asset Type</asp:Label>
                        </td>
                        <td class="TableTitle" style="height: 27px">
                            <asp:DropDownList ID="ddlAssetType" runat="server" Width="150px"></asp:DropDownList>
                        </td>
                        <td class="TableTitle" style="height: 27px">
                            <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Branch Name</asp:Label>
                        </td>
                        <td class="TableTitle" style="height: 27px">
                            <asp:TextBox ID="txtBranchName" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <table style="width: 1200px;">
                    <tr>
                        <td class="TableTitle" style="height: 27px">
                            <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Supplier Name</asp:Label>
                        </td>
                        <td class="TableTitle" style="height: 27px">
                            <asp:TextBox ID="txtSupplierName" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="TableTitle" style="height: 27px">
                            <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Payment Made</asp:Label>
                        </td>
                        <td class="TableTitle" style="height: 27px">
                            <asp:DropDownList ID="ddlPaymentMade" runat="server" Width="150px"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table style="width: 1200px;">
                    <tr>
                        <td class="TableTitle" style="height: 27px" colspan="8">
                            <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Remark</asp:Label>
                        </td>
                        <td class="TableTitle" style="height: 27px" colspan="8">
                            <asp:TextBox ID="txtRemark" runat="server" Width="515px" Height="69px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                </table>
            </asp:Panel>
            <table style="width: 1200px;">
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">Received Date</asp:Label>
                    </td>
                    <td class="auto-style7" colspan="8">
                        <asp:TextBox ID="txtReceivedDate" runat="server" ReadOnly="true" Font-Bold="True"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;" Font-Bold="true">User ID</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtUserID" runat="server" ReadOnly="true" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <table style="width: 1200px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4" >
                <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save And Continue"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSaveAndContinue_Click"/></td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnSaveAndExit" runat="server" Text="Save And Exit" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSaveAndExit_Click" /></td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000"
                    BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnBack_Click" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
