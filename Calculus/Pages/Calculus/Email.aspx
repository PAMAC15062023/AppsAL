<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Email.aspx.cs" Inherits="Pages_Calculus_Email" StylesheetTheme="SkinFile"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnMail" runat="server" onclick="BtnMail_Click" Text="Mail" 
                    Width="135px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

