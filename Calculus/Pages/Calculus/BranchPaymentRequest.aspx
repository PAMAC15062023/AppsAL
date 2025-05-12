<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="BranchPaymentRequest.aspx.cs" Inherits="Pages_Calculus_BranchPaymentRequest"
    Title="Branch Payment Request" StylesheetTheme="SkinFile" Theme="SkinFile" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>

    <script language="javascript" type="text/javascript">



        function Auto_Remark() {
            var strRemark = ' ';
            var ddlAccountHeadList = document.getElementById("<%=ddlAccountHeadList.ClientID%>");
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");
            var txtBillNo = document.getElementById("<%=txtBillNo.ClientID%>");
            var txtMobile_TelNo = document.getElementById("<%=txtMobile_TelNo.ClientID%>");

            var lblbranch = document.getElementById("<%=lblbranch.ClientID%>");
            var lblRegionCluster = document.getElementById("<%=lblRegionCluster.ClientID%>");
            var ddlActivityList = document.getElementById("<%=ddlActivityList.ClientID%>");

            var Index_AccHead = ddlAccountHeadList.selectedIndex;
            var Index_Activity = ddlActivityList.selectedIndex;


            if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Advertising and Sales Promotion') {
                strRemark = strRemark + "Advertising and Sales Promotion for ____ for the Period _____ agst bill no: " + txtBillNo.value + "for Activity (" + ddlActivityList.options[Index_Activity].innerText + ") for Branch (" + lblbranch.innerText + "), Cluster (" + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Brokerage & Commission') {

                strRemark = strRemark + "Brokerage for __ of Branch(" + lblbranch.innerText + "), Cluster(" + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Conveyance Expenses') {
                strRemark = strRemark + "Being amount paid towards Conveyance of (Name) for (purpose) for the (period) for(" + ddlActivityList.options[Index_Activity].innerText + ") for(" + lblbranch.innerText + ") (" + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Courier Charges') {
                strRemark = strRemark + "Courier Charges for the (Period) agst (" + txtBillNo.value + ") for(" + ddlActivityList.options[Index_Activity].innerText + "), for(" + lblbranch.innerText + "),(" + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Electricity Expenses') {
                strRemark = strRemark + "Electricity exps for the (period) for(" + lblbranch.innerText + "), (" + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Email / Internet Charges') {
                strRemark = strRemark + "Email / Internet Charges of (office) for the (period) for (" + ddlActivityList.options[Index_Activity].innerText + ")(" + lblbranch.innerText + ")(" + lblRegionCluster.innerText + ".)";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Fixed Assets') {
                strRemark = strRemark + "Fixed Asset (Asset Name) agst (" + txtBillNo.value + "), (Bill dtd), for(" + ddlActivityList.options[Index_Activity].innerText + ") for(" + lblbranch.innerText + ") (" + lblRegionCluster.innerText + ".)";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Computer Hire Charges') {
                strRemark = strRemark + "computer hire charges for (No of) systems for(" + ddlActivityList.options[Index_Activity].innerText + ") for the month of (Period),(" + lblbranch.innerText + "),(" + lblRegionCluster.innerText + ") OR Furniture hire charges for (office) ( " + ddlActivityList.options[Index_Activity].innerText + ") for the month of (Period),( " + lblbranch.innerText + "),( " + lblRegionCluster.innerText + ") OR Generator hire charges for (office) for ( " + ddlActivityList.options[Index_Activity].innerText + " ) for the month of (Period),( " + lblbranch.innerText + " ),( " + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Insurance Expenses') {
                strRemark = strRemark + "Being amount paid towards Insurance  Premium of Policy No (__)for the (period) for (" + ddlActivityList.options[Index_Activity].innerText + ")(" + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Dox Verification Expenses') {
                strRemark = strRemark + "Being amount paid to (name) towards ITR / Dox Verification Exps of (case) for(" + ddlActivityList.options[Index_Activity].innerText + "),(" + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Motor Car Expenses') {
                strRemark = strRemark + "Being amount paid towards (Exps details) for( " + ddlActivityList.options[Index_Activity].innerText + "),(" + lblRegionCluster.innerText + ")";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Profession Tax') {
                strRemark = strRemark + "Being amount paid towards Profession Tax for the month of (Period), ( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " )";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Office Rent') {
                strRemark = strRemark + "Rent for the month of ____ for Branch ( " + lblbranch.innerText + " ), Cluster ( " + lblRegionCluster.innerText + " )";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'ROC Expenses') {
                strRemark = strRemark + "Being amount paid towards ROC Charges( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " )";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Security Charges') {
                strRemark = strRemark + "Security Charges for the (period) for (" + ddlActivityList.options[Index_Activity].innerText + " ),( " + lblbranch.innerText + " ),( " + lblRegionCluster.innerText + " )";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Society Maintenance Charges') {
                strRemark = strRemark + "Society Maintenance Charges for the month of ___ for Branch ( " + lblbranch.innerText + " ), Cluster ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Staff Welfare Expenses') {
                strRemark = strRemark + "(Nature) Charges for the (Period) agst (" + txtBillNo.value + ") for( " + ddlActivityList.options[Index_Activity].innerText + ") for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Communication Cost') {
                strRemark = strRemark + "Communication Cost expenses of (Ph.no." + txtMobile_TelNo.value + "), for the (period ) for(" + ddlActivityList.options[Index_Activity].innerText + " ), for ( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " )";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Travelling Expenses') {
                strRemark = strRemark + "Travelling exps of (Name),  from(Place) to (place) for the period ___ ( " + ddlActivityList.options[Index_Activity].innerText + "), for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " )";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Office Deposit') {
                strRemark = strRemark + "Office Deposit for(office details) for(" + ddlActivityList.options[Index_Activity].innerText + ") for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Rates & Taxes') {
                strRemark = strRemark + "(Purpose),(in favour of) (Location), for( " + ddlActivityList.options[Index_Activity].innerText + " ) for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Registration Charges') {
                strRemark = strRemark + "Registration Charges of (office details), (Location),for (" + ddlActivityList.options[Index_Activity].innerText + " ) for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Security Charges') {
                strRemark = strRemark + "Security Deposit for (purpose) of (office details) (Location),for (" + ddlActivityList.options[Index_Activity].innerText + ") for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Software Exps') {
                strRemark = strRemark + "Administrator Salary for the (period) (Location),for( " + ddlActivityList.options[Index_Activity].innerText + " ) for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ). OR New Software (name) purchased for office details , (Location), for (Activity) for(Branch), (Cluster).";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Travelling Expenses') {
                strRemark = strRemark + "Transportation Charges for (purpose), (Location), for(" + ddlActivityList.options[Index_Activity].innerText + " ) for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }
            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Computer Peripherals') {
                strRemark = strRemark + "Computer Stationery (Product)(Location), for( " + ddlActivityList.options[Index_Activity].innerText + " ) for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'Membership & Subscription') {
                strRemark = strRemark + "Membership & Subscription of (purpose)  (Location), for(" + ddlActivityList.options[Index_Activity].innerText + ") for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }

            else if (ddlAccountHeadList.options[Index_AccHead].innerText == 'PMWP') {
                strRemark = strRemark + "Being amount paid towards PMWP Payment of (Pamacian Name) for( " + lblbranch.innerText + " ), ( " + lblRegionCluster.innerText + " ).";
                txtRemark.innerText = strRemark;
            }

            var txtEmpCode = document.getElementById("<%=txtEmpCode.ClientID%>"); //add on 04/03/2024

            var TransRefNoDDL = document.getElementById("<%=TransRefNoDDL.ClientID%>");  //add by Rutu on 18/11/23

        }



        function openwindow() {
            window.open('ViewOpeningBalanceByBranch.aspx', '_blank', 'height=350px,width=700px,status=yes,resizable=yes');
        }

        function Get_PanNo() {
            ////debugger;
            var ddlVenderList = document.getElementById("<%=ddlVenderList.ClientID%>");
            var txtPanCard = document.getElementById("<%=txtPanCard.ClientID%>");
            //var selectedIndex_Vender=parseInt(ddlVenderList.selectedIndex);

            var selectedIndex_Vender = ddlVenderList.value;

            Vender_details = selectedIndex_Vender.split(':', selectedIndex_Vender.length)
            var VenderID = Vender_details[0];
            var PanNo = '';
            if (Vender_details.length > 1) {
                PanNo = Vender_details[1];
            }
            txtPanCard.innerText = PanNo;

        }

        function TotalReqAmountCalculation() {
            ////debugger;       
            var lblTotalRequestedAmount = document.getElementById("<%=lblTotalRequestedAmount.ClientID%>");
            var hdnSavingPaymentDetails = document.getElementById("<%=hdnSavingPaymentDetails.ClientID%>");
            var MainTab = document.getElementById("MainTab");
            var i = 0;
            var TotalAmt = 0;

            for (i = 0; i <= MainTab.rows.length - 1; i++) {
                if (i != 0) {
                    TotalAmt = TotalAmt + parseFloat(MainTab.rows[i].cells[18].innerText);
                }
            }

            lblTotalRequestedAmount.innerText = TotalAmt;
            hdnSavingPaymentDetails.value = TotalAmt;
        }
        function Page_load_validation() {
            var hdnChequeDetails = document.getElementById("<%=hdnPaymentDetails.ClientID%>");
            RenderTable(hdnChequeDetails.value);

        }
        function Validate_Headers() {
            ////debugger
            var ReturnValue = true;
            var ErrorMessage = "";
            var lblError = document.getElementById("<%=lblError.ClientID%>");
            var MainTab = document.getElementById("MainTab");
            var lblAvailableAmt = document.getElementById("<%=lblAvailableAmt.ClientID%>");
            var lblTotalRequestedAmount = document.getElementById("<%=lblTotalRequestedAmount.ClientID%>");
            var txtPaymentDate = document.getElementById("<%=txtPaymentDate.ClientID%>");

            var TotalRequestedAmount = parseFloat(lblTotalRequestedAmount.innerText);
            var AvailableAmt = parseFloat(lblAvailableAmt.innerText);

            if (TotalRequestedAmount > AvailableAmt) {
                ErrorMessage = "Requested Amount is Exceed the limit!";
                ReturnValue = false;

            }


            else if (txtPaymentDate.value == '') {
                ErrorMessage = "Please Enter Request date to continue...!";
                ReturnValue = false;
                txtPaymentDate.focus();
            }

            else if (MainTab.rows.length == 1) {
                ErrorMessage = "Please Enter Payment Request Details to continue...!";
                ReturnValue = false;

            }
            window.scroll(0, 0);
            lblError.innerText = ErrorMessage;
            return ReturnValue;
        }
        function Clear_PaymentDetails() {
            var ddlVenderList = document.getElementById("<%=ddlVenderList.ClientID%>");
            var txtBillNo = document.getElementById("<%=txtBillNo.ClientID%>");
            var txtBillDate = document.getElementById("<%=txtBillDate.ClientID%>");
            var txtBillAmt = document.getElementById("<%=txtBillAmt.ClientID%>");
            var ddlServiceTax = document.getElementById("<%=ddlServiceTax.ClientID%>");
            var txtPayeeNameSearch = document.getElementById("<%=txtPayeeNameSearch.ClientID%>");
            var ddlServiceTax = document.getElementById("<%=ddlServiceTax.ClientID%>");
            var ddlTaxtype = document.getElementById("<%=ddlTaxtype.ClientID%>");
            var ddladjusttype = document.getElementById("<%=ddladjusttype.ClientID%>");
            var txtServiceTaxAmt = document.getElementById("<%=txtServiceTaxAmt.ClientID%>");
            var txtServiceTaxAmt1 = document.getElementById("<%=txtServiceTaxAmt1.ClientID%>");
            var txtServiceTaxRegNo = document.getElementById("<%=txtServiceTaxRegNo.ClientID%>");

            var ddlAccountHeadList = document.getElementById("<%=ddlAccountHeadList.ClientID%>");
            var txtEmpCode = document.getElementById("<%=txtEmpCode.ClientID%>"); //add on 04/03/2024
            var TransRefNoDDL = document.getElementById("<%=TransRefNoDDL.ClientID%>"); //add by Rutu on 18/11/23

            var txtMobile_TelNo = document.getElementById("<%=txtMobile_TelNo.ClientID%>");
            var txtDuedate = document.getElementById("<%=txtDuedate.ClientID%>");
            var txtDueAmount = document.getElementById("<%=txtDueAmount.ClientID%>");
            var txtPanCard = document.getElementById("<%=txtPanCard.ClientID%>");
            var ddlIsReimbursable = document.getElementById("<%=ddlIsReimbursable.ClientID%>"); //added by omkar 30072020
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");

            var ddlActivityList = document.getElementById("<%=ddlActivityList.ClientID%>");
            var ddlProductList = document.getElementById("<%=ddlProductList.ClientID%>");
            var ddlVerticalList = document.getElementById("<%=ddlVerticalList.ClientID%>");

            ddlActivityList.selectedIndex = 0;
            ddlProductList.selectedIndex = 0;
            ddlVerticalList.selectedIndex = 0;
            ddladjusttype.selectedIndex = 0;
            ddlTaxtype.selectedIndex = 0;
            ddlVenderList.selectedIndex = 0;
            TransRefNoDDL.selectedIndex = 0;  //add by Rutu on 18/11/23
            txtEmpCode.value = ""; //add on 04/03/2024
            txtBillNo.value = '';
            txtPayeeNameSearch.value = '';
            txtBillDate.value = '';
            txtBillAmt.value = '';
            ddlServiceTax.selectedIndex = 0;
            txtServiceTaxAmt.value = '';
            txtServiceTaxRegNo.value = '';
            ddlAccountHeadList.selectedIndex = 0;
            txtMobile_TelNo.value = '';
            txtDuedate.value = '';
            txtDueAmount.value = '';

            txtPanCard.value = '';
            ddlIsReimbursable.selectedIndex = 0;
            txtRemark.value = '';
            txtDueAmount.value = '';
            txtServiceTaxAmt1.value = '';




        }
        function ValidateGrid()// add by:Manswini 08-Nov-2014
        {

            debugger;
            var ReturnValue = true;
            var ErrorMessage = "";
            var txtPaymentDate = document.getElementById("<%=txtPaymentDate.ClientID%>");

            var ddlActivityList = document.getElementById("<%=ddlActivityList.ClientID%>");
            var ddlProductList = document.getElementById("<%=ddlProductList.ClientID%>");
            var ddlVerticalList = document.getElementById("<%=ddlVerticalList.ClientID%>");


            var ddlVenderList = document.getElementById("<%=ddlVenderList.ClientID%>");
            var txtBillNo = document.getElementById("<%=txtBillNo.ClientID%>");
            var txtBillDate = document.getElementById("<%=txtBillDate.ClientID%>");
            var txtBillAmt = document.getElementById("<%=txtBillAmt.ClientID%>");
            var ddlServiceTax = document.getElementById("<%=ddlServiceTax.ClientID%>");

            var ddladjusttype = document.getElementById("<%=ddladjusttype.ClientID%>");

            var txtServiceTaxAmt = document.getElementById("<%=txtServiceTaxAmt.ClientID%>");
            var txtServiceTaxRegNo = document.getElementById("<%=txtServiceTaxRegNo.ClientID%>");

            var ddlAccountHeadList = document.getElementById("<%=ddlAccountHeadList.ClientID%>");

            var txtMobile_TelNo = document.getElementById("<%=txtMobile_TelNo.ClientID%>");
            var txtDuedate = document.getElementById("<%=txtDuedate.ClientID%>");
            var txtDueAmount = document.getElementById("<%=txtDueAmount.ClientID%>");
            var txtPanCard = document.getElementById("<%=txtPanCard.ClientID%>");
            var ddlIsReimbursable = document.getElementById("<%=ddlIsReimbursable.ClientID%>"); //added by omkar 30072020
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");

            var txtEmpCode = document.getElementById("<%=txtEmpCode.ClientID%>"); //add on 04/03/2024
            var TransRefNoDDL = document.getElementById("<%=TransRefNoDDL.ClientID%>"); //add by Rutu on 18/11/23

            var lblError = document.getElementById("<%=lblError.ClientID%>");

            if (ddlVerticalList.selectedIndex == 0) {
                ErrorMessage = "Please select Vertical to continue...!";
                ReturnValue = false;
                ddlVerticalList.focus();
            }
            else if (ddlActivityList.selectedIndex == 0) {
                ErrorMessage = "Please Activity Payee to continue...!";
                ReturnValue = false;
                ddlActivityList.focus();
            }
            else if (ddlVenderList.selectedIndex == 0) {
                ErrorMessage = "Please select Payee to continue...!";
                ReturnValue = false;
                ddlVenderList.focus();
            }
            else if (txtBillNo.value == '') {
                ErrorMessage = "Please Enter Bill No to continue...!";
                ReturnValue = false;
                txtBillNo.focus();
            }
            else if (txtBillDate.value == '') {
                ErrorMessage = "Please Enter Bill Date to continue...!";
                ReturnValue = false;
                txtBillDate.focus();
            }
            else if (txtBillAmt.value == '0.00') {
                ErrorMessage = "Please Enter Bill Amount to continue...!";
                ReturnValue = false;
                txtBillAmt.focus();
            }
            else if (txtBillAmt.value == '') {
                ErrorMessage = "Please Enter Bill Amount to continue...!";
                ReturnValue = false;
                txtBillAmt.focus();
            }
            else if (ddlServiceTax.selectedIndex == 0) {
                ErrorMessage = "Please select Service Tax  to continue...!";
                ReturnValue = false;
                ddlServiceTax.focus();
            }
            else if (ddlProductList.selectedIndex == 0) {
                ErrorMessage = "Please select Product to continue...!";
                ReturnValue = false;
                ddlProductList.focus();
            }

            else if (ddladjusttype.selectedIndex == 0) {
                ErrorMessage = "Please select Adjustment Type to continue...!";
                ReturnValue = false;
                ddladjusttype.focus();
            }


            else if (ddlAccountHeadList.selectedIndex == 0) {
                ErrorMessage = "Please select Account Head to continue...!";
                ReturnValue = false;
                ddlAccountHeadList.focus();
            }

            else if (txtDuedate.value != '') {
                if (txtDueAmount.value == '') {
                    ErrorMessage = "Please enter Due Date Amount to continue...!";
                    ReturnValue = false;
                    txtDueAmount.focus();
                }
            }

            if (txtBillDate.value != '') {
                var strtxtBillDate = txtBillDate.value;
                var strtxtBillDate = strtxtBillDate.split('/', strtxtBillDate.length);
                var diff = 0;
                if (strtxtBillDate.length > 0) {
                    var BillDate = new Date(strtxtBillDate[2], strtxtBillDate[1] - 1, strtxtBillDate[0]);
                    today = new Date();

                    var one_day = 1000 * 60 * 60 * 24;
                    diff = Math.ceil((today.getTime() - BillDate.getTime()) / (one_day));
                }
                if (diff < 0) {
                    ErrorMessage = "You Cannot Enter Post Bill Date!";
                    ReturnValue = false;
                    txtBillDate.focus();
                }
            }
            else if (txtDuedate.value != '') {
                if (txtDueAmount.value == '') {
                    ErrorMessage = "Please enter Due Date Amount to continue...!";
                    ReturnValue = false;
                    txtDueAmount.focus();
                }
            }

            if (ddlAccountHeadList.selectedIndex == 55) //add by Rutu on 18/11/23 
            {
                if (TransRefNoDDL.selectedIndex == 0) {
                    ErrorMessage = "Please select Trans Ref No to continue...!";
                    ReturnValue = false;
                    TransRefNoDDL.focus();
                }
                if (txtEmpCode.Text == '') {
                    ErrorMessage = "Please enter Emp Code to continue...!";
                    ReturnValue = false;
                    txtEmpCode.Text.focus();
                }
            }


            window.scroll(0, 0);
            lblError.innerText = ErrorMessage;
            return ReturnValue;
        }
        //--------comp----------------
        function CalulateTax() {
            var txtBillAmt = document.getElementById("<%=txtBillAmt.ClientID%>");
            var ddlServiceTax = document.getElementById("<%=ddlServiceTax.ClientID%>");
            var txtServiceTaxAmt = document.getElementById("<%=txtServiceTaxAmt.ClientID%>");
            var txtServiceTaxAmt1 = document.getElementById("<%=txtServiceTaxAmt1.ClientID%>");
            var ddlTaxtype = document.getElementById("<%=ddlTaxtype.ClientID%>");

            var ddladjusttype = document.getElementById("<%=ddladjusttype.ClientID%>");

            var ErrorMessage = "";
            var lblError = document.getElementById("<%=lblError.ClientID%>");
            var txtServiceTaxRegNo = document.getElementById("<%=txtServiceTaxRegNo.ClientID%>");


            if (txtBillAmt.value != '') {
                var regex1 = /^\d{1,9}|[.]{1,1}|\d{1,2}$/;  //this is the pattern of regular expersion
                if (regex1.test(txtBillAmt.value) == false) {
                    ErrorMessage = "Please Enter numeric to continue...!";
                    txtBillAmt.value = '0.00';
                    //txtBillAmt.focus();   
                }
            }

            if (ddlServiceTax.selectedIndex != 0 && ddlTaxtype.selectedIndex == 1) {
                var Index = parseInt(ddlServiceTax.selectedIndex);
                txtServiceTaxAmt.value = ((parseFloat(txtBillAmt.value) * parseFloat(ddlServiceTax.options[Index].innerText)) / 100)
                txtServiceTaxAmt1.value = Math.round(0)
            }
            else if (ddlServiceTax.selectedIndex != 0) {
                var Index = parseInt(ddlServiceTax.selectedIndex);
                txtServiceTaxAmt.value = ((parseFloat(txtBillAmt.value) * parseFloat(ddlServiceTax.options[Index].innerText)) / 100) / 2
                txtServiceTaxAmt1.value = ((parseFloat(txtBillAmt.value) * parseFloat(ddlServiceTax.options[Index].innerText)) / 100) / 2
            }
            else {
                txtServiceTaxAmt.value = ((parseFloat(txtBillAmt.value) * 0) / 100)
                txtServiceTaxAmt1.value = ((parseFloat(txtBillAmt.value) * 0) / 100)
            }

            lblError.innerText = ErrorMessage;
        }
        function AdjustmntAmt() {
            //debugger;
            var txtDueAmount = document.getElementById("<%=txtDueAmount.ClientID%>");
            var ddladjusttype = document.getElementById("<%=ddladjusttype.ClientID%>");

            if (ddladjusttype.value != 0 && ddladjusttype.value == 4) {
                var Index = parseInt(ddladjusttype.value);
                txtDueAmount.value = '0.00';
                txtDueAmount.disabled = true;

            }
            else {
                txtDueAmount.value = '';
                txtDueAmount.disabled = false;
            }
        }

        function RemoveColumnFromGrid() {
            var hdnChequeDetails = document.getElementById("<%=hdnPaymentDetails.ClientID%>");


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
                    strhdvValue = strhdvValue + MainTab.rows[i].cells[1].innerText + "|" + MainTab.rows[i].cells[2].innerText + "|" + MainTab.rows[i].cells[3].innerText + "|" + MainTab.rows[i].cells[4].innerText + "|" + MainTab.rows[i].cells[5].innerText + "|" + MainTab.rows[i].cells[6].innerText + "|" + MainTab.rows[i].cells[7].innerText + "|" + MainTab.rows[i].cells[8].innerText + "|" + MainTab.rows[i].cells[9].innerText + "|" + MainTab.rows[i].cells[10].innerText + "|" + MainTab.rows[i].cells[11].innerText + "|" + MainTab.rows[i].cells[12].innerText + "|" + MainTab.rows[i].cells[13].innerText + "|" + MainTab.rows[i].cells[14].innerText + "|" + MainTab.rows[i].cells[15].innerText + "|" + MainTab.rows[i].cells[16].innerText + "|" + MainTab.rows[i].cells[17].innerText + "|" + MainTab.rows[i].cells[18].innerText + "|" + MainTab.rows[i].cells[19].innerText + "|" + MainTab.rows[i].cells[20].innerText + "|" + MainTab.rows[i].cells[21].innerText + "|" + MainTab.rows[i].cells[22].innerText + "|" + MainTab.rows[i].cells[23].innerText + "|" + MainTab.rows[i].cells[24].innerText + "|" + MainTab.rows[i].cells[25].innerText + "^";
                    hdnChequeDetails.value = strhdvValue;
                }
            }

            RenderTable(strhdvValue);
            //TotalReqAmountCalculation();
            return false;
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


        function AddColumnToGrid() {
            debugger;
            if (ValidateGrid()) {

                var ddlActivityList = document.getElementById("<%=ddlActivityList.ClientID%>");
                var ddlProductList = document.getElementById("<%=ddlProductList.ClientID%>");
                var ddlVerticalList = document.getElementById("<%=ddlVerticalList.ClientID%>");

                var ddlVenderList = document.getElementById("<%=ddlVenderList.ClientID%>");
                var txtBillNo = document.getElementById("<%=txtBillNo.ClientID%>");
                var txtBillDate = document.getElementById("<%=txtBillDate.ClientID%>");
                var txtBillAmt = document.getElementById("<%=txtBillAmt.ClientID%>");
                var ddlServiceTax = document.getElementById("<%=ddlServiceTax.ClientID%>");
                var ddlTaxtype = document.getElementById("<%=ddlTaxtype.ClientID%>");
                var ddladjusttype = document.getElementById("<%=ddladjusttype.ClientID%>");
                var txtServiceTaxAmt = document.getElementById("<%=txtServiceTaxAmt.ClientID%>");
                var txtServiceTaxAmt1 = document.getElementById("<%=txtServiceTaxAmt1.ClientID %>");
                var txtServiceTaxRegNo = document.getElementById("<%=txtServiceTaxRegNo.ClientID%>");
                var hdnPaymentDetails = document.getElementById("<%=hdnPaymentDetails.ClientID%>");
                var hdnSavingPaymentDetails = document.getElementById("<%=hdnSavingPaymentDetails.ClientID%>");
                var hdnadjtyp = document.getElementById("<%=hdnadjtyp.ClientID%>");
                var ddlAccountHeadList = document.getElementById("<%=ddlAccountHeadList.ClientID%>");
                var txtMobile_TelNo = document.getElementById("<%=txtMobile_TelNo.ClientID%>");
                var txtDuedate = document.getElementById("<%=txtDuedate.ClientID%>");
                var txtDueAmount = document.getElementById("<%=txtDueAmount.ClientID%>");
                var txtPanCard = document.getElementById("<%=txtPanCard.ClientID%>");
                var ddlIsReimbursable = document.getElementById("<%=ddlIsReimbursable.ClientID%>"); //added by omkar 30072020
                var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");
                var ddladjusttype = document.getElementById("<%=ddladjusttype.ClientID%>");
                var txtEmpCode = document.getElementById("<%=txtEmpCode.ClientID%>"); //add on 04/03/2024
                var TransRefNoDDL = document.getElementById("<%=TransRefNoDDL.ClientID%>");      //add by Rutu on 18/11/23
                var MainTab = document.getElementById("MainTab");

                var selectedIndex_Activity = parseInt(ddlActivityList.selectedIndex);
                var selectedIndex_Product = parseInt(ddlProductList.selectedIndex);
                var selectedIndex_Vertical = parseInt(ddlVerticalList.selectedIndex);

                var selectedIndex_Vender = ddlVenderList.value;
                var Index = parseInt(ddlVenderList.selectedIndex);

                Vender_details = selectedIndex_Vender.split(':', selectedIndex_Vender.length)

                var VenderID = Vender_details[0];

                var selectedIndex_ServiceTax = parseInt(ddlServiceTax.selectedIndex);
                var selectedIndex_AccountHeadList = parseInt(ddlAccountHeadList.selectedIndex);



                if (ddlAccountHeadList.selectedIndex == 55) {
                    var txtEmpCode = document.getElementById("<%=txtEmpCode.ClientID%>"); //add on 04/03/2024
                    var selectedIndex_TransRefNoDDL = TransRefNoDDL.selectedIndex;  // parseInt(TransRefNoDDL.selectedIndex); //add by Rutu on 18/11/23
                }

                var selectedIndex_Taxtype = parseInt(ddlTaxtype.selectedIndex);

                var selectedIndex_Adjtype = parseInt(ddladjusttype.selectedIndex);

                var selectedIndex_IsReimbursable = parseInt(ddlIsReimbursable.selectedIndex);


                var strhdvValue = "";
                strhdvValue = hdnPaymentDetails.value;
                //alert(ddladjusttype.value);
                if (ddladjusttype.value == '2') {
                    var TotalPayableAmt = parseFloat(txtBillAmt.value) + parseFloat(txtServiceTaxAmt.value) + parseFloat(txtServiceTaxAmt1.value) + parseFloat(txtDueAmount.value);
                }
                else if (ddladjusttype.value == '4') {
                    var TotalPayableAmt = parseFloat(txtBillAmt.value) + parseFloat(txtServiceTaxAmt.value) + parseFloat(txtServiceTaxAmt1.value);
                }
                else {
                    var TotalPayableAmt = parseFloat(txtBillAmt.value) + parseFloat(txtServiceTaxAmt.value) + parseFloat(txtServiceTaxAmt1.value) - parseFloat(txtDueAmount.value);
                }


                if (ddlAccountHeadList.selectedIndex == 55) {
                    strhdvValue = strhdvValue + ddlVerticalList.options[selectedIndex_Vertical].innerText + "|" + ddlActivityList.options[selectedIndex_Activity].innerText + "|" + ddlProductList.options[selectedIndex_Product].innerText + "|" + ddlVenderList.options[Index].innerText + "|" + txtBillNo.value + "|" + txtBillDate.value + "|" + txtBillAmt.value + "|" + ddlTaxtype.options[selectedIndex_Taxtype].innerText + "|" + ddlServiceTax.options[selectedIndex_ServiceTax].innerText + "|" + txtServiceTaxAmt.value + "|" + txtServiceTaxAmt1.value + "|" + ddladjusttype.options[selectedIndex_Adjtype].innerText + "|" + txtDueAmount.value + "|" + txtServiceTaxRegNo.value + "|" + ddlAccountHeadList.options[selectedIndex_AccountHeadList].innerText + "|" + txtMobile_TelNo.value + "|" + txtDuedate.value + "|" + TotalPayableAmt + "|" + txtPanCard.value + "|" + ddlIsReimbursable.options[selectedIndex_IsReimbursable].innerText + "|" + txtRemark.value + "|" + txtEmpCode.value + "|" + TransRefNoDDL.options[selectedIndex_TransRefNoDDL].innerText + "|" + VenderID + "|" + ddlServiceTax.value + "|" + ddlAccountHeadList.value + "|" + ddlVerticalList.value + "|" + ddlActivityList.value + "|" + ddlProductList.value + "^";
                }
                else {
                    strhdvValue = strhdvValue + ddlVerticalList.options[selectedIndex_Vertical].innerText + "|" + ddlActivityList.options[selectedIndex_Activity].innerText + "|" + ddlProductList.options[selectedIndex_Product].innerText + "|" + ddlVenderList.options[Index].innerText + "|" + txtBillNo.value + "|" + txtBillDate.value + "|" + txtBillAmt.value + "|" + ddlTaxtype.options[selectedIndex_Taxtype].innerText + "|" + ddlServiceTax.options[selectedIndex_ServiceTax].innerText + "|" + txtServiceTaxAmt.value + "|" + txtServiceTaxAmt1.value + "|" + ddladjusttype.options[selectedIndex_Adjtype].innerText + "|" + txtDueAmount.value + "|" + txtServiceTaxRegNo.value + "|" + ddlAccountHeadList.options[selectedIndex_AccountHeadList].innerText + "|" + txtMobile_TelNo.value + "|" + txtDuedate.value + "|" + TotalPayableAmt + "|" + txtPanCard.value + "|" + ddlIsReimbursable.options[selectedIndex_IsReimbursable].innerText + "|" + txtRemark.value + "|" + "" + "|" + "NA" + "|" + VenderID + "|" + ddlServiceTax.value + "|" + ddlAccountHeadList.value + "|" + ddlVerticalList.value + "|" + ddlActivityList.value + "|" + ddlProductList.value + "^";
                }

                //alert(txtDueAmount.value);
                RenderTable(strhdvValue);
                hdnPaymentDetails.value = "";
                hdnPaymentDetails.value = strhdvValue;



                //hdnadjtyp.value = ddladjusttype.options[selectedIndex_Adjtype].innerText;
                Clear_PaymentDetails();

            }
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


                    if (j >= 23) { /*22*/
                        ColChkObj.style.display = "none";
                    }

                }
            }
            TotalReqAmountCalculation();
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

    <!--add by Rutu on 24/11/23-->
    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script> //comment on 01/03/2024
     <script type="text/javascript">
         $(document).ready(function () { //$(document).ready(function () {
             $("#<%=TransRefNoDDL.ClientID%>").select2(); //$("#TransRefNoDDL").select2();
         });
     </script>
    <a href="https://cdn.jsdeliver.net/npm/select2@4.0.13/dist/css/select2.min.css" rel="Stylesheet" ></a>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/select2@4.0.13/dist/js/select2.min.js"></script>--%>
    <!--add by Rutu on 24/11/23-->

    <table style="width: 782px" border="0" cellpadding="1" cellspacing="2" class="Table">
        <tr>
            <td colspan="11">
                <asp:Label ID="lblError" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class=" TableHeader" colspan="11" style="height: 22px">&nbsp;Branch Payment Request (Vendor)
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 60px; height: 2px"></td>
            <td colspan="10" style="height: 2px">
                <table>
                    <tr>
                        <td style="width: 6px; height: 20px"></td>
                        <td class="TableTitle" colspan="4" style="height: 20px">&nbsp;<strong>Transaction ID</strong> &nbsp;&nbsp; :
                            <asp:Label ID="lblTransactionID" runat="server" Font-Bold="True" Width="320px"></asp:Label>
                        </td>
                        <td class="TableTitle" colspan="4" style="height: 20px; text-align: center; font-weight: 700;">&nbsp;HO Approved Budget Balance
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 6px; height: 20px;"></td>
                        <td class="TableTitle" style="height: 20px">&nbsp;Region/Cluster
                        </td>
                        <td style="width: 142px; height: 20px;" class="TableGrid">
                            <asp:Label ID="lblRegionCluster" runat="server" SkinID="LabelSkin" Width="149px"></asp:Label>
                        </td>
                        <td class="TableTitle" style="width: 90px; height: 20px;">&nbsp;Centre
                        </td>
                        <td style="width: 72px; height: 20px;" class="TableGrid">
                            <asp:Label ID="lblbranch" runat="server" SkinID="LabelSkin" Font-Bold="False" Width="130px"></asp:Label>
                        </td>
                        <td class="TableTitle" style="height: 20px">&nbsp;Opening Balance
                        </td>
                        <td class="TableGrid" colspan="3" style="height: 20px">
                            <asp:Label ID="lblOpeningBalance" runat="server" SkinID="LabelSkin"></asp:Label><a
                                href="javascript:openwindow();" title="View Opening Balance"></a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 6px;"></td>
                        <td class="TableTitle">&nbsp;<asp:Label ID="lblRequestDate" runat="server" Text="Request Date" Width="96px"></asp:Label>
                        </td>
                        <td style="width: 142px;" class="TableGrid">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 105px">
                                <tr>
                                    <td style="width: 100px; height: 20px;">
                                        <asp:TextBox ID="txtPaymentDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                            Width="78px" ReadOnly="True"></asp:TextBox>&nbsp;
                                    </td>
                                    <td style="width: 95px; height: 20px;">
                                        <img id="Img1" alt="Calendar" src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="TableTitle" style="width: 90px;">&nbsp;
                        </td>
                        <td style="width: 72px;" class="TableGrid"></td>
                        <td class="TableTitle">&nbsp;Transaction During Month
                        </td>
                        <td class="TableGrid" colspan="3">
                            <asp:Label ID="lblTransactionAmout" runat="server" SkinID="LabelSkin" Width="206px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 6px;"></td>
                        <td class="TableTitle" colspan="4">&nbsp;&nbsp;<a href="javascript:openwindow();" title="View Opening Balance">View Opening
                                Budget Balance</a>
                        </td>
                        <td class="TableTitle">&nbsp;<asp:Label ID="lbl" runat="server" Text="Available Amount" Width="117px"></asp:Label>
                        </td>
                        <td class="TableGrid">
                            <asp:Label ID="lblAvailableAmt" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>
                        <td class="TableTitle" colspan="1">&nbsp;YearMonth
                        </td>
                        <td class="TableGrid">&nbsp;<asp:Label ID="lblYearMonth" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnPaymentDetails" runat="server" />
                <asp:HiddenField ID="hdnSavingPaymentDetails" runat="server" EnableViewState="False" />
                <asp:HiddenField ID="hdnTransactionID" runat="server" />
                <asp:HiddenField ID="hdnadjtyp" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="11" style="height: 19px">&nbsp;Payment Request Details
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td class="TableTitle" colspan="2" style="text-align: left">&nbsp;Vertical
            </td>
            <td class="TableTitle" style="text-align: left">&nbsp; Activity
            </td>
            <td style="text-align: left;" class="TableTitle">Payee Name
            </td>
            <td style="text-align: left;" class="TableTitle">&nbsp; &nbsp;Bill no
            </td>
            <td class="TableTitle">&nbsp;Bill Date
            </td>
            <td style="width: 93px;" class="TableTitle">&nbsp;Bill Amount
            </td>
            <td style="width: 93px;" class="TableTitle">TAx Type
            </td>
            <td style="width: 37px;" class="TableTitle">&nbsp;GST%
            </td>
            <td class="TableTitle">&nbsp;IGST/CGST+SGST
            </td>
        </tr>
        <tr>
            <td style="width: 60px;"></td>
            <td class="TableGrid" colspan="2">&nbsp;<asp:DropDownList ID="ddlVerticalList" runat="server" SkinID="ddlSkin" AccessKey="N">
            </asp:DropDownList>
                <%--AutoPostBack="True" OnSelectedIndexChanged="ddlVerticalList_SelectedIndexChanged"--%>
            </td>
            <td class="TableGrid">&nbsp;
                <asp:DropDownList ID="ddlActivityList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 5px">
                    <tr>
                        <td style="width: 100px; height: 21px;">
                            <asp:TextBox ID="txtPayeeNameSearch" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="98px" MaxLength="25"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 21px;">
                            <asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Height="19px" Text=">>"
                                Width="30px" Font-Bold="True" OnClick="btnSearch_Click" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px">
                            <asp:DropDownList ID="ddlVenderList" OnSelectedIndexChanged="ddlVenderList_SelectedIndexChanged1"
                                AutoPostBack="true" runat="server" SkinID="ddlSkin" Font-Bold="False">
                            </asp:DropDownList>
                            <%--OnSelectedIndexChanged="ddlVenderList_SelectedIndexChanged1" AutoPostBack="true"--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid">
                <asp:TextBox ID="txtBillNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="82px"
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px;">
                            <asp:TextBox ID="txtBillDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="62px"
                                MaxLength="10"></asp:TextBox>&nbsp;
                        </td>
                        <td style="width: 100px; height: 20px;">
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 93px;" class="TableGrid">
                <asp:TextBox ID="txtBillAmt" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="72px"
                    MaxLength="15" oninput="validateDecimal(this)">0.00</asp:TextBox>
            </td>
            <td style="width: 93px;" class="TableGrid">
                <asp:DropDownList ID="ddlTaxtype" runat="server" SkinID="ddlSkin" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlTaxtype_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <%--<asp:ListItem Value="1">Service Tax</asp:ListItem>--%>
                    <asp:ListItem Value="2">IGST</asp:ListItem>
                    <asp:ListItem Value="3">CGST + SGST</asp:ListItem>
                    <asp:ListItem Value="4">NA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 37px;" class="TableGrid">
                <asp:DropDownList ID="ddlServiceTax" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td class="TableGrid">
                <asp:TextBox ID="txtServiceTaxAmt" runat="server" BorderWidth="1px" onkeypress="return false;" onpaste="return false;"
                    SkinID="txtSkin" Width="74px" MaxLength="15">0.00</asp:TextBox>&nbsp; <strong>+</strong><br />
                &nbsp;<asp:TextBox ID="txtServiceTaxAmt1" runat="server" BorderWidth="1px" onkeypress="return false;" onpaste="return false;"
                    SkinID="txtSkin" Width="74px" MaxLength="15">0.00</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 60px;">&nbsp;
            </td>
            <td class="TableGrid" colspan="2">&nbsp;
            </td>
            <td class="TableGrid">&nbsp;
            </td>
            <td class="TableGrid">&nbsp;
            </td>
            <td class="TableGrid">&nbsp;
            </td>
            <td class="TableGrid">&nbsp;
            </td>
            <td style="width: 93px;" class="TableGrid">&nbsp;
            </td>
            <td style="width: 93px;" class="TableGrid">&nbsp;
            </td>
            <td style="width: 37px;" class="TableGrid">&nbsp;
            </td>
            <td class="TableGrid">&nbsp;
            </td>
            <td class="TableGrid">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td class="TableTitle" colspan="2">&nbsp;<br />
                &nbsp; GST No
            </td>
            <td class="TableTitle">&nbsp;Product
            </td>
            <td class="TableTitle">&nbsp;Account Head
            </td>
            <td class="TableTitle">&nbsp;MobileNo/TelNo
            </td>
            <td class="TableTitle">&nbsp;BillDueDate
            </td>
            <td class="TableTitle" style="width: 93px">Adjust type
            </td>
            <td class="TableTitle" style="width: 93px">Adjustment&nbsp; Amount
            </td>
            <td class="TableTitle" style="width: 37px">&nbsp;PanNo
            </td>
            <td class="TableTitle" style="width: 93px">Is Reimbursable
            </td>
        </tr>
        <tr>
            <td style="width: 60px;"></td>
            <td class="TableGrid" colspan="2">
                <asp:TextBox ID="txtServiceTaxRegNo" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="82px" MaxLength="20"></asp:TextBox>
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlProductList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td class="TableGrid">
                <%--                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="udpAhl" runat="server">
                    <ContentTemplate>--%>
                <asp:DropDownList ID="ddlAccountHeadList" runat="server" SkinID="ddlSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountHeadList_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Traveling Expenses</asp:ListItem>
                </asp:DropDownList>
                <%-- </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlAccountHeadList" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>--%>
            </td>
            <td class="TableGrid">
                <asp:TextBox ID="txtMobile_TelNo" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="82px" MaxLength="12"></asp:TextBox>
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                            <asp:TextBox ID="txtDuedate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="62px"
                                MaxLength="10"></asp:TextBox>&nbsp;
                        </td>
                        <td style="width: 100px; height: 20px;">
                            <img id="Img4" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDuedate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid" style="width: 93px">
                <asp:DropDownList ID="ddladjusttype" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <%--   <asp:ListItem Value="1">Service Tax</asp:ListItem>--%>
                    <asp:ListItem Value="2">Plus</asp:ListItem>
                    <asp:ListItem Value="3">Minus</asp:ListItem>
                    <asp:ListItem Value="4">NA</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:ListItem Value="1">Service Tax</asp:ListItem>--%>
            </td>
            <td class="TableGrid" style="width: 93px">
                <asp:TextBox ID="txtDueAmount" runat="server" BorderWidth="1px" ToolTip="Kindly Enter Adjustment amount only"
                    SkinID="txtSkin" Width="71px" oninput="validateDecimal(this)"></asp:TextBox>
            </td>
            <td style="width: 37px;" class="TableGrid">
                <asp:TextBox ID="txtPanCard" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                    Width="72px"></asp:TextBox>
            </td>
            <td class="TableGrid" style="width: 93px">
                <asp:DropDownList ID="ddlIsReimbursable" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <!--Add by rutu on 16/11/23 start-->
        <tr id="TransR1" runat="server">
            <td style="width: 60px"></td>
            <td class="TableTitle" colspan="2" id="EmployeeCode">&nbsp;Employee Code <%--add on 04/03/2024--%>
            </td>
            <td class="TableTitle" colspan="9" id="TransRefNo">&nbsp; Trans Ref No
            </td>
            <td class="TableTitle"></td>
        </tr>

        <!--Add by rutu on 16/11/23 end-->
        <tr id="TransR2" runat="server">
            <td style="width: 60px;"></td>
            <td class="TableGrid" colspan="2"><%--add on 04/03/2024--%>
                <asp:TextBox ID="txtEmpCode" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="82px" MaxLength="20" OnTextChanged="txtEmpCode_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="TableGrid" colspan="9">

                <asp:DropDownList ID="TransRefNoDDL" runat="server" SkinID="ddlSkin" AutoPostBack="true" OnSelectedIndexChanged="TransRefNoDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>

            </td>
            <td class="TableGrid"></td>
        </tr>


        <!--Add by rutu on 16/11/23 end-->

        <tr>
            <td style="width: 60px"></td>
            <td class="TableTitle" colspan="9">&nbsp;Remark
            </td>
            <td class="TableTitle"></td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td class="TableGrid" colspan="9">
                <asp:TextBox ID="txtRemark" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="793px"
                    MaxLength="500" TextMode="MultiLine" Height="36px"></asp:TextBox>
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 124px">
                    <tr>
                        <td style="width: 58px; height: 18px;">
                            <asp:Button ID="btnAddtoGrid" runat="server" BorderWidth="1px" CssClass="Button"
                                Text="Add" ToolTip="add selected to grid" Width="58px" OnClick="btnAddtoGrid_Click"
                                AccessKey="A" />
                        </td>
                        <td style="width: 100px; height: 18px;">&nbsp;<asp:Button ID="btnRemove" runat="server" BorderWidth="1px" CssClass="Button"
                            Text="Remove" ToolTip="Remove Selected from grid" Width="60px" AccessKey="R"
                            OnClick="btnRemove_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="11">&nbsp; Payment Request List
            </td>
        </tr>
        <tr>
            <td style="width: 60px; height: 12px"></td>
            <td colspan="10" style="height: 12px">
                <div style="overflow: auto; width: 944px; height: 160px; border-right: darkgray 1px solid; border-top: darkgray 1px solid; border-left: darkgray 1px solid; border-bottom: darkgray 1px solid;"
                    id="DIV1" runat="server">
                    <table id="MainTab" class="GridViewStyle">
                        <tr>
                            <th class="TableGrid">
                                <input id="chkSelectAll" onclick="javascript: SelectAll();" type="checkbox" />
                            </th>
                            <th class="TableGrid">Vertical
                            </th>
                            <th class="TableGrid">Activity
                            </th>
                            <th class="TableGrid">Product
                            </th>
                            <th class="TableGrid">&nbsp;PayeeName
                            </th>
                            <th class="TableGrid">&nbsp;BillNo
                            </th>
                            <th class="TableGrid">&nbsp; BillDate
                            </th>
                            <th class="TableGrid">&nbsp;BillAmount
                            </th>
                            <th class="TableGrid">TaxType
                            </th>
                            <th class="TableGrid">&nbsp;GST%
                            </th>
                            <th class="TableGrid">CGST/IGST Amount
                            </th>
                            <th class="TableGrid">SGST Amount
                            </th>
                            <th class="TableGrid">Adjustment Type
                            </th>
                            <th class="TableGrid">Adjustment Amt
                            </th>
                            <th class="TableGrid">GST NO
                            </th>
                            <th class="TableGrid">&nbsp;AccountHead
                            </th>
                            <th class="TableGrid">MobileNo /TelNo
                            </th>
                            <th class="TableGrid">Bill Due Date
                            </th>
                            <th class="TableGrid">Bill Total Due Amt
                            </th>
                            <th class="TableGrid">Pan No
                            </th>
                            <th class="TableGrid">Is Reimbursable
                            </th>
                            <th class="TableGrid">Remark
                            </th>
                            <th class="TableGrid">EmployeeCode <%--add on 04/03/2024--%>
                            </th>
                            <th class="TableGrid">TransRefNo
                            </th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="11">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="TableTitle">&nbsp;<strong>Attach Support Document</strong>
                        </td>
                        <td class="TableGrid">
                            <asp:FileUpload ID="FileUpload1" runat="server" BorderWidth="1px" Width="307px" Font-Bold="False"
                                Height="23px" AccessKey="B" />
                        </td>
                        <td style="width: 100px"></td>
                        <td style="width: 100px"></td>
                        <td style="width: 100px; text-align: right" class="TableTitle">Total:
                        </td>
                        <td class="TableGrid" style="width: 100px">
                            <asp:Label ID="lblTotalRequestedAmount" runat="server" Width="12px" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" style="height: 18px">&nbsp;<strong>Uploaded Document</strong>
                        </td>
                        <td class="TableGrid" style="height: 18px">
                            <asp:Label ID="lblAttachDocumentName" runat="server"></asp:Label>
                        </td>
                        <td style="width: 100px; height: 18px;"></td>
                        <td style="width: 100px; height: 18px;"></td>
                        <td class="TableTitle" style="width: 100px; text-align: right; height: 18px;"></td>
                        <td class="TableGrid" style="width: 100px; height: 18px;"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="11" style="height: 17px">&nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Save" Width="70px"
                    OnClick="btnSave_Click" AccessKey="S" />&nbsp;
                <asp:Button ID="btnAdd" runat="server" BorderWidth="1px" Text="Add New Transaction"
                    Width="145px" OnClick="btnAdd_Click" />&nbsp;<asp:Button ID="btnCancel" runat="server"
                        BorderWidth="1px" Text="Cancel" Width="69px" OnClick="btnCancel_Click" AccessKey="C" />
            </td>
        </tr>
        <tr>
            <td style="width: 60px"></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td style="width: 93px"></td>
            <td style="width: 93px">&nbsp;
            </td>
            <td style="width: 37px"></td>
            <td></td>
        </tr>

    </table>

</asp:Content>

