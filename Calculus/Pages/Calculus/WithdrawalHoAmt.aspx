<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="WithdrawalHoAmt.aspx.cs" Inherits="Pages_Calculus_WithdrawalHoAmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>

    <script language="javascript" type="text/javascript">
        function Validation_AllField() {  ////debugger;
            var ReturnType = true;
            var ErrorMessage = "";
            var hndOpeningBalId = document.getElementById("<%=hndOpeningBalId.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
            var txtWithdrawDate = document.getElementById("<%=txtWithdrawDate.ClientID%>");
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");
            var ddlRequestType = document.getElementById("<%=ddlRequestType.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            debugger;
            if (txtAmount.value == '' || txtAmount.value == 0) {
                ErrorMessage = "Plz Enter Amount";
                ReturnType = false;
            }
            else {
                var regex1 = /^((\d{1,9})(|\056{1}\d{1,2}))$/;  //this is the pattern of regular expersion
                if (regex1.test(txtAmount.value) == false) {
                    ErrorMessage = "Please enter valid tax";
                    ReturnType = false;
                    txtAmount.focus();
                }
                else {
                    if (parseInt(txtAmount.value, 10) % 100 != 0) {
                        ErrorMessage = "Plz Enter Withdrawal Amount Which Is Multiple of 100";
                        ReturnType = false;
                    }
                }
            }

            if (ddlRequestType.selectedIndex == 0) {
                ErrorMessage = "Plz Select RequestType";
                ReturnType = false;
            }


            //            if (parseInt(txtAmount, 10) % 100 != 0) {
            //                ErrorMessage = "Plz Enter Withdrawal Amount Which Is Multiple of 100";
            //                ReturnType = false;
            //            }

            if (ReturnType) {
                var lblWait = document.getElementById("<%=lblWait.ClientID%>");
                lblWait.innerText = "Please wait.....";
            }


            lblMessage.innerText = ErrorMessage;

            return ReturnType;

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

    <script language="javascript" type="text/javascript" src="../popcalendar.js"> </script>

    <table style="width: 858px; height: 59px">
        <tr>
            <td class="TableHeader" colspan="4" style="height: 24px">&nbsp;Withdrawal HO Amount
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 268px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="857px"></asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td style="height: 26px; width: 234px;" class="TableTitle">
                Actual Date Of Withdrawal&nbsp;
            </td>
            <td style="width: 100px; height: 20px" class="TableGrid">
                <asp:TextBox ID="txtPaymentDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="78px" AutoPostBack="true" 
                    ontextchanged="txtPaymentDate_TextChanged1"></asp:TextBox>&nbsp;<img
                        id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPaymentDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" />
            </td>
            <td style="width: 95px; height: 20px">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>--%>
        <tr>
            <td style="height: 32px; width: 234px;" class="TableTitle">Actual Year Of Withdrawal&nbsp;
            </td>
            <td style="width: 100px; height: 32px" class="TableGrid">
                <asp:DropDownList ID="ddlYear" runat="server" Width="109px" Height="28px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                    <asp:ListItem Value="2021">2021</asp:ListItem>
                    <asp:ListItem Value="2022">2022</asp:ListItem>
                    <asp:ListItem Value="2023">2023</asp:ListItem>
                    <asp:ListItem Value="2024">2024</asp:ListItem>
                    <asp:ListItem Value="2025">2025</asp:ListItem>
                    <asp:ListItem Value="2026">2026</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 95px; height: 32px">&nbsp;
            </td>
            <td style="height: 32px"></td>
        </tr>
        <tr>
            <td style="height: 32px; width: 234px;" class="TableTitle">Actual Month Of Withdrawal&nbsp;
            </td>
            <td style="width: 100px; height: 32px" class="TableGrid">
                <asp:DropDownList ID="ddlMonth" runat="server" Width="109px" Height="28px" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="TableTitle" style="width: 223px">Transfer HO Available Amount
            </td>
            <td style="width: 264px; height: 15px" class="TableGrid">
                <asp:Label ID="lblHOAmount" runat="server" Height="21px" Width="91px" Visible="False"
                    Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <%--<asp:DropDownList ID="ddlMonth" runat="server" Width="78px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" Width="78px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                </asp:DropDownList>--%>
            </td>
        </tr>
        <%--<tr>
            <td style="height: 26px; width: 234px;" class="TableTitle">
                Branch Name
            </td>
            <td style="width: 264px; height: 26px" class="TableGrid">
                &nbsp;<asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
                <asp:Label ID="lblBranchName" runat="server" Height="23px" Width="91px" Visible="False"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
        </tr>--%>
        <tr>
            <td class="TableTitle" style="width: 234px">Date Of Withdrawal
            </td>
            <td style="width: 264px; height: 15px" class="TableGrid">
                <asp:TextBox ID="txtWithdrawDate" MaxLength="10" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtWithdrawDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" />
                <%--<asp:DropDownList ID="ddlMonth" runat="server" Width="78px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" Width="78px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                </asp:DropDownList>--%>
            </td>
            <td style="width: 223px"></td>
            <td style="width: 105px; height: 15px"></td>
        </tr>
        <%--<tr>
            <td class="TableTitle">
                Year & Month
            </td>
            <td style="width: 264px; height: 15px">
                <asp:DropDownList ID="ddlMonth" runat="server" Width="78px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" Width="78px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 101px">
            </td>
            <td style="width: 105px; height: 15px">
            </td>
        </tr>--%>
        <tr>
            <td class="TableTitle" style="height: 17px; width: 234px;">Withdrawal Amount
            </td>
            <td style="width: 264px; height: 17px" class="TableGrid">
                <asp:TextBox ID="txtAmount" runat="server" oninput="validateDecimal(this)"></asp:TextBox>
            </td>
            <td style="width: 223px; height: 17px"></td>
            <td style="width: 105px; height: 17px"></td>
        </tr>
        <tr>
            <td style="height: 29px; width: 234px;" class="TableTitle">Remark
            </td>
            <td style="width: 264px; height: 29px" class="TableGrid">
                <asp:TextBox ID="txtRemark" runat="server" Width="232px" Columns="4" Rows="4" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td style="height: 29px; width: 223px;"></td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 29px; width: 234px;">Request Type
            </td>
            <td style="width: 264px; height: 29px" class="TableGrid">
                <asp:DropDownList ID="ddlRequestType" runat="server">
                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                    <asp:ListItem Value="1">Petty Cash</asp:ListItem>
                    <%--<asp:ListItem Value="2">Vender Payment</asp:ListItem>
                    <asp:ListItem Value="3">Utility Payment</asp:ListItem>
                    <asp:ListItem Value="4">EMP Payment</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td style="height: 29px; width: 223px;"></td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 26px" class="TableTitle">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="24px"
                    Width="52px" />
                &nbsp; &nbsp;
                <%--<asp:Button ID="btnAdd" runat="server" Text="Add" Height="24px" Width="52px" OnClick="btnAdd_Click" />--%>
                &nbsp;&nbsp; &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="24px"
                    Width="52px" OnClick="btnCancel_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnHOTrnsfr" runat="server" Text="Download Ho Withdraw" Height="24px"
                    Width="152px" OnClick="btnHOTrnsfr_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
                <asp:HiddenField ID="hndOpeningBalId" runat="server" Value="0" />
            </td>
            <td style="height: 29px; width: 223px;"></td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td style="height: 17px" colspan="4">
                <asp:GridView ID="Gr_Ope_Bal" runat="server" AutoGenerateColumns="False" Height="131px"
                    Width="717px" CssClass="mGrid">
                    <Columns>
                        <%--<asp:BoundField DataField="openingBalanceID">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BranchID">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                        <asp:BoundField DataField="openingBalanceYear" HeaderText="Year" />
                        <asp:BoundField DataField="openingBalanceMonth" HeaderText="Month" />
                        <asp:BoundField DataField="BalanceAmount" HeaderText="Amount" />
                        <asp:BoundField DataField="RequestType" HeaderText="RequestType" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <%--<asp:BoundField DataField="MonthId">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReqType">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent"
                                BorderStyle="None" />
                        </asp:BoundField>--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
