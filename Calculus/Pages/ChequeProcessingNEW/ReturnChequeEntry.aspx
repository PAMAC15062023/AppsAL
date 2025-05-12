<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnChequeEntry.aspx.cs" Inherits="Pages_ChequeProcessingNEW_ReturnChequeEntry" MasterPageFile="~/Pages/MasterPage.master" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function Validate_MemoDate() {
            //debugger;
            var txtMemodt = document.getElementById("<%=txtMemodt.ClientID%>");
        var lblvalue = document.getElementById("<%=lblvalue.ClientID%>");
        var hdnValue = document.getElementById("<%=hdnValue.ClientID%>");
        var txtMicrNo = document.getElementById("<%=txtMicrNo.ClientID%>");
        var txtMEMOdate = txtMemodt.value;
        var d = txtMEMOdate.split('/', txtMEMOdate.length);
        if (d.length > 0) {
            var ChequeDate = new Date(d[2], d[1] - 1, d[0]);
        }
        var month = "" + (ChequeDate.getMonth() + 1), day = "" + ChequeDate.getDate(), year = "" + (ChequeDate.getYear());

        if (month.length == 1) {
            month = "0" + month;
        }

        if (day.length == 1) {
            day = "0" + day;
        }
        var dd = [day, month, year];
        var newdate = dd.join('/');

        hdnValue.value = newdate;
        //        txtMicrNo.focus();
    }

    function Validate_Save() {
        alert("Record Saved Successfully....!!!");
    }

    function showDate(sender, args) {
        if (sender._textbox.get_element().value == "") {
            var todayDate = new Date();
            sender._selectedDate = todayDate;
        }
    }

    function pad(number, length) {
        var str = '' + number;
        while (str.length < length) {
            str = '0' + str;
        }
        return str;
    }

    //    function Validate_Client() {
    //        debugger;
    //        var ddlClientList = document.getElementById("<%=ddlClientList.ClientID%>");
        //        var txtMemodt = document.getElementById("<%=txtMemodt.ClientID%>");
        //        var selectedIndex = ddlClientList.selectedIndex;

        //        if (ddlClientList.selectedIndex == 0) {
        //            alert('Select Client..!!');
        //            ddlClientList.focus();
        //        }
        //        else {
        //            txtMemodt.focus();
        //        }
        //    }

        function Validate_ChequeAmt() {
            //debugger;

            var ErrorMessage = "";
            var txtChequeAmt = document.getElementById("<%=txtChqAmt.ClientID%>");
        var txtChqNo = document.getElementById("<%=txtChqNo.ClientID%>");
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var hdnChqAmt = document.getElementById("<%=hdnChqAmt.ClientID%>");
        //            alert(txtChequeAmt.value);
        // var num = parseFloat(txtChequeAmt).toFixed(2);
        var strChequeAmount = parseFloat(txtChequeAmt.value).toFixed(2);
        //            alert(strChequeAmount); 
        //var strChequeAmount = num.value;

        //            var strChequeAmount = txtChequeAmt.value;

        hdnChqAmt.value = strChequeAmount;

        var sText = '';
        if (strChequeAmount.length == 0) {
            //ErrorMessage="Cheque amount can not left blank!";
            alert("Cheque amount can not left blank!");
            //            hdnChequeStaus.value = '1';
            //            txtChequeAmt.focus();
        }
        else {
            sText = txtChequeAmt.value;
            var ValidChars = "0123456789.";
            var IsNumber = true;
            var Char;

            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }

            }
            if (IsNumber == false) {
                //ErrorMessage="Invalid Cheque Amount Entered!";
                alert("Invalid Cheque Amount Entered!");
                //                hdnChequeStaus.value = '1';
                //                txtChequeAmt.focus();
            }
            else {

            }
            txtChqNo.focus();

        }
    }

    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <table style="width: 100%">
        <tr>
            <td colspan="5" style="height: 17px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">Return/Bounce Entry</td>
        </tr>
        <tr>
            <td style="width: 4px; height: 26px;">&nbsp;</td>
            <td class="TableTitle" style="width: 15%; height: 26px;">
                <strong>Location</strong></td>
            <td style="width: 32%; height: 26px;" class="TableGrid">
                <asp:Label ID="lblLocation2" runat="server"></asp:Label>
            </td>
            <td style="width: 18%; height: 26px;" class="TableTitle">
                <strong>Client</strong></td>
            <td style="width: 98%; height: 26px;" class="TableGrid" align="left"
                valign="middle">
                <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="ddlClientList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 4px; height: 26px;"></td>
            <td class="TableTitle" style="width: 15%; height: 26px;">
                <strong>Return Date</strong></td>
            <td style="width: 32%; height: 26px;" class="TableGrid">
                <asp:TextBox ID="txtReturnDate" runat="server" CssClass="TEXTBOX"></asp:TextBox>
            </td>
            <td style="width: 18%; height: 26px;" class="TableTitle">
                <strong>Return Memo No.</strong></td>
            <td style="width: 98%; height: 26px;" class="TableGrid" align="left"
                valign="middle">
                <asp:Label ID="lblRetMemoNo" runat="server" SkinID="LabelSkin"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 15%" class="TableTitle">
                <strong>Memo Date</strong></td>
            <td style="width: 32%" class="TableGrid">
                <asp:TextBox ID="txtMemodt" runat="server" AutoPostBack="true"
                    CssClass="TEXTBOX"
                    onkeydown="javascript:if(event.keyCode==13) {event.keyCode=9;};"
                    OnTextChanged="txtMemodt_TextChanged" SkinID="txtskin"></asp:TextBox>
                <asp:CalendarExtender ID="txtMemodt_CalendarExtender" runat="server" Format="dd/MM/yyyy" OnClientShowing="showDate"
                    Enabled="True" TargetControlID="txtMemodt">
                </asp:CalendarExtender>
                <asp:Label ID="lblvalue" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="width: 18%" class="TableTitle">
                <strong>MICR No.</strong></td>
            <td style="width: 98%" class="TableGrid">
                <asp:TextBox ID="txtMicrNo" runat="server" AutoPostBack="true" MaxLength="9"
                    CssClass="TEXTBOX"
                    OnTextChanged="txtMicrNo_TextChanged" SkinID="txtskin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td class="TableTitle" style="width: 15%">
                <strong>Cheque Amount</strong></td>
            <td class="TableGrid" style="width: 32%">
                <asp:TextBox ID="txtChqAmt" runat="server" CssClass="TEXTBOX" SkinID="txtSkin"
                    OnTextChanged="txtChqAmt_TextChanged"></asp:TextBox>
            </td>
            <td style="width: 18%" class="TableTitle">
                <strong>Cheque No.</strong></td>
            <td style="width: 98%" class="TableGrid">
                <asp:TextBox ID="txtChqNo" runat="server" AutoPostBack="true" MaxLength="6"
                    CssClass="TEXTBOX"
                    onkeydown="javascript:if(event.keyCode==13) {event.keyCode=9;};"
                    OnTextChanged="txtChqNo_TextChanged" SkinID="txtskin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 15%" class="TableTitle">
                <strong>Bank</strong></td>
            <td style="width: 32%" class="TableGrid">
                <asp:Label ID="lblBank" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 18%" class="TableTitle">
                <strong>Branch</strong></td>
            <td style="width: 98%" class="TableGrid">
                <asp:Label ID="lblBranch" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 15%" class="TableTitle">
                <strong>Location</strong></td>
            <td style="width: 32%" class="TableGrid">
                <asp:Label ID="lblLocation" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 18%" class="TableTitle">
                <strong>Total Amount</strong></td>
            <td style="width: 98%" class="TableGrid">
                <asp:Label ID="lblTotalAmt" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 15%" class="TableTitle">
                <strong>Cheque Date</strong></td>
            <td style="width: 32%" class="TableGrid">
                <asp:Label ID="lblChqDate" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 18%" class="TableTitle">
                <strong>Card No.</strong></td>
            <td style="width: 98%" class="TableGrid">
                <asp:Label ID="lblCardNo" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 15%" class="TableTitle">
                <strong>Payment Mode</strong></td>
            <td style="width: 32%" class="TableGrid">
                <asp:Label ID="lblPayMode" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 18%" class="TableTitle">
                <strong>Account No.</strong></td>
            <td style="width: 98%" class="TableGrid">
                <asp:Label ID="lblAccNo" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 15%" class="TableTitle">
                <strong>Deposit No.</strong></td>
            <td style="width: 32%" class="TableGrid">
                <asp:Label ID="lblDepNo" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 18%" class="TableTitle">
                <strong>Deposit Date</strong></td>
            <td style="width: 98%" class="TableGrid">
                <asp:Label ID="lblDepDate" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 4px; height: 28px;"></td>
            <td style="width: 15%; height: 28px;" class="TableTitle" align="center">
                <strong>Remarks</strong></td>
            <td class="TableGrid" colspan="3" align="left" valign="middle"
                style="height: 28px">
                <asp:DropDownList ID="ddlReason" runat="server" CssClass="dropdown">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="TableTitle" colspan="5">
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click"
                    Text="Reset" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:HiddenField ID="hdnTransactionDetailID" runat="server" />
                <asp:HiddenField ID="hdnChqAmt" runat="server" />
                <asp:HiddenField ID="hdnBatchNo" runat="server" />
                <asp:HiddenField ID="hdnValue" runat="server" />
            </td>
        </tr>
    </table>


</asp:Content>
