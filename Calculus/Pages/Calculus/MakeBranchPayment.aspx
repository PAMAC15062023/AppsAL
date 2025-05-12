<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="MakeBranchPayment.aspx.cs" Inherits="Pages_Calculus_MakeBranchPayment"
    Title="Make Payment " StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>

    <script language="javascript" type="text/javascript">

        function Validate_ddlTDSPercentage() {

            var Enabled = true;
            var ddlTDSPercentage = document.getElementById("ddlTDSPercentage");
            var txtTDSPercentage = document.getElementById("<%=txtTDSPercentage.ClientID%>");
            var selectedIndex = ddlTDSPercentage.selectedIndex;
            if (ddlTDSPercentage.options[selectedIndex].innerText == 'Other') {


                txtTDSPercentage.value = "";
                Enabled = false;
                Validate_TDSPercentage(txtTDSPercentage.value);
            }
            else {

                txtTDSPercentage.value = "0.00";
                Validate_TDSPercentage(ddlTDSPercentage.value);
            }

            txtTDSPercentage.disabled = Enabled;



        }

        function Validate_NatureofPayment() {

            var ddlNatureofPayment = document.getElementById("<%=ddlNatureofPayment.ClientID%>");
            var selectedIndex = ddlNatureofPayment.selectedIndex;

            var ddlRecipientType = document.getElementById("<%=ddlRecipientType.ClientID%>");

            var ddlTDSPercentage = document.getElementById("ddlTDSPercentage");
            var txtTDSPercentage = document.getElementById("<%=txtTDSPercentage.ClientID%>");

            var EnableValue = false;


            if (ddlNatureofPayment.options[selectedIndex].innerText == "NA") {

                EnableValue = true;
                ddlRecipientType.selectedIndex = 0;
                ddlTDSPercentage.selectedIndex = 0;
                txtTDSPercentage.value = 0.00;
                Validate_TDSPercentage(txtTDSPercentage.value);
            }
            else {

                EnableValue = false;
                ddlRecipientType.selectIndex = 0;
                ddlTDSPercentage.selectedIndex = 0;
                txtTDSPercentage.value = 0.00;
                Validate_TDSPercentage(ddlTDSPercentage.value);
            }

            ddlRecipientType.disabled = EnableValue;
            ddlTDSPercentage.disabled = EnableValue;
            txtTDSPercentage.disabled = true;


        }

        function Validate_RecipientType() {

            var ddlRecipientType = document.getElementById("<%=ddlRecipientType.ClientID%>");
            var ddlTDSPercentage = document.getElementById("ddlTDSPercentage");
            var i = 0;



            for (i = ddlTDSPercentage.options.length; i >= 0; i--) {

                ddlTDSPercentage.options.remove(i);
            }

            var optSelect = document.createElement("option");
            optSelect.text = "--Select--";
            optSelect.value = '0.00';
            ddlTDSPercentage.options.add(optSelect);


            //Added By Omkar 15062020 Start
            var opt4 = document.createElement("option");
            opt4.text = "7.50 %";
            opt4.value = 7.50;
            ddlTDSPercentage.options.add(opt4);

            var opt5 = document.createElement("option");
            opt5.text = "1.50 %";
            opt5.value = 1.50;
            ddlTDSPercentage.options.add(opt5);

            var opt6 = document.createElement("option");
            opt6.text = "0.75 %";
            opt6.value = 0.75;
            ddlTDSPercentage.options.add(opt6);

            var opt7 = document.createElement("option");
            opt7.text = "3.75 %";
            opt7.value = 3.75;
            ddlTDSPercentage.options.add(opt7);
            //Added By Omkar 15062020 End


            if (ddlRecipientType.selectedIndex != 0) {
                var opt1 = document.createElement("option");
                opt1.text = "10.00 %";
                opt1.value = 10.00;
                ddlTDSPercentage.options.add(opt1);

                if (ddlRecipientType.selectedIndex == 1) {

                    var opt2 = document.createElement("option");
                    opt2.text = "2.00 %";
                    opt2.value = 2.00;
                    ddlTDSPercentage.options.add(opt2);
                }
                else if (ddlRecipientType.selectedIndex == 2) {

                    var opt3 = document.createElement("option");
                    opt3.text = "1.00 %";
                    opt3.value = 1.00;
                    ddlTDSPercentage.options.add(opt3);
                }

                var optOther = document.createElement("option");
                optOther.text = "Other";
                optOther.value = "0.00";
                ddlTDSPercentage.options.add(optOther);

            }


        }

        function switchViews(obj, row) {

            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            if (div.style.display == "none") {
                div.style.display = "inline";
                if (row == 'alt') {
                    img.src = "Images/minus.png";
                    mce_src = "Images/minus.png";
                }
                else {
                    img.src = "Images/minus.png";
                    mce_src = "Images/minus.png";
                }
                img.alt = "Close to view other customers";
            }
            else {
                div.style.display = "none";
                if (row == 'alt') {

                    img.src = "Images/plus.png";
                    mce_src = "Images/plus.png";
                }
                else {
                    img.src = "Images/plus.png";
                    mce_src = "Images/plus.png";

                }
                img.alt = "Expand to show Transactions";
            }
        }

        function openwindow() {
            window.open('OpeningBalanceBranchwise.aspx', '_blank', 'height=350,width=700,status=yes,resizable=yes');
        }

        function Backin_History() {

            return true;
        }

        function Validate_TDSPercentage(taxPercentage) {

            var ReturnValue = true;
            var txtTDSPercentage = document.getElementById("<%=txtTDSPercentage.ClientID%>");
            if ((taxPercentage == null) || (taxPercentage == '')) {
                taxPercentage = txtTDSPercentage.value;
            }
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var txtPaymentAmount = document.getElementById("<%=txtPaymentAmount.ClientID%>");
            var lblBillAmount = document.getElementById("<%=lblBillAmount.ClientID%>");
            var txtTDSAmount = document.getElementById("<%=txtTDSAmount.ClientID%>");
            var txtFinalPaymentAmount = document.getElementById("<%=txtFinalPaymentAmount.ClientID%>");

            var ErrorMessage = "";
            var finalAmount = 0;

            if (taxPercentage == '') {

                ErrorMessage = 'Please enter tds Percentage to continue...';
                ReturnValue = false;
            }
            else {


                var ValidChars = "0123456789.";
                var IsNumber = true;
                var Char;

                var sText = taxPercentage;

                for (i = 0; i < sText.length && IsNumber == true; i++) {

                    Char = sText.charAt(i);

                    if (ValidChars.indexOf(Char) == -1) {
                        IsNumber = false;
                        ReturnValue = false;
                    }
                }

                if (IsNumber == false) {

                    ErrorMessage = 'Please enter only numeric characters to continue!';
                    ReturnValue = false;
                }
            }
            txtTDSAmount.value = ((parseInt(lblBillAmount.value) / 100) * (taxPercentage));
            txtFinalPaymentAmount.value = parseInt(txtPaymentAmount.value) - (txtTDSAmount.value);

            if (ErrorMessage != "") {
                lblMessage.innerText = ErrorMessage;
            }
            return ReturnValue;
        }

        function Validate_BankDetails() {

            var ddlBankList = document.getElementById("<%=ddlBankList.ClientID%>");
            var ddlBankBranchList = document.getElementById("ddlBankBranchList");
            var hdnBankBranchDetails = document.getElementById("<%=hdnBankBranchDetails.ClientID%>");


            var i = 0;

            for (i = ddlBankBranchList.options.length; i >= 0; i--) {

                ddlBankBranchList.options.remove(i);
            }

            var optSelect = document.createElement("option");
            optSelect.text = "--Select--";
            optSelect.value = '0';
            ddlBankBranchList.options.add(optSelect);


            var strhdvValue = hdnBankBranchDetails.value;
            var strOutPut = "";
            var strRowDetails = "";
            var strColDetails = "";

            strRowDetails = strhdvValue.split('^', strhdvValue.length);
            var i = 0;
            var j = 0;
            var strRowlength = 0;

            for (i = 0; i <= strRowDetails.length - 1; i++) {


                strColDetails = strRowDetails[i];
                strColDetails = strColDetails.split('*', strColDetails.length);

                if (strColDetails[2] == ddlBankList.value) {
                    var optNew = new Object();

                    optNew = document.createElement("option");
                    optNew.text = strColDetails[0];
                    optNew.value = strColDetails[1];
                    ddlBankBranchList.options.add(optNew);
                }
            }

        }

        function Validate_BankBranchList() {

            var ddlBankBranchList = document.getElementById("ddlBankBranchList");
            var txtAccountNo = document.getElementById("<%=txtAccountNo.ClientID%>");
            var txtAccountHolderName = document.getElementById("<%=txtAccountHolderName.ClientID%>");

            var Index = ddlBankBranchList.selectedIndex;

            if (ddlBankBranchList.selectedIndex != 0) {
                var valueAssign = ddlBankBranchList.value;
                var strRowDetails = "";
                strRowDetails = valueAssign.split('|', valueAssign.length);

                txtAccountNo.value = strRowDetails[2];
                txtAccountHolderName.value = strRowDetails[1];
            }
            else {
                txtAccountNo.value = "";
                txtAccountHolderName.value = "";
            }

        }



        //  -----------------------------------------------------------------------------------
        function Validate_PaymentMode() {

            ////debugger

            //alert("Validate_PaymentMode");
            var ddlIsChequePrint = document.getElementById("<%=ddlIsChequePrint.ClientID%>");
            var ddlPaymentType = document.getElementById("<%=ddlPaymentType.ClientID%>");
            var ddlIsBearer = document.getElementById("<%=ddlIsBearer.ClientID%>");
            //kanchan
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");

            if (ddlPaymentType.selectedIndex == 2) {

                ddlIsChequePrint.selectedIndex = 2;
                ddlIsChequePrint.disabled = true;
                ddlIsBearer.disabled = true;
                ddlIsBearer.selectedIndex = 2;

            }
            //kanchan

            else if (ddlPaymentType.selectedIndex == 3) {

                ddlIsChequePrint.selectedIndex = 2;
                ddlIsChequePrint.disabled = true;
                ddlIsBearer.disabled = true;
                ddlIsBearer.selectedIndex = 2;

                txtChequeNo.disabled = true;
                txtChequeDate.disabled = true;


            }

            else {
                ddlIsBearer.disabled = false;
                ddlIsChequePrint.disabled = false;
                Validate_ChequePrint();

            }




        }

        function Validate_ChequePrint() {



            var ddlIsChequePrint = document.getElementById("<%=ddlIsChequePrint.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var Img2 = document.getElementById("Img2");


            if (ddlIsChequePrint.selectedIndex == 1) {
                txtChequeNo.value = "000000";
                txtChequeNo.disabled = true;
                txtChequeDate.value = "01/01/1900";
                txtChequeDate.disabled = true;
                Img2.disabled = true;
            }
            else {
                //txtChequeNo.value="";            
                txtChequeNo.disabled = false;

                txtChequeDate.value = "";
                txtChequeDate.disabled = false;
                Img2.disabled = false;
            }

        }
        function ValidateSave() {
            var hdnIssuePaymentDetails = document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");
            var hdnPaymentID = document.getElementById("<%=hdnPaymentID.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var ReturnValue = true;
            var ErrorMessage = "";
            if (hdnIssuePaymentDetails.value == '') {
                ErrorMessage = 'No Record found for save!';
                ReturnValue = false;
            }

            lblMessage.innerText = ErrorMessage;
            window.scroll(0, 0);
            return ReturnValue;
        }

        function SelectAll() {

            var MainTab = document.getElementById("MainTab");
            var chkSelectAll = document.getElementById("chkSelectAll");
            var i = 0;

            for (i = 0; i <= MainTab.rows.length - 1; i++) {
                var row = MainTab.rows[i];
                var chkObj = row.cells[0].childNodes[0];

                if (chkObj != null) {
                    chkObj.checked = chkSelectAll.checked;
                }
            }
            //chkSelectAll.checked=false;
        }


        function TotalReqAmountCalculation() {
            var lblTotalPaymentAmount = document.getElementById("<%=lblTotalPaymentAmount.ClientID%>");
            var hdnSavingPaymentDetails = document.getElementById("<%=hdnSavingPaymentDetails.ClientID%>");
            var MainTab = document.getElementById("MainTab");
            var i = 0;
            var TotalAmt = 0;

            for (i = 0; i <= MainTab.rows.length - 1; i++) {
                if (i != 0) {
                    TotalAmt = TotalAmt + parseFloat(MainTab.rows[i].cells[14].innerText);
                }
            }

            lblTotalPaymentAmount.innerText = TotalAmt;
            hdnSavingPaymentDetails.value = TotalAmt;
        }



        function Page_load_validation() {

            var hdnIssuePaymentDetails = document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");
            RenderTable(hdnIssuePaymentDetails.value);
            AssignValues();
            Validate_PaymentMode();
            Validate_NatureofPayment();
        }

        function ClearGrid() {
            var ddlPaymentRequestList = document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
            ddlPaymentRequestList.selectedIndex = 0;
            AssignValues();

        }
        function RemoveColumnFromGrid() {
            var hdnChequeDetails = document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");
            var MainTab = document.getElementById("MainTab");
            var i = 0;
            var strhdvValue = "";

            for (i = MainTab.rows.length - 1; i > 0; i--) {

                var row = MainTab.rows[i];
                var chkObj = row.cells[0].childNodes[0];

                if (chkObj != null) {
                    if (chkObj.checked == true) {

                        MainTab.deleteRow(i);
                    }

                }
            }
            hdnChequeDetails.value = "";
            for (i = 0; i <= MainTab.rows.length - 1; i++) {

                if (i == 0) {
                }
                else {
                    hdnChequeDetails.value = "";
                    strhdvValue = strhdvValue + MainTab.rows[i].cells[1].innerText + "|" + MainTab.rows[i].cells[2].innerText + "|" + MainTab.rows[i].cells[3].innerText + "|" + MainTab.rows[i].cells[4].innerText + "|" + MainTab.rows[i].cells[5].innerText + "|" + MainTab.rows[i].cells[6].innerText + "|" + MainTab.rows[i].cells[7].innerText + "|" + MainTab.rows[i].cells[8].innerText + "|" + MainTab.rows[i].cells[9].innerText + "|" + MainTab.rows[i].cells[10].innerText + "|" + MainTab.rows[i].cells[11].innerText + "|" + MainTab.rows[i].cells[12].innerText + "|" + MainTab.rows[i].cells[13].innerText + "|" + MainTab.rows[i].cells[14].innerText + "|" + MainTab.rows[i].cells[15].innerText + "|" + MainTab.rows[i].cells[16].innerText + "|" + MainTab.rows[i].cells[17].innerText + "|" + MainTab.rows[i].cells[18].innerText + "|" + MainTab.rows[i].cells[19].innerText + "|" + MainTab.rows[i].cells[20].innerText + "|" + MainTab.rows[i].cells[21].innerText + "|" + MainTab.rows[i].cells[22].innerText + "|" + MainTab.rows[i].cells[23].innerText + "|" + MainTab.rows[i].cells[24].innerText + "|" + MainTab.rows[i].cells[25].innerText + "|" + MainTab.rows[i].cells[26].innerText + "|" + MainTab.rows[i].cells[27].innerText + "|" + MainTab.rows[i].cells[28].innerText + "^";
                    hdnChequeDetails.value = strhdvValue;
                }
            }


            RenderTable(strhdvValue);
            return false;

        }


        function RenderTable(strhdvValue) {

            var MainTab = document.getElementById("MainTab");
            var Totalrows = MainTab.rows.length;
            for (i = MainTab.rows.length - 1; i > 0; i--) {
                MainTab.deleteRow(i);
            }

            var strOutPut = "";
            var strRowDetails = "";
            var strColDetails = "";

            strRowDetails = strhdvValue.split('^', strhdvValue.length);
            var i = 0;
            var j = 0;
            var strRowlength = 0;

            for (i = 0; i <= strRowDetails.length - 2; i++) {
                var rowCount = MainTab.rows.length;

                rowCount = rowCount;
                var row = document.getElementById('MainTab').insertRow(rowCount);

                strColDetails = strRowDetails[i];
                strColDetails = strColDetails.split('|', strColDetails.length);

                var ColChkObj = row.insertCell(0);
                ColChkObj.innerHTML = "<input id='Chk_" + rowCount + "' type='checkbox' />";

                for (j = 0; j <= strColDetails.length - 1; j++) {

                    ColChkObj = row.insertCell(j + 1);
                    ColChkObj.innerHTML = strColDetails[j];
                    if (j >= 21) {
                        ColChkObj.style.display = "none";
                    }
                }
            }
            TotalReqAmountCalculation();
            Hide_SelectedDropDownField();
        }

        function AddColumnToGrid() {

            debugger
            if (ValidateAddPayment()) {
                var ddlPaymentRequestList = document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
                var hdnIssuePaymentDetails = document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");

                var ddlPaymentType = document.getElementById("<%=ddlPaymentType.ClientID%>");
                var txtPaymentAmount = document.getElementById("<%=txtPaymentAmount.ClientID%>");
                var txtChequeIssueTo = document.getElementById("<%=txtChequeIssueTo.ClientID%>");
                var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
                var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
                var txtAccountHolderName = document.getElementById("<%=txtAccountHolderName.ClientID%>");
                var txtAccountNo = document.getElementById("<%=txtAccountNo.ClientID%>");

                var ddlBankList = document.getElementById("<%=ddlBankList.ClientID%>");
                var ddlBankBranchList = document.getElementById("ddlBankBranchList");
                var ddlIsChequePrint = document.getElementById("<%=ddlIsChequePrint.ClientID%>");
                var ddlIsBearer = document.getElementById("<%=ddlIsBearer.ClientID%>");
                var txtTDSPercentage = document.getElementById("<%=txtTDSPercentage.ClientID%>");
                var txtTDSAmount = document.getElementById("<%=txtTDSAmount.ClientID%>");
                var txtFinalPaymentAmount = document.getElementById("<%=txtFinalPaymentAmount.ClientID%>");

                var ddlNatureofPayment = document.getElementById("<%=ddlNatureofPayment.ClientID%>");
                var ddlRecipientType = document.getElementById("<%=ddlRecipientType.ClientID%>");
                var ddlTDSPercentage = document.getElementById("ddlTDSPercentage");



                var valueBankBranchID = ddlBankBranchList.value;
                var strRowBankBranchID = "";
                strRowBankBranchID = valueBankBranchID.split('|', valueBankBranchID.length);

                var valueAssign = ddlPaymentRequestList.value;
                var strRowDetails = "";
                strRowDetails = valueAssign.split('|', valueAssign.length);

                var selectedPaymentType = parseInt(ddlPaymentType.selectedIndex);
                var selectedTransactionID = parseInt(ddlPaymentRequestList.selectedIndex);
                var selectedBankList = parseInt(ddlBankList.selectedIndex);
                var selectedBankBranchList = parseInt(ddlBankBranchList.selectedIndex);
                var selectedTDSPercentage = parseInt(ddlTDSPercentage.selectedIndex);


                var TdsPercentage = 0.00;
                if (ddlTDSPercentage.selectedIndex != 0) {
                    if (ddlTDSPercentage.options[selectedTDSPercentage].innerText == 'Other') {

                        TdsPercentage = parseFloat(txtTDSPercentage.value);
                    }
                    else {

                        TdsPercentage = parseFloat(ddlTDSPercentage.value);
                    }
                }

                // Validate_TDSPercentage(TdsPercentage);                                     

                var strhdvValue = "";
                strhdvValue = hdnIssuePaymentDetails.value;
                strhdvValue = strhdvValue + ddlPaymentRequestList.options[selectedTransactionID].innerText + "|" + strRowDetails[1] + "|" + strRowDetails[2] + "|" + strRowDetails[3] + "|" + strRowDetails[4] + "|" + strRowDetails[5] + "|" + strRowDetails[6] + "|" + strRowDetails[7] + "|" + ddlPaymentType.options[selectedPaymentType].innerText + "|" + ddlNatureofPayment.value + "|" + ddlRecipientType.value + "|" + parseFloat(TdsPercentage) + "|" + parseFloat(txtTDSAmount.value) + "|" + txtFinalPaymentAmount.value + "|" + txtChequeIssueTo.value + "|" + txtChequeNo.value + "|" + txtChequeDate.value + "|" + txtAccountHolderName.value + "|" + txtAccountNo.value + "|" + ddlBankList.options[selectedBankList].innerText + "|" + ddlBankBranchList.options[selectedBankBranchList].innerText + "|" + strRowDetails[0] + "|" + ddlPaymentType.value + "|" + ddlIsChequePrint.value + "|" + ddlIsBearer.value + "|1|" + ddlBankList.value + "|" + strRowBankBranchID[0] + "^";
                RenderTable(strhdvValue);
                hdnIssuePaymentDetails.value = strhdvValue;
                ClearGrid();
                Get_Count_TransactionDetailsToAdd();

            }

            return false;
        }

        function Hide_SelectedDropDownField() {

            var ddlPaymentRequestList = document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
            var MainTab = document.getElementById("MainTab");
            var i = 0;
            var j = 0;

            for (j = 0; j <= ddlPaymentRequestList.options.length - 1; j++) {

                for (i = 0; i <= MainTab.rows.length - 1; i++) {

                    if (MainTab.rows[i].cells[1].innerText == ddlPaymentRequestList.options[j].innerText) {

                        ddlPaymentRequestList.options[j].style.backgroundColor = "yellow";
                        break;
                    }

                }
            }

        }

        function Get_Count_TransactionDetailsToAdd() {
            var MainTab = document.getElementById("MainTab");
            var ddlPaymentRequestList = document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
            if (MainTab.rows.length < ddlPaymentRequestList.options.length) {
                ddlPaymentRequestList.focus();

            }


        }

        //seARCH KANCHAN

        function ValidateAddPayment() {

            var MainTab = document.getElementById("MainTab");
            var ddlPaymentRequestList = document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var txtPaymentAmount = document.getElementById("<%=txtPaymentAmount.ClientID%>");
            var txtChequeIssueTo = document.getElementById("<%=txtChequeIssueTo.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var txtAccountHolderName = document.getElementById("<%=txtAccountHolderName.ClientID%>");
            var txtAccountNo = document.getElementById("<%=txtAccountNo.ClientID%>");
            var ddlPaymentType = document.getElementById("<%=ddlPaymentType.ClientID%>");
            var lblTotalBillAmt = document.getElementById("<%=lblTotalBillAmt.ClientID%>");
            var ddlIsChequePrint = document.getElementById("<%=ddlIsChequePrint.ClientID%>");
            var ddlIsBearer = document.getElementById("<%=ddlIsBearer.ClientID%>");
            var txtTDSPercentage = document.getElementById("<%=txtTDSPercentage.ClientID%>");
            var txtTDSAmount = document.getElementById("<%=txtTDSAmount.ClientID%>");
            var ddlBankList = document.getElementById("<%=ddlBankList.ClientID%>");
            var ddlBankBranchList = document.getElementById("ddlBankBranchList");
            var txtFinalPaymentAmount = document.getElementById("<%=txtFinalPaymentAmount.ClientID%>");

            var ddlNatureofPayment = document.getElementById("<%=ddlNatureofPayment.ClientID%>");
            var ddlRecipientType = document.getElementById("<%=ddlRecipientType.ClientID%>");
            var ddlTDSPercentage = document.getElementById("ddlTDSPercentage");


            var ReturnValue = true;
            var ErrorMessage = "";

            if (ddlPaymentRequestList.selectedIndex == 0) {
                ErrorMessage = 'Please Select Payment Request to continue!';
                ddlPaymentRequestList.focus();
                ReturnValue = false;
            }
            if (ddlPaymentRequestList.selectedIndex != 0) {
                var SelectedIndex_PaymentRequestList = parseInt(ddlPaymentRequestList.selectedIndex);
                for (i = 0; i <= MainTab.rows.length - 1; i++) {
                    //////debugger;
                    var Value = ddlPaymentRequestList.options[SelectedIndex_PaymentRequestList].innerText;
                    if (MainTab.rows[i].cells[1].innerText == Value) {
                        ErrorMessage = 'Entry already Added!';
                        ddlPaymentRequestList.focus();
                        ReturnValue = false;
                    }
                }
            }

            if (ddlPaymentType.selectedIndex == 0) {
                ErrorMessage = 'Please Select Payment Type to continue!';
                ddlPaymentType.focus();
                ReturnValue = false;
            }

            if (ddlPaymentType.value == 1) {
                if (ddlIsChequePrint.selectedIndex == 2) {
                    var strChequeNo = txtChequeNo.value;
                    if (strChequeNo.length < 6) {
                        ErrorMessage = 'Please enter Cheque No to continue!';
                        txtChequeNo.focus();
                        ReturnValue = false;
                    }
                    if (strChequeNo == '000000') {
                        ErrorMessage = 'Please enter Valid Cheque No to continue!';
                        txtChequeNo.focus();
                        ReturnValue = false;
                    }

                }
                if (txtChequeNo.value == '') {
                    ErrorMessage = 'Please enter Cheque No to continue!';
                    txtChequeNo.focus();
                    ReturnValue = false;
                }
                else if (txtChequeDate.value == '') {
                    ErrorMessage = 'Please enter Cheque Date to continue!';
                    txtChequeDate.focus();
                    ReturnValue = false;
                }
                else if (txtChequeIssueTo.value == '') {
                    ErrorMessage = 'Please enter Cheque Issue Details to continue!';
                    txtChequeIssueTo.focus();
                    ReturnValue = false;
                }
            }

            else if (ddlPaymentType.value == 2) {
                if (txtAccountHolderName.value == '') {
                    ErrorMessage = 'Please enter Account Holder Name to continue!';
                    txtAccountHolderName.focus();
                    ReturnValue = false;
                }
                else if (txtAccountNo.value == '') {
                    ErrorMessage = 'Please enter AccountNo to continue!';
                    txtAccountNo.focus();
                    ReturnValue = false;
                }
            }

            if (txtPaymentAmount.value == '') {
                ErrorMessage = 'Please enter Payment Amount to continue!';
                txtPaymentAmount.focus();
                ReturnValue = false;
            }
            if (txtPaymentAmount.value == '0.00') {

                ErrorMessage = 'Please enter Payment Amount to continue!';
                txtPaymentAmount.focus();
                ReturnValue = false;
            }
            if (txtPaymentAmount.value == '0') {

                ErrorMessage = 'Please enter Payment Amount to continue!';
                txtPaymentAmount.focus();
                ReturnValue = false;
            }

            if (parseFloat(txtPaymentAmount.value) > parseFloat(lblTotalBillAmt.innerText)) {
                ErrorMessage = 'You cannot Enter cheque amount more than actual bill amount!';
                txtPaymentAmount.focus();
                ReturnValue = false;
            }
            if (ddlIsBearer.selectedIndex == 0) {
                ErrorMessage = 'Please Select Cross Cheque Details to continue!';
                ddlIsBearer.focus();
                ReturnValue = false;
            }

            if (txtTDSPercentage.value == '') {

                ErrorMessage = 'Please enter TDS Percentage to continue!';
                txtTDSPercentage.focus();
                ReturnValue = false;
            }
            if (txtTDSAmount.value == '') {

                ErrorMessage = 'Please enter TDS Percentage to continue!';
                txtTDSAmount.focus();
                ReturnValue = false;
            }

            if ((txtFinalPaymentAmount.value == '') || (txtFinalPaymentAmount.value == 0)) {

                ErrorMessage = 'Please Payment Amount to continue!';
                txtFinalPaymentAmount.focus();
                ReturnValue = false;
            }

            if (ddlBankList.selectedIndex == 0) {

                ErrorMessage = 'Please select Bank to continue!';
                ddlBankList.focus();
                ReturnValue = false;
            }

            if (ddlBankBranchList.selectedIndex == 0) {

                ErrorMessage = 'Please select Bank Branch to continue!';
                ddlBankList.focus();
                ReturnValue = false;
            }

            if (ddlNatureofPayment.selectedIndex == 0) {

                ErrorMessage = 'Please select Nature of Payment!';
                ddlNatureofPayment.focus();
                ReturnValue = false;
            }

            if (ddlNatureofPayment.selectedIndex == 1) {
            }
            else {
                if (ddlTDSPercentage.selectedIndex == 0) {

                    ErrorMessage = 'Please select TDS Percentage!';
                    ddlTDSPercentage.focus();
                    ReturnValue = false;
                }

                if (ddlRecipientType.selectedIndex == 0) {

                    ErrorMessage = 'Please select Recipient Type!';
                    ddlRecipientType.focus();
                    ReturnValue = false;
                }



            }

            lblMessage.innerText = ErrorMessage;
            window.scroll(0, 0);
            return ReturnValue;

        }
        function AssignValues() {

            debugger ///---------

            var ddlPaymentRequestList = document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
            var lblPayeeName = document.getElementById("<%=lblPayeeName.ClientID%>");
            var lblBillNo = document.getElementById("<%=lblBillNo.ClientID%>");
            var lblBillDate = document.getElementById("<%=lblBillDate.ClientID%>");
            var lblBillAmount = document.getElementById("<%=lblBillAmount.ClientID%>");

            var lblServiceTaxPercent = document.getElementById("<%=lblServiceTaxPercent.ClientID%>");
            var lblServiceTaxAmt = document.getElementById("<%=lblServiceTaxAmt.ClientID%>");
            var lblTotalBillAmt = document.getElementById("<%=lblTotalBillAmt.ClientID%>");

            var ddlPaymentType = document.getElementById("<%=ddlPaymentType.ClientID%>");
            var txtPaymentAmount = document.getElementById("<%=txtPaymentAmount.ClientID%>");
            var txtChequeIssueTo = document.getElementById("<%=txtChequeIssueTo.ClientID%>");

            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var txtAccountHolderName = document.getElementById("<%=txtAccountHolderName.ClientID%>");
            var txtAccountNo = document.getElementById("<%=txtAccountNo.ClientID%>");
            var ddlBankList = document.getElementById("<%=ddlBankList.ClientID%>");
            var ddlBankBranchList = document.getElementById("ddlBankBranchList");
            var ddlIsChequePrint = document.getElementById("<%=ddlIsChequePrint.ClientID%>");
            var ddlIsBearer = document.getElementById("<%=ddlIsBearer.ClientID%>");
            var txtTDSAmount = document.getElementById("<%=txtTDSAmount.ClientID%>");
            var txtTDSPercentage = document.getElementById("<%=txtTDSPercentage.ClientID%>");
            var txtFinalPaymentAmount = document.getElementById("<%=txtFinalPaymentAmount.ClientID%>");

            var ddlNatureofPayment = document.getElementById("<%=ddlNatureofPayment.ClientID%>");
            var ddlRecipientType = document.getElementById("<%=ddlRecipientType.ClientID%>");
            var ddlTDSPercentage = document.getElementById("ddlTDSPercentage");

            var lblNaration = document.getElementById("<%=lblNaration.ClientID%>");
            var lblAccountLedger = document.getElementById("<%=lblAccountLedger.ClientID%>");


            if (ddlPaymentRequestList.selectedIndex != 0) {
                var valueAssign = ddlPaymentRequestList.value;
                var strRowDetails = "";
                strRowDetails = valueAssign.split('|', valueAssign.length);

                lblPayeeName.innerText = strRowDetails[1];
                lblBillNo.innerText = strRowDetails[2];
                lblBillDate.innerText = strRowDetails[3];
                lblBillAmount.value = strRowDetails[4];
                lblServiceTaxPercent.innerText = strRowDetails[5];
                lblServiceTaxAmt.innerText = strRowDetails[6];
                lblTotalBillAmt.innerText = strRowDetails[7];
                txtChequeIssueTo.value = strRowDetails[10];
                lblNaration.innerText = strRowDetails[20];

                lblAccountLedger.innerText = strRowDetails[19] + ":";
                ddlPaymentType.value = strRowDetails[21];

                Validate_PaymentMode();
            }
            else {
                lblPayeeName.innerText = "";
                lblBillNo.innerText = "";
                lblBillDate.innerText = "";
                lblBillAmount.value = "";
                lblServiceTaxPercent.innerText = "";
                lblServiceTaxAmt.innerText = "";
                lblTotalBillAmt.innerText = "";

                ddlPaymentType.selectedIndex = 0;
                txtPaymentAmount.value = "0.00";
                txtChequeIssueTo.value = "";

                txtChequeNo.value = "";
                txtChequeDate.value = "";
                txtAccountHolderName.value = "";
                txtAccountNo.value = "";
                ddlBankList.selectedIndex = 0;
                ddlBankBranchList.selectedIndex = 0;
                //ddlBankBranchList.focus();
                ddlIsChequePrint.selectedIndex = 0;
                ddlIsBearer.selectedIndex = 0;

                txtTDSAmount.value = "";
                txtTDSPercentage.value = "";
                txtFinalPaymentAmount.value = "";

                ddlNatureofPayment.selectedIndex = 0;
                ddlRecipientType.selectedIndex = 0;
                ddlTDSPercentage.selectedIndex = 0;
                lblNaration.innerText = "";
                lblAccountLedger.innerText = "";
            }


        }
    </script>
 

    <table style="width: 167px">
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 16px">&nbsp;Make Branch Payment</td>
        </tr>
        <tr>
            <td colspan="7">
                <table>
                    <tr>
                        <td style="width: 5px"></td>
                        <td class="TableTitle" colspan="4">&nbsp;
                            <asp:Label ID="lblPaymentID" runat="server" SkinID="LabelSkin" Width="500px" Font-Bold="True"></asp:Label>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 5px"></td>
                        <td class="TableTitle">&nbsp;TransactionID</td>
                        <td class="TableGrid">&nbsp;<asp:Label ID="lblTransctionID" runat="server" SkinID="LabelSkin" Width="224px"></asp:Label>&nbsp;</td>
                        <td class="TableTitle" style="width: 100px">Total Amount
                        </td>
                        <td class="TableGrid">
                            <asp:Label ID="lblTotalAmount" runat="server" SkinID="LabelSkin"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 5px">&nbsp;</td>
                        <td class="TableTitle">&nbsp;Branch</td>
                        <td class="TableGrid">&nbsp;<asp:Label ID="lblBranchName" runat="server" SkinID="LabelSkin"></asp:Label>&nbsp;</td>
                        <td class="TableTitle" style="width: 100px">Payout Date</td>
                        <td class="TableGrid">
                            <asp:Label ID="lblPayoutDate" runat="server" SkinID="LabelSkin"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td>
                            <a href="javascript:switchViews('div01', 'one');" style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: #ffffff; border-bottom-style: none">
                                <img id="imgdiv01" alt="Click to show/hide transaction details"
                                    src="Images/plus.png" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" /></a></td>
                    </tr>
                    <tr>
                        <td colspan="8" class="GridViewSelectedRowStyle">
                            <div id='div01'
                                style="display: none; position: inherit; left: 15px; overflow: scroll;">

                                <asp:Label ID="Label1" runat="server" Text="Test Application"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnIssuePaymentDetails" runat="server" />
                <asp:HiddenField ID="hdnSavingPaymentDetails" runat="server" />
                <asp:HiddenField ID="hdnBranchID" runat="server" />
                <asp:HiddenField ID="hdnPaymentID" runat="server" />
                <asp:HiddenField ID="hdnBankBranchDetails" runat="server" />
                &nbsp&nbsp<a href="javascript:openwindow();" title="View Opening Balance">View Opening
                    Balance</a></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 6px">&nbsp; Payment Add Details</td>
        </tr>
        <tr>
            <td style="height: 20px;"></td>
            <td class="TableTitle" style="height: 20px">&nbsp;PaymentRequest</td>
            <td class="TableTitle" style="height: 20px">&nbsp;PayeeName</td>
            <td class="TableTitle" style="height: 20px">&nbsp;Bill No</td>
            <td class="TableTitle" style="width: 100px; height: 20px;">&nbsp;Bill Date</td>
            <td class="TableTitle" style="height: 20px">&nbsp;Bill Amount</td>
            <td class="TableTitle" style="height: 20px">&nbsp;GST %</td>
        </tr>
        <tr>
            <td></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlPaymentRequestList" runat="server" SkinID="ddlSkin"
                    AccessKey="N">
                </asp:DropDownList></td>
            <td class="TableGrid">&nbsp;<asp:Label ID="lblPayeeName" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td class="TableGrid">&nbsp;<asp:Label ID="lblBillNo" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td class="TableGrid" style="width: 100px">
                <asp:Label ID="lblBillDate" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td class="TableGrid">&nbsp;<asp:TextBox ID="lblBillAmount" runat="server" Text="0.00" Enabled="false"
                MaxLength="10" SkinID="txtSkin" Width="92px" Style="font-weight: bold"></asp:TextBox>
                <%--<asp:Label ID="lblBillAmount" runat="server" SkinID="LabelSkin" Width="31px">0.00</asp:Label>--%></td>
            <td class="TableGrid">
                <asp:Label ID="lblServiceTaxPercent" runat="server" SkinID="LabelSkin">0.00</asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="TableTitle">&nbsp;GST Amt</td>
            <td class="TableTitle">&nbsp;Total Bill Amt</td>
            <td class="TableTitle">&nbsp;Payment Mode</td>
            <td class="TableTitle" style="width: 100px">&nbsp;PaymentAmt
            </td>
            <td class="TableTitle">&nbsp;Payment Issue To</td>
            <td class="TableTitle">&nbsp;Cheque Print</td>
        </tr>
        <tr>
            <td></td>
            <td class="TableGrid">

                <asp:Label ID="lblServiceTaxAmt" runat="server" SkinID="LabelSkin">0.00</asp:Label></td>
            <td class="TableGrid">
                <asp:Label ID="lblTotalBillAmt" runat="server" SkinID="LabelSkin"
                    Style="font-weight: 700">0.00</asp:Label>
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlPaymentType" runat="server" Enabled="True" Font-Bold="True" ForeColor="Black" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">ByCheuqe</asp:ListItem>
                    <asp:ListItem Value="2">ByOnlineTransfer</asp:ListItem>
                    <asp:ListItem Value="4">ByNEFT</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtPaymentAmount" runat="server" MaxLength="10" SkinID="txtSkin"
                    Width="92px" Style="font-weight: bold"></asp:TextBox></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtChequeIssueTo" runat="server" MaxLength="30" SkinID="txtSkin"
                    Width="138px" Style="font-weight: bold"></asp:TextBox></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlIsChequePrint" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td class="TableTitle">&nbsp;Cheque No</td>
            <td class="TableTitle">&nbsp;Cheque Date</td>
            <td class="TableTitle">&nbsp;Bank Name
            </td>
            <td class="TableTitle" style="width: 100px">&nbsp;Branch Name</td>
            <td class="TableTitle">&nbsp;Account No&nbsp;</td>
            <td class="TableTitle">&nbsp;Account Holder</td>
        </tr>
        <tr>
            <td></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="6" SkinID="txtSkin" Width="69px"></asp:TextBox></td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlBankList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableGrid">
                <select id="ddlBankBranchList" onchange="javascript:Validate_BankBranchList();"
                    class="dropdown">
                    <option>--Select--</option>
                </select></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtAccountNo" runat="server" MaxLength="25" SkinID="txtSkin" Width="135px"
                    ReadOnly="True"></asp:TextBox></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtAccountHolderName" runat="server" MaxLength="25" SkinID="txtSkin"
                    Width="113px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="dropdown"></td>
            <td class="TableTitle">&nbsp;Cross On Cheque</td>
            <td class="TableTitle">&nbsp;Nature Of Payment</td>
            <td class="TableTitle">&nbsp;Recipient Type</td>
            <td class="TableTitle">&nbsp; Tds Percentage</td>
            <td class="TableTitle">&nbsp; Tds Amount&nbsp;</td>
            <td class="TableTitle">&nbsp;
                Final Amount
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlIsBearer" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlNatureofPayment" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="Not Applicable">NA</asp:ListItem>
                    <asp:ListItem Value="Interest from a Banking Company">Interest Banking Company</asp:ListItem>
                    <asp:ListItem Value="Interest other than from a Banking">Interest other than Banking Co</asp:ListItem>
                    <asp:ListItem Value="Contractors">Contractors</asp:ListItem>
                    <asp:ListItem Value="Commission or Brokerage">Comm or Brokr</asp:ListItem>
                    <asp:ListItem Value="Rent other than Plant, Mach.&amp; Eqp.">Rent Other</asp:ListItem>
                    <asp:ListItem Value="Rent of Plant , Machinery &amp; Equipments">Rent of Plant , Mach &amp; Equip</asp:ListItem>
                    <asp:ListItem Value="Professional Charges">Prof Chrgs</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlRecipientType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="Not Applicable">--Select--</asp:ListItem>
                    <asp:ListItem>Company</asp:ListItem>
                    <asp:ListItem>Indivudual</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="TableGrid">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <select id="ddlTDSPercentage" class="dropdown" onchange="javascript:Validate_ddlTDSPercentage();">
                                <option>--Select--</option>
                            </select>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtTDSPercentage" runat="server" MaxLength="6"
                                SkinID="txtSkin" Width="69px" Style="font-weight: bold">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid">
                <asp:TextBox ID="txtTDSAmount" runat="server" MaxLength="6" SkinID="txtSkin"
                    Width="69px" ReadOnly="True" Style="font-weight: bold">0</asp:TextBox>
            </td>
            <td class="TableGrid">
                <asp:TextBox ID="txtFinalPaymentAmount" runat="server" MaxLength="10" SkinID="txtSkin"
                    Width="92px" ReadOnly="True" Style="font-weight: bold">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="TableGrid" colspan="5">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblAccountLedger" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNaration" runat="server" SkinID="LabelSkin" Width="100%"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 107px">
                    <tr>
                        <td style="width: 100px; height: 24px">
                            <asp:Button ID="btnAddtoGrid" runat="server" BorderWidth="1px" Text="Add" Width="43px"
                                AccessKey="A" /></td>
                        <td style="width: 100px; height: 24px">&nbsp;<asp:Button ID="btnRemove" runat="server" BorderWidth="1px" Text="Remove" Width="55px"
                            AccessKey="R" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7">&nbsp;Payment Add Listt</td>
        </tr>
        <tr>
            <td colspan="7">
                <div id="dv1" style="overflow: scroll; width: 800px; height: 150px">
                    <table id="MainTab" class="GridViewStyle">
                        <tr>
                            <th class="TableGrid" style="height: 24px">
                                <input id="chkSelectAll" onclick="javascript:SelectAll();" type="checkbox" /></th>
                            <th class="TableGrid" style="height: 24px">&nbsp;DetailID</th>
                            <th class="TableGrid" style="height: 24px">Payee</th>
                            <th class="TableGrid" style="height: 24px">&nbsp;BillNo</th>
                            <th class="TableGrid" style="height: 24px">&nbsp;BillDate</th>
                            <th class="TableGrid" style="height: 24px">&nbsp;BillAmt</th>
                            <th class="TableGrid" style="height: 24px">&nbsp;GST%</th>
                            <th class="TableGrid" style="height: 24px">GSTAmt</th>
                            <th class="TableGrid" style="height: 24px">BillTotalAmt</th>
                            <th class="TableGrid" style="height: 24px">Type</th>
                            <th class="TableGrid" style="height: 24px">NOP</th>
                            <th class="TableGrid" style="height: 24px">Recipient Type</th>
                            <th class="TableGrid" style="height: 24px">&nbsp;TDS%&nbsp;</th>
                            <th class="TableGrid" style="height: 24px">TDS Amt</th>
                            <th class="TableGrid" style="height: 24px">&nbsp;Amount</th>
                            <th class="TableGrid" style="height: 24px">IssueTo</th>
                            <th class="TableGrid" style="height: 24px">ChequeNo</th>
                            <th class="TableGrid" style="height: 24px">ChequeDate</th>
                            <th class="TableGrid" style="height: 24px">AcctHolderName</th>
                            <th class="TableGrid" style="height: 24px">AccountNo</th>
                            <th class="TableGrid" style="height: 24px">Bank</th>
                            <th class="TableGrid" style="height: 24px">Branch</th>
                            <th style="height: 24px"></th>
                            <th style="height: 24px"></th>
                            <th style="height: 24px"></th>
                            <th style="height: 24px"></th>
                            <th style="height: 24px"></th>
                            <th style="height: 24px"></th>
                            <th style="height: 24px"></th>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table style="width: 770px">
        <tr>
            <td colspan="7">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7"></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 27px" class="TableTitle">
                <table style="width: 797px">
                    <tr>
                        <td style="height: 24px">
                            <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Save" Width="71px"
                                OnClick="btnSave_Click" AccessKey="S" />
                            <asp:Button ID="btnSaveNext" runat="server" BorderWidth="1px"
                                Text="Save n Next" Width="101px"
                                OnClick="btnSaveNext_Click" AccessKey="N" />
                            <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="61px"
                                OnClick="btnCancel_Click" AccessKey="C" />
                            <asp:Button ID="btnBack" runat="server" BorderWidth="1px"
                                Text="Back to Search" Width="122px" AccessKey="B" OnClick="btnBack_Click" /></td>
                        <td style="height: 24px"></td>
                        <td>&nbsp;</td>
                        <td class="TableTitle" style="height: 24px">&nbsp;<strong> Payment Amount</strong></td>
                        <td class="TableGrid" style="height: 24px">&nbsp;<asp:Label ID="lblTotalPaymentAmount" runat="server" Font-Bold="False" SkinID="LabelSkin"
                            Width="155px">0.00</asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
    </table>





</asp:Content>
