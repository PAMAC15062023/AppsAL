<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="TemplateConfigurationManager.aspx.cs" Inherits="TemplateConfigurationManager" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
<fieldset><legend class="FormHeading" style="width: 157px">Template Configuration Manager</legend>
        <table align="center" width="100%">
        <tr><td>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Width="233px"></asp:Label>
        </td></tr>
            <tr>
                <td  valign="top" align="right">
                
                    <asp:Button ID="btnAdd" runat="server" 
                        SkinID="btnAddNewSkin" Text="Add" OnClick="btnAdd_Click"  />  
                    </td>
            </tr>
            <tr>
                <td valign="top" >
                    <asp:GridView ID="gvImport" runat="server" AutoGenerateColumns="False" DataSourceID="sdsgvImportData"
                         HorizontalAlign="Center" Width="100%" SkinID="gridviewSkin" OnRowCommand="gvImport_RowCommand" OnRowDataBound="gvImport_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="template_name" HeaderText="Template Name" ReadOnly="True" />
                             <asp:BoundField DataField="activity_name" HeaderText="Activity Name" ReadOnly="True" />
                              <asp:BoundField DataField="product_name" HeaderText="Product Name" ReadOnly="True" />
                               <asp:BoundField DataField="client_name" HeaderText="Client Name" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Edit Template">
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" CommandArgument='<%# Eval("template_id") %>'
                                        CommandName="Edit"><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Edit Verification">
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkVerification" runat="server" CausesValidation="False" CommandArgument='<%# Eval("template_id") %>'
                                        CommandName="EditVerification"><img src="../images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplateDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("template_id") %>'
                                        CommandName="Delete1"><img src="../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                        

                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            
        </table>
    
    
        <asp:SqlDataSource ID="sdsgvImportData" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT distinct idm.[TEMPLATE_ID], idm.[TEMPLATE_NAME], idm.[centre_id], idm.[activity_id], idm.[product_id], idm.[client_id],am.activity_name,pm.product_name,cm.client_name FROM [IMPORT_DATA_MASTER] idm inner join activity_master am on(idm.activity_id=am.activity_id) inner join product_master pm on(pm.product_id=idm.product_id)inner join client_master cm on(cm.client_id=idm.client_id)   order by TEMPLATE_NAME">
        </asp:SqlDataSource>
        </fieldset>
        </td></tr></table>
        </asp:Content>
    
