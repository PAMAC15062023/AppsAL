<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Account_LedgerInfo.aspx.cs" Inherits="Pages_Calculus_Account_LedgerInfo" Title="Account Head" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function GV_RowSelection(RowNo, id) {
            ////debugger; 
            var RowNo = (parseInt(RowNo) + 1);
            var hdnAccountLedger = document.getElementById("<%=hdnAccountLedger.ClientID%>");
            var txtLedgerName = document.getElementById("<%=txtLedgerName.ClientID%>");
            var ddlGroupName = document.getElementById("<%=ddlGroupName.ClientID%>");
            var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
            var Gv_AccountLed = document.getElementById("<%=Gv_AccountLed.ClientID%>");

            hdnAccountLedger.value = Gv_AccountLed.rows[RowNo].cells[0].innerText;
            txtLedgerName.value = Gv_AccountLed.rows[RowNo].cells[1].innerText;
            ddlGroupName.value = Gv_AccountLed.rows[RowNo].cells[4].innerText;
            ddlIsActive.value = Gv_AccountLed.rows[RowNo].cells[3].innerText;

            var i = 0;
            for (i = 0; i <= Gv_AccountLed.rows.length - 1; i++) {
                if (i != 0) {
                    if (hdnAccountLedger.value == Gv_AccountLed.rows[i].cells[0].innerText) {
                        Gv_AccountLed.rows[i].style.backgroundColor = "DarkGray";
                    }
                    else {
                        Gv_AccountLed.rows[i].style.backgroundColor = "white";
                    }
                }
            }
        }

        function Validation_AllField() {
            ////debugger;
            var ReturnType = true;
            var ErrorMessage = "";

            var txtLedgerName = document.getElementById("<%=txtLedgerName.ClientID%>");
    var ddlGroupName = document.getElementById("<%=ddlGroupName.ClientID%>");
    var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
    var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

    if (txtLedgerName.value == '') {
        ErrorMessage = "Account Ledger text field can't be blank";
        ReturnType = false;
    }

    if (ddlGroupName.selectedIndex == 0) {
        ErrorMessage = "Group Name can't be blank";
        ReturnType = false;
    }

    if (ddlIsActive.value == '-Select-') {
        ErrorMessage = "Is Active can't be blank";
        ReturnType = false;
    }

    if (ReturnType) {
        var lblWait = document.getElementById("<%=lblWait.ClientID%>");
          lblWait.innerText = "Please wait.....";
      }

      lblMessage.innerText = ErrorMessage;

      return ReturnType;

  }

    </script>
    <table>
        <tr>
            <td colspan="4" rowspan="1" style="height: 12px">
                <asp:Label ID="lblMessage" runat="server" Width="591px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="3">Account Ledger Info</td>
        </tr>
        <tr>
            <td style="height: 13px; width: 190px;" class="TableTitle">Account Ledger Name</td>
            <td style="height: 13px">
                <asp:TextBox ID="txtLedgerName" runat="server"></asp:TextBox></td>
            <td style="height: 13px; width: 311px;">
                <asp:HiddenField ID="hdnAccountLedger" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 190px; height: 9px" class="TableTitle">Account Ledger Group Name</td>
            <td style="height: 9px">
                <asp:DropDownList ID="ddlGroupName" runat="server" Width="133px">
                </asp:DropDownList></td>
            <td style="width: 311px; height: 9px"></td>
        </tr>
        <tr>
            <td style="width: 190px; height: 27px" class="TableTitle">Is Active</td>
            <td style="height: 27px">
                <asp:DropDownList ID="ddlIsActive" runat="server" Width="75px">
                  <%--  <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="width: 311px; height: 27px"></td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td colspan="3" style="width: 190px">
                <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                <asp:Label ID="lblWait" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="width: 190px; height: 3px">
                <asp:GridView ID="Gv_AccountLed" runat="server"
                    OnRowDataBound="Gv_AccountLed_RowDataBound" AutoGenerateColumns="False"
                    BorderColor="Black" BorderStyle="Double" CssClass="mGrid">
                    <Columns>
                        <asp:BoundField DataField="AccountLedgerId">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AccountledgerName" HeaderText="AccountledgerName" />
                        <asp:BoundField DataField="AccountLedgerGroupName" HeaderText="AccountLedgerGroupName" />
                        <asp:BoundField DataField="Is_Active" HeaderText="Is_Active" />
                        <asp:BoundField DataField="AccountLedgerGroupID">
                            <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

