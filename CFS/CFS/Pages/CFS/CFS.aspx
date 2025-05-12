<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CFS.aspx.cs" Inherits="Pages_CFS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     
     <asp:Panel ID="pnlproduct" runat="server">
        <table style="width: 688px; height: 40px;">
            <tr>
                <td class="TableHeader" colspan="4" style="width: 690px;">&nbsp;&nbsp; CUSTOMER FeedBack Solution
                </td>
            </tr>
        </table>
    </asp:Panel>

    <br />
    <br />
    <br />

    <asp:Button ID="btnCustomerMaster" runat="server" OnClick="btnCustomerMaster_Click" Text="Customer Master" Width="150px" />

    <asp:Button ID="btnSendMail" runat="server" OnClick="btnSendMail_Click" Text="Send mail" />

     <asp:Button ID="btnCustomerResponseManual" runat="server" OnClick="btnCustomerResponseManual_Click" 
         Text="Manual Customer Response" Width="200px" />

    <asp:Button ID="btnReports" runat="server"  Text="Reports" OnClick="btnReports_Click" /> 

    <asp:Button ID="btnDuplicateMail" runat="server"  Text="DuplicateMail" OnClick="btnDuplicateMail_Click"/> 
 
    <br />
    <br />
    <br />
</asp:Content>

