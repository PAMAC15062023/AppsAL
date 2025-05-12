<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="FEPincodeMapping.aspx.cs" Inherits="Administrator_FEPincodeMapping" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
<fieldset><legend class="FormHeading">FE Pincode Mapping</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td >
        <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td></tr>     
        <tr><td style="width: 924px">&nbsp;</td></tr> 
<tr><td >
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
          <td>
              &nbsp;
          </td>
          <td >FE Name<span class="txtRed"> * </span></td><td>:</td><td >
        <asp:DropDownList ID="ddlFEName" runat="server" DataSourceID="sdsFeName" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlFEName_DataBound" SkinID="ddlSkin">
        </asp:DropDownList></td><td>
                </td></tr>
        <tr>
            <td colspan="1">
            </td>
            <td colspan="4">&nbsp;
            </td>
            
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Client <strong><span style="color: #ff0000">* </span></strong>
            </td>
            <td>
                :</td>
            <td colspan="2">
                    <asp:ListBox ID="lstClients" SelectionMode="Multiple" runat="server" DataSourceID="sdsClient" SkinID="lbSkin" DataTextField="CLIENT_NAME" DataValueField="CLIENT_ID" Width="200px"></asp:ListBox>&nbsp;
                    <asp:SqlDataSource ID="sdsClient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
                    SelectCommand="SELECT '0' as [CLIENT_ID],'--All--' as [CLIENT_NAME] UNION SELECT DISTINCT [CLIENT_ID], [CLIENT_NAME] FROM [ce_ac_pr_ct_vw] WHERE [CENTRE_ID]=? AND CLIENT_ID IS NOT NULL order by CLIENT_NAME">
                     <SelectParameters>
                        <asp:SessionParameter Name="?" SessionField="CENTREID" />
                    </SelectParameters>
                    </asp:SqlDataSource>
            </td>
            
        </tr>
        <tr>
            <td colspan="1">
            </td>
            <td colspan="4">&nbsp;
            </td>
            
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Pincode<span class="txtRed"> * </span>
            </td>
            <td>
            </td>
            <td >
            <asp:TextBox ID="txtPincode" runat="server" MaxLength="50" SkinID="txtSkin" Width="563px"></asp:TextBox>
                &nbsp;&nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="height: 14px">
            </td>
            <td colspan="3" style="height: 14px">
            </td>
            <td style="height: 14px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="height: 14px">
            </td>
            <td align="center" colspan="3" style="height: 14px">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                    Text="Save" ValidationGroup="grpFEPinMapping" />
                &nbsp; &nbsp;
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btnCancelSkin"
                    Text="Cancel" /></td>
            <td style="height: 14px">
            </td>
        </tr>
        <tr>
            <td colspan="1">
            </td>
            <td colspan="3">
                <span style="color: #ff0000"><strong>* </strong><span style="color: #000000">Indicate
                    mandatory fields. </span></span>
            </td>
            <td>
            </td>
        </tr>
    </table></td></tr>
    </table></fieldset></td></tr></table>
        <asp:SqlDataSource ID="sdsFeName" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [EMP_ID], [FULLNAME] FROM [FE_VW] WHERE CENTRE_ID=? order by FULLNAME">
            <SelectParameters>
                <asp:SessionParameter Name="?" SessionField="CENTREID" />
            </SelectParameters>
        </asp:SqlDataSource>
    &nbsp;
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="grpFEPinMapping" />
        &nbsp;
        <asp:RequiredFieldValidator ID="rfvFEName" runat="server" ControlToValidate="ddlFEName"
            Display="None" ErrorMessage="Please select FE Name" SetFocusOnError="True" ValidationGroup="grpFEPinMapping"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="lstClients"
            Display="None" ErrorMessage="Please select atleast one client." SetFocusOnError="True" ValidationGroup="grpFEPinMapping"></asp:RequiredFieldValidator>     
        <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="txtPincode"
            Display="None" ErrorMessage="Please enter Pincode" SetFocusOnError="True" ValidationGroup="grpFEPinMapping"></asp:RequiredFieldValidator>&nbsp;               
        <asp:RegularExpressionValidator ID="revPin" runat="server" ErrorMessage="Please enter only number for Pincode" Display="None" SetFocusOnError="True" 
            ValidationExpression="^[,\d]+$" ValidationGroup="grpFEPinMapping" ControlToValidate="txtPincode"></asp:RegularExpressionValidator>

</asp:Content>

