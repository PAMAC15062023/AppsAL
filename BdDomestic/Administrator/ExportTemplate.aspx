<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="ExportTemplate.aspx.cs" Inherits="Administrator_ExportTemplate"  Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
<fieldset><legend class="FormHeading" style="width: 157px">Export Template for Cellular</legend>
        <table align="center" width="100%">
             <tr>
                <td  valign="top" align="right">
                    <asp:Button ID="btnAdd" runat="server" 
                        SkinID="btnAddNewSkin" Text="Add" OnClick="btnAdd_Click"  />  <asp:Label ID="lblMsg" runat="server" ForeColor="Red" 
                        Width="233px"></asp:Label>
                    </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td valign="top" >
                    <asp:GridView ID="gvExportTemplate" runat="server" AutoGenerateColumns="False" DataSourceID="sdsExportData"
                         HorizontalAlign="Center" Width="100%" SkinID="gridviewSkin" OnRowCommand="gvExportTemplate_RowCommand" OnRowDataBound="gvExportTemplate_RowDataBound" >
                        <Columns>
                        <asp:TemplateField Visible="false">
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTemplateId" Text='<%# Eval("TEMPLATE_ID")%>' runat="server"  ></asp:Label>                                      
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:BoundField DataField="template_name" HeaderText="Template Name" ReadOnly="True" />
                            <asp:BoundField DataField="CASE_TYPE" HeaderText="Case Type" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Edit Template">
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TEMPLATE_ID") %>'
                                        CommandName="Edit"><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplateDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TEMPLATE_ID") %>'
                                        CommandName="Delete1"><img src="../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                        

                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
           <tr><td>&nbsp;</td></tr>
        </table>
    
    
        <asp:SqlDataSource ID="sdsExportData" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
            SelectCommand="SELECT ET.TEMPLATE_ID,ET.CASE_TYPE_ID,ET.TEMPLATE_NAME,CT.CASE_TYPE FROM CPV_CELLULAR_EXPORT_TEMPLATE ET 
            INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER CT ON ET.CASE_TYPE_ID=CT.CASE_TYPE_ID ORDER BY ET.TEMPLATE_NAME">
        </asp:SqlDataSource>
        </fieldset>
        </td></tr></table>
        </asp:Content>
    





