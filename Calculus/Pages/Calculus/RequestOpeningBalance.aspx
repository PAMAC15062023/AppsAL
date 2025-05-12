<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="RequestOpeningBalance.aspx.cs" Inherits="Pages_Calculus_Opening_Balance" Title="ExceedBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function GV_RowSelection(RowNo, id) {
            var RowNo = (parseInt(RowNo) + 1);
            var hndOpeningBalId = document.getElementById("<%=hndOpeningBalId.ClientID%>");
            var ddlMonth = document.getElementById("<%=ddlMonth.ClientID%>");
            var ddlYear = document.getElementById("<%=ddlYear.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");
            var ddlRequestType = document.getElementById("<%=ddlRequestType.ClientID%>");
            var Gr_Ope_Bal = document.getElementById("<%=Gr_Ope_Bal.ClientID%>");

            hndOpeningBalId.value = Gr_Ope_Bal.rows[RowNo].cells[0].innerText;
            ddlYear.value = Gr_Ope_Bal.rows[RowNo].cells[3].innerText;
            ddlMonth.value = Gr_Ope_Bal.rows[RowNo].cells[9].innerText;
            txtAmount.value = Gr_Ope_Bal.rows[RowNo].cells[5].innerText;
            ddlRequestType.value = Gr_Ope_Bal.rows[RowNo].cells[10].innerText;
            txtRemark.value = Gr_Ope_Bal.rows[RowNo].cells[7].innerText;

            var i = 0;
            for (i = 0; i <= Gr_Ope_Bal.rows.length - 1; i++) {
                if (i != 0) {
                    if (hndOpeningBalId.value == Gr_Ope_Bal.rows[i].cells[0].innerText) {
                        Gr_Ope_Bal.rows[i].style.backgroundColor = "DarkGray";
                    }
                    else {
                        Gr_Ope_Bal.rows[i].style.backgroundColor = "white";
                    }
                }
            }
        }




        function Validation_AllField() {  ////debugger;
            var ReturnType = true;
            var ErrorMessage = "";

            var hndOpeningBalId = document.getElementById("<%=hndOpeningBalId.ClientID%>");
            var ddlMonth = document.getElementById("<%=ddlMonth.ClientID%>");
            var ddlYear = document.getElementById("<%=ddlYear.ClientID%>");
            var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
            var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");
            var ddlRequestType = document.getElementById("<%=ddlRequestType.ClientID%>");
            var Gr_Ope_Bal = document.getElementById("<%=Gr_Ope_Bal.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            if (ddlMonth.selectedIndex == 0) {
                ErrorMessage = "Plz Select Proper Month";
                ReturnType = false;
            }
            if (ddlYear.selectedIndex == 0) {
                ErrorMessage = "Plz Select Current Year";
                ReturnType = false;
            }

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
            }

            if (ddlRequestType.selectedIndex == 0) {
                ErrorMessage = "Plz Select RequestType";
                ReturnType = false;
            }

            var i = 0;
            for (i = 0; i <= Gr_Ope_Bal.rows.length - 1; i++) {
                if (hndOpeningBalId.value == Gr_Ope_Bal.rows[i].cells[0].innerText) {
                    if (Gr_Ope_Bal.rows[i].cells[8].innerText == 'Accept') {
                        ErrorMessage = "You Can't Modify Accepted Entry!";
                        ReturnType = false;
                    }
                    if (Gr_Ope_Bal.rows[i].cells[8].innerText == 'Reject') {
                        ErrorMessage = "You Can't Modify Rejected Entry!";
                        ReturnType = false;
                    }
                }
            }

            if (ReturnType) {
                var lblWait = document.getElementById("<%=lblWait.ClientID%>");
                lblWait.innerText = "Please wait.....";
            }

            lblMessage.innerText = ErrorMessage;

            return ReturnType;

        }

        function dropdown_validator() {
            var ddlMonth = document.getElementById("<%=ddlMonth.ClientID%>");
            var ddlYear = document.getElementById("<%=ddlYear.ClientID%>");
            var right_now = new Date();
            var the_year = right_now.getYear();
            var the_month = right_now.getMonth();

            if (ddlYear.value > the_year) {
                alert("Please check the year of your request.");
                return (false);
            }
            return (true);
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

    <table style="width: 858px; height: 59px">
        <tr>
            <td class="TableHeader" colspan="4">&nbsp;Request Opening Balance</td>
        </tr>
        <tr>
            <td colspan="4" style="width: 268px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="857px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 26px" class="TableTitle">Branch Name</td>
            <td style="width: 264px; height: 26px">&nbsp;<asp:DropDownList ID="ddlBranchList"
                runat="server" SkinID="ddlSkin">
            </asp:DropDownList>
                <asp:Label ID="lblBranchName" runat="server" Height="23px" Width="91px"
                    Visible="False"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td style="width: 101px; height: 26px">
                <asp:HiddenField ID="hndOpeningBalId" runat="server" Value="0" />
            </td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td class="TableTitle">Year &amp; Month</td>
            <td style="width: 264px; height: 15px">
                <asp:DropDownList ID="ddlMonth" runat="server" Width="78px">
                    <%-- <asp:ListItem>-Select-</asp:ListItem>
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
                    <asp:ListItem Value="12">December</asp:ListItem>--%>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" Width="78px">
                    <%--  <asp:ListItem>-Select-</asp:ListItem>
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
                    <asp:ListItem>2025</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="width: 101px"></td>
            <td style="width: 105px; height: 15px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 17px">Requested
                Amount</td>
            <td style="width: 264px; height: 17px">
                <asp:TextBox ID="txtAmount" runat="server" oninput="validateDecimal(this)"></asp:TextBox></td>
            <td style="width: 101px; height: 17px"></td>
            <td style="width: 105px; height: 17px"></td>
        </tr>
        <tr>
            <td style="height: 29px" class="TableTitle">Remark</td>
            <td style="width: 264px; height: 29px">
                <asp:TextBox ID="txtRemark" runat="server" Width="232px" Columns="4" Rows="4" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td style="height: 29px"></td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 29px">Request Type</td>
            <td style="width: 264px; height: 29px">
                <asp:DropDownList ID="ddlRequestType" runat="server">
                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                    <asp:ListItem Value="1">Petty Cash</asp:ListItem>
                    <asp:ListItem Value="2">Vender Payment</asp:ListItem>
                    <asp:ListItem Value="3">Utility Payment</asp:ListItem>
                    <asp:ListItem Value="4">EMP Payment</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 29px"></td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 26px">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="24px" Width="52px" />
                &nbsp; &nbsp;
                <asp:Button ID="btnAdd" runat="server" Text="Add" Height="24px" Width="52px" OnClick="btnAdd_Click" />
                &nbsp;&nbsp; &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="24px" Width="52px" OnClick="btnCancel_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" class="TableTitle" style="height: 16px"></td>
        </tr>
        <tr>
            <td style="height: 17px" colspan="4">
                <asp:GridView ID="Gr_Ope_Bal" runat="server" AutoGenerateColumns="False"
                    OnRowDataBound="Gv_Opening_Balance_RowDataBound" Height="131px" Width="717px"
                    CssClass="mGrid">
                    <Columns>
                        <asp:BoundField DataField="openingBalanceID">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BranchID">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                        <asp:BoundField DataField="openingBalanceYear" HeaderText="Year" />
                        <asp:BoundField DataField="openingBalanceMonth" HeaderText="Month" />
                        <asp:BoundField DataField="OpeningBalanceAmount" HeaderText="Amount" />
                        <asp:BoundField DataField="RequestType" HeaderText="RequestType" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="MonthId">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReqType">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StatusID">
                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                CssClass="grv_Column_hidden" />
                            <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

