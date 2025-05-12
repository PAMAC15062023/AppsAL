<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Administrator/Admin_MasterPage.master" CodeFile="CongfigurationVerificatinManager.aspx.cs" Inherits="CongfigurationVerificatinManager" Theme="SkinFile"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<fieldset><legend class="FormHeading" style="width: 157px">Configuration&nbsp; Verification Manager</legend>
    <table align="center" width="100%">
            <tr>
                <td >
                    <asp:GridView ID="gvImport" runat="server" AutoGenerateColumns="False" DataSourceID="sdsgvImportData"
                        Height="140px" HorizontalAlign="Center" Width="1012px" SkinID="gridviewSkin" OnRowCommand="gvImport_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="template_name" HeaderText="Template Name" ReadOnly="True" />
                            <asp:BoundField DataField="activity_name" HeaderText="Activity Name" ReadOnly="True" />
                            <asp:BoundField DataField="product_name" HeaderText="Product Name" ReadOnly="True" />
                            <asp:BoundField DataField="client_name" HeaderText="Client Name" ReadOnly="True" />
                            <asp:TemplateField>
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" CommandArgument='<%# Eval("template_id") %>'
                                        CommandName="Edit"><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        <tr>
            <td>
                    <asp:Button ID="btnAdd" runat="server" 
                        SkinID="btnAddNewSkin" Text="Add" OnClick="btnAdd_Click" />
                <asp:Label ID="lblMsg" runat="server" ForeColor="Black" 
                        Width="233px"></asp:Label></td>
        </tr>
        </table>
   
     <asp:SqlDataSource ID="sdsgvImportData" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT distinct IDM.[TEMPLATE_NAME], IVM.[TEMPLATE_ID], IVM.[TABLE_NAME], IVM.[MULTIPLE_COLUMN], IVM.[MULTIPLE_VALUE], IVM.[COLUMN_NAME],am.activity_name,pm.product_name,cm.client_name FROM [IMPORT_VERIFICATION_MASTER] IVM INNER JOIN IMPORT_DATA_MASTER IDM ON(IDM.TEMPLATE_ID=IVM.TEMPLATE_ID )
   inner join activity_master am on(idm.activity_id=am.activity_id) inner join product_master pm on(pm.product_id=idm.product_id)inner join client_master cm on(cm.client_id=idm.client_id)  order by TABLE_NAME">
        </asp:SqlDataSource>
        </fieldset>
        </asp:Content>
    
