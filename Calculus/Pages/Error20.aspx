<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Error20.aspx.cs" Inherits="Pages_Error20" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <br />
    <br />
    <table style="height: 270px" width="100%">
        <tr>
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
    <asp:Label ID="lblMessage" runat="server" Font-Size="14pt" ForeColor="Red" Height="33px"
        Text="User Already Logined !!!!!!!!!!!!!!" Width="470px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px; text-align: center">
    <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click" ToolTip="Please click to Login button" Width="117px">Login Again</asp:LinkButton></td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    <br />
    &nbsp;
    <br />
    &nbsp;
</asp:Content>

