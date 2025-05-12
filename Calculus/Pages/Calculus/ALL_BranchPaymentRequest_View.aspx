<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ALL_BranchPaymentRequest_View.aspx.cs" Inherits="Pages_Calculus_ALL_BranchPaymentRequest_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"> 
    
    </script>
    <script language="javascript" type="text/javascript">
        function Validate_Search() {
            var txtTransactionID = document.getElementById("<%=txtTransactionID.ClientID%>");
            var txtTotalAmount = document.getElementById("<%=txtTotalAmount.ClientID%>");
            var txtBillNo = document.getElementById("<%=txtBillNo.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var txtPayeeName = document.getElementById("<%=txtPayeeName.ClientID%>");
            var txtBillDate = document.getElementById("<%=txtBillDate.ClientID%>");
            var txtRequestDate = document.getElementById("<%=txtRequestDate.ClientID%>");
            var txtServiceTaxRegNo = document.getElementById("<%=txtServiceTaxRegNo.ClientID%>");
            var txtBillAmount = document.getElementById("<%=txtBillAmount.ClientID%>");
            var ReturnValue = true;
            var Count = 0;
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var ErrorMessage = '';

            if (txtTransactionID.value != '') {

                Count = 1;
            }
            if (txtTotalAmount.value != '') {

                Count = 1;
            }
            if (txtBillNo.value != '') {

                Count = 1;
            }
            if (txtPayeeName.value != '') {
                Count = 1;
            }
            if (txtBillDate.value != '') {

                Count = 1;
            }
            if (txtBillAmount.value != '') {

                Count = 1;
            }
            if (txtServiceTaxRegNo.value != '') {

                Count = 1;
            }

            if (txtRequestDate.value != '') {

                Count = 1;
            }
            if (ddlBranchList.selectedIndex != 0) {
                Count = 1;
            }

            if (Count == 0) {
                ReturnValue = false;
                ErrorMessage = 'Please Enter aleast one search parameters!';
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

                                if ((grvTransactionInfo.rows[i].cells[7].innerText != 'Pending') && (ID == 1)) {
                                    ErrorMessage = "you cannot modify selected entry!";
                                    ReturnValue = false;
                                }

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
            <td class="TableHeader" colspan="7" style="height: 22px">&nbsp;Branch Payment Request 
                - All Branch View</td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle">&nbsp;TransactionID</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtTransactionID" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Total Amount</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtTotalAmount" runat="server" BorderWidth="1px" SkinID="txtSkin" oninput="validateDecimal(this)"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Bill No</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtBillNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle">&nbsp;Branch</td>
            <td style="width: 100px" class="TableGrid">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle">&nbsp;Payee Name</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtPayeeName" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Bill Date</td>
            <td style="width: 100px" class="TableGrid">
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
            <td class="TableTitle">&nbsp;Request Date</td>
            <td style="width: 100px" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtRequestDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">&nbsp;GST No</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtServiceTaxRegNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">&nbsp;Bill Amount</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtBillAmount" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="92px" oninput="validateDecimal(this)"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnTransID" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 31px;" class="TableTitle" colspan="7">&nbsp;<asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Font-Bold="False"
                OnClick="btnSearch_Click" Text="Search" />&nbsp;<asp:Button ID="btnReset" runat="server"
                    BorderWidth="1px" Text="Reset" Width="54px" OnClick="btnReset_Click" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 16px">&nbsp;Payment Request View</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="overflow: scroll; width: 854px; height: 200px">
                    <asp:GridView ID="grvTransactionInfo" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataKeyNames="TransactionID" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                        PageSize="20" ForeColor="Black" GridLines="Horizontal" CssClass="mGrid">
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
                            <asp:BoundField DataField="Region_Name" HeaderText="RegionName" SortExpression="Region_Name" />
                            <asp:BoundField DataField="BranchName" HeaderText="Branch" SortExpression="BranchName" />
                            <asp:BoundField DataField="PaymentRequestDate" HeaderText="RequestDate" SortExpression="PaymentRequestDate" />
                            <asp:BoundField DataField="RequestedAmount" HeaderText="RequestAmount" SortExpression="RequestedAmount" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                        <tr>
                                            <td style="width: 100px">
                                                <img src="../../Pages/Calculus/Images/donload.JPG" alt="Down" /></td>
                                            <td style="width: 100px">
                                                <asp:LinkButton ID="lnkDownloadFile" runat="server" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"DownloadFilePath"))%>'
                                                    ToolTip="Click to Download Attach Documents" OnClick="lnkDownloadFile_Click">Download</asp:LinkButton></td>
                                        </tr>
                                    </table>
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
                                                    GridLines="Horizontal" Width="80%" CssClass="SubNormal">
                                                    <Columns>
                                                        <asp:BoundField DataField="Payee_Name" HeaderText="PayeeName" />
                                                        <asp:BoundField DataField="BillNo" HeaderText="BillNo" />
                                                        <asp:BoundField DataField="BillDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="BillDate"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                        <asp:BoundField DataField="ServiceTaxPercentage" HeaderText="GST%" />
                                                        <asp:BoundField DataField="ServiceTaxAmount" HeaderText="CGST/IGST Amount" />
                                                        <asp:BoundField DataField="ServiceTaxAmount1" HeaderText="SGST Amount"></asp:BoundField>
                                                        <asp:BoundField DataField="AdjAmtTyp" HeaderText="Adjustment Type"></asp:BoundField>
                                                        <asp:BoundField DataField="AdjAMT" HeaderText="Adjustment Amount"></asp:BoundField>
                                                        <asp:BoundField DataField="ServiceTaxRegNo" HeaderText="GST NO" />
                                                        <asp:BoundField DataField="AccountLedgerName" HeaderText="AccountLedger" />
                                                        <asp:BoundField DataField="DueDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="Due Date"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="Mobile_TelNo" HeaderText="ContactNo" />
                                                        <asp:BoundField DataField="DueAmount" HeaderText="DueAmt" />
                                                        <asp:BoundField DataField="PanNo" HeaderText="PanNo" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                                        <%--<asp:BoundField DataField="TotalAmt" HeaderText="Total" />--%>
                                                        <asp:BoundField DataField="Authorize" HeaderText="Authorize" />
                                                        <asp:BoundField DataField="vertical_name" HeaderText="Vertical" />

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
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                            ForeColor="White" />

                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableGrid" colspan="7" style="height: 28px">&nbsp;
                <asp:Button ID="btnView" runat="server" BorderWidth="1px" Font-Bold="False"
                    Text="View" Width="67px" OnClick="btnView_Click" />&nbsp;<asp:Button ID="btnAddNew" runat="server" BorderWidth="1px" OnClick="btnAddNew_Click"
                        Text="Add New" Width="75px" />&nbsp;<asp:Button ID="btnModify"
                            runat="server" BorderWidth="1px" Text="Modify" Width="75px" OnClick="btnModify_Click" />
                <asp:Button ID="btnCancel" runat="server"
                    BorderWidth="1px" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
    </table>
</asp:Content>
