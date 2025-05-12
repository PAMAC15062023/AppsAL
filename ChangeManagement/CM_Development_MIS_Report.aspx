<%@ Page Language="C#" MasterPageFile="~/CM.master" AutoEventWireup="true" CodeBehind="CM_Development_MIS_Report.aspx.cs" Inherits="ChangeManagement.CM_Development_MIS_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript" src="App_Assets/js/popcalendar.js"></script>

    <script language="javascript" type="text/javascript">
        function DisableDelete(e) {
            var code;
            if (!e) var e = window.event; // some browsers don't pass e, so get it from the window
            if (e.keyCode) code = e.keyCode; // some browsers use e.keyCode
            else if (e.which) code = e.which;  // others use e.which

            if (code == 8 || code == 46)
                return false;
        }
        function disallowDelete(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            alert(charCode);
            // return true;

        };

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  MIS Report &nbsp;</span>
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
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            
                <asp:Button ID="btnExport" runat="server" Text="Export" BorderColor="#400000" Visible="false"
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnExport_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" Width="105px" OnClick="btnBack_Click" />&nbsp;&nbsp;
                    
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 688px;">
        <tr>
            <%--  <td class="TableHeader" colspan="9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data
            </td>--%>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:GridView ID="gvData" runat="server" Height="16px" Width="1200px" CssClass="mGrid">
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />

</asp:Content>


