<%@ page language="C#" autoeventwireup="true" inherits="InvalidRequest, App_Web_error20.aspx.cdcab7d2" viewStateEncryptionMode="Always" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<script language="javascript" type="text/javascript">

</script>
<title>PAMAC Online Services</title>
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
 
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center" background="Images/topnar.gif" colspan="2" style="font-size: x-large;
                        color: white; font-family: Verdana; height: 35px">
                        P M S
                    </td>
                    <td style="height: 35px" width="41">
                        <img height="51" src="Images/righttopalbo.gif" width="42" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                    <td background="Images/rightbar.gif" rowspan="2">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp; &nbsp;<img height="213" src="Images/PamacLogo1.jpg" width="231" /></td>
                    <td height="450" valign="top">
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">&nbsp;<br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="lblMessage" runat="server" Font-Size="14pt" ForeColor="Red" Height="44px"
                                Text="Error 20: Your request could not be completed."
                                Width="882px" Font-Bold="True"></asp:Label><br />
                            <asp:LinkButton ID="lnkLogin" runat="server" Font-Bold="True" OnClick="lnkLogin_Click"
                                ToolTip="Please click to Login button" Width="575px" Visible="False">Login Again</asp:LinkButton></font></td>
                </tr>
                <tr>
                    <td background="Images/bottomline.gif" colspan="2">
                        <img src="Images/bottomline.gif" /></td>
                    <td>
                        <img height="62" src="Images/rightbottomalbo.gif" width="42" /></td>
                </tr>
            </table>
        </form>
    
   

</body>
</html>
