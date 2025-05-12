<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IT_LoginPage.aspx.cs" Inherits="IncidentTracker.IT_LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" style="width: 728px">
            <td style="width: 214px" align="center">
                <td style="width: 513px">&nbsp;<table cellpadding="0" cellspacing="0"
                    style="width: 600px; background-image: url('Images/LoginScreen4.jpg'); height: 204px; background-repeat: no-repeat;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <table cellpadding="2" cellspacing="1">
                                <tr>
                                    <td colspan="6" style="height: 0px">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 14px; text-align: center; height: 31px;"></td>
                                </tr>

                                <tr>
                                    <td style="width: 13px; height: 22px;">&nbsp;&nbsp;
                                    </td>
                                    <td style="width: 9px; height: 22px"></td>
                                    <td style="width: 133px; height: 35px; color: #FFFFFF;">
                                        <b style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; User ID</b>
                                    </td>
                                    <td style="height: 22px">
                                        <asp:TextBox ID="txtUserName" runat="server" SkinID="txtSkin"
                                            Style="margin-left: 0px" Width="104px" autofocus="true" Height="11px"></asp:TextBox>
                                    </td>
                                    <td style="width: 11px; text-align: center; height: 22px;">
                                        <asp:RequiredFieldValidator ID="rqUserName" runat="server"
                                            ControlToValidate="txtUserName" ToolTip="Enter User Name" Width="2px">?</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 13px"></td>
                                    <td style="width: 9px"></td>
                                    <td style="width: 133px; color: #FFFFFF;">
                                        <b style="text-align: center">&nbsp; &nbsp; &nbsp; Password</b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" SkinID="txtSkin"
                                            TextMode="Password" Width="104px" Height="11px"></asp:TextBox>
                                    </td>
                                    <td style="width: 11px; text-align: center;">
                                        <asp:RequiredFieldValidator ID="Rq_Password" runat="server"
                                            ControlToValidate="txtPassword" ToolTip="Enter password'" Width="15px">?</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 13px; height: 22px;"></td>
                                    <td style="width: 9px; height: 22px"></td>
                                    <td style="width: 133px; height: 22px; color: #FFFFFF;">
                                        <b style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Branch</b></td>
                                    <td style="height: 32px">
                                        <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin"
                                            Width="112px" Height="19px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 14px; height: 32px;">
                                        <asp:RequiredFieldValidator ID="rq_Branch" runat="server"
                                            ControlToValidate="ddlBranchList" InitialValue="--Select--"
                                            Style="text-align: center" ToolTip="please select Branch" Width="17px">?</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 13px; height: 22px;"></td>
                                    <td style="width: 9px; height: 22px"></td>
                                    <td style="width: 133px; height: 22px; color: #FFFFFF;">
                                        <b style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ClientName</b></td>
                                    <td style="height: 32px">
                                        <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin"
                                            Width="112px" Height="19px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 14px; height: 32px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="ddlClientList" InitialValue="--Select--"
                                            Style="text-align: center" ToolTip="Please select Client Name" Width="17px">?</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 6px; height: 32px;"></td>
                                </tr>
                                <tr>
                                    <td style="width: 13px"></td>
                                    <td style="width: 9px"></td>
                                    <td style="width: 133px; color: #FFFFFF;">
                                        <asp:Image ID="imgCaptcha" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCaptchaAnswer" runat="server" SkinID="txtSkin"
                                            Width="105px"></asp:TextBox>
                                    </td>
                                    <td style="width: 14px; text-align: center;">
                                        <asp:RequiredFieldValidator ID="rvCaptcha" runat="server"
                                            ControlToValidate="txtCaptchaAnswer" ToolTip="Enter password'" Width="15px">?</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 6px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 13px; height: 33px;"></td>
                                    <td style="height: 33px; width: 9px; text-align: left;">&nbsp;</td>
                                    <td style="height: 33px; width: 133px; text-align: center;">
                                        <asp:Button ID="btnLogin" runat="server" BorderWidth="1px" CssClass="button"
                                            Font-Bold="False" OnClick="btnLogin_Click" Height="29px" Text="Login" Width="100px" />
                                    </td>
                                    <td style="height: 33px; text-align: center;">
                                        <asp:LinkButton ID="lkbtnforgotPassword" runat="server" ForeColor="Yellow"
                                            CausesValidation="false">Forgot Password</asp:LinkButton>
                                    </td>
                                    <td style="width: 14px; height: 33px;"></td>
                                    <td style="width: 6px; height: 33px;"></td>
                                </tr>
                                <tr>
                                    <td style="width: 13px; height: 25px"></td>
                                    <td style="height: 25px; width: 9px;"></td>
                                    <td colspan="4" style="height: 25px;"></td>
                                    <td style="height: 25px;"></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">&nbsp;</td>
                                    <td style="text-align: left">&nbsp;</td>
                                    <td colspan="4" style="text-align: left">&nbsp;</td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 100px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 133px"></td>
                        <td style="height: 133px">&nbsp;</td>

                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Height="16px"
                            Visible="False" Width="100%" Font-Bold="True"></asp:Label>
                    </tr>
                </td>
                </td>
            </table> 
    </form>
</body>
</html>
