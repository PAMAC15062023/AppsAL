<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin_MasterPage.master" Theme="skinFile" CodeFile="ProductMasterManage.aspx.cs" Inherits="Administrator_ProductMasterManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
 <table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
<fieldset><legend class="FormHeading">Product Master</legend>
    
        <table width="100%" cellpadding="2" cellspacing="0" runat="server" id="table1" border="0">
            <tr>
              <%-- <td colspan="3" align="left">
                    Product Master
                </td>--%>
                <td colspan="3" align="right">                    
                    <asp:Label SkinID="lblSkin" ID="lblTask" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                Product Code
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td>
                :
                </td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtProductCode" runat="server"></asp:TextBox>
                </td>
                <td>
                Product Name<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                :
                </td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtProductName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
            </tr>
            <tr>
                <td valign="top">
                Select Activity
                </td>
                <td>
               <%-- :--%>
                </td>
                <td colspan="4">
                    <asp:TreeView Runat="Server"  ID="tvProduct" ShowCheckBoxes="Leaf">
                        <Nodes>
                            <asp:TreeNode Text="Centre" Value="0"/>
                        </Nodes>
                    </asp:TreeView> 
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center">
                    <asp:Button SkinID="btnSaveSkin" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="valgrpProductMaster" />
                    <asp:Button SkinID="btnCancelSkin" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                <asp:RequiredFieldValidator ID="valProductCode" runat="server" ErrorMessage="Please enter Product Code." ControlToValidate="txtProductCode" Display="None" SetFocusOnError="True" ValidationGroup="valgrpProductMaster"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="valProductNmae" runat="server" ErrorMessage="Please enter Product Name." ControlToValidate="txtProductName" Display="None" SetFocusOnError="True" ValidationGroup="valgrpProductMaster"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="valgrpProductMaster" />
    </td>
            </tr>
        </table>
    
    </fieldset></td></tr></table>
</asp:Content>