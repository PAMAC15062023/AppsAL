<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaymentIssueProcess.aspx.cs" Inherits="Pages_Calculus_PaymentIssueProcess"
    Title="Payment Issue" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"> 
    </script>

    <script language="javascript" type="text/javascript">

        function Validate_Search() {

            var ReturnValue = true;
            var ErrorMessage = '';

            var ddlPaymentType = document.getElementById("<%=ddlPaymentType.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            if (ddlPaymentType.selectedIndex == 0) {

                ErrorMessage = 'Please select Payment Type To Continue...';
                ReturnValue = false;
                ddlPaymentType.focus();
                ddlPaymentType.style.backgroundColor = "yellow";
            }

            lblMessage.innerText = ErrorMessage;
            return ReturnValue;
        }


        function checkSelected(chkSelect) {
            ////debugger;
            var grvTransactionInfo = document.getElementById("<%=grvTransactionInfo.ClientID%>");
            var chkSelect1 = document.getElementById(chkSelect);

            var cell;
            for (i = 0; i <= grvTransactionInfo.rows.length - 1; i++) {
                cell = grvTransactionInfo.rows[i].cells[1];
                if (cell != null) {
                    for (j = 0; j < cell.childNodes.length; j++) {

                        if (cell.childNodes[j].type == "checkbox") {
                            if (cell.childNodes[j].checked == true) {
                                cell.childNodes[j].checked = false;
                            }
                        }
                    }
                }

            }


            chkSelect1.checked = true;
        }

        function Get_SelectedTransactionID() {
            ////debugger;
            var grvTransactionInfo = document.getElementById("<%=grvTransactionInfo.ClientID%>");
        var hdnTransID = document.getElementById("<%=hdnTransID.ClientID%>");
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var ReturnValue = true;
            var ErrorMessage = '';


            var cell;
            for (i = 0; i <= grvTransactionInfo.rows.length - 1; i++) {
                cell = grvTransactionInfo.rows[i].cells[1];
                if (cell != null) {
                    for (j = 0; j < cell.childNodes.length; j++) {

                        if (cell.childNodes[j].type == "checkbox") {
                            if (cell.childNodes[j].checked == true) {
                                hdnTransID.value = grvTransactionInfo.rows[i].cells[2].innerText;
                                break;
                            }
                        }
                    }
                }

            }



            if (hdnTransID.value == '') {
                ErrorMessage = "Please select atleast one record to continue!";
                ReturnValue = false;

            }

            window.scroll(0, 0);
            return ReturnValue;

        }


        function switchViews(obj, row) {
            ////debugger;
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            if (div.style.display == "none") {
                div.style.display = "inline";
                if (row == 'alt') {
                    img.src = "Images/close.png";
                    mce_src = "Images/close.png";
                }
                else {
                    img.src = "Images/close.png";
                    mce_src = "Images/close.png";
                }
                img.alt = "Close to view other customers";
            }
            else {
                div.style.display = "none";
                if (row == 'alt') {

                    img.src = "Images/open.png";
                    mce_src = "Images/open.png";
                }
                else {
                    img.src = "Images/open.png";
                    mce_src = "Images/open.png";

                }
                img.alt = "Expand to show Transactions";
            }
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

    <table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 22px">&nbsp;Payment Request Approved List Search</td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle" style="width: 173px">&nbsp;TransactionID</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtTransactionID" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="width: 141px">&nbsp;Total Amount</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtTotalAmount" runat="server" BorderWidth="1px" SkinID="txtSkin" oninput="validateDecimal(this)"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Payment Type&nbsp;</td>
            <td class="TableGrid" style="width: 100px">
                <asp:DropDownList ID="ddlPaymentType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Vender Payment</asp:ListItem>
                    <asp:ListItem Value="2">Petty Cash</asp:ListItem>
                    <asp:ListItem Value="3">OTP Cash</asp:ListItem>
                    <asp:ListItem Value="4">Utility Payment</asp:ListItem>
                    <asp:ListItem Value="5">EPM Request</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle" style="width: 173px">&nbsp;Branch</td>
            <td class="TableGrid" style="width: 100px">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle" style="width: 141px">&nbsp;Payee Name</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtPayeeName" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Bill Date</td>
            <td class="TableGrid" style="width: 100px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtBillDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle" style="width: 173px">&nbsp;Payout Date</td>
            <td class="TableGrid" style="width: 100px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtPayoutDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPayoutDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="width: 141px">&nbsp;Bill No</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtBillNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Bill Amount</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtBillAmount" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="92px" oninput="validateDecimal(this)"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td style="width: 173px"></td>
            <td style="width: 100px"></td>
            <td style="width: 141px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnTransID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 31px">&nbsp;<asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Font-Bold="False"
                OnClick="btnSearch_Click" Text="Search" />&nbsp;<asp:Button ID="btnReset" runat="server"
                    BorderWidth="1px" Text="Reset" Width="54px" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 16px">&nbsp;Payment Request Approved List</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="overflow: scroll; width: 854px; height: 200px">
                    <asp:GridView ID="grvTransactionInfo" runat="server"
                        AutoGenerateColumns="False" DataKeyNames="TransactionID" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                        PageSize="20" CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'one');" style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: #ffffff; border-bottom-style: none">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="Images/open.png" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" /></a>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'alt');">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="Images/open.png" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" />
                                    </a>
                                </AlternatingItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
                            <asp:BoundField DataField="Region_Name" HeaderText="Region" SortExpression="Region_Name" />
                            <asp:BoundField DataField="BranchName" HeaderText="Branch" SortExpression="BranchName" />
                            <asp:BoundField DataField="PaymentRequestDate" HeaderText="Request Date" SortExpression="PaymentRequestDate" />
                            <asp:BoundField DataField="RequestedAmount" HeaderText="Requested Amount" SortExpression="RequestedAmount" />
                            <asp:BoundField DataField="Status" HeaderText="Auth.Status" SortExpression="Status" />
                            <asp:BoundField DataField="RequestType" HeaderText="Request Type" SortExpression="RequestType" />
                            <asp:TemplateField HeaderText="Remark By Account">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin"></asp:TextBox>
                                    <%--<asp:DropDownList ID="ddlBillStatus" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>Received</asp:ListItem>
                                    <asp:ListItem>Not Received</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownloadFile" runat="server" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"DownloadFilePath"))%>'
                                        ToolTip="Click Download Attach Documents" OnClick="lnkDownloadFile_Click">Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("AutoNo") %>' style="display: none; position: inherit; left: 15px; overflow: scroll;">
                                                <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="TransactionID"
                                                    EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                    GridLines="Horizontal" Width="80%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Vertical" HeaderText="Vertical" />
                                                        <asp:BoundField DataField="Activity" HeaderText="Activity" />
                                                        <asp:BoundField DataField="Payee_Name" HeaderText="PayeeName/Client" />
                                                        <asp:BoundField DataField="BillNo" HeaderText="BillNo/VoucherNo" />
                                                        <asp:BoundField DataField="BillDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="BillDate"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                        <asp:BoundField DataField="TaxType" HeaderText="Tax Type" />
                                                        <asp:BoundField DataField="ServiceTaxPercentage" HeaderText="GST %" />
                                                        <asp:BoundField DataField="ServiceTaxAmount" HeaderText="CGST/IGST Amount" />
                                                        <asp:BoundField DataField="ServiceTaxAmount1" HeaderText="SGST Amount" />
                                                        <asp:BoundField DataField="AdjAmtTyp" HeaderText="Adjustment Type"></asp:BoundField>
                                                        <asp:BoundField DataField="AdjAMT" HeaderText="Adjustment Amount"></asp:BoundField>
                                                        <asp:BoundField DataField="ServiceTaxRegNo" HeaderText="GST No" />
                                                        <asp:BoundField DataField="AccountLedgerName" HeaderText="AccountLedger" />
                                                        <asp:BoundField DataField="DueDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="Total DueAmt"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="Mobile_TelNo" HeaderText="ContactNo" />
                                                        <asp:BoundField DataField="DueAmount" HeaderText="DueAmt" />
                                                        <asp:BoundField DataField="PanNo" HeaderText="PanNo" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark/Naration" />
                                                        <%--<asp:BoundField DataField="TotalAmt" HeaderText="Total" />--%>
                                                        <asp:BoundField DataField="Authorize" HeaderText="Auth.Status" />
                                                        <asp:BoundField DataField="AuthorizeBy" HeaderText="Authorize By" />
                                                        <asp:BoundField DataField="Authorize_date" HeaderText="Authorize Date" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                                                        Font-Overline="False" Font-Size="7.5pt" Font-Underline="False" ForeColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle Font-Names="Tahoma" Font-Size="8pt" />
                        <HeaderStyle Font-Names="Tahoma" Font-Size="8pt" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td style="width: 173px"></td>
            <td style="width: 100px"></td>
            <td style="width: 141px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableGrid" colspan="7" style="height: 32px">
                <asp:Button ID="btnAddPayment" runat="server" BorderWidth="1px" Font-Bold="False"
                    OnClick="btnAddPayment_Click" Text="Make Payment" Width="108px" />
                <asp:Button ID="btnRejectPayment" runat="server" BorderWidth="1px" Font-Bold="False"
                    OnClick="btnRejectPayment_Click" Text="Reject Payment" Width="108px" />
                <asp:Button ID="btnCancel" runat="server"
                    BorderWidth="1px" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td style="width: 173px"></td>
            <td style="width: 100px"></td>
            <td style="width: 141px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
    </table>
</asp:Content>
