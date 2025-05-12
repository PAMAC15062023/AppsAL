<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile" CodeFile="kyc_Export_Template.aspx.cs" Inherits="Administrator_kyc_Export_Template" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
<fieldset><legend class="FormHeading" style="width: 157px">Export Template for kyc</legend>
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
                         HorizontalAlign="Center" Width="100%" SkinID="gridviewSkin" OnRowCommand="gvExportTemplate_RowCommand" OnRowDataBound="gvExportTemplate_RowDataBound" OnSelectedIndexChanged="gvExportTemplate_SelectedIndexChanged" >
                        <Columns>
                        <asp:TemplateField Visible="false">
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTemplateId" Text='<%# Eval("TEMPLATE_ID")%>' runat="server"  ></asp:Label>                                      
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:BoundField DataField="template_name" HeaderText="Template Name" ReadOnly="True" />
                            <asp:BoundField DataField="client_Name" HeaderText="ClientName" ReadOnly="True" />
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
            SelectCommand="SELECT ET.TEMPLATE_ID,ET.Client_id,ET.TEMPLATE_NAME,CT.CLIENT_NAME FROM CPV_kyc_EXPORT_TEMPLATE ET 
            INNER JOIN client_master CT ON ET.Client_id=CT.Client_id ORDER BY ET.TEMPLATE_NAME">
        </asp:SqlDataSource>
        </fieldset>
        </td></tr></table>
        </asp:Content>
    