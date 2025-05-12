<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" Theme="SkinFile" CodeFile="EBC_VerificationView.aspx.cs" Inherits="CPV_EBC_EBC_VerificationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
       <!--
       function ClientValidate(source, arguments)
       {
          //alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       // -->
</script>
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
    <tr><td  style="height: 14px"></td><td style="height: 14px"></td><td style="height: 14px"></td></tr>
        <tr>
            <td style="width:10%">
                &nbsp;&nbsp;<asp:Label SkinID="lblSkin" ID="lblCaseId" runat="server" Text="CASE ID"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="width:20%">
                <asp:TextBox SkinID="txtSkin" ID="txtCaseId" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCaseId" runat="server" ErrorMessage="Please enter caseId." 
                ControlToValidate="txtCaseId" Display="None" SetFocusOnError="True" ValidationGroup="grpValidateSearch"></asp:RequiredFieldValidator>
            </td>
          
            <td  class="TDWidth" style="width:10%" >
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Enter" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="grpValidateSearch" /></td>
            <td style="width:2%">
                <asp:HiddenField ID="hdnFEID" runat="server" />
            </td>
            <td style="width:10%">
                &nbsp;&nbsp;
            </td>
            <td>&nbsp;</td>
            <td style="width:60%">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr><td style="height: 14px"></td><td style="height: 14px"></td><td style="height: 14px"></td></tr>
    </table>
    </asp:Panel>  
   <!--End Search Panel-->
     
   <asp:ValidationSummary ID="vsValidateSearch" runat="server" 
                    ValidationGroup="grpValidateSearch" ShowMessageBox="True" ShowSummary="False" />
   </fieldset> 
</td></tr></table>

</asp:Content>
