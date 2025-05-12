<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LNT_Master.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="LNTFinance.Pages.MenuPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" BackImageUrl="Calender.gif"
        Height="32px" Width="47px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 9%">
            <tr>
                <td style="width: 100px; height: 20px; text-align: center">
                    <asp:Label ID="lblMonth" runat="server" Font-Bold="True" ForeColor="White" Text="Sep"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center">
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True" Text="17"></asp:Label></td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </asp:Panel>
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table style="font-size: 8pt; color: gray; font-family: Verdana; text-align: left">
        <tbody>
            <tr>
                <td style="text-align: left; width: 130px;">&nbsp; &nbsp;&nbsp;
                </td>
                <td style="text-align: left"></td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle" style="text-align: left; width: 130px;">&nbsp;
                    User</td>
                <td class="TableGrid" style="text-align: left">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr style="color: #808080">
                <td class="GridViewPagerStyle" style="text-align: left; width: 130px;">&nbsp;
                    Branch</td>
                <td class="TableGrid" style="text-align: left">
                    <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle"
                    style="height: 15px; text-align: left; width: 130px;">&nbsp;
                    Group-Role</td>
                <td class="TableGrid" style="height: 15px; text-align: left">
                    <asp:Label ID="lblRole" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle"
                    style="text-align: left; width: 130px; height: 14px;">&nbsp; Client_Name</td>
                <td class="TableGrid" style="height: 15px; text-align: left">
                    <asp:Label ID="lblClient" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
        </tbody>
    </table>
    &nbsp;
    <marquee><SPAN>&nbsp;<asp:Label id="Label1" runat="server" ForeColor="Gray" Font-Size="7pt" Font-Names="Verdana" Text="[Please Select Your Desire Operation From Menu]"></asp:Label></SPAN></marquee>
    <br />
</asp:Content>
