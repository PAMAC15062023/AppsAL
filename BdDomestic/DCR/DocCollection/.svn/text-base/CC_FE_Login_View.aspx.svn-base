<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" CodeFile="CC_FE_Login_View.aspx.cs" Inherits="CPV_CC_CC_FE_Login_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<fieldset><legend class="FormHeading">FE View Cases </legend>
    <table width="100%">
        <tr>
            <td >
                <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg" Visible="False"></asp:Label></td>
            <td >
            </td>
            <td >
            </td>
        </tr>
        <tr>
            <td colspan="3" rowspan="2">
                <asp:GridView ID="FEgv" runat="server" SkinID="gridviewSkin" Width="100%" DataSourceID="sdsGV">
                </asp:GridView>
            </td>
        </tr>
        <tr>
        </tr>
    </table>
    <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
</fieldset>
</asp:Content>

