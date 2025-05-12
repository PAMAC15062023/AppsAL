<%@ Page Language="C#" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" AutoEventWireup="true" CodeFile="KYC_VerificationView.aspx.cs" Inherits="KYC_KYC_VerificationView" Theme="skinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend  class="FormHeading">Case Verification</legend>

<asp:Panel ID="pnlMsg" runat="server" Width="100%" style="background-color:#E7F6FF">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth" align="center">
            <asp:Label SkinID="lblErrorMsg" ID="lblMsg" runat="server" ></asp:Label></td>               
        </tr>
        
       </table>
 </asp:Panel>
<!--Start Search Panel-->
    <asp:Panel ID="pnlSearch" runat="server" Width="100%">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSearch" style="width:100%" runat="server" >
    <tr><td  style="height: 14px"></td><td style="height: 14px"></td>
        <td style="height: 14px">
        </td>
        <td style="height: 14px; width: 394px;"></td>
        <td style="width: 22px; height: 14px">
        </td>
        <td style="width: 1188px; height: 14px">
        </td>
        <td style="width: 1188px; height: 14px">
        </td>
        <td style="height: 14px">
        </td>
    </tr>
        <tr>
            <td style="width:10%; height: 24px;">
                &nbsp;&nbsp;<asp:Label SkinID="lblSkin" ID="lblCaseId" runat="server" Text="CASE ID"></asp:Label>
            </td>
            <td >:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtCaseId" runat="server" ></asp:TextBox></td>
           
            <td style="width: 394px">
                &nbsp;Verification Type</td>
            <td style="width: 22px">
                :</td>
                <td style="width: 183px">
                &nbsp;<asp:DropDownList SkinID="ddlSkin" ID="ddlVerifyType" runat="server" DataSourceID="sdsVerifyType"
                 DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID" >
            </asp:DropDownList></td>
            <td style="width: 183px">
                <asp:Button ID="Button1" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="grpValidateSearch" /></td>
        </tr>
        <tr><td style="height: 14px"></td><td style="height: 14px"></td>
            <td style="height: 14px">
            </td>
            <td style="height: 14px; width: 394px;"></td>
            <td style="width: 22px; height: 14px">
                &nbsp;</td>
            <td style="width: 1188px; height: 14px">
            </td>
            <td style="width: 1188px; height: 14px">
            </td>
            <td style="height: 14px">
            </td>
        </tr>
    </table>
                <asp:HiddenField ID="hdnFEID" runat="server" />
                <asp:RequiredFieldValidator ID="rfvCaseId" runat="server" ErrorMessage="Please enter caseId." 
                ControlToValidate="txtCaseId" Display="None" SetFocusOnError="True" ValidationGroup="grpValidateSearch"></asp:RequiredFieldValidator>
            <asp:SqlDataSource ID="sdsVerifyType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
              ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
              SelectCommand="Select [VERIFICATION_TYPE_ID],[VERIFICATION_TYPE], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER 
               WHERE VERIFICATION_TYPE_ID IN(1,2,19)">
            </asp:SqlDataSource>
            </asp:Panel>  
   <!--End Search Panel-->
     
   <asp:ValidationSummary ID="vsValidateSearch" runat="server" 
                    ValidationGroup="grpValidateSearch" ShowMessageBox="True" ShowSummary="False" />
                </fieldset> 
</td></tr></table>
</asp:Content>
