<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ReimbursedPayment.aspx.cs" Inherits="Pages_Calculus_ReimbursedPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.11.0/jquery-ui.min.js"></script>

    <script type="text/javascript">
        jQuery(function ($) {
            $(".txtDateCss").datepicker({ dateFormat: 'dd/mm/yy' });
        });
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

    <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="857px"></asp:Label>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="24px"
        Width="52px" OnClick="btnCancel_Click" />
    <asp:GridView ID="Gr_Ope_Bal" runat="server" AutoGenerateColumns="False" Height="131px"
        Width="717px" CssClass="mGrid" OnRowEditing="Gr_Ope_Bal_RowEditing"
        OnRowUpdating="Gr_Ope_Bal_RowUpdating"
        OnRowCancelingEdit="Gr_Ope_Bal_RowCancelingEdit">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblTransactionDetailID" runat="server" Text='<%#Eval("TransactionDetailID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" ReadOnly="true" />
            <asp:BoundField DataField="BillNo" HeaderText="Bill No." ReadOnly="true" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="true" />

            <asp:TemplateField HeaderText="Reimbursted Amount">
                <EditItemTemplate>
                    <asp:TextBox ID="txtReimburstedAmount" runat="server" autocomplete="off" oninput="validateDecimal(this)"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Updated Remark">
                <EditItemTemplate>
                    <asp:TextBox ID="txtReimburstedRemark" runat="server" autocomplete="off"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reimbursted On">
                <%--<ItemTemplate>
                    <asp:TextBox ID="txtReimburstedOn" runat="server" CssClass="txtDateCss"></asp:TextBox>
                </ItemTemplate>--%>
                <EditItemTemplate>
                    <asp:TextBox ID="txtReimburstedOn" runat="server" CssClass="txtDateCss" autocomplete="off"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

