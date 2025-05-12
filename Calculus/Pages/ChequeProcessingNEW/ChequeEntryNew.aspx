<%@ Page Title="Check Entry New" Language="C#" MasterPageFile="~/Pages/MasterPage.master"
    AutoEventWireup="true" CodeFile="ChequeEntryNew.aspx.cs" Inherits="Pages_ChequeProcessingNEW_ChequeEntryNew" Theme=""%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">     
    </script>
    <script language="Javascript" type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    
    </script>
    <script language="javascript" type="text/javascript">

        var ChequeStatus = new Array(10);
        ChequeStatus[0] = '0'; //Instrument Type
        ChequeStatus[1] = '0'; //Cheque No
        ChequeStatus[2] = '0'; //Cheque Amt
        ChequeStatus[3] = '1'; //Cheque Date
        ChequeStatus[4] = '0'; //Card No
        ChequeStatus[5] = '0'; //MICR Code
        ChequeStatus[6] = '0'; //Account No
        ChequeStatus[7] = '1'; //Signature
        ChequeStatus[8] = '0'; //
        ChequeStatus[9] = '0'; //            

        function Validate_AllDetails() {
            Get_DropBoxDetails(null);

            Validate_Signature();
            Validate_ChequeNo();
            Validate_ChequeAmt();
            ChequeDate_Validate();
            Validate_CardNo();
            Validate_MICRCode();
            Validate_AccountNo();
            Validate_TransactionCode();
        }
        function Validate_TransactionCode() {
            //debugger;
            var txtTransactionCode = document.getElementById("<%=txtTransactionCode.ClientID%>");
            var lblBankName = document.getElementById("<%=lblBankName.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            var ErrorMessage = '';
            var bankName = lblBankName.innerText;
            if (bankName != "") {
                if (bankName.match('SBI') != null) {
                    if (txtTransactionCode.value == '') {
                        ErrorMessage = 'Please enter Transaction Code';

                        //                         alert('Please enter Transaction Code');                  
                    }
                }
            }

            lblMessage.innerText = ErrorMessage;
        }


        function LockSelection(IsPage) {
            //debugger;
            var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");
            var hdnDropboxID = document.getElementById("<%=hdnDropboxID.ClientID%>");
            var chkLockDropBox = document.getElementById('chkLockDropBox');

            if (IsPage == 1) {
                if (hdnDropboxID.value != "0") {
                    ddlDropBoxList.selectedIndex = hdnDropboxID.value;
                    chkLockDropBox.checked = true;

                }
                else {
                    ddlDropBoxList.selectedIndex = 0;
                    chkLockDropBox.checked = false;

                }
            }
            else {
                if (chkLockDropBox.checked == true) {
                    if (ddlDropBoxList.selectedIndex != 0) {
                        hdnDropboxID.value = ddlDropBoxList.selectedIndex;

                    }
                    else {
                        hdnDropboxID.value = "0";

                    }
                }
                else {
                    hdnDropboxID.value = "0";

                }
            }
        }

        function Page_load_validation() {
            Get_DropBoxDetails(event);
            //           Validate_Signature();


        }
        function Disable_UserControls(Value) {

            var ddlSignature = document.getElementById("<%=ddlSignature.ClientID%>");
            var ddlReasonList = document.getElementById("<%=ddlReasonList.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var txtCardNo = document.getElementById("<%=txtCardNo.ClientID%>");
            var txtAcountNo = document.getElementById("<%=txtAcountNo.ClientID%>");
            var txtTransactionCode = document.getElementById("<%=txtTransactionCode.ClientID%>");
            var txtContactNo = document.getElementById("<%=txtContactNo.ClientID%>");
            //  var txtReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>");
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");


            ddlSignature.disabled = Value;
            ddlReasonList.disabled = Value;
            txtChequeNo.disabled = Value;
            txtChequeAmt.disabled = Value;
            txtChequeDate.disabled = Value;
            txtCardNo.disabled = Value;
            //            txtMICRCode.disabled=Value;
            txtAcountNo.disabled = Value;
            txtTransactionCode.disabled = Value;
            txtContactNo.disabled = Value;
            // txtReceiptNo.disabled = Value;
            txtRemark.disabled = Value;



        }


        function Validate_AccountNo() {//debugger;

            var ErrorMessage = '';
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var txtAcountNo = document.getElementById("<%=txtAcountNo.ClientID%>");
            var txtMICR = document.getElementById("<%=TextBox1.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            if (txtAcountNo.value == '') {
                //                ErrorMessage = 'Account No not Entered!';
                alert('Account No not Entered!');
                hdnChequeStaus.value = '1';
                txtMICR.focus();
                idtxtAcountNo.className = "ErrorCell";
            }
            else {
                hdnChequeStaus.value = '0';
                idtxtAcountNo.className = "TableGrid";
            }

            lblMessage.innerText = ErrorMessage;
           // Validate_ChequeStatus(6, hdnChequeStaus.value);

        }

        function Validate_CreditCardNo(CardNo) {

            var IsValidate = false;
            var ComapareList = new Array(16);
            ComapareList[0] = 1;
            ComapareList[1] = 2;
            ComapareList[2] = 1;

            ComapareList[3] = 2;
            ComapareList[4] = 1;
            ComapareList[5] = 2;
            ComapareList[6] = 1;
            ComapareList[7] = 2;
            ComapareList[8] = 1;
            ComapareList[9] = 2;
            ComapareList[10] = 1;
            ComapareList[11] = 2;
            ComapareList[12] = 1;
            ComapareList[13] = 2;
            ComapareList[14] = 1;
            ComapareList[15] = 2;

            var intCDigit = 0;
            var SumOfValue = 0;
            var ArrayCount = 15;
            var i = 0;
            if (CardNo.length == 16) {
                for (i = 0; i <= CardNo.length - 1; i++) {
                    intCDigit = parseInt(CardNo.charAt(i));
                    intCDigit = Math.round(intCDigit * ComapareList[ArrayCount]);
                    ArrayCount = ArrayCount - 1;

                    if (intCDigit < 10) {
                        SumOfValue = Math.round(SumOfValue + intCDigit);
                    }
                    else {
                        intCDigit = Math.round(parseInt(intCDigit / 10) + parseInt(intCDigit % 10));

                        SumOfValue = Math.round(SumOfValue + intCDigit);
                    }
                }

                if (SumOfValue % 10 == 0) {
                    IsValidate = true;
                }
                else {
                    IsValidate = false;
                }
            }

            return IsValidate;
        }


        function Validate_CardNo() {
            //debugger;
            var ErrorMessage = '';
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var txtCardNo = document.getElementById("<%=txtCardNo.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblCardAmount = document.getElementById("<%=lblCardAmount.ClientID%>");
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var hdnIsSuspenseCheque = document.getElementById("<%=hdnIsSuspenseCheque.ClientID%>");
            var hdnBinLogoDetails = document.getElementById("<%=hdnBinLogoDetails.ClientID%>");
            var strhdnsuspCardNo = document.getElementById("<%=hdnsuspCardNo.ClientID %>");
            var strCardNo = txtCardNo.value;
            var strShortCardNo = strCardNo.slice(0, 9);

            if (strCardNo.length < 16) {
                //                ErrorMessage = 'Please enter valid CardNo to continue...';
                alert('Please enter valid CardNo to continue...');
                txtChequeDate.focus();
                hdnChequeStaus.value = '1';
                idtxtCardNo.className = "ErrorCell";

            }
            else {
                var sText = txtCardNo.value;
                var ValidChars = "0123456789";
                var IsNumber = true;
                var Char;
                hdnIsSuspenseCheque.value = '0';

                for (i = 0; i < sText.length && IsNumber == true; i++) {
                    Char = sText.charAt(i);
                    if (ValidChars.indexOf(Char) == -1) {
                        IsNumber = false;
                    }
                }
                if (IsNumber == false) {
                    //                    ErrorMessage = "Please enter numeric character!";
                    alert("Please enter numeric character!");
                    hdnChequeStaus.value = '1';
                    idtxtCardNo.className = "ErrorCell";

                }
                else {

                    var strOutPut = "";
                    var strRowDetails = "";
                    var strColDetails = "";

                    var strhdvValue = hdnBinLogoDetails.value;

                    strRowDetails = strhdvValue.split('^', strhdvValue.length);
                    var i = 0;
                    var j = 0;
                    var strRowlength = 0;
                    var valueFound = 0;
                    for (i = 0; i <= strRowDetails.length - 2; i++) {
                        strColDetails = strRowDetails[i];
                        strColDetails = strColDetails.split('|', strColDetails.length);

                        if (strShortCardNo == strColDetails[1]) {

                            valueFound = valueFound + 1;
                            hdnChequeStaus.value = '0';
                            break;
                        }
                    }

                    if (valueFound != 0) {


                        if (Validate_CreditCardNo(txtCardNo.value)) {
                            //                            lblCardAmount.innerText = txtChequeAmt.value;
                            hdnChequeStaus.value = '0';
                            idtxtCardNo.className = "TableGrid";
                            IdCardSuspended.className = "TableGrid";
                            IdCardSuspended.innerText = " Valid Card ";
                            strhdnsuspCardNo.value = " Valid Card";
                        }


                        else {
                            var r = confirm("Card not Validated,do you want mark as Suspense?");
                            if (r == true) {
                                //                            ErrorMessage = "Card Marked as Suspense";
                                alert("Card Marked as Suspense");
                                hdnChequeStaus.value = '0';
                                //hdnChequeStaus.value = '1';
                                hdnIsSuspenseCheque.value = '1';
                                IdCardSuspended.className = "ErrorCell";
                                IdCardSuspended.innerText = " Suspense Card ";
                                 strhdnsuspCardNo.value = "Suspense Card";
                            }

                            else {
                                ErrorMessage = "Invalid Card No Entered!";
                                alert("Invalid Card No Entered!");
                                hdnChequeStaus.value = '1';
                                hdnIsSuspenseCheque.value = '0';
                                idtxtCardNo.className = "ErrorCell";
                                IdCardSuspended.className = "ErrorCell";
                                txtCardNo.innerText = '';
                                txtChequeDate.focus();
                            }

                        }
                        txtCardNo.focus();
                    }
                    else {
                        alert("Card Marked as Suspense");
                        hdnChequeStaus.value = '0';
                        //hdnChequeStaus.value = '1';
                        hdnIsSuspenseCheque.value = '1';
                        IdCardSuspended.className = "ErrorCell";
                        IdCardSuspended.innerText = " Suspense Card ";
                         strhdnsuspCardNo.value = " Suspense Card";
                    }

                }



            }
            lblMessage.innerText = ErrorMessage;
           // Validate_ChequeStatus(4, hdnChequeStaus.value);
        }

        function ChequeDate_Validate() {
                       // debugger;

            var ErrorMessage = '';
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var hdnDate = document.getElementById("<%=hdnDate.ClientID%>");
            var strChequeDate = txtChequeDate.value;
            var strhdncheqdate = document.getElementById("<%=hdncheqdate.ClientID%>");
            var strlbl = document.getElementById("<%=Label1.ClientID%>");
            var sText = '';

            if (strChequeDate.length == 0) {
                alert("Cheque Date cannot be Blank. Enter Cheque Date to Continue");
                hdnChequeStaus.value = '1';
                txtChequeAmt.focus();
                idtxtChequeDate.className = "ErrorCell";
                idChequeDate.className = "ErrorCell";
            }

            else {

                var strtxtChequeDate = txtChequeDate.value;

                strtxtChequeDate = strtxtChequeDate.split('/', strtxtChequeDate.length);

                var strCurrentDate = hdnDate.value;
                strCurrentDate = strCurrentDate.split('/', strCurrentDate.length);

                var diff = 0;
                if (strtxtChequeDate.length > 0) {
                    var ChequeDate = new Date(strtxtChequeDate[2], strtxtChequeDate[1] - 1, strtxtChequeDate[0]);
                    var CurrentDate = new Date(strCurrentDate[2], strCurrentDate[1] - 1, strCurrentDate[0]);

                    var one_day = 1000 * 60 * 60 * 24;
                    diff = Math.ceil((CurrentDate.getTime() - ChequeDate.getTime()) / (one_day));
                }
             
                //if (diff <= -1 && diff > -30) {
                if (diff < 0 && diff >= -30) {
                    //                            ErrorMessage="Post Dated Cheque!";
                    alert("Post Dated Cheque!");
                    hdnChequeStaus.value = '1';
                    idtxtChequeDate.className = "ErrorCell";
                    idChequeDate.innerText = " Post Dated ";

                    strhdncheqdate.value = "Post Dated";

                } else

                    if (diff < -30 && diff >= -90) {
                        //                            ErrorMessage="Post Dated Cheque!";
                        alert("Post Dated Cheque Beyond 30 Days!");
                        hdnChequeStaus.value = '1';
                        idtxtChequeDate.className = "ErrorCell";

                        idChequeDate.innerText = " Post Dated Beyond 30 Days";
                        strhdncheqdate.value = "Post Dated Beyond 30 Days";
                    }
                    else
                        if (diff <= -91) {
                            alert("Out Of Date");
                            hdnChequeStaus.value = '1';
                            idtxtChequeDate.className = "ErrorCell";

                            idChequeDate.innerText = " Out Of Date";
                            strhdncheqdate.value = "Out Of Date";
                        }

                      
                        else 
                            if (diff > 90) {
                                alert("Cheque is Old More than 3 Month !");
                                hdnChequeStaus.value = '1';
                                idtxtChequeDate.className = "ErrorCell";
                                idChequeDate.className = "ErrorCell";
                                idChequeDate.innerText = " Old Cheque ";
                                strhdncheqdate.value = "Old Cheque";
                            }
                            else {
                                hdnChequeStaus.value = '0';
                                idtxtChequeDate.className = "TableGrid";
                                idChequeDate.className = "TableGrid";
                                //                             idChequeDate.className="ErrorCell";                        nikhil
                                idChequeDate.innerText = " Valid Cheque "; //nnnnnnnnnnn
                                strhdncheqdate.value = "Valid Cheque";
                            }

                        
            }

            //lblMessage.innerText = ErrorMessage;
            Validate_ChequeStatus(3, hdnChequeStaus.value);
        }

        function Validate_Save() {
            //            debugger;
            var ErrorMessage = '';
            var returnValue = true;
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");

            var txtCardNo = document.getElementById("<%=txtCardNo.ClientID%>");
            var txtAcountNo = document.getElementById("<%=txtAcountNo.ClientID%>");
            var ddlSignature = document.getElementById("<%=ddlSignature.ClientID%>");
            var hdnTransactionDetailID = document.getElementById("<%=hdnTransactionDetailID.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var strDropBoxDetails = '';
            var strRowDetails = "";
            var ddlReasonList = document.getElementById("<%=ddlReasonList.ClientID%>");



            strDropBoxDetails = ddlDropBoxList.value;
            strRowDetails = strDropBoxDetails.split('|', strDropBoxDetails.length);

            Validate_ChequeStatus(8, 0);

            if (ddlDropBoxList.selectedIndex == 0) {
                returnValue = false;
                //                ErrorMessage = 'Please select Valid Dropbox to continue!';
                alert('Please select Valid Dropbox to continue!');
                ddlDropBoxList.focus();
            }

            else {

                if (txtCardNo.value == '') {
                    returnValue = false;
                    //                    ErrorMessage='Please Enter Card No to continue!';
                    alert('Please Enter Card No to continue!');
                    txtCardNo.focus();
                }
                if (ddlSignature.selectedIndex == 0) {
                    returnValue = false;
                    //                    ErrorMessage='Please select Signature on Cheque to continue!';
                    alert('Please select Signature on Cheque to continue!');
                    ddlSignature.focus();
                }
            }

            if ((hdnChequeStaus.value == '1') && (ddlReasonList.selectedIndex == 0)) {
                returnValue = false;
                //                 ErrorMessage='Please Select Invalid Cheque Reason!';
                alert('Please Select Invalid Cheque Reason!');
                ddlReasonList.focus();
                idddlReasonList.className = "ErrorCell";
            }
            else {
                idddlReasonList.className = "TableGrid";
            }


            lblMessage.innerText = ErrorMessage;
            return returnValue;
        }

        function Validate_Signature() {
            //debugger;
            var ErrorMessage = '';
            var ddlSignature = document.getElementById("<%=ddlSignature.ClientID%>");

            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var selectedIndex = ddlSignature.selectedIndex;

            if (ddlSignature.selectedIndex != 0) {
                if (ddlSignature.options[selectedIndex].innerText == 'Yes') {
                    hdnChequeStaus.value = '0';
                    idddlSignature.className = "TableGrid";
                }
                else {
                    hdnChequeStaus.value = '1';
                    idddlSignature.className = "ErrorCell";
                }
                Validate_ChequeStatus(7, hdnChequeStaus.value);
            }
            else {
                hdnChequeStaus.value = '1';
                //                ErrorMessage='please select signature on cheque' ;
                alert('please select signature on cheque');
            }
            lblMessage.innerText = ErrorMessage;


        }

//        function Validate_ChequeStatus(ArrayNo, value) {

//            //            ChequeStatus[0] = '0';//Instrument Type
//            //            ChequeStatus[1] = '1';//Cheque No
//            //            ChequeStatus[2] = '1';//Cheque Amt
//            //            ChequeStatus[3] = '1';//Cheque Date
//            //            ChequeStatus[4] = '1';//Card No
//            //            ChequeStatus[5] = '1';//MICR Code
//            //            ChequeStatus[6] = '1';//Account No
//            //            ChequeStatus[7] = '1';//Signature
//            //            ChequeStatus[8] = '0';//
//            //            ChequeStatus[9] = '0';//     


//            ChequeStatus[ArrayNo] = value;

//            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
//            var lblChequeStatus = document.getElementById("<%=lblChequeStatus.ClientID%>");
//            var ddlReasonList = document.getElementById("<%=ddlReasonList.ClientID%>");
//            var lblLabel1 = document.getElementById("<%=Label1.ClientID%>");

//            var i = 0;
//            var finalValue = 0;
//            for (i = 0; i <= ChequeStatus.length; i++) {
//                var ChequeType = ChequeStatus[i];
//                if (ChequeType == '1') {
//                    finalValue = finalValue + 1;
//                }
//            }

//            if (finalValue > 0) {
//                hdnChequeStaus.value = 1;
//            }
//            else {
//                hdnChequeStaus.value = 0;
//            }

//            if (hdnChequeStaus.value == '0') {
//                lblChequeStatus.innerText = 'Valid';
//              
//            }
//          
//            else {

//                lblChequeStatus.innerText = 'Invalid';
//             
//                   
//            }



//        }
        function Validate_ChequeStatus(ArrayNo, value) {
//            var ChequeStatus = new Array(10);
//           ChequeStatus[0] = '0'; //Instrument Type
//           ChequeStatus[1] = '1'; //Cheque No
//            ChequeStatus[2] = '1'; //Cheque Amt
//            ChequeStatus[3] = '1'; //Cheque Date
//           ChequeStatus[4] = '1'; //Card No
//           ChequeStatus[5] = '1'; //MICR Code
//            ChequeStatus[6] = '1'; //Account No
//            ChequeStatus[7] = '1'; //Signature
//            ChequeStatus[8] = '0'; //
//           ChequeStatus[9] = '0';


            ChequeStatus[ArrayNo] = value;
            
            
 
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var lblChequeStatus = document.getElementById("<%=lblChequeStatus.ClientID%>");
            var ddlReasonList = document.getElementById("<%=ddlReasonList.ClientID%>");
            var hdnchkstat = document.getElementById("<%=hdnchkstat.ClientID%>");
            var hdnArray = document.getElementById("<%=hdnArray.ClientID%>");
            var HiddenField1 = document.getElementById("<%=HiddenField1.ClientID%>");
            var i = 0;
            var finalValue = 0;
            hdnArray.value = 0;
           
            for (i = 1; i <= ChequeStatus.length-1; i++) {
                hdnArray.value = hdnArray.value +','+ ChequeStatus[i];
            }
           
            var chk ;
            if (HiddenField1.value != null && HiddenField1.value != "" && HiddenField1.value != "0,0,0,0,0,0,0,0,0,0") {
                chk = HiddenField1.value.split(',');
                for (i = 0; i < chk.length; i++) {
                    ChequeStatus[i] = chk[i];
                }
                ChequeStatus[ArrayNo] = value
                HiddenField1.value = "";
            }

            for (i = 0; i <= ChequeStatus.length; i++) {
                var ChequeType = ChequeStatus[i];
                if (ChequeType == '1') {
                    finalValue = finalValue + 1;
                 
                }
            }

            if (finalValue > 0) {
                hdnChequeStaus.value = 1;
            }
            else {
                hdnChequeStaus.value = 0;
            }

            if (hdnChequeStaus.value == '0') {
                lblChequeStatus.innerText = 'Valid';
                //                ddlReasonList.disabled = true;
                hdnchkstat.value = 'Valid';
            }
            else {
                lblChequeStatus.innerText = 'Invalid';
                //                ddlReasonList.disabled = false;
                hdnchkstat.value = 'Invalid';
            }



        }
        function Validate_ChequeAmt() {
            //  debugger;

            var ErrorMessage = "";
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var strChequeAmount = txtChequeAmt.value;


            var sText = '';
            if (strChequeAmount.length == 0 || txtChequeAmt.value == 0) {
                //                ErrorMessage="Cheque amount can not left blank!";
                alert("Cheque amount can not left blank!");
                hdnChequeStaus.value = '1';
                txtChequeNo.focus();
                idtxtChequeAmt.className = "ErrorCell";
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
                    //                    ErrorMessage="Invalid Cheque Amount Entered!";
                    alert("Invalid Cheque Amount Entered!");
                    hdnChequeStaus.value = '1';
                    txtChequeNo.focus();
                    idtxtChequeAmt.className = "ErrorCell";
                }
                else {
                    hdnChequeStaus.value = '0';
                  //  Validate_ChequeStatus(2, hdnChequeStaus.value);
                    idtxtChequeAmt.className = "TableGrid";
                }

            }
            lblMessage.innerText = ErrorMessage;

        }


        function Validate_ChequeNo() {
            //            debugger;


            var ErrorMessage = "";
            var ddlInstrumentType = document.getElementById("<%=ddlInstrumentType.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");

            var selectedIndex = ddlInstrumentType.selectedIndex;

            var strChequeValue = txtChequeNo.value;


            if (strChequeValue.length < 6 || txtChequeNo.value == '') {
                //                        ErrorMessage="Invalid Cheque No! please enter again.";
                alert("Invalid Cheque No! please enter again.");
                hdnChequeStaus.value = '1';
                ddlInstrumentType.focus();
                idtxtChequeNo.className = "ErrorCell";
            }
            else {
                sText = strChequeValue;
                var ValidChars = "0123456789";
                var IsNumber = true;
                var Char;

                for (i = 0; i < sText.length && IsNumber == true; i++) {
                    Char = sText.charAt(i);
                    if (ValidChars.indexOf(Char) == -1) {
                        IsNumber = false;
                    }
                }
                if (IsNumber == false) {
                    //                                    ErrorMessage="Invalid Cheque No Entered!";
                    alert("Invalid Cheque No Entered!");
                    hdnChequeStaus.value = '1';
                    ddlInstrumentType.focus();
                    idtxtChequeNo.className = "ErrorCell";
                }
                else {
                    hdnChequeStaus.value = '0';
                   // Validate_ChequeStatus(1, hdnChequeStaus.value);
                    idtxtChequeNo.className = "TableGrid";
                }

            }


            lblMessage.innerText = ErrorMessage;
            window.scrollBy(0, 0);



        }

        function Get_DropBoxDetails(evt) {

            evt = (evt) ? evt : ((event) ? event : null);
            var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");

            if (evt != null) {
                if (evt.keyCode == 13) {
                    evt.keyCode = 9;
                }
            }
            var ErrorMessage = "";
            //var ddlDropBoxList=document.getElementById("<%=ddlDropBoxList.ClientID%>");       
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblDropBoxName = document.getElementById("<%=lblDropBoxName.ClientID%>");
            var btnCancel = document.getElementById("<%=btnCancel.ClientID%>");

            var lblTotalChqueCapture = document.getElementById("<%=lblTotalChqueCapture.ClientID%>");
            var hdnTransactionDetailID = document.getElementById("<%=hdnTransactionDetailID.ClientID%>");

            var Value = false;

            var SelectIndex = parseInt(ddlDropBoxList.selectedIndex);

            var strDropBoxDetails = '';
            var strRowDetails = "";

            if (ddlDropBoxList.selectedIndex != 0) {
                strDropBoxDetails = ddlDropBoxList.value;
                strRowDetails = strDropBoxDetails.split('|', strDropBoxDetails.length);
                lblDropBoxName.innerText = strRowDetails[1];
                lblTotalChqueCapture.innerText = strRowDetails[3] + " of " + strRowDetails[2];

                if ((strRowDetails[3] == strRowDetails[2]) && (hdnTransactionDetailID.value == '0')) {
                    Value = true;
                    //                            ErrorMessage='All Cheques Captured for selected drop box!!';
                    alert('All Cheques Captured for selected drop box!!');
                    //                            ddlDropBoxList.focus();//nnnnnn
                    btnCancel.focus();
                }
                else {
                    Value = false;
                }
            }
            else {
                lblDropBoxName.innerText = '';
                lblTotalChqueCapture.innerText = '';
                Value = true;
                ErrorMessage = 'Please select valid dropbox to continue!';
                //                        alert('Please select valid dropbox to continue!');
            }

            lblMessage.innerText = ErrorMessage;
            Disable_UserControls(Value);


        }

        function Validate_MICRCode() {
            //            debugger;
            var ErrorMessage = "";
            var txtMICRCode = document.getElementById("<%=TextBox1.ClientID%>");
            var txtCardNo = document.getElementById("<%=txtCardNo.ClientID%>");
            var hdnMicrCheck = document.getElementById("<%=hdnMicrCheck.ClientID%>")
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var strMICRCode = txtMICRCode.value;
            var strMicrDetails = '';
            var strRowDetails = "";

            //             
            if (strMICRCode.length < 9) {
                //                ErrorMessage='Please enter  proper MICR Code to continue...!';
                alert('Please enter  proper MICR Code to continue...!');
                txtCardNo.focus();
                idtxtMICRCode.className = "ErrorCell";
            }
            else (strMICRCode.length == 9)
            {

                var strMicrDetails = '';
                var strRowDetails = "";
                var strRowDetails2 = "";

                strMicrDetails = hdnMicrCheck.value;
                strRowDetails = strMicrDetails.split('^', strMicrDetails.length);

                //                strRowDetails2 = strRowDetails.split('|', strRowDetails.length);

                var i = 0;
                var finalValue = 0;
                for (i = 0; i <= strRowDetails.length; i++) {
                    var ChequeType = strRowDetails[i];
                    if (ChequeType == txtMICRCode.value) {
                        finalValue = finalValue + 1;
                        idtxtMICRCode.className = "TableGrid";
                        hdnChequeStaus.value = '0';
                        txtMICRCode.focus();
                    }
                }

                //   if (finalValue == 0)
                // {
                //      alert('Invalid MICR code Entered..Enter Proper code!!');
                //                                         TextBox1.value = '';
                //     txtCardNo.focus();
                //     idtxtMICRCode.className = "ErrorCell";
                //       }
            }

            window.scrollBy(0, 0);
          //  Validate_ChequeStatus(5, hdnChequeStaus.value);


        }        
    </script>
     
              
    <table id="MainTab2">
        <tr>
            <td colspan="8" style="height: 15px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 21px">
                &nbsp;
                <asp:Label ID="lblChequeCategory" runat="server"></asp:Label>
                Cheque Data Entry&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="TableTitle">
                &nbsp;<strong>Batch No </strong>
            </td>
            <td class="TableGrid" style="width: 100px;">
                <asp:TextBox ID="txtBatchNo" runat="server" BorderWidth="1px" ReadOnly="True" Width="158px"
                    SkinID="txtSkin"></asp:TextBox>
            </td>
            <td class="TableTitle">
                &nbsp;<strong>BatchDate</strong>
            </td>
            <td class="TableGrid" colspan="2">
                &nbsp;<asp:Label ID="lblBatchDate" runat="server" Width="70px" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 100px;" class="TableTitle">
                &nbsp;No Of Cheque Captured
            </td>
            <td class="TableGrid" style="width: 100px;">
                <asp:Label ID="lblNoOfCheque" runat="server" Width="70px" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
            </td>
            <td class="TableTitle" style="height: 35px">
                &nbsp;Drop Box Code
            </td>
            <td style="width: 100px; height: 35px;" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 143px; height: 36px;">
                    <tr>
                        <td style="height: 30px;">
                            <asp:DropDownList ID="ddlDropBoxList" runat="server" SkinID="ddlSkin" Height="25px"
                                Width="104px" AutoPostBack="True" OnSelectedIndexChanged="ddlDropBoxList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px; height: 30px;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="height: 35px">
                &nbsp;DropBoxName
            </td>
            <td class="TableGrid" colspan="2" style="height: 35px">
                &nbsp;<asp:Label ID="lblDropBoxName" runat="server" Width="234px" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 100px; height: 35px;" class="TableTitle">
                DropBoxChequeCaptured
            </td>
            <td class="TableGrid" style="width: 100px; height: 35px;">
                <asp:Label ID="lblTotalChqueCapture" runat="server" Width="70px" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">
                &nbsp;Card and Personal Details
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;InstrumentType
            </td>
            <td class="TableGrid" style="width: 100px;" id="IdInstrumentType">
                <asp:DropDownList ID="ddlInstrumentType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="TableTitle" id="idChequeNo">
                &nbsp;Cheuqe No
            </td>
            <td class="TableGrid" id="idtxtChequeNo">
                <asp:TextBox ID="txtChequeNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="74px"
                    MaxLength="6"></asp:TextBox>
            </td>
            <td class="TableTitle" id="idChequeAmt">
                &nbsp;Cheque Amt
            </td>
            <td class="TableGrid" id="idtxtChequeAmt" colspan="2">
                <asp:TextBox ID="txtChequeAmt" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="99px"></asp:TextBox>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle" id="idChequeDate2">
                &nbsp;Cheque Date
            </td>
            <td style="width: 100px" class="TableGrid" id="idtxtChequeDate">
                <table cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px" AutoPostBack="True" OnTextChanged="txtChequeDate_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            [DD/MM/YYYY]
                        </td>
                        <%-- <td style="width: 100px; height: 22px">
                            <img id="Img2" alt="Calendar" 
                            onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" onchange="DATE(this);"  /></td>--%>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;Date Status
            </td>
            <td class="TableGrid" id="idChequeDate">
                <asp:Label ID="Label1" runat="server" SkinID="LabelSkin" Width="115px"></asp:Label>
                &nbsp;
            </td>
            <td class="TableTitle">
                &nbsp;
                <%--     ChequeCaptureUser --%>
                &nbsp;
            </td>
            <td class="TableGrid" colspan="2">
                &nbsp;
                <asp:Label ID="lblChequeCapturedByUser" runat="server" SkinID="LabelSkin" Width="70px"
                    Visible="false"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;<strong>Card No. *</strong>
            </td>
            <td style="width: 100px" class="TableGrid" id="idtxtCardNo">
                <asp:TextBox ID="txtCardNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px"
                    MaxLength="16"></asp:TextBox>
            </td>
            <td class="TableTitle">
                &nbsp;Card Status
            </td>
            <td class="TableGrid" id="IdCardSuspended">
            </td>
            <td class="TableTitle">
                &nbsp;
                <%--Card Amount--%>
            </td>
            <td class="TableGrid" colspan="2">
                &nbsp;
                <asp:Label ID="lblCardAmount" runat="server" SkinID="LabelSkin" Width="71px" Visible="false" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 1px">
            </td>
            <td class="TableTitle" style="height: 1px" colspan="7">
                <%--<asp:TextBox ID="txtMICRCode" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px"
                    MaxLength="9" AutoPostBack="True"></asp:TextBox>--%>
                <br />
               <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <table style="width: 100%" class="TableTitle">
                            <tr>
                                <td class="TableTitle">
                                    &nbsp;<strong>MICR Code </strong>
                                </td>
                                <td class="TableGrid" style="width: 207px" align="left" valign="middle" id="idtxtMICRCode">
                                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" onkeydown="javascript:if(event.keyCode==13) {event.keyCode=9};"
                                        OnTextChanged="TextBox1_TextChanged" MaxLength="9"></asp:TextBox>
                                </td>
                                <td class="TableTitle">
                                    &nbsp;<strong>Bank</strong>
                                </td>
                                <td class="TableGrid">
                                    <asp:Label ID="lblBankName" runat="server" SkinID="LabelSkin" Width="212px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableTitle">
                                    &nbsp;<strong>Branch </strong>
                                </td>
                                <td style="width: 207px" align="left" class="TableGrid" valign="middle">
                                    <br />
                                    <asp:Label ID="lblBranchName" runat="server" SkinID="LabelSkin" Width="146px"></asp:Label>
                                    <br />
                                </td>
                                <td class="TableTitle">
                                    &nbsp;<strong>City</strong>
                                </td>
                                <td class="TableGrid">
                                    <asp:Label ID="lblCity" runat="server" SkinID="LabelSkin" Width="164px"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="height: 32px">
            </td>
            <td class="TableTitle" style="height: 32px">
                &nbsp;Account No </td><td style="width: 100px; height: 32px;" class="TableGrid" id="idtxtAcountNo">
                    <asp:TextBox ID="txtAcountNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px"
                        MaxLength="16"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 32px">
                    &nbsp;
                </td>
                <td class="TableGrid" style="height: 32px">
                    &nbsp;
                </td>
                <td class="TableTitle" style="width: 45px; height: 32px;">
                    &nbsp;ChequeStatus
                </td>
                <td class="TableGrid" colspan="2" style="height: 32px">
                    <asp:Label ID="lblChequeStatus" runat="server" SkinID="LabelSkin" Width="232px"></asp:Label>
                </td>
               
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Signature
            </td>
            <td class="TableGrid" style="width: 100px; height: 24px" id="idddlSignature">
                <asp:DropDownList ID="ddlSignature" runat="server" SkinID="ddlSkin" AutoPostBack="true"
                    onselectedindexchanged="ddlSignature_SelectedIndexChanged1">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Reason
            </td>
            <td class="TableGrid" style="height: 24px" colspan="4" id="idddlReasonList">
                <asp:DropDownList ID="ddlReasonList" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;TransactionCode
            </td>
            <td class="TableGrid" style="width: 100px; height: 24px;">
                <asp:TextBox ID="txtTransactionCode" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="120px" MaxLength="2"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Contact No
            </td>
            <td class="TableGrid" style="width: 100px; height: 24px">
                <asp:TextBox ID="txtContactNo" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="120px" MaxLength="10" onkeypress="return isNumberKey(event)"> 
                  
                </asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 24px; width: 45px;">
                &nbsp;
                <%-- ReceiptNo--%>
            </td>
            <td class="TableGrid" colspan="2" style="height: 24px">
                <asp:TextBox ID="txtReceiptNo" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="120px" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 46px">
            </td>
            <td class="TableTitle" style="height: 46px">
                &nbsp;Remarks
            </td>
            <td class="TableGrid" colspan="6" style="height: 46px">
                <asp:TextBox ID="txtRemark" runat="server" BorderWidth="1px" Height="36px" MaxLength="500"
                    SkinID="txtSkin" Width="556px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 38px">
                &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" OnClick="btnSave_Click"
                    Text="Save" Width="59px" AccessKey="S" />&nbsp;<asp:Button ID="btnCancel" runat="server"
                        BorderWidth="1px" Text="Cancel" OnClick="btnCancel_Click" AccessKey="C" />
                <asp:Button ID="btnBackToSearch" runat="server" BorderWidth="1px" Text="Back to Search"
                    OnClick="btnBackToSearch_Click" Width="119px" AccessKey="B" />
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:HiddenField ID="hdnChqCount" runat="server" />
                <asp:HiddenField ID="hdnC" runat="server" />
                <asp:HiddenField ID="hdnMicrCheck" runat="server" />
                <asp:HiddenField ID="hdnT" runat="server" />
                <asp:HiddenField ID="hdnTotalChqs" runat="server" />
                <asp:HiddenField ID="hdnDate" runat="server" />
                <asp:HiddenField ID="hdnTransactionDetailID" runat="server" />
                <asp:HiddenField ID="hdnChequeStaus" runat="server" />
                <asp:HiddenField ID="hdnMICRDetails" runat="server" />
                <asp:HiddenField ID="hdnEntryStart" runat="server" />
                <asp:HiddenField ID="hdnDepositDate" runat="server" />
                <asp:HiddenField ID="hdnchequeCategory" runat="server" Value="0" />
                <asp:HiddenField ID="hdnIsSuspenseCheque" runat="server" Value="0" />
                <asp:HiddenField ID="hdnDropboxID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnBinLogoDetails" runat="server" />
                <asp:HiddenField ID="hdncheqdate" runat="server" Value="" />
                <asp:HiddenField ID="hdnsuspCardNo" runat="server" Value="" />
                <asp:HiddenField ID="hdnchkstat" runat="server" Value="" />
                <asp:HiddenField ID="hdnArray" runat="server" Value="0" />
                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
              
            </td>
          
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 45px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
     
</asp:Content>
