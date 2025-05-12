<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaymentRequestProcess.aspx.cs" Inherits="Pages_Calculus_PaymentRequestProcess"
    Title="Branch Payment Process " StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"> 
    </script>

    <script language="javascript" type="text/javascript">
        function Validate_Search() {
            var txtTransID = document.getElementById("<%=txtTransID.ClientID%>");
            var ddlRequestType = document.getElementById("<%=ddlRequestType.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var ddlPaymentRequestStatus = document.getElementById("<%=ddlPaymentRequestStatus.ClientID%>");
            var txtRequestFromDate = document.getElementById("<%=txtRequestFromDate.ClientID%>");
            var txtRequestToDate = document.getElementById("<%=txtRequestToDate.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");

            var ReturnValue = true;
            var Count = 0;
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var ErrorMessage = '';

            if (txtTransID.value != '') {
                Count = 1;
            }
            if (ddlRequestType.selectedIndex != 0) {
                Count = 1;
            }
            if (ddlBranchList.selectedIndex != 0) {
                Count = 1;
            }
            if (ddlPaymentRequestStatus.selectedIndex != 0) {
                Count = 1;
            }

            if (txtAmount.value != '') {
                Count = 1;
            }


            if (txtRequestToDate.value == '') {

                ReturnValue = false;
                ErrorMessage = 'Please Request To Date parameters!';
                txtRequestToDate.focus();
            }
            else {

                Count = 1;
            }

            if (txtRequestFromDate.value == '') {
                ReturnValue = false;
                ErrorMessage = 'Please Request From Date parameters!';
                txtRequestFromDate.focus();

            }
            else {

                Count = 1;
            }


            if (Count == 0) {
                ReturnValue = false;
                ErrorMessage = 'Please Enter aleast one search parameters!';
            }




            lblMessage.innerText = ErrorMessage;
            return ReturnValue;
        }
        function openwindow() {
            window.open('OpeningBalanceBranchwise.aspx', '_blank', 'height=350,width=700,status=yes,resizable=yes');
        }

        function resetControls() {
            ////debugger;
            var txtTransID = document.getElementById("<%=txtTransID.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var txtRequestFromDate = document.getElementById("<%=txtRequestFromDate.ClientID%>");
            var txtRequestToDate = document.getElementById("<%=txtRequestToDate.ClientID%>");
            var ddlPaymentRequestStatus = document.getElementById("<%=ddlPaymentRequestStatus.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");

            txtTransID.value = '';
            ddlBranchList.selectedIndex = 0;
            txtRequestFromDate.value = '';
            txtRequestToDate.value = '';
            ddlPaymentRequestStatus.selectedIndex = 0;
            txtAmount.value = '';

            return false;

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

    <table id="MainTable">
        <tr>
            <td>
                <table border="0" cellpadding="1" cellspacing="2">
                    <tr>
                        <td colspan="7">
                            <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="TableHeader" colspan="7" style="height: 22px">&nbsp;Authorize Payment Request</td>
                    </tr>
                    <tr>
                        <td style="width: 11px"></td>
                        <td class="TableTitle">&nbsp;Transaction ID</td>
                        <td class="TableGrid" style="width: 100px">
                            <asp:TextBox ID="txtTransID" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="106px"></asp:TextBox></td>
                        <td class="TableTitle">&nbsp;Request Type</td>
                        <td class="TableGrid">
                            <asp:DropDownList ID="ddlRequestType" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Selected="True" Value="0">--Select All--</asp:ListItem>
                                <asp:ListItem Value="1">Petty Cash Voucher</asp:ListItem>
                                <asp:ListItem Value="2">Vendor Payment</asp:ListItem>
                                <asp:ListItem Value="3">OtherThan Petty Cash</asp:ListItem>
                                <asp:ListItem Value="4">Utility Payment</asp:ListItem>
                                <asp:ListItem Value="5">EPM Request</asp:ListItem>
                            </asp:DropDownList></td>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnVerticalID" runat="server" />
                            <asp:HiddenField ID="hdnRemark" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11px;"></td>
                        <td class="TableTitle">&nbsp;Branch</td>
                        <td style="width: 100px;" class="TableGrid">
                            <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                            </asp:DropDownList></td>
                        <td class="TableTitle">&nbsp;Request Status</td>
                        <td class="TableGrid">
                            <asp:DropDownList ID="ddlPaymentRequestStatus" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Pending</asp:ListItem>
                                <asp:ListItem Value="2">Accept</asp:ListItem>
                                <asp:ListItem Value="3">Reject</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 100px;"></td>
                        <td style="width: 100px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 11px;"></td>
                        <td class="TableTitle">&nbsp;Request From Date</td>
                        <td class="TableGrid">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                                <tr>
                                    <td style="width: 100px; height: 20px">
                                        <asp:TextBox ID="txtRequestFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                            Width="72px"></asp:TextBox>&nbsp;</td>
                                    <td style="width: 100px; height: 20px">
                                        <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                            src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                                </tr>
                            </table>
                        </td>
                        <td class="TableTitle">&nbsp;Request To Date</td>
                        <td class="TableGrid">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                                <tr>
                                    <td style="width: 100px; height: 20px">
                                        <asp:TextBox ID="txtRequestToDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                            Width="72px"></asp:TextBox>&nbsp;</td>
                                    <td style="width: 100px; height: 20px">
                                        <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                            src="../ChequeProcessing/SmallCalendar.png"
                                            style="width: 19px; height: 18px" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 100px;" class="TableTitle">Amount</td>
                        <td style="width: 100px;" class="TableGrid">
                            <asp:TextBox ID="txtAmount" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="106px" oninput="validateDecimal(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" style="height: 15px">&nbsp; <a href="javascript:openwindow();" title="View Opening Balance">View Opening
                    Balance</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" colspan="7" style="height: 32px">&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" BorderWidth="1px" OnClick="btnSearch_Click"
                    Font-Bold="False" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" BorderWidth="1px" Width="54px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 11px"></td>
                        <td colspan="6">
                            <div style="overflow: scroll; width: 822px; height: 241px; table-layout: fixed; position: static;">
                                <asp:GridView ID="grvTransactionInfo" runat="server" PageSize="20"
                                    OnRowDataBound="grv_RowDataBound" Font-Size="8pt"
                                    DataKeyNames="TransactionID" AutoGenerateColumns="False" CssClass="mGrid">
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
                                        <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID"></asp:BoundField>
                                        <asp:BoundField DataField="Region_Name" HeaderText="Region" SortExpression="Region_Name"></asp:BoundField>
                                        <asp:BoundField DataField="BranchName" HeaderText="Branch" SortExpression="BranchName"></asp:BoundField>
                                        <asp:BoundField DataField="PaymentRequestDate" HeaderText="Request Date" SortExpression="PaymentRequestDate"></asp:BoundField>
                                        <asp:BoundField DataField="RequestedAmount" HeaderText="Requested Amount" SortExpression="RequestedAmount"></asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                                        <asp:BoundField DataField="RequestType" HeaderText="Request Type" />
                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemark" runat="server" MaxLength="100" SkinID="txtSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"Remark"))%>'></asp:TextBox>
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
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelectDetails" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TransactionDetailID" HeaderText="TransactionDetailID"></asp:BoundField>
                                                        <asp:BoundField DataField="Vertical" HeaderText="Vertical"></asp:BoundField>
                                                        <asp:BoundField DataField="Payee_Name" HeaderText="PayeeName/ClientName"></asp:BoundField>
                                                        <asp:BoundField DataField="BillNo" HeaderText="BillNo/VoucherNo"></asp:BoundField>
                                                        <asp:BoundField DataField="BillDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="BillDate/RequestDate"
                                                            HtmlEncode="False"></asp:BoundField>
                                                        <asp:BoundField DataField="Amount" HeaderText="Amount"></asp:BoundField>
                                                        <asp:BoundField DataField="ServiceTaxPercentage" HeaderText="GST%"></asp:BoundField>
                                                        <asp:BoundField DataField="ServiceTaxAmount" HeaderText="CGST/IGST Amount"></asp:BoundField>
                                                        <asp:BoundField DataField="ServiceTaxAmount1" HeaderText="SGST Amount"></asp:BoundField>
                                                        <asp:BoundField DataField="AdjAmtTyp" HeaderText="Adjustment Type"></asp:BoundField>
                                                        <asp:BoundField DataField="AdjAMT" HeaderText="Adjustment Amount"></asp:BoundField>
                                                        <asp:BoundField DataField="ServiceTaxRegNo" HeaderText="GST NO"></asp:BoundField>
                                                        <asp:BoundField DataField="AccountLedgerName" HeaderText="AccountLedger"></asp:BoundField>
                                                        <asp:BoundField DataField="DueDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="Due Date"
                                                            HtmlEncode="False"></asp:BoundField>
                                                        <asp:BoundField DataField="Mobile_TelNo" HeaderText="ContactNo"></asp:BoundField>
                                                        <asp:BoundField DataField="DueAmount" HeaderText="DueAmt"></asp:BoundField>
                                                        <asp:BoundField DataField="PanNo" HeaderText="PanNo"></asp:BoundField>
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark/Naration"></asp:BoundField>
                                                        <%-- <asp:BoundField DataField="TotalAmt" HeaderText="Total"></asp:BoundField>--%>
                                                        <asp:BoundField DataField="Authorize_Remark" HeaderText="Authorizer Remark"></asp:BoundField>
                                                        <asp:BoundField DataField="Authorize" HeaderText="Auth.Status"></asp:BoundField>
                                                        <asp:BoundField DataField="AuthorizeBy" HeaderText="Auth.By"></asp:BoundField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="dimgray" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                                                        Font-Overline="False" Font-Size="7.5pt" Font-Underline="False" ForeColor="wheat" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle Font-Names="Verdana" Font-Size="7.5pt" />
                                    <HeaderStyle Font-Names="Verdana" Font-Size="7.5pt" />
                                </asp:GridView>
                                &nbsp;
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td style="height: 13px">
                                <asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>
                                &nbsp;<asp:GridView ID="GridView2" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 11px; height: 34px;"></td>
                        <td colspan="6" class="TableTitle" style="height: 34px">&nbsp; &nbsp;
                <asp:Button ID="btnAccept" runat="server" Text="Approve" BorderWidth="1px" OnClick="btnAccept_Click"
                    Width="83px" />
                            <asp:Button ID="btnReject" runat="server" Text="Reject" BorderWidth="1px" OnClick="btnReject_Click"
                                Width="78px" />
                            <asp:Button ID="btnExport" runat="server" Text="Export" BorderWidth="1px" OnClick="btnExport_Click" Width="83px" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderWidth="1px" OnClick="btnCancel_Click" Width="83px" /></td>
                    </tr>
                    <tr>
                        <td colspan="7">&nbsp;</td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
</asp:Content>
