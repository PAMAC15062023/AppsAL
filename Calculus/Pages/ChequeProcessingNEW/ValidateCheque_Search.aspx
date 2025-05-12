<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ValidateCheque_Search.aspx.cs" Inherits="ValidateCheque_Search" Title="BatchFileView" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>
    <script language="javascript" type="text/javascript">

        function checkSelected(chkSelect) {
            //debugger;
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
         //   debugger;
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
                            //debugger;   
                            if ((grvTransactionInfo.rows[i].cells[7].innerText != ' ') && (ID == 1)) {
                                ErrorMessage = "you cannot modify selected entry!";
                                ReturnValue = false;
                            }
                            if ((grvTransactionInfo.rows[i].cells[9].innerText == '0') && (ID == 3)) {
                                ErrorMessage = "All cheques captured!";
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
        // debugger;
        var div = document.getElementById(obj);
        var img = document.getElementById('img' + obj);

        if (div.style.display == "none") {
            div.style.display = "inline";
            if (row == 'alt') {
                img.src = "../Calculus/Images/minus.png";
                mce_src = "../Calculus/Images/minus.png";
            }
            else {
                img.src = "../Calculus/Images/minus.png";
                mce_src = "../Calculus/Images/minus.png";
            }
            img.alt = "Close to view other customers";
        }
        else {
            div.style.display = "none";
            if (row == 'alt') {

                img.src = "../Calculus/Images/plus.png";
                mce_src = "../Calculus/Images/plus.png";
            }
            else {
                img.src = "../Calculus/Images/plus.png";
                mce_src = "../Calculus/Images/plus.png";

            }
            img.alt = "Expand to show Transactions";
        }
    }

    </script>
    <table style="width: 851px">
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 22px">&nbsp;Validate Cheque Entry Search</td>
        </tr>
        <tr>
            <td style="width: 17px;"></td>
            <td style="width: 100px;" class="TableTitle">&nbsp;Batch No</td>
            <td style="width: 100px;" class="TableGrid">
                <asp:TextBox ID="txtBatchNo" runat="server" MaxLength="200" SkinID="txtSkin" Width="119px"></asp:TextBox></td>
            <td style="width: 100px;" class="TableTitle">&nbsp;PickupDate</td>
            <td style="width: 100px;" class="TableGrid">
                <table cellpadding="0" cellspacing="0" style="width: 87px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtPickupDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">&nbsp;<img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px;" class="TableTitle">&nbsp;Send Date</td>
            <td style="width: 88px;" class="TableGrid">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtSendDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">&nbsp;<img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtSendDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 17px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Client</td>
            <td style="width: 100px" class="TableGrid">
                <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Deposit Date</td>
            <td style="width: 100px" class="TableGrid">
                <table cellpadding="0" cellspacing="0" style="width: 54px">
                    <tr>
                        <td style="width: 42px; height: 22px">
                            <asp:TextBox ID="txtDepositdate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="70px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">&nbsp;<img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px" class="TableTitle">&nbsp;Deposit Slip
            </td>
            <td style="width: 88px" class="TableGrid">
                <asp:TextBox ID="txtDepositSlipNo" runat="server" MaxLength="200" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnTransID" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 34px;" class="TableTitle" colspan="7">&nbsp;
                <asp:Button ID="btnSearch" runat="server" BorderWidth="1px" OnClick="btnSearch_Click"
                    Text="Search" />&nbsp;<asp:Button ID="btnClear" runat="server" BorderWidth="1px"
                        OnClick="btnClear_Click" Text="Clear" /></td>
        </tr>
        <tr>
            <td style="height: 6px;" class="TableHeader" colspan="7">&nbsp;&nbsp; Validate Cheque Entry View</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="overflow: scroll; width: 840px; height: 199px">
                    <asp:GridView ID="grvTransactionInfo" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataKeyNames="BatchNo" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                        PageSize="20">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'one');" style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: #ffffff; border-bottom-style: none">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="../Calculus/Images/plus.png" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" /></a>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'alt');">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="../Calculus/Images/plus.png" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" />
                                    </a>
                                </AlternatingItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" SortExpression="BatchNo" />
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" SortExpression="BranchName" />
                            <asp:BoundField DataField="ClientName" HeaderText="ClientName" SortExpression="ClientName" />
                            <asp:BoundField DataField="ChequePickeupDate" HeaderText="ChequePickeupDate" SortExpression="ChequePickeupDate" />
                            <asp:BoundField DataField="ChequeDepositDate" HeaderText="ChequeDepositDate" SortExpression="ChequeDepositDate" />
                            <asp:BoundField DataField="DepositSlipNo" HeaderText="DepositSlipNo" />
                            <asp:BoundField DataField="TotalCount" HeaderText="TotalCount" />
                            <asp:BoundField DataField="Pending" HeaderText="Pending" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                <tr>
                                    <td colspan="100%">
                                        <div id='div<%# Eval("AutoNo") %>' style="display: none; position: relative; left: 15px;">
                                            <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="BatchNo"
                                                EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                GridLines="Horizontal" Width="80%">
                                                <Columns>
                                                    <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
                                                    <asp:BoundField DataField="DropBox_Code" HeaderText="DropBox Code" />
                                                    <asp:BoundField DataField="DropBox_Name" HeaderText="DropBox Name" />
                                                    <asp:BoundField DataField="TotalCount" HeaderText="ChequeCounts" />
                                                    <asp:BoundField DataField="CaptureCount" HeaderText="CaptureCount" />
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
                        <RowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#330099" />
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                            ForeColor="#FFFFCC" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 31px;" class="TableTitle" colspan="7">&nbsp;
                <asp:Button ID="btnView" runat="server" BorderWidth="1px" Text="Validate Cheque Entry" Width="152px" OnClick="btnView_Click" />
                <asp:Button ID="btnClose" runat="server" BorderWidth="1px" Text="Close" Width="65px" OnClick="btnClose_Click" /></td>
        </tr>
        <tr>
            <td style="width: 17px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 88px"></td>
        </tr>
    </table>
</asp:Content>

