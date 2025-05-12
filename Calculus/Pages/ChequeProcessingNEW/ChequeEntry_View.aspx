<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ChequeEntry_View.aspx.cs" Inherits="Pages_ChequeProcessingNEW_ChequeEntry_View" Title="Cheque Entry View" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">
 
    </script>
    <script language="javascript" type="text/javascript">
        function checkSelected(chkSelect) {
            //debugger;
            var grvTransactionInfo = document.getElementById("<%=grv_ChequeEntryList.ClientID%>");
         var chkSelect1 = document.getElementById(chkSelect);


         var cell;
         for (i = 0; i <= grvTransactionInfo.rows.length - 1; i++) {
             cell = grvTransactionInfo.rows[i].cells[0];
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
         // debugger;
         var grvTransactionInfo = document.getElementById("<%=grv_ChequeEntryList.ClientID%>");
        var hdnTransID = document.getElementById("<%=hdnTransactionID.ClientID%>");
        var hdnTransactionID = document.getElementById("<%=hdnTransactionID.ClientID%>");
        var hdnBatchNo = document.getElementById("<%=hdnBatchNo.ClientID%>");

        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var ReturnValue = true;
        var ErrorMessage = '';


        var cell;
        for (i = 0; i <= grvTransactionInfo.rows.length - 1; i++) {
            cell = grvTransactionInfo.rows[i].cells[0];
            if (cell != null) {
                for (j = 0; j < cell.childNodes.length; j++) {

                    if (cell.childNodes[j].type == "checkbox") {
                        if (cell.childNodes[j].checked == true) {

                            if ((grvTransactionInfo.rows[i].cells[20].innerText != ' ') && (ID == 1)) {
                                ErrorMessage = "you cannot modify selected entry!";
                                ReturnValue = false;
                            }

                            hdnTransID.value = grvTransactionInfo.rows[i].cells[22].innerText;
                            hdnBatchNo.value = grvTransactionInfo.rows[i].cells[1].innerText;
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
        else {
            hdnTransactionID.value = hdnTransID.value;
        }
        lblMessage.innerText = ErrorMessage;
        window.scroll(0, 0);
        return ReturnValue;

    }
    </script>
    <table>
        <tr>
            <td colspan="8" style="height: 18px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">&nbsp;Cheque Entry View</td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Batch No</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtBatchNo" runat="server" BorderWidth="1px" MaxLength="200" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Batch Date</td>
            <td style="width: 100px" class="TableGrid">
                <table cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtBatchDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBatchDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px" class="TableTitle">&nbsp;Pickup Date</td>
            <td class="TableGrid" style="width: 100px">
                <table cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtPickupdate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Cheque No</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtChequeNo" runat="server" BorderWidth="1px" MaxLength="6" SkinID="txtSkin"
                    Width="80px"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Cheque Date</td>
            <td class="TableGrid" style="width: 100px">
                <table cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="width: 100px">&nbsp;Cheque Amount</td>
            <td class="TableGrid" style="width: 100px">
                <strong><span style="font-size: 11pt; color: #943634; font-family: Rupee"></span></strong>
                <asp:TextBox ID="txtChequeAmount" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="80px"></asp:TextBox><span style="font-size: 11pt; color: #ffffff; font-family: Rupee; background-color: firebrick"><strong> </strong>`<strong> </strong></span>
                <span style="font-family: Rupee"></span>
            </td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Card No
            </td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtCardNo" runat="server" BorderWidth="1px" MaxLength="16" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;MICR Code</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtMICRCode" runat="server" BorderWidth="1px" MaxLength="9" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Account No</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtAccountNo" runat="server" BorderWidth="1px" MaxLength="16" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Bank Name</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtBankName" runat="server" BorderWidth="1px" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Branch Name</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtBranchName" runat="server" BorderWidth="1px" MaxLength="100"
                    SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Branch City</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtBranchCity" runat="server" BorderWidth="1px" MaxLength="100"
                    SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Contact No</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtContactNo" runat="server" BorderWidth="1px" MaxLength="20" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;TransactionCode</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtTransactionCode" runat="server" BorderWidth="1px" MaxLength="20"
                    SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Receipt No</td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtReceiptNo" runat="server" BorderWidth="1px" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="height: 35px;" class="TableTitle" colspan="8">&nbsp;<asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Text="Search" OnClick="btnSearch_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" BorderWidth="1px" Text="Reset" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">&nbsp;Cheque Entry View List</td>
        </tr>
        <tr>
            <td colspan="8">
                <div style="overflow: scroll; width: 830px; height: 203px">
                    <asp:GridView ID="grv_ChequeEntryList" runat="server" BackColor="White" BorderColor="#CC9966"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grv_ChequeEntryList_RowDataBound" AutoGenerateColumns="False">
                        <RowStyle BackColor="White" ForeColor="#330099" Font-Size="7.5pt" />
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" Font-Size="7.5pt" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                            <asp:BoundField DataField="ClientName" HeaderText="ClientName" />
                            <asp:BoundField DataField="ChequePickupdate" HeaderText="ChequePickupdate" />
                            <asp:BoundField DataField="ChequeDepositdate" HeaderText="ChequeDepositdate" />
                            <asp:BoundField DataField="DropBox_Code" HeaderText="DropBoxCode" />
                            <asp:BoundField DataField="IntrumentType" HeaderText="IntrumentType" />
                            <asp:BoundField DataField="ChequeNo" HeaderText="ChequeNo" />
                            <asp:BoundField DataField="ChequeAmt" HeaderText="Cheque Amt" />
                            <asp:BoundField DataField="CardNo" HeaderText="Card No" />
                            <asp:BoundField DataField="ChequeDate" HeaderText="ChequeDate" />
                            <asp:BoundField DataField="CardAmount" HeaderText="CardAmount" />
                            <asp:BoundField DataField="MICRCode" HeaderText="MICRCode" />
                            <asp:BoundField DataField="BankName" HeaderText="BankName" />
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                            <asp:BoundField DataField="BranchCity" HeaderText="BranchCity" />
                            <asp:BoundField DataField="AccountNo" HeaderText="AccountNo" />
                            <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                            <asp:BoundField DataField="ReceiptNo" HeaderText="ReceiptNo" />
                            <asp:BoundField DataField="TransactionCode" HeaderText="TransactionCode" />
                            <asp:BoundField DataField="DepositSlipNo" HeaderText="DepositSlipNo" />
                            <asp:BoundField DataField="TransactionDetailID" HeaderText="TID" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
            <td style="width: 100px; height: 6px;"></td>
        </tr>
        <tr>
            <td style="height: 28px;" class="TableTitle" colspan="8">&nbsp;<asp:Button
                ID="btnView" runat="server" BorderWidth="1px" Text="View" Width="68px" OnClick="btnView_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="69px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:HiddenField ID="hdnTransactionID" runat="server" />
                <asp:HiddenField ID="hdnBatchNo" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 10px"></td>
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

