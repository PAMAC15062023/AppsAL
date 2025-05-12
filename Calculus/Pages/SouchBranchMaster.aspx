<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="SouchBranchMaster.aspx.cs" Inherits="Pages_SouchBranchMaster" Title="Source Master Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label><br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="BranchENtry" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;Source Branch Master</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; height: 28px;">
                &nbsp;Souce Branch Name</td>
            <td style="width: 100px; height: 28px;">
                <asp:TextBox ID="txtSourceBranchName" runat="server" ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px; height: 28px;">
                <asp:RequiredFieldValidator ID="Rq_SourceBranchName" runat="server" ControlToValidate="txtSourceBranchName"
                    ErrorMessage="Source Branch not Selected!" ValidationGroup="BranchENtry">?</asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px;">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">
                &nbsp;Branch Mapping</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlBranchList" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                </asp:DropDownList></td>
            <td style="width: 100px">
                <asp:RequiredFieldValidator ID="Rq_Branch" runat="server" ControlToValidate="ddlBranchList"
                    ErrorMessage=" Branch not Selected!" InitialValue="--Select--" ValidationGroup="BranchENtry">?</asp:RequiredFieldValidator></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                    Width="67px" ValidationGroup="BranchENtry" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="grvBranchList" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

