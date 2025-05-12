<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="StandarTatHour.aspx.cs" Inherits="Administrator_StandarTatHour" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
<fieldset><legend class="FormHeading">Standard Tat Hour</legend>

    <table id="tblSTDTAT" width="100%" cellpadding="0" cellspacing="0">
        <tr>
        <td style="width: 132px"><asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 132px">Activity</td>
           
            <td style="width: 615px"><asp:DropDownList ID="ddlActivity" runat="server" SkinID="ddlSkin"  AutoPostBack="True" OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged" Width="76px" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 132px"> Product</td>
            <td style="width: 615px"><asp:DropDownList ID="ddlProduct" runat="server" SkinID="ddlSkin"  AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" Width="76px"></asp:DropDownList></td>
           
        </tr>
        <tr>
            <td style="width: 132px">Client</td>
            <td style="width: 615px"><asp:DropDownList ID="ddlClient" SkinID="ddlSkin"  runat="server" Width="76px"></asp:DropDownList></td>
            
        </tr>
        <tr>
            <td style="width: 132px">Std_Tat_Hours1</td>
            <td style="width: 615px"><asp:TextBox ID="txtHrs1" SkinID="txtSkin"  runat="server" Width="117px" MaxLength="6"></asp:TextBox>&nbsp; [hhh:mm]</td>        
        </tr>
        <tr>
            <td style="width: 132px">Std_Tat_Hours2</td>
            <td style="width: 615px"><asp:TextBox ID="txtHrs2" SkinID="txtSkin" Width="117px"  runat="server" MaxLength="6"></asp:TextBox>&nbsp; [hhh:mm]</td>
                      
        </tr>
        <tr>
            <td style="width: 132px">Std_Tat_Hours3</td>
            <td style="width: 615px"><asp:TextBox ID="txtHrs3" SkinID="txtSkin"  Width="117px" runat="server" MaxLength="6"></asp:TextBox>&nbsp; [hhh:mm]</td>
        </tr>
        <tr>            
            <td align="right" colspan="2"><asp:Button ID="btnSave" runat="server" SkinID="btnSaveSkin" Text="Save" OnClick="btnSave_Click" ValidationGroup="grp" Width="55px" />
            <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin"  OnClick="btnCancel_Click" Text="Button" />&nbsp; &nbsp; </td>
          
        </tr>
        <tr> <td colspan="8" >&nbsp;</td></tr>
       
        <tr>
            <td style="width: 132px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHrs1"
                    ErrorMessage="Please Enter Standard Tat Hour1" SetFocusOnError="True" ValidationGroup="grp" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHrs2"
                    ErrorMessage="Please Enter Standard Tat Hour2" SetFocusOnError="True" ValidationGroup="grp" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHrs3"
                    ErrorMessage="Please Enter Standard Tat Hour3" SetFocusOnError="True" ValidationGroup="grp" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="List" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="grp" />
            </td>
            <td style="width: 615px">
                <asp:CompareValidator ID="cfvfordddActivity" runat="server" ControlToValidate="ddlActivity"
                    Display="None" ErrorMessage="Please Select Activity" Operator="GreaterThan"
                    ValidationGroup="grp" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidatorproduct" runat="server" ControlToValidate="ddlProduct"
                    Display="None" ErrorMessage="Please Select Product !!" Operator="GreaterThan"
                    ValidationGroup="grp" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidatorclient" runat="server" ControlToValidate="ddlClient"
                    Display="None" ErrorMessage="Please Select Client !! " Operator="GreaterThan"
                    ValidationGroup="grp" ValueToCompare="0"></asp:CompareValidator>
                <asp:RegularExpressionValidator ID="Tat_Hours1" runat="server" ControlToValidate="txtHrs1"
                    Display="None" ErrorMessage="Please enter valid Time Format For Std_Tat_Hours1 " SetFocusOnError="True"
                    ValidationExpression="^([0-9][0-9][0-9]|[0-9][0-9]|[0-9])(:([0-5][0-9])){1,3}$" ValidationGroup="grp"></asp:RegularExpressionValidator>&nbsp;
                <asp:HiddenField ID="hidTemplateID" runat="server" />
                <asp:HiddenField ID="hdnField" runat="server" />
                <br />
                <asp:RegularExpressionValidator ID="Tat_Hours2" runat="server" ControlToValidate="txtHrs2"
                    Display="None" ErrorMessage="Please enter valid Time Format For Std_Tat_Hours2" SetFocusOnError="True"
                    ValidationExpression="^([0-9][0-9][0-9]|[0-9][0-9]|[0-9])(:([0-5][0-9])){1,3}$" ValidationGroup="grp" Height="18px"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="Tat_Hours3" runat="server" ControlToValidate="txtHrs3"
                    Display="None" ErrorMessage="Please enter valid Time Format For Std_Tat_Hours3" SetFocusOnError="True"
                    ValidationExpression="^([0-9][0-9][0-9]|[0-9][0-9]|[0-9])(:([0-5][0-9])){1,3}$" ValidationGroup="grp"></asp:RegularExpressionValidator></td>
        </tr>
    </table>
    </fieldset>
    </td></tr></table>
</asp:Content>

