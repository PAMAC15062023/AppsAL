<%@ Page Title="" Language="C#" MasterPageFile="~/IncidentTracker2.Master" AutoEventWireup="true" CodeBehind="IT_InvalidRequest.aspx.cs" Inherits="IncidentTracker.IT_InvalidRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 100px"></td>
            <td style="width: 100px; text-align: center">
                <asp:Label ID="lblMessage" runat="server" Font-Size="14pt" ForeColor="Red" Height="149px"
                    Text="Invalid Request or Session Expired , Please continue with username and password" Width="565px"></asp:Label></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 100px"></td>
            <td style="width: 100px; text-align: left">&nbsp;<asp:LinkButton ID="lnkLogin" runat="server"  OnClick="lnkLogin_Click" ToolTip="Please click to Login button" Width="575px">Login Again</asp:LinkButton></td>
            <td style="width: 100px"></td>
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
