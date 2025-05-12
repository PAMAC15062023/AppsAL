<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="OtherThanPettyCash.aspx.cs" Inherits="OtherThanPettyCash" Title="Other Than Petty Cash Request" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>
    <script language="javascript" type="text/javascript">

        function Validation_OnField() {

            var ReturnValue = true;
            var ErrorMessage = "";
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var txtPaymentReqDate = document.getElementById("<%=txtPaymentReqDate.ClientID%>");
            var ddlActivity = document.getElementById("<%=ddlActivity.ClientID%>");
            var ddlVerticalHead = document.getElementById("<%=ddlActivity.ClientID%>");
            var ddlProduct = document.getElementById("<%=ddlProduct.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");

            if (txtPaymentReqDate.value == "") {
                ErrorMessage = "Payment Request Date Can't left blank";
                ReturnValue = false;
            }
            if (ddlActivity.selectedIndex == 0) {
                ErrorMessage = "Plz Select Activity";
                ReturnValue = false;
            }
            if (ddlVerticalHead.selectedIndex == 0) {
                ErrorMessage = "Plz Select Vertical Head";
                ReturnValue = false;
            }
            if (ddlProduct.selectedIndex == 0) {
                ErrorMessage = "Plz Select Product";
                ReturnValue = false;
            }
            if (txtAmount.selectedIndex == 0) {
                ErrorMessage = "Plz Enter Payment Amount";
                ReturnValue = false;
            }
            if (txtRemark.selectedIndex == "") {
                ErrorMessage = "Plz Enter Remark for Payment";
                ReturnValue = false;
            }
            if (ReturnValue) {
                var lblWait = document.getElementById("<%=lblWait.ClientID%>");
                lblWait.innerText = "Please wait.....";
            }

            lblMessage.innerText = ErrorMessage;

            return ReturnValue;

        }
    </script>

    <script type="text/javascript">
        function validateDecimal(input) {
            // Allow only digits and at most one decimal point
            let value = input.value;

            // Replace invalid characters
            let validValue = value.replace(/[^0-9.]/g, '');

            // Only keep the first decimal point
            let parts = validValue.split('.');
            if (parts.length > 2) {
                validValue = parts[0] + '.' + parts.slice(1).join('');
            }

            // Update the input
            if (value !== validValue) {
                input.value = validValue;
            }
        }
    </script>

    <table style="width: 710px; height: 103px">
        <tr>
            <td colspan="1" style="width: 9px; height: 20px;"></td>
            <td colspan="11" style="width: 45px; height: 20px;">
                <asp:Label ID="lblMessage" runat="server" Width="697px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px"></td>
            <td class=" TableHeader" colspan="10">Payment Request For Other than Petty Cash</td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px; height: 2px;"></td>
            <td colspan="5" class="TableTitle" style="height: 2px; text-align: left;">&nbsp;<strong>TransactionID : </strong>
                <asp:Label ID="lblTransactionID" runat="server" Width="594px" Height="16px" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="" style="width: 9px; height: 1px"></td>
            <td colspan="" style="width: 194px; height: 1px" class="TableTitle">&nbsp;Cluster Name</td>
            <td style="width: 158px; height: 1px" class="TableGrid">
                <asp:Label ID="lblCluster" runat="server" Width="151px" SkinID="LabelSkin"></asp:Label></td>
            <td style="width: 172px; height: 1px" class="TableTitle">&nbsp;Branch Name</td>
            <td style="height: 1px" class="TableGrid">
                <asp:Label ID="lblBranch" runat="server" Width="169px" SkinID="LabelSkin"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px;"></td>
            <td colspan="" style="width: 194px;" class="TableTitle">&nbsp;Request Date</td>
            <td colspan="" style="width: 158px;" class="TableGrid">
                <asp:TextBox ID="txtPaymentReqDate" runat="server" Width="100px" SkinID="txtSkin"></asp:TextBox>
                <img id="Img1" alt="Calendar" src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px"
                    onclick="popUpCalendar(this, document.all.<%=txtPaymentReqDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
            <td colspan="" style="width: 172px;" class="TableTitle">&nbsp;Vertical Head
            </td>
            <td colspan="" style="width: 4px;" class="TableGrid">
                <asp:DropDownList ID="ddlVerticalHead" runat="server" SkinID="ddlSkin" AutoPostBack="True" OnSelectedIndexChanged="ddlVerticalHead_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px; height: 13px"></td>
            <td colspan="" style="width: 194px; height: 13px" class="TableTitle">&nbsp;Product</td>
            <td colspan="1" style="width: 158px; height: 13px" class="TableGrid">
                <asp:DropDownList ID="ddlProduct" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td colspan="1" style="width: 172px; height: 13px" class="TableTitle">&nbsp;Activity</td>
            <td colspan="1" style="width: 14px; height: 13px" class="TableGrid">
                <asp:DropDownList ID="ddlActivity" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px;"></td>
            <td class="TableTitle" colspan="1" style="width: 194px;">&nbsp;Amount</td>
            <td class="TableGrid" colspan="1" style="width: 158px;">
                <asp:TextBox ID="txtAmount" runat="server" Width="100px" SkinID="txtSkin" oninput="validateDecimal(this)"></asp:TextBox></td>
            <td class="TableTitle" colspan="1" style="width: 172px;"></td>
            <td class="TableGrid" colspan="1" style="width: 14px;">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px; height: 14px"></td>
            <td colspan="1" style="width: 194px; height: 14px" class="TableTitle">&nbsp;Remark</td>
            <td colspan="10" style="width: 45px; height: 14px" class="TableGrid">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="490px" Height="31px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="12" style="height: 35px">&nbsp;
                <asp:Button ID="btnSaveRecord" runat="server" OnClick="btnSaveRecord_Click"
                    Text="Save" BorderWidth="1px" />&nbsp;
                <asp:Button ID="btnAddNew" runat="server" OnClick="btnAddNew_Click" Text="AddNew" BorderWidth="1px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px; height: 13px"></td>
            <td colspan="10" style="width: 45px; height: 13px" class="TableTitle">&nbsp;<asp:Label ID="lblWait" runat="server" Width="523px"></asp:Label></td>
        </tr>
    </table>
    <br />
    <asp:HiddenField ID="hdnTransactionID" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

