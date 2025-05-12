<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ValidateChequeDataEntry.aspx.cs" Inherits="ValidateChequeDataEntry"
    Title="Cheque Capture " StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js">     
    </script>

    <script language="javascript" type="text/javascript"> 
    
        var ChequeStatus=new Array(10);  
        ChequeStatus[0] = '0';//Instrument Type
        ChequeStatus[1] = '1';//Cheque No
        ChequeStatus[2] = '1';//Cheque Amt
        ChequeStatus[3] = '1';//Cheque Date
        ChequeStatus[4] = '1';//Card No
        ChequeStatus[5] = '0';//MICR Code
        ChequeStatus[6] = '0';//Account No
        ChequeStatus[7] = '0';//Signature
        ChequeStatus[8] = '0';//
        ChequeStatus[9] = '0';//
        
        var ChequeValidateStatus=new Array(14);  
        ChequeValidateStatus[0]='0';//TransactionID
        ChequeValidateStatus[1]='0';//DropBoxID
        ChequeValidateStatus[2]='0';//InstrumentType
        ChequeValidateStatus[3]='1';//ChequeNo
        ChequeValidateStatus[4]='1';//ChequeAmount
        ChequeValidateStatus[5]='1';//ChequeDate
        ChequeValidateStatus[6]='1';//CardNo
        ChequeValidateStatus[7]='0';//MICRCode
        ChequeValidateStatus[8]='0';//AccountNo
        ChequeValidateStatus[9]='0';//Signature
        ChequeValidateStatus[10]='0';//ReasonID
        ChequeValidateStatus[11]='0';//TransactionCode
        ChequeValidateStatus[12]='0';//ContactNo
        ChequeValidateStatus[13]='0';//ReceiptNo
        
       
        
        function Validate_ChequeEntry(Value,IntSequence)
        {
           // debugger;
            var hdnTransactionDetailID=document.getElementById("<%=hdnTransactionDetailID.ClientID%>");

            var hdnValidateChequeEntry = document.getElementById("<%=hdnValidateChequeEntry.ClientID%>");

            var ddlInstrumentType = document.getElementById("<%=ddlInstrumentType.ClientID%>");
            var ddlSignature = document.getElementById("<%=ddlSignature.ClientID%>");
            var ddlReasonList = document.getElementById("<%=ddlReasonList.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var txtCardNo = document.getElementById("<%=txtCardNo.ClientID%>");
            var txtMICRCode = document.getElementById("<%=txtMICRCode.ClientID%>");
            var txtAcountNo = document.getElementById("<%=txtAcountNo.ClientID%>");
            var txtTransactionCode = document.getElementById("<%=txtTransactionCode.ClientID%>");
            var txtContactNo = document.getElementById("<%=txtContactNo.ClientID%>");
            var txtReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>");
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>"); 
                                          
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");                  
            var btnSave=document.getElementById("<%=btnSave.ClientID%>");                  
           
            var valueFound=0;
            var ErrorMessage="";
            
            var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>");                              
           
            
            if (hdnValidateChequeEntry.value!="")
            {
                var strOutPut="";
                var strRowDetails="";
                var strColDetails="";
               
                var strhdvValue=hdnValidateChequeEntry.value;              
                 
                 strRowDetails=strhdvValue.split('^', strhdvValue.length); 
                 var i=0;
                 var j=0;
                 var strRowlength=0;
                 
                 for (i=0;i<=strRowDetails.length-1;i++)            
                 { 
                     strColDetails=strRowDetails[i];
                     strColDetails=strColDetails.split('|', strColDetails.length);
                                   
                     if ((strColDetails[IntSequence]==Value))
                     {
                        valueFound=valueFound+1;
                        hdnTransactionDetailID.value=strColDetails[0];
                        break;
                     }  
                }
            
            }
             
             if (valueFound==0)
             {   
                 if (IntSequence==1)
                 {
                      ErrorMessage='DropBox Not found!';                      
                 }
                 if (IntSequence==2)
                 {
                      ErrorMessage='Instrument Type Not found!';                      
                 }
                 if (IntSequence==3)
                 {
                     ErrorMessage = 'Cheque No Not found!';
                     ddlInstrumentType.focus();                     
                 }
                 else if (IntSequence==4)
                 {
                     ErrorMessage = 'Cheuqe Amount Not found!';
                     txtChequeNo.focus();
                 }
                 else if (IntSequence==5)
                 {
                     ErrorMessage = 'Cheuqe Date Not found!';
                     txtChequeAmt.focus();
                 }
                 else if (IntSequence==6)
                 {
                     ErrorMessage = 'Card No Not found!';
                                          txtChequeDate.focus();
//                     alert('Card No Not found!');
//                     txtCardNo.focus();
                     
                 }
                 else if (IntSequence==7)
                 {
                     ErrorMessage = 'MICR Code Not Found!';
                     txtCardNo.focus();
                 }
                 else if (IntSequence==8)
                 {
                     ErrorMessage = 'Account No Not Found!';
                     txtMICRCode.focus();
                 }
                 else if (IntSequence==9)
                 {
                     ErrorMessage = 'Signature not Found!';
                     ddlSignature.focus();
                 }
                 else if (IntSequence==10)
                 {
                     ErrorMessage = 'Reason not Found!';
                     ddlSignature.focus();
                 }
                 else if (IntSequence==11)
                 {
                     ErrorMessage = 'Transaction Code not found!';
                     if (ddlReasonList.disable = true) {
                         ddlSignature.focus();
                     }
                     else {
                         ddlReasonList.focus(); 
                     }
                 }
                 else if (IntSequence==12)
                 {
                     ErrorMessage = 'Contact No not found!';
                     txtTransactionCode.focus();
                 }
                 else if (IntSequence==13)
                 {
                     ErrorMessage = 'Receipt No not found!';
                     txtContactNo.focus();
                 }
                 ChequeValidateStatus[IntSequence]='1';
             } 
             else
             {
                 ChequeValidateStatus[IntSequence]='0';
             }
           
            var Value=false;
            var i=0;
            var finalValue=0;
            
            for (i=0;i<=ChequeValidateStatus.length;i++)
            {   
                var IsValidate=ChequeValidateStatus[i];
                if (IsValidate=='1')
                {
                    finalValue=finalValue+1;
                    Value=true;
                    break;
                    
                }
            }


            btnSave.disabled = Value;
//            //NIKHIL
//            if (Value == false) {
//                btnSave.focus();
//            }
            
             lblMessage.innerText=ErrorMessage;
             window.scrollBy(0,0);
        
        }
        function Validate_InstrumentType() {
            //debugger;
            var ErrorMessage = "";
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var ddlInstrumentType = document.getElementById("<%=ddlInstrumentType.ClientID%>");
            var selectedIndex = ddlInstrumentType.selectedIndex;
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");

            if (ddlInstrumentType.selectedIndex == 0) {
                alert('Please select Intrument Type to continue!');
                hdnChequeStaus.value = '1';
                ddlInstrumentType.focus();
            }
            else {
                hdnChequeStaus.value = '0';
                txtChequeNo.focus();
            }

            Validate_ChequeStatus(0, hdnChequeStaus.value);
            Validate_ChequeEntry(ddlInstrumentType.value, 2);
        }

        function Validate_ChequeNo() {
            //valid=0
            //Invalid=1
            //OutStation=2
            //Otherbank=3
           // debugger;
            var ErrorMessage = "";
            var ddlInstrumentType = document.getElementById("<%=ddlInstrumentType.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var hdnDropboxID = document.getElementById("<%=hdnDropboxID.ClientID%>");

            var selectedIndex = ddlInstrumentType.selectedIndex;

            var strChequeValue = txtChequeNo.value;
            if (ddlInstrumentType.options[selectedIndex].innerText == 'Cheque') {
                if (strChequeValue.length < 6) {
                    ErrorMessage = "Invalid Cheque No! please enter again.";
                    hdnChequeStaus.value = '1';
                    ddlInstrumentType.focus();
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
                        ErrorMessage = "Invalid Cheque No Entered!";
                        hdnChequeStaus.value = '1';
                        ddlInstrumentType.focus();
                    }
                    else {
                        hdnChequeStaus.value = '0';
                    }

                }
                Validate_ChequeStatus(1, hdnChequeStaus.value);
            }

            lblMessage.innerText = ErrorMessage;
            window.scrollBy(0, 0);

            Validate_ChequeEntry(ddlInstrumentType.value, 2);
            Validate_ChequeEntry(txtChequeNo.value, 3);

        }

        function Validate_ChequeAmt() {
           // debugger;

            var ErrorMessage = "";
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var strChequeAmount = parseFloat(txtChequeAmt.value).toFixed(2);


            var sText = '';
            if (strChequeAmount.length == 0 || txtChequeAmt.value == 0) {
                alert('Cheque amount can not left blank!');
                //                ErrorMessage="Cheque amount can not left blank!";
                hdnChequeStaus.value = '1';
                txtChequeNo.focus();
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
                    ErrorMessage = "Invalid Cheque Amount Entered!";
                    hdnChequeStaus.value = '1';
                    txtChequeNo.focus();
                }
                else {
                    hdnChequeStaus.value = '0';
                }

            }
            lblMessage.innerText = ErrorMessage;
            Validate_ChequeStatus(2, hdnChequeStaus.value);
            Validate_ChequeEntry(strChequeAmount, 4);
        }


        function ChequeDate_Validate() {
           // debugger;
            var ErrorMessage = '';
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var hdnDate = document.getElementById("<%=hdnDate.ClientID%>");
            var strChequeDate = txtChequeDate.value;
            var sText = '';

            if (strChequeDate.length == 0) {
                alert("Cheque Date cannot be Blank. Enter Cheque Date to Continue");
                hdnChequeStaus.value = '1';
                txtChequeAmt.focus();
                //                idtxtChequeDate.className = "ErrorCell";
                //                idChequeDate.className = "ErrorCell";
            }

            else {

                var strtxtChequeDate = txtChequeDate.value;
                var strtxtChequeDate = strtxtChequeDate.split('/', strtxtChequeDate.length);

                var strCurrentDate = hdnDate.value;
                var strCurrentDate = strCurrentDate.split('/', strCurrentDate.length);

                var diff = 0;
                if (strtxtChequeDate.length > 0) {
                    var ChequeDate = new Date(strtxtChequeDate[2], strtxtChequeDate[1] - 1, strtxtChequeDate[0]);
                    var CurrentDate = new Date(strCurrentDate[2], strCurrentDate[1] - 1, strCurrentDate[0]);

                    var one_day = 1000 * 60 * 60 * 24;
                    diff = Math.ceil((CurrentDate.getTime() - ChequeDate.getTime()) / (one_day));
                }

                if (diff <= -1) {
                    alert('Post Dated Cheque!');
                    //                        ErrorMessage = "Post Dated Cheque!";
                    hdnChequeStaus.value = '1';
                }
                else {
                    if (diff >= 90) {
                        hdnChequeStaus.value = '1';
                    }
                    else {
                        hdnChequeStaus.value = '0';
                    }
                }


            }
            lblMessage.innerText = ErrorMessage;
            Validate_ChequeStatus(3, hdnChequeStaus.value);
            Validate_ChequeEntry(strChequeDate, 5);
        }

        function Validate_CreditCardNo(CardNo) {
           // debugger;
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
           // debugger;
            var ErrorMessage = '';
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var txtCardNo = document.getElementById("<%=txtCardNo.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblCardAmount = document.getElementById("<%=lblCardAmount.ClientID%>");
            var txtChequeAmt = document.getElementById("<%=txtChequeAmt.ClientID%>");
            var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
            var hdnIsSuspenseCheque = document.getElementById("<%=hdnIsSuspenseCheque.ClientID%>");
            var hdnBinLogoDetails = document.getElementById("<%=hdnBinLogoDetails.ClientID%>");

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
                            lblCardAmount.innerText = txtChequeAmt.value;
                            hdnChequeStaus.value = '0';
                            idtxtCardNo.className = "TableGrid";
                            IdCardSuspended.className = "TableGrid";
                            IdCardSuspended.innerText = " Valid Card ";
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
                    }

                }



            }
            lblMessage.innerText = ErrorMessage;
            Validate_ChequeStatus(4, hdnChequeStaus.value);
            Validate_ChequeEntry(txtCardNo.value, 6);//nikhil
//            if (lblMessage.innerText != '')
//             {
//                txtChequeDate.focus();
//                }
//            btnSave.disabled = false;
//            btnSave.focus();
        }

        function Validate_MICRCode() {
          //  debugger;
            var ErrorMessage = "";
            var txtMICRCode = document.getElementById("<%=txtMICRCode.ClientID%>");
            var hdnMICRDetails = document.getElementById("<%=hdnMICRDetails.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblBankName = document.getElementById("<%=lblBankName.ClientID%>");
            var lblBranchName = document.getElementById("<%=lblBranchName.ClientID%>");
            var lblCity = document.getElementById("<%=lblCity.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var strMICRCode = txtMICRCode.value;

            if (strMICRCode.length < 9) {
                alert('Please enter MICR Code to continue...!');
                //                    ErrorMessage = 'Please enter MICR Code to continue...!';
                txtMICRCode.focus();
            }
            else (strMICRCode.length == 9)
            {

                var strOutPut = "";
                var strRowDetails = "";
                var strColDetails = "";

                var strhdvValue = hdnMICRDetails.value;

                strRowDetails = strhdvValue.split('^', strhdvValue.length);
                var i = 0;
                var j = 0;
                var strRowlength = 0;
                var valueFound = 0;
                for (i = 0; i <= strRowDetails.length - 2; i++) {
                    strColDetails = strRowDetails[i];
                    strColDetails = strColDetails.split('|', strColDetails.length);

                    if (txtMICRCode.value == strColDetails[0]) {
                        lblBankName.innerText = strColDetails[1];
                        lblBranchName.innerText = strColDetails[2];
                        lblCity.innerText = strColDetails[3];
                        valueFound = valueFound + 1;
                        hdnChequeStaus.value = '0';
                        break;
                    }
                }
                if (valueFound == 0) {
                    alert('MICR Code not Validate Correctly!');
                    //                        ErrorMessage = 'MICR Code not Validate Correctly!';
                    lblBankName.innerText = '';
                    lblBranchName.innerText = '';
                    lblCity.innerText = '';
                    hdnChequeStaus.value = '1';
                    txtMICRCode.focus();
                }

            }

            lblMessage.innerText = ErrorMessage;
            window.scrollBy(0, 0);
            Validate_ChequeStatus(5, hdnChequeStaus.value);
            Validate_ChequeEntry(txtMICRCode.value, 7);
        }

        function Validate_AccountNo() {
           // debugger;
            var ErrorMessage = '';
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var txtAcountNo = document.getElementById("<%=txtAcountNo.ClientID%>");
            var txtMICRCode = document.getElementById("<%=txtMICRCode.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            if (txtAcountNo.value == '') {
                alert('Account No not Entered!');
                //                ErrorMessage='Account No not Entered!';
                hdnChequeStaus.value = '1';
                txtMICRCode.focus();
            }
            else {
                hdnChequeStaus.value = '0';
            }

            lblMessage.innerText = ErrorMessage;
            Validate_ChequeStatus(6, hdnChequeStaus.value);
            Validate_ChequeEntry(txtAcountNo.value, 8);
        }

        function Validate_Signature() {
           // debugger;
            var ErrorMessage = '';
            var ddlSignature = document.getElementById("<%=ddlSignature.ClientID%>");
            var hdnChequeStaus = document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var selectedIndex = ddlSignature.selectedIndex;

            if (ddlSignature.selectedIndex != 0) {
                if (ddlSignature.options[selectedIndex].innerText == 'Yes') {
                    hdnChequeStaus.value = '0';
                }
                else {
                    hdnChequeStaus.value = '1';
                }
            }
            else {
                hdnChequeStaus.value = '1';
                ErrorMessage = 'please select signature on cheque';
            }
            lblMessage.innerText = ErrorMessage;

            Validate_ChequeStatus(7, hdnChequeStaus.value);

            Validate_ChequeEntry(ddlSignature.value, 9);

        }

        function Validate_ReasonList(Value) {
            //debugger;
            var txtTransactionCode = document.getElementById("<%=txtTransactionCode.ClientID%>");
            var txtContactNo = document.getElementById("<%=txtContactNo.ClientID%>");
            var txtReceiptNo = document.getElementById("<%=txtReceiptNo.ClientID%>");
            var hdnDropboxID = document.getElementById("<%=hdnDropboxID.ClientID%>");
            var ddlReasonList = document.getElementById("<%=ddlReasonList.ClientID%>");
            var btnSave = document.getElementById("<%=btnSave.ClientID%>");

            var ReasonValue = 0;
            if (ddlReasonList.selectedIndex != 0) {
                ReasonValue = ddlReasonList.value;
            }


            if (Value == 2) {
                Validate_ChequeEntry(txtTransactionCode.value, 11);
            }
            else if (Value == 3) {
                Validate_ChequeEntry(txtContactNo.value, 12);
            }
            else if (Value == 4) {
                Validate_ChequeEntry(txtReceiptNo.value, 13);

            }
            Validate_ChequeEntry(ReasonValue, 10);
            //            if (Value == 4) 
            //            {
            //                btnSave.focus();
            //            }
            //Validate_ChequeEntry(hdnDropboxID.value,1); 


        }

        function Disable_UserControls(Value)
         {
            var btnModify = document.getElementById("<%=btnModify.ClientID%>");
            var ddlInstrumentType=document.getElementById("<%=ddlInstrumentType.ClientID%>");                              
            var ddlSignature=document.getElementById("<%=ddlSignature.ClientID%>");                                          
            var ddlReasonList=document.getElementById("<%=ddlReasonList.ClientID%>");                              
            var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>"); 
            var txtChequeAmt=document.getElementById("<%=txtChequeAmt.ClientID%>");                              
            var txtChequeDate=document.getElementById("<%=txtChequeDate.ClientID%>");                                          
            var txtCardNo=document.getElementById("<%=txtCardNo.ClientID%>");                              
            var txtMICRCode=document.getElementById("<%=txtMICRCode.ClientID%>"); 
            var txtAcountNo=document.getElementById("<%=txtAcountNo.ClientID%>");                              
            var txtTransactionCode=document.getElementById("<%=txtTransactionCode.ClientID%>");                              
            var txtContactNo=document.getElementById("<%=txtContactNo.ClientID%>");                              
            var txtReceiptNo=document.getElementById("<%=txtReceiptNo.ClientID%>");  
            var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");  
              
            ddlInstrumentType.disabled=Value;
            ddlSignature.disabled=Value;
            ddlReasonList.disabled=Value;
            txtChequeNo.disabled=Value;            
            txtChequeAmt.disabled=Value;
            txtChequeDate.disabled=Value;            
            txtCardNo.disabled=Value;
            txtMICRCode.disabled=Value;
            txtAcountNo.disabled=Value;
            txtTransactionCode.disabled=Value;            
            txtContactNo.disabled=Value;
            txtReceiptNo.disabled=Value;
            txtRemark.disabled=Value;

            btnModify.disabled = Value;
        
        }
        
       
      
      
        
       
        function Validate_Save()
        {
           // debugger;
            var ErrorMessage=''; 
            var returnValue=true;
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");                                        
            var ddlDropBoxList=document.getElementById("<%=ddlDropBoxList.ClientID%>");
            var ddlInstrumentType=document.getElementById("<%=ddlInstrumentType.ClientID%>");                             
            var txtCardNo=document.getElementById("<%=txtCardNo.ClientID%>");
            var txtAcountNo=document.getElementById("<%=txtAcountNo.ClientID%>");
            var ddlSignature=document.getElementById("<%=ddlSignature.ClientID%>");
            var hdnTransactionDetailID=document.getElementById("<%=hdnTransactionDetailID.ClientID%>");
            var hdnChequeStaus=document.getElementById("<%=hdnChequeStaus.ClientID%>");
            var strDropBoxDetails='';        
            var strRowDetails="";
            var ddlReasonList=document.getElementById("<%=ddlReasonList.ClientID%>");                              
            
            
          
            strDropBoxDetails=ddlDropBoxList.value; 
            strRowDetails=strDropBoxDetails.split('|', strDropBoxDetails.length); 

            Validate_ChequeStatus(8,0); 
            
            if (ddlDropBoxList.selectedIndex==0)
            {
                returnValue=false;
                ErrorMessage='Please select Valid Dropbox to continue!';
                ddlDropBoxList.focus();
            }
//            else if ((strRowDetails[3]== strRowDetails[2])&&(hdnTransactionDetailID.value=='0'))
//            {    
//                returnValue=false;
//                ErrorMessage='All Cheques captured for selected Dropbox!';
//                ddlDropBoxList.focus();
//            }
            else 
            {
                if  (ddlInstrumentType.selectedIndex==0)
                {
                    returnValue=false;
                    ErrorMessage='Please select Intrument Type to continue!';
                    ddlInstrumentType.focus();
                }
                if (txtCardNo.value=='')
                {
                    returnValue=false;
                    ErrorMessage='Please Enter Card No to continue!';
                    txtCardNo.focus(); 
                }
                if (ddlSignature.selectedIndex==0)
                {   
                    returnValue=false;
                    ErrorMessage='Please select Signature on Cheque to continue!';
                    ddlSignature.focus();                 
                }
            }
            
            if ((hdnChequeStaus.value=='1')&&(ddlReasonList.selectedIndex==0))            
            {
                 returnValue=false;
                 ErrorMessage='Please Select Invalid Cheque Reason!';
                 ddlReasonList.focus();   
            }
            
                        
            lblMessage.innerText=ErrorMessage;
            return returnValue; 
        }   
    
        
        
        function Validate_ChequeStatus(ArrayNo,value) {
           // debugger;
            ChequeStatus[ArrayNo]=value;
                        
            var hdnChequeStaus=document.getElementById("<%=hdnChequeStaus.ClientID%>");                              
            var lblChequeStatus=document.getElementById("<%=lblChequeStatus.ClientID%>");                              
            var ddlReasonList=document.getElementById("<%=ddlReasonList.ClientID%>");                              
            
            var i=0;
            var finalValue=0;
            for (i=0;i<=ChequeStatus.length;i++)
            {   
                var ChequeType=ChequeStatus[i];
                if (ChequeType=='1')
                {
                    finalValue=finalValue+1;
                }
            }
            
            if (finalValue>0)
            {
              hdnChequeStaus.value=1;      
            }
            else
            {
              hdnChequeStaus.value=0;      
            }
            
            if (hdnChequeStaus.value=='0')
            {
                lblChequeStatus.innerText='Valid';
                ddlReasonList.disabled=true;
            }
            else
            {
                lblChequeStatus.innerText='Invalid';
                ddlReasonList.disabled=false;
            }  
        }
        
 
            
        
             
    </script>

    <table>
        <tr>
            <td colspan="8" style="height: 15px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 21px">
                &nbsp;&nbsp; Validate
                Cheque Data Entry
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="TableTitle">
                &nbsp;<strong>Batch No </strong>
            </td>
            <td class="TableGrid" style="width: 100px;">
                <asp:TextBox ID="txtBatchNo" runat="server" BorderWidth="1px" ReadOnly="True" Width="158px"
                    SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;<strong>BatchDate</strong></td>
            <td class="TableGrid" colspan="2">
                &nbsp;<asp:Label ID="lblBatchDate" runat="server" Width="70px"></asp:Label></td>
            <td style="width: 100px;" class="TableTitle">
                &nbsp;No Of ChequeCaptured</td>
            <td class="TableGrid" style="width: 100px;">
                <asp:Label ID="lblNoOfCheque" runat="server" Width="70px"></asp:Label></td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;Drop Box Code</td>
            <td style="width: 100px;" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 137px; height: 10px;">
                    <tr>
                        <td style="height: 30px;">
                            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                            <asp:DropDownList ID="ddlDropBoxList" runat="server" SkinID="ddlSkin" 
                                AutoPostBack="True" 
                                OnSelectedIndexChanged="ddlDropBoxList_SelectedIndexChanged" 
                                ViewStateMode="Enabled">
                            </asp:DropDownList>
                            <%--  </ContentTemplate>
                            </asp:UpdatePanel>--%>
                            </td>
                        <td style="width: 100px; height: 30px;">
                            <input id="chkLockDropBox" type="checkbox" onkeydown="javascript:if(event.keyCode==13) {event.keyCode=9};LockSelection('2');" onclick="javascript:LockSelection('2');"/>
                            Freeze</td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;DropBoxName</td>
            <td class="TableGrid" colspan="2">
                &nbsp;<asp:Label ID="lblDropBoxName" runat="server" Width="251px" 
                    ViewStateMode="Enabled"></asp:Label></td>
            <td style="width: 100px;" class="TableTitle">
                &nbsp;DropBoxChequeCaptured
            </td>
            <td class="TableGrid" style="width: 100px;">
                <asp:Label ID="lblTotalChqueCapture" runat="server" Width="70px"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">
                &nbsp;Card and Personal Details</td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;InstrumentType</td>
            <td class="TableGrid" style="width: 100px;">
                <asp:DropDownList ID="ddlInstrumentType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableTitle">
                &nbsp;CheuqeNo</td>
            <td class="TableGrid">
                <asp:TextBox ID="txtChequeNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="74px"
                    MaxLength="6"></asp:TextBox></td>
            <td class="TableTitle" style="width: 45px">
                &nbsp;ChequeAmt</td>
            <td style="width: 100px;" class="TableGrid">
                <asp:TextBox ID="txtChequeAmt" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="99px" ontextchanged="txtChequeAmt_TextChanged"></asp:TextBox></td>
            <td style="width: 100px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;ChequeDate</td>
            <td style="width: 100px" class="TableGrid">
                <table cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            &nbsp;<img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;ChequeCaptureUser&nbsp; &nbsp; &nbsp;</td>
            <td class="TableGrid" colspan="4">
                &nbsp;<asp:Label ID="lblChequeCapturedByUser" runat="server" SkinID="LabelSkin" Width="70px"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;<strong>Card No. *</strong></td>
            <td style="width: 100px" class="TableGrid" id="idtxtCardNo">
                <asp:TextBox ID="txtCardNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px"
                    MaxLength="16"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;Card Status</td>
            <td class="TableGrid" id="IdCardSuspended">
            </td>
            <td class="TableTitle">
                &nbsp;Card Amount</td>
            <td class="TableGrid" colspan="2">
                &nbsp;<asp:Label ID="lblCardAmount" runat="server" SkinID="LabelSkin" Width="71px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 1px">
            </td>
            <td class="TableTitle" style="height: 1px">
                &nbsp;<strong>MICRCode *</strong></td>
            <td class="TableGrid" style="width: 100px; height: 1px;">
                <asp:TextBox ID="txtMICRCode" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px"
                    MaxLength="9" Enabled="False"></asp:TextBox></td>
            <td class="TableTitle" style="height: 1px">
                &nbsp;Bank</td>
            <td class="TableGrid" style="height: 1px">
                &nbsp;<asp:Label ID="lblBankName" runat="server" SkinID="LabelSkin" Width="152px"></asp:Label></td>
            <td class="TableTitle" style="height: 1px; width: 45px;">
                &nbsp;Branch</td>
            <td class="TableGrid" colspan="2" style="height: 1px">
                <asp:Label ID="lblBranchName" runat="server" SkinID="LabelSkin" Width="284px"></asp:Label></td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;Account No</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtAcountNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px"
                    MaxLength="16" Enabled="False"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;City</td>
            <td class="TableGrid">
                &nbsp;<asp:Label ID="lblCity" runat="server" SkinID="LabelSkin" Width="164px"></asp:Label></td>
            <td class="TableTitle" style="width: 45px">
                &nbsp;ChequeStatus</td>
            <td class="TableGrid" colspan="2">
                <asp:Label ID="lblChequeStatus" runat="server" SkinID="LabelSkin" Width="232px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Signature</td>
            <td class="TableGrid" style="width: 100px; height: 24px">
                <asp:DropDownList ID="ddlSignature" runat="server" SkinID="ddlSkin" 
                    Enabled="False">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Reason</td>
            <td class="TableGrid" style="height: 24px" colspan="4">
                <asp:DropDownList ID="ddlReasonList" runat="server" SkinID="ddlSkin" 
                    Enabled="False">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;TransactionCode</td>
            <td class="TableGrid" style="width: 100px; height: 24px;">
                <asp:TextBox ID="txtTransactionCode" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="120px" MaxLength="2" Enabled="False"></asp:TextBox></td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Contact No</td>
            <td class="TableGrid" style="height: 24px">
                <asp:TextBox ID="txtContactNo" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="120px" MaxLength="10" Enabled="False"></asp:TextBox></td>
            <td class="TableTitle" style="height: 24px; width: 45px;">
                &nbsp;ReceiptNo</td>
            <td class="TableGrid" colspan="2" style="height: 24px">
                <asp:TextBox ID="txtReceiptNo" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="120px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 46px">
            </td>
            <td class="TableTitle" style="height: 46px">
                &nbsp;Remarks</td>
            <td class="TableGrid" colspan="5" style="height: 46px">
                <asp:TextBox ID="txtRemark" runat="server" BorderWidth="1px" Height="36px" MaxLength="500"
                    SkinID="txtSkin" Width="556px" Enabled="False"></asp:TextBox></td>
            <td style="width: 100px; height: 46px;">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 38px">
                &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" OnClick="btnSave_Click"
                    Text="Save" Width="59px" />
                &nbsp;<asp:Button ID="btnModify" runat="server" onclick="btnModify_Click" 
                    Text="Modify" BorderWidth="1px" Width="59px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" OnClick="btnCancel_Click" />
                &nbsp;<asp:Button ID="btnBackToSearch" runat="server" BorderWidth="1px" Text="Back to View Search"
                    OnClick="btnBackToSearch_Click" Width="128px" /></td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:HiddenField ID="hdnDate" runat="server" />
                <asp:HiddenField ID="hdnTransactionDetailID" runat="server" />
                <asp:HiddenField ID="hdnC" runat="server" />
                <asp:HiddenField ID="hdnChqCount" runat="server" />
                <asp:HiddenField ID="hdnTotalChqs" runat="server" />
                <asp:HiddenField ID="hdnT" runat="server" />
                <asp:HiddenField ID="hdnChequeStaus" runat="server" />
                <asp:HiddenField ID="hdnMICRDetails" runat="server" />
                <asp:HiddenField ID="hdnTID" runat="server" />
                <asp:HiddenField ID="hdnEntryStart" runat="server" />
                <asp:HiddenField ID="hdnDepositDate" runat="server" />              
                <asp:HiddenField ID="hdnIsSuspenseCheque" runat="server" Value="0" />
                <asp:HiddenField ID="hdnDropboxID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnValidateChequeEntry" runat="server" Value="" />
                <asp:HiddenField ID="hdnValue" runat="server" Value="true" />
                <asp:HiddenField ID="hdnBinLogoDetails" runat="server" />
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
