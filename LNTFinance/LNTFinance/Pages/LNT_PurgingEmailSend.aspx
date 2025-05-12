<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/LNT_CommonMaster.Master" CodeBehind="LNT_PurgingEmailSend.aspx.cs" Inherits="LNTFinance.LNT_PurgingEmailSend" %>

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
    <style>
        .TableTitle {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            border-right: #660000 1px solid;
            border-top: #660000 1px solid;
            border-left: #660000 1px solid;
            border-bottom: #660000 1px solid;
            white-space: no-wrap;
            border-color: #808080;
        }
    </style>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">&nbsp;&nbsp;&nbsp;Purging&nbsp;Email&nbsp;Send</span>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
     <table>
                <tr>
                    <td class="TableTitle" style="height: 27px; width: 158px;">
                        <asp:Label runat="server" Width="158px" Font-Size="10" Height="20" Style="text-align: center;">Purging Status</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px;width: 177px;">
                        <asp:DropDownList ID="ddlPurgingStatus" runat="server" Width="158px">
                            <asp:ListItem Text="--Select--" Value="select"></asp:ListItem>
                         <asp:ListItem Text="Success" Value="Success"></asp:ListItem>
                            <asp:ListItem Text="Failed" Value="Failed"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
         </table>
     <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                <asp:Button ID="btnOk" runat="server" Text="Send"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" Onclick="btnOk_Click"/>&nbsp;
                   
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000"
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnBack_Click" />&nbsp;
            </td>
        </tr>
    </table>
  
    </asp:Content>
