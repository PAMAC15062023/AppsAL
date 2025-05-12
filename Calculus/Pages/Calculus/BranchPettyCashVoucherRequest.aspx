<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="BranchPettyCashVoucherRequest.aspx.cs" Inherits="Pages_Calculus_BranchPettyCashVoucherRequest"
    Title="Branch Petty Cash Reqest" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function openwindow() {
            window.open('ViewOpeningBalancePetty.aspx', '_blank', 'height=350,width=700,status=yes,resizable=yes');
        }

        function Validate_Headers() {
            var ReturnValue = true;
            var ErrorMessage = '';
            var lblTotalRequestedAmount = document.getElementById("<%=lblTotalRequestedAmount.ClientID%>");
            var lblAvailableAmt = document.getElementById("<%=lblAvailableAmt.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            var TotalRequestedAmount = parseFloat(lblTotalRequestedAmount.innerText);
            var AvailableAmt = parseFloat(lblAvailableAmt.innerText);
            var hdnChequeDetails = document.getElementById("<%=hdnPaymentDetails.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            if (TotalRequestedAmount > AvailableAmt) {
                ErrorMessage = "Requested Amount is Exceed the limit!";
                ReturnValue = false;

            }
            else if (MainTab.rows.length == 1) {
                ErrorMessage = "Please Enter Cash Voucher Request Details to continue...!";
                ReturnValue = false;

            }
            window.scroll(0, 0);
            lblMessage.innerText = ErrorMessage;
            return ReturnValue;
        }

        function TotalReqAmountCalculation() {
            var lblTotalRequestedAmount = document.getElementById("<%=lblTotalRequestedAmount.ClientID%>");
            var hdnSavingPaymentDetails = document.getElementById("<%=hdnSavingPaymentDetails.ClientID%>");
            var MainTab = document.getElementById("MainTab");
            var i = 0;
            var TotalAmt = 0;

            for (i = 0; i <= MainTab.rows.length - 1; i++) {
                if (i != 0) {
                    TotalAmt = TotalAmt + parseFloat(MainTab.rows[i].cells[5].innerText);
                }
            }

            lblTotalRequestedAmount.innerText = TotalAmt;
            hdnSavingPaymentDetails.value = TotalAmt;
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
                    strhdvValue = strhdvValue + MainTab.rows[i].cells[1].innerText + "|" + MainTab.rows[i].cells[2].innerText + "|" + MainTab.rows[i].cells[3].innerText + "|" + MainTab.rows[i].cells[4].innerText + "|" + MainTab.rows[i].cells[5].innerText + "|" + MainTab.rows[i].cells[6].innerText + "|" + MainTab.rows[i].cells[7].innerText + "|" + MainTab.rows[i].cells[8].innerText + "|" + MainTab.rows[i].cells[9].innerText + "^";
                    hdnChequeDetails.value = strhdvValue;
                }
            }

            RenderTable(strhdvValue);
            return false;
        }

        function Page_load_validation() {
            var hdnChequeDetails = document.getElementById("<%=hdnPaymentDetails.ClientID%>");
            RenderTable(hdnChequeDetails.value);

        }

        function Clear_PaymentDetails() {
            var txtClientName = document.getElementById("<%=txtClientName.ClientID%>");
            var ddlVerticalList = document.getElementById("<%=ddlVerticalList.ClientID%>");
            var ddlActivityList = document.getElementById("<%=ddlActivityList.ClientID%>");
            var ddlAccountHeadList = document.getElementById("<%=ddlAccountHeadList.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
            var ddlPaymentTyp = document.getElementById("<%=ddlPaymentTyp.ClientID%>");
            var txtNaration = document.getElementById("<%=txtNaration.ClientID%>");
            var txtClientName = document.getElementById("<%=txtClientName.ClientID%>");


            ddlActivityList.selectedIndex = 0;
            ddlAccountHeadList.selectedIndex = 0;
            ddlPaymentTyp.selectedIndex = 0;
            txtClientName.value = '';
            txtAmount.value = '';
            txtNaration.value = '';

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

        }

        function ValidateGrid() {
            var ReturnValue = true;
            var ErrorMessage = "";

            var txtClientName = document.getElementById("<%=txtClientName.ClientID%>");
            var ddlVerticalList = document.getElementById("<%=ddlVerticalList.ClientID%>");
            var ddlActivityList = document.getElementById("<%=ddlActivityList.ClientID%>");
            var ddlAccountHeadList = document.getElementById("<%=ddlAccountHeadList.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
            var ddlPaymentTyp = document.getElementById("<%=ddlPaymentTyp.ClientID%>");
            var txtNaration = document.getElementById("<%=txtNaration.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");


            if (ddlAccountHeadList.selectedIndex == 0) {
                ErrorMessage = "Please select Account Head to continue!";
                ReturnValue = false;
                ddlAccountHeadList.focus();
            }

            else if (ddlVerticalList.selectedIndex == 0) {
                ErrorMessage = "Please select Vertical to continue!";
                ReturnValue = false;
                ddlVerticalList.focus();
            }
            else if (ddlActivityList.selectedIndex == 0) {
                ErrorMessage = "Please select Activity to continue!";
                ReturnValue = false;
                ddlActivityList.focus();
            }
            else if (ddlPaymentTyp.selectedIndex == 0) {
                ErrorMessage = "Please select Payment Type to continue!";
                ReturnValue = false;
                ddlPaymentTyp.focus();
            }
            if (txtAmount.value == 0) {
                ErrorMessage = "Please Enter Amount to continue!";
                ReturnValue = false;
                txtAmount.focus();
            }
            if (txtClientName.value == '') {
                ErrorMessage = "Please Enter ClientName to continue!";
                ReturnValue = false;
                txtAmount.focus();
            }
            if (txtAmount.value != '') {

            }
            lblMessage.innerText = ErrorMessage;
            window.scroll(0, 0);
            return ReturnValue;
        }

        function AddColumnToGrid() {

            if (ValidateGrid()) {

                var txtClientName = document.getElementById("<%=txtClientName.ClientID%>");
                var ddlVerticalList = document.getElementById("<%=ddlVerticalList.ClientID%>");
                var ddlActivityList = document.getElementById("<%=ddlActivityList.ClientID%>");
                var ddlAccountHeadList = document.getElementById("<%=ddlAccountHeadList.ClientID%>");
                var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
                var ddlPaymentTyp = document.getElementById("<%=ddlPaymentTyp.ClientID%>");
                var txtNaration = document.getElementById("<%=txtNaration.ClientID%>");


                var hdnPaymentDetails = document.getElementById("<%=hdnPaymentDetails.ClientID%>");
                var hdnSavingPaymentDetails = document.getElementById("<%=hdnSavingPaymentDetails.ClientID%>");
                var MainTab = document.getElementById("MainTab");

                var selectedIndex_Activity = parseInt(ddlActivityList.selectedIndex);
                var selectedIndex_Vertical = parseInt(ddlVerticalList.selectedIndex);
                var selectedIndex_AccountHeadList = parseInt(ddlAccountHeadList.selectedIndex);
                var selectedIndex_ddlPaymentTyp = parseInt(ddlPaymentTyp.selectedIndex);

                ////debugger;  
                var strhdvValue = "";
                strhdvValue = hdnPaymentDetails.value;
                strhdvValue = strhdvValue + txtClientName.value + "|" + ddlAccountHeadList.options[selectedIndex_AccountHeadList].innerText + "|" + ddlVerticalList.options[selectedIndex_Vertical].innerText + "|" + ddlActivityList.options[selectedIndex_Activity].innerText + "|" + txtAmount.value + "|" + ddlPaymentTyp.options[selectedIndex_ddlPaymentTyp].innerText + "|" + txtNaration.value + "|" + ddlAccountHeadList.value + "|" + ddlVerticalList.value + "|" + ddlActivityList.value + "^";

                RenderTable(strhdvValue);
                hdnPaymentDetails.value = "";
                hdnPaymentDetails.value = strhdvValue;
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
                    if (j >= 7) {
                        ColChkObj.style.display = "none";
                    }

                }
            }
            TotalReqAmountCalculation();
        }

    </script>
    <script language="javascript" type="text/javascript" src="../popcalendar.js"> </script>

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


    <table>
        <tr>
            <td colspan="1" style="width: 11px"></td>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 22px">&nbsp;Branch Petty Cash Request
            </td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td class="TableTitle" colspan="4">&nbsp;
                <asp:Label ID="lblTransactionID" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td colspan="3" rowspan="3">
                <table>
                    <tr>
                        <td class="TableTitle" colspan="7" style="height: 20px; text-align: center">&nbsp;Petty Cash Balance
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" colspan="2" style="height: 20px">&nbsp;Opening Balance
                        </td>
                        <td class="TableGrid" colspan="5" style="height: 20px">
                            <asp:Label ID="lblOpeningBalance" runat="server" SkinID="LabelSkin"></asp:Label><a
                                href="javascript:openwindow();" title="View Opening Balance"></a>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" colspan="2">&nbsp;Transaction During Month
                        </td>
                        <td class="TableGrid" colspan="5">
                            <asp:Label ID="lblTransactionAmout" runat="server" SkinID="LabelSkin" Width="206px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <%--<td class="TableTitle" colspan="2">
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="Transfer From HO" Width="99px"></asp:Label>
                        </td>
                        <td class="TableGrid" colspan="3">
                            <asp:Label ID="lblHOAmout" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>--%>
                        <td class="TableTitle" colspan="2">&nbsp;Withdrawal During Amount
                        </td>
                        <td class="TableGrid" colspan="5">
                            <asp:Label ID="lblHOWthdrwAmt" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" colspan="2">&nbsp;<asp:Label ID="lbl" runat="server" Text="Available Amount" Width="99px"></asp:Label>
                        </td>
                        <td class="TableGrid" colspan="3">
                            <asp:Label ID="lblAvailableAmt" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>
                        <td class="TableTitle" colspan="1">&nbsp;YearMonth
                        </td>
                        <td class="TableGrid">
                            <asp:Label ID="lblYearMonth" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>
                    </tr>
                </table>
                &nbsp; <a href="javascript:openwindow();" title="View Opening Balance">ViewOpeningBudgetBalance</a>
            </td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Branch
            </td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblBranch" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
            <td style="width: 100px" class="TableTitle">&nbsp;Region/Cluster
            </td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblRegion" runat="server" SkinID="LabelSkin" Width="138px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Vendor Date
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 105px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtPaymentDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="78px" AutoPostBack="true" OnTextChanged="txtPaymentDate_TextChanged"></asp:TextBox>
                            <br />
                            <strong>[DD/MM/YYYY]</strong>&nbsp;
                        </td>
                        <%--<td style="width: 95px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPaymentDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" />
                        </td>--%>
                    </tr>
                </table>
            </td>
            <td style="width: 100px" class="TableTitle">&nbsp;
            </td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblWeek" Visible="false" runat="server" SkinID="LabelSkin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 19px">
                <asp:HiddenField ID="hdnSavingPaymentDetails" runat="server" EnableViewState="False" />
                <asp:HiddenField ID="hdnPaymentDetails" runat="server" />
                <asp:HiddenField ID="hdnTransactionID" runat="server" />
                <asp:HiddenField ID="hdnClosingAMT" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 19px">&nbsp;Add Branch Petty Cash Request
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 16px"></td>
            <td style="width: 100px; height: 16px;" class="TableTitle">&nbsp;Payee Name
            </td>
            <td style="width: 100px; height: 16px;" class="TableTitle">&nbsp;Account Head&nbsp;
            </td>
            <td style="width: 100px; height: 16px;" class="TableTitle">&nbsp;Vertical
            </td>
            <td style="width: 100px; height: 16px;" class="TableTitle">&nbsp;Activity
            </td>
            <td class="TableTitle">&nbsp;Amount
            </td>

            <td class="TableTitle">&nbsp;Payment Type
            </td>
            <td style="width: 100px; height: 16px;"></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 24px"></td>
            <td style="height: 24px;" class="TableGrid">
                <asp:TextBox ID="txtClientName" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="144px" AccessKey="N"></asp:TextBox>
            </td>
            <td style="height: 24px;" class="TableGrid">
                <asp:DropDownList ID="ddlAccountHeadList" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Traveling Expenses</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:DropDownList ID="ddlVerticalList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVerticalList_SelectedIndexChanged"
                    SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:DropDownList ID="ddlActivityList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td class="TableGrid">
                <asp:TextBox ID="txtAmount" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="78px" oninput="validateDecimal(this)"></asp:TextBox>
            </td>
            <td style="height: 24px;" class="TableGrid">
                <asp:DropDownList ID="ddlPaymentTyp" runat="server" SkinID="ddlSkin"
                    Height="20px" Width="87px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Petty">Petty Cash</asp:ListItem>
                    <asp:ListItem Value="OTP">OTP</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 100px; height: 24px;"></td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td class="TableTitle" colspan="4">&nbsp;Narration
            </td>
            <td style="width: 131px" class="TableTitle"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td class="TableGrid" colspan="4">
                <asp:TextBox ID="txtNaration" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="514px"
                    MaxLength="500" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 127px">
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="btnAddtoGrid" runat="server" BorderWidth="1px" CssClass="Button"
                                Text="Add" ToolTip="Add selected to grid" Width="58px" AccessKey="A" />
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="btnRemove" runat="server" BorderWidth="1px" CssClass="Button" Text="Remove"
                                ToolTip="Remove Selected from grid" Width="60px" AccessKey="R" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">&nbsp;Branch Petty Cash Request List
            </td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td colspan="7">
                <div id="DIV1" runat="server" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; overflow: auto; border-left: darkgray 1px solid; width: 809px; border-bottom: darkgray 1px solid; height: 160px">
                    <table id="MainTab" class="GridViewStyle">
                        <tr>
                            <th class="TableGrid">
                                <input id="chkSelectAll" onclick="javascript:SelectAll();" type="checkbox" />
                            </th>
                            <th class="TableGrid">Payee Name
                            </th>
                            <th class="TableGrid">&nbsp;AccountHead
                            </th>
                            <th class="TableGrid">Vertical
                            </th>
                            <th class="TableGrid">Activity
                            </th>
                            <th class="TableGrid">Amount
                            </th>
                            <th class="TableGrid">Payment Type
                            </th>
                            <th class="TableGrid">Naration
                            </th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 32px; text-align: left">
                <table border="0" cellpadding="1" cellspacing="2">
                    <tr>
                        <td class="TableGrid">
                            <strong>Attach Support Document </strong>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" BorderWidth="1px" Font-Bold="False"
                                Height="23px" Width="287px" AccessKey="B" />
                        </td>
                        <td style="width: 100px"></td>
                        <td class="TableGrid">Grand Total
                        </td>
                        <td class="TableGrid" style="width: 100px">
                            <asp:Label ID="lblTotalRequestedAmount" runat="server" Font-Bold="True" Font-Size="8pt"
                                Text="0.00" Width="114px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableGrid">&nbsp;<strong>Uploaded Document</strong>
                        </td>
                        <td>
                            <asp:Label ID="lblAttachDocumentName" runat="server"></asp:Label>
                        </td>
                        <td style="width: 100px"></td>
                        <td class="TableGrid"></td>
                        <td class="TableGrid" style="width: 100px"></td>
                    </tr>
                </table>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 32px">&nbsp;<asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Save" Width="61px"
                OnClick="btnSave_Click" AccessKey="S" />&nbsp;<asp:Button ID="btnAddNew" runat="server"
                    BorderWidth="1px" Text="Add New Voucher" />&nbsp;<asp:Button ID="btnCancel" runat="server"
                        BorderWidth="1px" Text="Cancel" Width="61px" OnClick="btnCancel_Click" AccessKey="C" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 11px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 131px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 131px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
        </tr>
    </table>
</asp:Content>
