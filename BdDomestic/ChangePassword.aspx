<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Theme ="SkinFile"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PMS Online</title>
    <link href="styleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">     
       
    <table class="roundedCorners">
        <tr>
            <td colspan="7" style="height: 16px">
            <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" class="TableHeader">
                &nbsp;Change Password</td>
        </tr>
        <tr>
            <td style="width: 164px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 164px" class="TableTitle">
                &nbsp;Old Password</td>
            <td>
                <span style="color: #ff0000">*</span></td>
            <td style="width: 100px">
                                                  <asp:TextBox ID="txtOldPwd" runat="server" CssClass="TEXTBOX" MaxLength="20" TextMode="Password" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
                                                  <asp:RequiredFieldValidator ID="rfvOld" runat="server" ControlToValidate="txtOldPwd"
                                                      Display="None" ErrorMessage="Please enter Old Password" ValidationGroup="grpCngPwd"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 164px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 164px" class="TableTitle">
                &nbsp;New Password</td>
            <td>
                <span style="color: #ff0000">*</span></td>
            <td style="width: 100px">
                                                    <asp:TextBox ID="txtNewPwd" runat="server" CssClass="TEXTBOX" MaxLength="20" TextMode="Password" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
                                                    <asp:RequiredFieldValidator ID="rfvNew" runat="server" ControlToValidate="txtNewPwd"
                                                        Display="None" ErrorMessage="Please enter Type New Password" ValidationGroup="grpCngPwd"></asp:RequiredFieldValidator>
                                                      </td>
            <td style="width: 100px">
                                                    <asp:CompareValidator ID="cmvNewOld" runat="server" ControlToCompare="txtOldPwd"
                                                        ControlToValidate="txtNewPwd" Display="None" ErrorMessage="Please enter different Type New Password"
                                                        Operator="NotEqual" ValidationGroup="grpCngPwd"></asp:CompareValidator></td>
            <td style="width: 100px">
                                                      </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 164px">
            </td>
            <td>
            </td>
            <td colspan="2">
                                                    </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 164px" class="TableTitle">
                &nbsp;Confirm New Password</td>
            <td>
                <span style="color: #ff0000">*</span></td>
            <td style="width: 100px">
                                                    <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="TEXTBOX" MaxLength="20" TextMode="Password" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
                &nbsp;<asp:CompareValidator ID="cmvConfirmNew" runat="server" ControlToCompare="txtNewPwd"
                                                        ControlToValidate="txtConfirmPwd" Display="None" ErrorMessage="Re-Type Password does not match with Type New Password"
                                                        ValidationGroup="grpCngPwd"></asp:CompareValidator></td>
            <td style="width: 100px">
                                                    <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" ControlToValidate="txtConfirmPwd"
                                                        Display="None" ErrorMessage="Please enter Re-type New Password" ValidationGroup="grpCngPwd"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 164px">
            </td>
            <td>
            </td>
            <td colspan="3">
                <asp:RegularExpressionValidator ID="regExAlphabets" runat="server" ControlToValidate="txtNewPwd"
                    ErrorMessage="Alleast 4 Alphabets required!" ValidationExpression=".{0,}[A-Za-z]{4,}.{0,}"
                    ValidationGroup="grpCngPwd" Width="311px"></asp:RegularExpressionValidator><br />
                <asp:RegularExpressionValidator ID="RegExSpecialChar" runat="server" ControlToValidate="txtNewPwd"
                    ErrorMessage="Alleast 1 Special Character required!  [[@ # $ ! ^ & *]]" ValidationExpression=".{0,}[@#$!^&*]{1,}.{0,}"
                    ValidationGroup="grpCngPwd" Width="311px"></asp:RegularExpressionValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewPwd"
                    ErrorMessage="Atleast 3  Numeric Characters required!!!  [0-9]" ValidationExpression=".{0,}[0-9]{3,}.{0,}"
                    ValidationGroup="grpCngPwd" Width="311px"></asp:RegularExpressionValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewPwd"
                    ErrorMessage="Minimum Length should be 8 Characters longs!" ValidationExpression="^.{8,}$"
                    ValidationGroup="grpCngPwd" Width="311px"></asp:RegularExpressionValidator></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 16px">
                <span style="color: #ff0000">&nbsp;*</span> <strong>[Indicate mandatory fields]</strong></td>
        </tr>
        <tr>
            <td colspan="7">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
                                                    <asp:Button ID="btnSave" runat="server" CssClass="button" ValidationGroup="grpCngPwd" OnClick="btnSave_Click" SkinID="btnSaveSkin" />&nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" CausesValidation="False" OnClick="btnCancel_Click" />&nbsp;
            <asp:Button ID="btnLogin" runat="server" CausesValidation="False" OnClick="btnLogin_Click" Text="Login Again" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="7">
               
                </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:ValidationSummary ID="ValidationSummary1"
                                                            runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpCngPwd" CssClass="ErrorMessage" />
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 16px">
            <div id="shadow-container">
		<div class="shadow1">
			<div class="shadow2">
				<div class="shadow3">
					<div class="container">
					<span style="color: #ff0000">&nbsp;<ul style="margin-top: 0in" type="disc">
                    <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                        <span style="font-size: 8pt; color: #000000; font-family: verdana">Your Password
                            Minimum Length should be 8 Characters longs.</span></li>
                    <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                        <span style="font-size: 8pt; color: #000000; font-family: verdana">Your Password
                            should consist of  at least 4 Alphabets Character [a-z] or [A-Z],</span></li>
                    <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                        <span style="font-size: 8pt; color: #000000; font-family: verdana">Your Password
                            Should consist of  least 1 Numeric [0-9] and 1 special character [!@#$%^&amp;*].</span></li>
          
            <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                <span style="font-size: 8pt; color: #000000; font-family: verdana">Your Password
                        Your Password should follow the below scenario. (For Example)
                 <p class="MsoNormal" style="margin: 0in 0in 0pt 0.75in">1). abcd@123 (Minimum) </p> 
                 <p class="MsoNormal" style="margin: 0in 0in 0pt 0.75in"> 2). abcdef@#1234%  (Medium) </p>
                  <p class="MsoNormal" style="margin: 0in 0in 0pt 0.75in">  3). @Abcdef@$123@12A (Strong)  </p>
                  </span>
               
                </ul>
                </span>
 					</div>
				</div>
			</div>
		</div>
	</div>
            
            </td>
        </tr>
        <tr>
            <td style="width: 164px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    	<div id="layout">
            &nbsp;</div>

	
	 
	 
</form>
</body>
</html>

