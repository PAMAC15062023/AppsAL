<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CM_InvalidRequest.aspx.cs" Inherits="ChangeManagement.CM_InvalidRequest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invalid Request</title>
    <style>
        .message {
            font-size: 14pt;
            color: red;
            text-align: center;
        }
        .login-button {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 801px; margin: 0 auto;">
            <br />
            <br />
            <table style="height: 270px" width="100%">
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMessage" runat="server" CssClass="message"
                            Text="Invalid Request or Session Expired, Please continue with username and password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="login-button">
                        <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click" ToolTip="Please click to Login button">Login Again</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px"></td>
                    <td style="width: 100px; text-align: center">
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
            
        </div>
    </form>
</body>
</html>

