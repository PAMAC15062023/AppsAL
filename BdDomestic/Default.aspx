<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Login" Theme="SkinFile" %>

<%@ Register TagPrefix="uc" Namespace="ASPNET_Captcha" Assembly="ASPNET_Captcha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script language="javascript" type="text/javascript">

</script>
    <title>PAMAC Online Services</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="2" background="Images/topnar.gif" align="center" style="color: white; font-family: Verdana; font-size: x-large; height: 35px;">P M S </td>
                <td width="41" style="height: 35px">
                    <img src="Images/righttopalbo.gif" width="42" height="51"></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td background="Images/rightbar.gif" rowspan="2"></td>
            </tr>
            <tr>
                <td valign="top">&nbsp;&nbsp;&nbsp;<img src="Images/PamacLogo1.jpg" width="231" height="213"></td>
                <td height="450px" valign="top">
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">&nbsp;</font>
                    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnSubmit" Height="50px" Width="125px">
                        <table border="0" cellspacing="0" cellpadding="0" width="60%">
                            <tr>
                                <td colspan="3">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 55px">&nbsp;</td>
                                <td style="width: 1%">&nbsp;</td>
                                <td style="width: 59%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 55px">Login ID<font color="red"> *</font></td>
                                <td style="height: 30px">:&nbsp;</td>
                                <td style="height: 30px">&nbsp; 
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" SkinID="txtSkin"></asp:TextBox><asp:RequiredFieldValidator
                                ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="None"
                                ErrorMessage="Please enter Username" SetFocusOnError="True" ValidationGroup="grpLogin"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="color: #000000">
                                <td align="left" style="width: 55px">Passwor<span style="color: black">d</span><font color="red"><span style="color: #ff3300">*</span></font></td>
                                <td style="height: 30px; color: #000000;">:&nbsp;</td>
                                <td style="height: 30px">&nbsp; 
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20" SkinID="txtSkin"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                ControlToValidate="txtPassword" Display="None" ErrorMessage="Please enter Password"
                                SetFocusOnError="True" ValidationGroup="grpLogin"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="color: #000000">
                                <td align="left" style="width: 55px">
                                    <span>Ce</span>ntre<font color="red"><span style="color: #000000"> *</span></font></td>
                                <td style="height: 30px; color: #000000;">:</td>
                                <td style="height: 30px">&nbsp; 
                            <asp:DropDownList ID="ddlCenter" runat="server" DataSourceID="sdsCenter"
                                DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin">
                            </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCenter" runat="server" ControlToValidate="ddlCenter"
                                        Display="None" ErrorMessage="please select centre" SetFocusOnError="True" ValidationGroup="grpLogin"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="color: #000000">
                                <td align="left" style="width: 55px"></td>
                                <td style="height: 30px; color: #000000;"></td>
                                <td style="height: 30px">
                                    <uc:ASPNET_Captcha ID="captcha1" runat="server" Align="Middle" Color="#FF0000" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Answer Only
                                    <asp:TextBox ID="txtCaptcha" runat="server" SkinID="txtSkin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCaptcha" runat="server" ErrorMessage="*Required"
                                        ControlToValidate="txtCaptcha" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 55px;">&nbsp;</td>
                                <td align="right" style="height: 30px">&nbsp;</td>
                                <td align="left" style="height: 30px">&nbsp;                            
                            <asp:Button ID="btnSubmit" SkinID="btnSignInSkin" runat="server" OnClick="btnLogin_Click" ValidationGroup="grpLogin" />
                                    &nbsp;&nbsp; </td>
                            </tr>
                            <tr>
                                <td style="width: 55px">&nbsp;</td>
                                <td align="right">&nbsp;</td>
                                <td align="center">&nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"><font color="Red">* </font>Indicate mandatory fields.</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 32px">
                                    <hr />
                                    &nbsp;</td>
                            </tr>
                            <tr style="height: 35">
                                <td colspan="3">Best 
                    viewed using IE 6+
                            <br />
                                    At a resolution of 1024 x 768 &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">&copy; PAMAC 2007. All rights reserved. &nbsp;</td>

                            </tr>
                            <tr>
                                <td colspan="3">&nbsp; &nbsp;&nbsp;<asp:Label ID="lblMsg" SkinID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ValidationSummary ID="vsLogin" runat="server" ValidationGroup="grpLogin" DisplayMode="List" ShowMessageBox="true" Visible="true" ShowSummary="false" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:SqlDataSource ID="sdsCenter" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="System.Data.OleDb"
                        SelectCommand="Select CENTRE_ID, CENTRE_NAME from centre_master order by CENTRE_NAME"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" background="Images/bottomline.gif">
                    <img src="Images/bottomline.gif"></td>
                <td>
                    <img src="Images/rightbottomalbo.gif" width="42" height="62"></td>
            </tr>
        </table>
    </form>
</body>
</html>
