<%@ page language="C#" autoeventwireup="true" inherits="Login, App_Web_default.aspx.cdcab7d2" theme="SkinFile" viewStateEncryptionMode="Always" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc" Namespace="ASPNET_Captcha" Assembly="ASPNET_Captcha" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>

<script language="javascript" src="aes.js" type="text/javascript">    </script>
<script language="JAVASCRIPT" type="text/javascript"> 
function Encrypt1() 
         {     
    var A1 = document.getElementById("<%=txtPassword.ClientID%>").value;  

    var A3 = document.getElementById("<%=txtCaptcha.ClientID%>").value;         
    var key = CryptoJS.enc.Utf8.parse('7061737323313233');//you can change Key value
    var iv = CryptoJS.enc.Utf8.parse('7061737323313233'); //you can change IV value
    var encrypted1 = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(A1+A3), key,
            {
                keySize: 128 / 8,
                iv: iv,
                mode: CryptoJS.mode.CBC,
                padding: CryptoJS.pad.Pkcs7
            });         
         document.getElementById("<%=HiddenField1.ClientID%>").value= encrypted1;    
         document.getElementById("<%=txtPassword.ClientID%>").value= encrypted1;      
          
}  
    </script>
    
<title>PAMAC Online Services</title>
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server"  autocomplete="off">
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr> 
    <td colspan="2" background="Images/topnar.gif" align="center" style="color: white; font-family:Verdana; font-size:x-large; height: 35px;"> P M S </td>
    <td width="41" style="height: 35px"><img src="Images/righttopalbo.gif" width="42" height="51"/></td>
  </tr>
  <tr><td colspan="2">&nbsp;</td>    
      <td background="Images/rightbar.gif" rowspan="2"></td>
</tr>
  <tr> 
    <td valign="top" style="width: 482px">&nbsp;&nbsp;&nbsp;<img src="Images/PamacLogo1.jpg" width="231" height="213"/></td>
     <td height="450px" valign="top">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">&nbsp;</font>
         <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnSubmit" Height="50px" Width="125px">
     <table border="0" cellspacing="0" cellpadding="0" style="width: 103%">
     <tr><td colspan="3"><hr /><asp:Label ID="lblMsg" SkinID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label></td></tr>
                      <tr> 
                        <td style="width:55px">&nbsp;</td>
                        <td style="width:28px">&nbsp;</td>
                        <td style="width:162px">&nbsp;</td>
                      </tr>
                      <tr> 
                        <td align="left" style="width: 55px">Login ID<font color="red"> *</font></td>
                        <td style="height: 30px; width: 28px;">:&nbsp;</td>
                        <td style="height: 30px; width: 162px;">&nbsp;<asp:TextBox ID="txtUserName" runat="server" MaxLength="30" SkinID="txtSkin" Height="20px" Width="151px" AutoCompleteType="disabled" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator
                                ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="None"
                                ErrorMessage="Please enter Username" SetFocusOnError="True" ValidationGroup="grpLogin"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr style="color: #000000"> 
                        <td align="left" style="width: 55px">
                            Passwor<span style="color: black">d</span><font color="red"><span style="color: #ff3300">*</span></font></td>
                        <td style="height: 30px; color: #000000; width: 28px;">:&nbsp;</td>
                        <td style="height: 30px; width: 162px;">&nbsp;<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  SkinID="txtSkin" Height="20px" Width="151px" AutoCompleteType="disabled" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                    ControlToValidate="txtPassword" Display="None" ErrorMessage="Please enter Password"
                                    SetFocusOnError="True" ValidationGroup="grpLogin"></asp:RequiredFieldValidator></td>
                      </tr>
                      <tr style="color: #000000"> 
                        <td align="left" style="width: 55px; height: 30px;">
                            <span>Ce</span>ntre<font color="red"><span style="color: #000000"> *</span></font></td>
                        <td style="height: 30px; color: #000000; width: 28px;">:</td>
                        <td style="height: 30px; width: 162px;">&nbsp;<asp:DropDownList ID="ddlCenter" runat="server" DataSourceID="sdsCenter"
                                DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" Height="28px" Width="157px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCenter" runat="server" ControlToValidate="ddlCenter"
                                Display="None" ErrorMessage="please select centre" SetFocusOnError="True" ValidationGroup="grpLogin"></asp:RequiredFieldValidator></td>
                      </tr>
         <tr>
             <td align="right" colspan="3" style="height: 30px">
                 <uc:ASPNET_Captcha ID="ucCaptcha" runat="server" Align="Middle" Color="#FF0000" />
                 Please Enter Answer &nbsp;Only<asp:Label ID="lblMessage" runat="server" Height="16px" Width="42px"></asp:Label><asp:TextBox ID="txtCaptcha" runat="server" Height="20px" SkinID="txtSkin" Width="151px" onblur="javascript:Encrypt1()"></asp:TextBox>&nbsp;</td>
         </tr>
                      <tr> 
                        <td style="height: 30px;" align="center" colspan="3">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnSubmit" SkinID="btnSignInSkin" runat="server" OnClick="btnLogin_Click" ValidationGroup="grpLogin" Height="26px" Width="106px" />
                          &nbsp;&nbsp; </td>
                      </tr>
                      <tr> 
                        <td style="width: 55px">&nbsp;</td>
                        <td align="right" style="width: 28px">&nbsp;</td>
                        <td align="center" style="width: 162px"> &nbsp; &nbsp;
                        </td>
                      </tr>
                      <tr> 
                        <td colspan="3"><font color="Red">* </font>Indicate mandatory fields.</td>
                      </tr>
                       <tr><td colspan="3" style="height: 32px"><hr />
                           &nbsp;</td></tr>
                       <tr style="height:35"> 
                        <td colspan="3">Best 
                    viewed using IE 6+
                            <br />At a resolution of 1024 x 768 &nbsp;</td>
                </tr>
                <tr> 
                  <td colspan="3">
                    &copy; PAMAC 2007. All rights reserved. &nbsp;</td>
                  
                </tr>
                <tr> 
                  <td colspan="3" style="height: 14px"></td>
                </tr>
         <tr>
             <td colspan="3">
                      <asp:ValidationSummary ID="vsLogin" runat="server" ValidationGroup="grpLogin" DisplayMode="List" ShowMessageBox="true" Visible="true" ShowSummary="false" />
             </td>
         </tr>
                    </table>
             <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label></asp:Panel>
                  <asp:SqlDataSource ID="sdsCenter" runat="server"  ProviderName="System.Data.OleDb"
                                SelectCommand="Sp_centre_client" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
         <asp:HiddenField ID="HiddenField1" runat="server" />
                  </td>
  </tr>
  <tr> 
    <td colspan="2" background="Images/bottomline.gif"><img src="Images/bottomline.gif"></td>
    <td><img src="Images/rightbottomalbo.gif" width="42" height="62"></td>
  </tr>
</table>
</form>
</body>
</html>
