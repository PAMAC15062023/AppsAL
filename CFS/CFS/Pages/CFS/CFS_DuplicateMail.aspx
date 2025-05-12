<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CFS_DuplicateMail.aspx.cs" Inherits="Pages_CFS_CFS_DuplicateMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:Panel ID="pnlproduct" runat="server">
        <table style="width: 688px; height: 40px;">
            <tr>
                <td class="TableHeader" colspan="4" style="width: 690px;">&nbsp;Send &nbsp;Duplicate&nbsp; Mail
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px; height: 123px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg1" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 71px;">
                    <strong>Customer ID</strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                   <asp:TextBox ID="txtCustomerId" runat="server" OnTextChanged="txtCustomerId_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                </tr>
            <tr>
                 <td class="TableTitle" style="width: 71px;">
                    <strong>Contact Name</strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
               <td class="TableTitle" style="width: 71px;">
                    <strong>Email ID</strong></td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <table>
        <tr>
            <td class="TableTitle" colspan="4">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"  
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnCalcel" runat="server" Text="Cancel" BorderColor="#400000" BorderWidth="1px"
                        Font-Bold="False" Width="105px"  OnClick="btnCalcel_Click" />
            </td>
        </tr>
    </table>

    <asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="validdata" />

</asp:Content>

