<%@ Page Language="C#" MasterPageFile="Admin_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="Summary_Panel_Mapping_View.aspx.cs" Inherits="Administrator_Summary_Panel_Mapping_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
        <tr><td style="padding-left:8px">
<fieldset><legend class="FormHeading">
    Summary Panel Mapping</legend>
    <table id="tblPanel" width="100%" cellpadding="0" cellspacing="0">
    <tr>
    <td align="right">
    <asp:Button ID="btnNew" SkinID="btnAddNewSkin" runat="server" Text="Add New Template" PostBackUrl="Summary_Panel_Mapping.aspx" OnClick="btnNew_Click"  />
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td>
    <asp:GridView ID="grvSummaryTemplate" SkinID="gridviewSkin" OnRowDataBound="grvSummaryTemplate_RowDataBound" 
    OnRowCommand="grvSummaryTemplate_RowCommand" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="sdsPanelView">
        <Columns>
            <asp:BoundField DataField="TEMPLATE_ID" HeaderText="TEMPLATE ID" SortExpression="TEMPLATE_ID" />
            <asp:BoundField DataField="TEMPLATE_NAME" HeaderText="TEMPLATE NAME" SortExpression="TEMPLATE_NAME" />
            <asp:BoundField DataField="ACTIVITY_NAME" HeaderText="ACTIVITY NAME" SortExpression="ACTIVITY_NAME" />
            <asp:BoundField DataField="PRODUCT_NAME" HeaderText="PRODUCT NAME" SortExpression="PRODUCT_NAME" />
            <asp:BoundField DataField="CLIENT_NAME" HeaderText="CLIENT NAME" SortExpression="CLIENT_NAME" />
            <asp:BoundField DataField="VERIFICATION_TYPE_CODE" HeaderText="VERIFICATION TYPE"
                SortExpression="VERIFICATION_TYPE_CODE" />
             <asp:TemplateField meta:resourcekey="TemplateFieldResource1"> 
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditEBC" runat="server" CommandArgument='<%# Eval("TEMPLATE_ID") %>'
                    CommandName="Edit" ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" />
                    </asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="ImgbtnDel" runat="server" CommandArgument='<%# Eval("TEMPLATE_ID") %>'
            CommandName="btnDelete"><img src="../Images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsPanelView" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT    SDTM.TEMPLATE_ID, SDTM.TEMPLATE_NAME, AM.ACTIVITY_NAME, PM.PRODUCT_NAME, CM.CLIENT_NAME, VTM.VERIFICATION_TYPE_CODE&#13;&#10;FROM         SUMMARY_DETAIL_TEMPLATE_MASTER SDTM INNER JOIN&#13;&#10;                      ACTIVITY_MASTER AM ON SDTM.ACTIVITY_ID = AM.ACTIVITY_ID INNER JOIN&#13;&#10;                      PRODUCT_MASTER PM ON SDTM.PRODUCT_ID = PM.PRODUCT_ID INNER JOIN&#13;&#10;                      CLIENT_MASTER CM ON SDTM.CLIENT_ID = CM.CLIENT_ID INNER JOIN&#13;&#10;                      VERIFICATION_TYPE_MASTER VTM ON SDTM.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID">
    </asp:SqlDataSource>
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </td></tr>
</fieldset>
</td></tr></table>
</asp:Content>

