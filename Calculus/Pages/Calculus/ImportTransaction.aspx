<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ImportTransaction.aspx.cs" Inherits="Pages_Calculus_ImportTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 858px; height: 59px">
        <tr>
            <td class="TableHeader" colspan="4" style="height: 24px">
                Import Transaction:
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 268px">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 268px">
                <asp:Label ID="lblMsgXls1" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 1042px; height: 33px;" class="TableTitle" colspan="1">
                <strong>Sample Download:</strong>
            </td>
            <td style="width: 393px; height: 33px" class="TableGrid" colspan="1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSample" runat="server" Text="Download" Width="82px" OnClick="btnSample_Click1" />
            </td>
            <td style="width: 549px; height: 33px" colspan="1">
            </td>
            <td style="width: 549px; height: 33px" colspan="1">
            </td>
        </tr>
        <td style="width: 1042px; height: 25px">
        </td>
        <tr>
            <td style="width: 1042px; height: 18px;" class="TableTitle" colspan="1">
                Transaction Type:
            </td>
            <td style="width: 393px; height: 18px" class="TableGrid" colspan="1">
                <asp:DropDownList ID="ddlTranstype" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="N">NEFT</asp:ListItem>
                    <asp:ListItem Value="C">Credit Card</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td style="width: 549px; height: 18px" colspan="1">
            </td>
            <td style="width: 549px; height: 18px" colspan="1">
            </td>
        </tr>
        <tr>
            <td style="width: 1042px; height: 1px;" class="TableTitle" colspan="1">
                Import File:
            </td>
            <td style="width: 393px; height: 1px" class="TableGrid" colspan="1">
                <asp:FileUpload ID="xslFileUpload" runat="server" />
            </td>
            <td style="width: 549px; height: 1px" colspan="1">
            </td>
            <td style="width: 549px; height: 1px" colspan="1">
            </td>
        </tr>
        <tr>
            <td style="width: 1042px; height: 51px;" class="TableGrid" colspan="1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupload" runat="server" Text="IMPORT" OnClick="btnupload_Click"
                    Height="23px" Width="74px" />
            </td>
            <td style="width: 393px; height: 51px" class="TableGrid" colspan="1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                    Width="59px" OnClick="btnCancel_Click" Height="27px" />
            </td>
            <td style="width: 549px; height: 51px" colspan="1">
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td style="width: 549px; height: 51px" colspan="1">
            </td>
        </tr>
    </table>
</asp:Content>
