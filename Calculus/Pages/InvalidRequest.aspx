<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="InvalidRequest.aspx.cs" Inherits="Pages_InvalidRequest" Title="Invalid Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;<br />
    <br />
    &nbsp;<br />
    <br />
    <table style="width: 801px">
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px; text-align: center">
    <asp:Label ID="lblMessage" runat="server" Font-Size="14pt" ForeColor="Red" Height="149px"
        Text="Invalid Request or Session Expired , Please continue with username and password" Width="565px"></asp:Label></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px; text-align: left">
                &nbsp;<asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click" ToolTip="Please click to Login button" Width="575px">Login Again</asp:LinkButton></td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

