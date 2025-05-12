<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="MakeBranchPaymentView.aspx.cs" Inherits="Pages_Calculus_PaymentIssueProcess"
    Title="Payment Issue" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"> 
    </script>

    <script language="javascript" type="text/javascript">

        function checkSelected(chkSelect) {
            ////debugger;
            var grvTransactionInfo = document.getElementById("<%=grvTransactionInfo.ClientID%>");
          var chkSelect1 = document.getElementById(chkSelect);
          var btnAddPayment = document.getElementById("<%=btnAddPayment.ClientID%>");


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

        function Get_SelectedTransactionID(ID) {
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

                                if ((grvTransactionInfo.rows[i].cells[7].innerText != 'Accept') && (ID == 1)) {
                                    ErrorMessage = "you cannot modify selected entry!";
                                    ReturnValue = false;
                                }

                                hdnTransID.value = grvTransactionInfo.rows[i].cells[5].innerText;

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
            lblMessage.innerText = ErrorMessage;
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
            <td class="TableHeader" colspan="7" style="height: 22px">&nbsp;Payment View Search</td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle" style="width: 173px">&nbsp;Payment ID</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtPaymentID" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Payment Amt</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtPaymentAmt" runat="server" BorderWidth="1px" SkinID="txtSkin" oninput="validateDecimal(this)"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Payment Date</td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="height: 20px">&nbsp;<asp:TextBox ID="txtPaymentDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                            Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPaymentDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle" style="width: 173px">&nbsp;Cheque Date</td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="height: 20px">&nbsp;<asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                            Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">&nbsp;ChequeAmt</td>
            <td class="TableGrid">
                <asp:TextBox ID="txtChequeAmount" runat="server" BorderWidth="1px" SkinID="txtSkin" oninput="validateDecimal(this)"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Cheque No</td>
            <td class="TableGrid">&nbsp;<asp:TextBox ID="txtCheuqeNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle" style="width: 173px">&nbsp;TransactionID</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtTransactionID" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Branch</td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle" style="width: 100px">&nbsp;ClientName/PayeeName</td>
            <td class="TableGrid">&nbsp;<asp:TextBox ID="txtPayeeName" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle" style="width: 173px">&nbsp;BillNo/VoucherNo</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtBillNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;BillDate/VoucherDate</td>
            <td class="TableGrid" style="width: 100px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtBillDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="72px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="width: 100px">&nbsp;Bill Amount</td>
            <td class="TableGrid">&nbsp;<asp:TextBox ID="txtBillAmount" runat="server" BorderWidth="1px" SkinID="txtSkin"
                Width="92px"  oninput="validateDecimal(this)"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnTransID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 31px">&nbsp;<asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Font-Bold="False"
                OnClick="btnSearch_Click" Text="Search" />&nbsp;<asp:Button ID="btnReset" runat="server"
                    BorderWidth="1px" Text="Reset" Width="54px" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 16px">&nbsp;Payment Made Search List</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="overflow: scroll; width: 854px; height: 200px">
                    <asp:GridView ID="grvTransactionInfo" runat="server"
                        AutoGenerateColumns="False" DataKeyNames="PaymentID" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
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
                            <asp:BoundField DataField="PaymentID" HeaderText="Payment ID" SortExpression="PaymentID" />
                            <asp:BoundField DataField="PaymentDate" HeaderText="PaymentDate" SortExpression="PaymentDate" />
                            <asp:BoundField DataField="PaymentAmount" HeaderText="PaymentAmount" SortExpression="PaymentAmount" />
                            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
                            <asp:BoundField DataField="BranchName" HeaderText="Branch" SortExpression="BranchName" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                            <asp:BoundField DataField="RequestType" HeaderText="RequestType" />
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
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="PaymentID"
                                                    EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                    GridLines="Horizontal" Width="80%">
                                                    <Columns>
                                                        <asp:BoundField DataField="TransID" HeaderText="TransID" />
                                                        <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" />
                                                        <asp:BoundField DataField="ChequeAmount" HeaderText="ChequeAmount" />
                                                        <asp:BoundField DataField="ChequeIssueTo" HeaderText="ChequeIssueTo" />
                                                        <asp:BoundField DataField="ChequeNo" HeaderText="ChequeNo" />
                                                        <asp:BoundField DataField="ChequeDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="ChequeDate"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="Payee" HeaderText="Payee" />
                                                        <asp:BoundField DataField="BillNo" HeaderText="BillNo" />
                                                        <asp:BoundField DataField="BillDate" HeaderText="BillDate" />
                                                        <asp:BoundField DataField="BillAmount" HeaderText="BillAmount" />
                                                        <asp:BoundField DataField="ServiceTax" HeaderText="ServiceTax" />
                                                        <asp:BoundField DataField="Serv_Amount" HeaderText="Tax Amount" />
                                                        <asp:BoundField DataField="DueDate" HeaderText="DueDate" />
                                                        <asp:BoundField DataField="DueAmount" HeaderText="DueAmount" />
                                                        <asp:BoundField DataField="AccountHolderName" HeaderText="AccountHolderName" />
                                                        <asp:BoundField DataField="AccountNo" HeaderText="AccountNo" />
                                                        <asp:BoundField DataField="BankName" HeaderText="BankName" />
                                                        <asp:BoundField DataField="BankBranchName" HeaderText="BankBranchName" />
                                                        <asp:BoundField DataField="AuthorizeBy" HeaderText="Authorize By" />

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
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableGrid" colspan="7" style="height: 28px">&nbsp;
                <asp:Button ID="btnAddPayment" runat="server" BorderWidth="1px" Font-Bold="False"
                    OnClick="btnAddPayment_Click" Text="Modify Payment" Width="114px" />
                &nbsp;<asp:Button ID="btnView" runat="server" BorderWidth="1px" Text="View Payment"
                    Width="122px" OnClick="btnView_Click" />
                <asp:Button ID="btnCancel" runat="server"
                    BorderWidth="1px" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td style="width: 173px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
    </table>
</asp:Content>
