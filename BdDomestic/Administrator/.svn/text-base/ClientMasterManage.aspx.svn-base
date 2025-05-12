<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin_MasterPage.master"  CodeFile="ClientMasterManage.aspx.cs" Theme="skinfile" Inherits="Administrator_ClientMasterManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <fieldset><legend class="FormHeading">Client Master</legend>
   
        <table width="100%" cellpadding="1" cellspacing="0" runat="server" id="Table1" border="0">
            <tr>
                <%--<td colspan="3" align="left">
                    Client Master
                </td>--%>
                <td colspan="3" align="right">
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*Mandatory Field"></asp:Label>
                    <asp:Label SkinID="lblSkin" ID="lblTask" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                Client Code
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td>
                :
                </td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtClientCode" runat="server"></asp:TextBox>
                </td>
                <td>
                Client Name
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td>
                :
                </td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtClientName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                Select Activity
                </td>
                <td>
               
                </td>
                <td colspan="4">
                    <asp:TreeView Runat="Server" ID="tvClient" ShowCheckBoxes="Leaf">
                        <Nodes>
                            <asp:TreeNode Text="Centre"  Value="0"/>
                        </Nodes>
                    </asp:TreeView> 
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center">
                    <asp:Button SkinID="btnSaveSkin" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button SkinID="btnCancelSkin" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server"></asp:Label></td>
            </tr>
        </table>
   
</fieldset>

</asp:Content>
