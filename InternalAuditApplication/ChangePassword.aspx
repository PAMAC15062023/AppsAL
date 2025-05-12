<%@ Page Language="C#" MasterPageFile="~/InternalAudit.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="InternalAuditApplication.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 848px; height: 280px">
        <tr>
            <td colspan="8" rowspan="1" style="height: 14px">
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorMessage" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" rowspan="1" style="height: 14px">&nbsp;Change Password</td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle">&nbsp; OldPassword&nbsp; <span style="color: #ff0000">*</span></td>
            <td style="font-size: 8pt; width: 471px;" class="TableGrid">
                <asp:TextBox ID="txtOldPassword" runat="server" MaxLength="20" TextMode="Password" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 101px; height: 3px">
                <asp:RequiredFieldValidator ID="rfvOldPass" runat="server" Display="None"
                    ErrorMessage="Plz Enter Old Password" ControlToValidate="txtOldPassword" ValidationGroup="grpCngPwd"></asp:RequiredFieldValidator></td>
            <td style="width: 184px; height: 3px"></td>
            <td style="width: 59px; height: 3px"></td>
            <td style="width: 59px; height: 3px"></td>
            <td style="width: 59px; height: 3px"></td>
        </tr>
        <tr>
            <td style="width: 9px"></td>
            <td class="TableTitle">&nbsp; NewPassword&nbsp; <span style="color: #ff0000">*</span></td>
            <td style="width: 471px;" class="TableGrid">
                <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="20" TextMode="Password" SkinID="txtSkin"></asp:TextBox>
                &nbsp; &nbsp; &nbsp;
            </td>
            <td style="width: 572px;">
                <asp:RequiredFieldValidator ID="rfvNewPass" runat="server" ErrorMessage="Plz Enter New Password" ControlToValidate="txtNewPassword" Display="None" ValidationGroup="grpCngPwd"></asp:RequiredFieldValidator></td>
            <td style="width: 572px;">
                <asp:CompareValidator ID="CmvNewPassword" runat="server" ErrorMessage="Plz Enter Any New Password" ControlToCompare="txtOldPassword" ControlToValidate="txtNewPassword" Display="None" ValidationGroup="grpCngPwd" Operator="NotEqual" Width="102px"></asp:CompareValidator></td>
            <td style="width: 572px;"></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 9px; height: 8px"></td>
            <td class="TableTitle" style="height: 8px;">ConfirmPassword<span style="color: #ff0000">*</span>
            </td>
            <td style="height: 8px; font-size: 8pt; width: 471px;" class="TableGrid">
                <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20" TextMode="Password" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 101px; height: 8px">
                <asp:RequiredFieldValidator ID="rfvConfirmPass" runat="server" ErrorMessage="Plz Enter Confirm Password" ControlToValidate="txtConfirmPassword" Display="None" ValidationGroup="grpCngPwd"></asp:RequiredFieldValidator></td>
            <td style="width: 184px; height: 8px">
                <asp:CompareValidator ID="cmvConfPass" runat="server" ErrorMessage="Re-enter password does not password" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" Display="None" Width="61px" ValidationGroup="grpCngPwd"></asp:CompareValidator></td>
            <td style="width: 59px; height: 8px"></td>
            <td style="width: 59px; height: 8px"></td>
            <td style="width: 59px; height: 8px"></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px"></td>
            <td colspan="7">
                <span style="color: #ff0000">&nbsp;<span style="font-size: 8pt">*</span></span>
                <strong><span style="font-size: 8pt">Indicate</span> <span style="font-size: 8pt">Mandatory</span>
                    <span style="font-size: 8pt">fields</span></strong></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px; height: 66px"></td>
            <td colspan="7" style="height: 66px">
                <asp:RegularExpressionValidator ID="regExAlphabets" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="Alleast 4 Alphabets required!" ValidationExpression=".{0,}[A-Za-z]{4,}.{0,}"
                    ValidationGroup="grpCngPwd" Width="311px"></asp:RegularExpressionValidator><br />
                <asp:RegularExpressionValidator ID="RegExSpecialChar" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="Alleast 1 Special Character required!  [[@ # $ ! ^ & *]]" ValidationExpression=".{0,}[@#$!^&*]{1,}.{0,}"
                    ValidationGroup="grpCngPwd" Width="315px"></asp:RegularExpressionValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="Atleast 3  Numeric Characters required!!!  [0-9]" ValidationExpression=".{0,}[0-9]{3,}.{0,}"
                    ValidationGroup="grpCngPwd" Width="311px"></asp:RegularExpressionValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="Minimum Length should be 8 Characters longs!" ValidationExpression="^.{8,}$"
                    ValidationGroup="grpCngPwd" Width="311px"></asp:RegularExpressionValidator></td>
        </tr>
        <tr style="font-size: 8pt">
            <td class="TableTitle" colspan="8" rowspan="1" style="height: 37px">&nbsp;&nbsp;
                <asp:Button ID="btnConfirm" runat="server" Text="Save" Font-Bold="True"  Width="71px" ValidationGroup="grpCngPwd" BorderWidth="1px" OnClick="btnConfirm_Click" />
                &nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" Font-Bold="True" BorderWidth="1px" OnClick="btnReset_Click" />
                &nbsp;
                <asp:Button ID="btnLogin" runat="server" Font-Bold="True"
                    Text="Login Again"  BorderWidth="1px" OnClick="btnLogin_Click" />&nbsp;
        </tr>
        <tr>
            <td colspan="1" style="width: 9px; height: 13px"></td>
            <td colspan="7">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                    ShowMessageBox="True" ShowSummary="False" Width="183px" ValidationGroup="grpCngPwd" />
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 9px; height: 12px"></td>
            <td style="width: 825px; height: 12px" colspan="7">
                <div id="shadow-container">
                    <div class="shadow1">
                        <div class="shadow2">
                            <div class="shadow3">
                                <div class="container">
                                    <span style="color: #ff0000">&nbsp;
					<ul style="margin-top: 0in" type="circle">
                        <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                            <span style="font-size: 8pt; color: navy; font-family: verdana">Your Password
                            Minimum Length should be 8 Characters longs.</span></li>
                        <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                            <span style="font-size: 8pt; color: navy; font-family: verdana">Your Password
                            should consist of  at least 4 Alphabets Character [a-z] or [A-Z],</span></li>
                        <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                            <span style="font-size: 8pt; color: navy; font-family: verdana">Your Password
                            Should consist of  least 1 Numeric [0-9] and 1 special character [!@#$%^&amp;*].</span></li>
                        <li class="MsoNormal" style="margin: 0in 0in 0pt; mso-list: l0 level1 lfo1; tab-stops: list .5in">
                            <span style="font-size: 8pt; color: navy; font-family: verdana">Your Password
                        Your Password should follow the below scenario. (For Example)
                 <p class="MsoNormal" style="margin: 0in 0in 0pt 0.75in">1). abcd@123 (Minimum) </p>
                                <p class="MsoNormal" style="margin: 0in 0in 0pt 0.75in">
                                    2). abcdef@#1234%  (Medium) 
                                </p>
                                <p class="MsoNormal" style="margin: 0in 0in 0pt 0.75in">3). @Abcdef@$123@12A (Strong)  </p>
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
            <td colspan="1" style="width: 9px; height: 12px"></td>
            <td colspan="7" style="width: 825px; height: 12px"></td>
        </tr>
    </table>
</asp:Content>

