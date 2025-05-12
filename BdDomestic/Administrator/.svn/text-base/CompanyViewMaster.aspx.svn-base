<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin_MasterPage.master" Theme="SkinFile" CodeFile="CompanyViewMaster.aspx.cs" Inherits="Administrator_CompanyViewMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
  <fieldset><legend class="FormHeading">Company View Master</legend>
        <table width="100%" cellpadding="1" class="tblBorder" style="border:0" cellspacing="0">
            <tr>
                <td colspan="2" valign="top" align="right"  >
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Black" SkinID="lblErrorMsg"></asp:Label>
                  
                    <asp:Button ID="btnSddNew" runat="server" 
                        SkinID="btnAddNewSkin" Text="Add" OnClick="btnAddMultiColumn_Click" /></td>
                        
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <td valign="top" >
                 <asp:GridView SkinID="gridviewSkin" ID="gvCompanyMaster" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataSourceID="sdsgvCompanyMaster" Width="100%"  OnRowUpdating="gvCompanyMaster_RowUpdating" OnRowCommand="gvCompanyMaster_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="company_name" HeaderText="Company name" SortExpression="company_name" ReadOnly="True" />
                            <asp:BoundField DataField="COMPANY_CODE" HeaderText="Company Code" ReadOnly="True" />
                           
                            <asp:TemplateField>	
                  <ItemTemplate>
                    <asp:LinkButton ID="lnkcompanyname" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Eval("company_id") %>'
                                            ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                  </ItemTemplate>
                  
                  <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>  
                        </Columns>
                    </asp:GridView>
                
                </td>
            </tr>
        </table>
    <asp:SqlDataSource ID="sdsgvCompanyMaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="System.Data.OleDb"
                        SelectCommand="select company_name,company_id,company_code from company_master order by company_name">
                    </asp:SqlDataSource>
        <br />
       </fieldset>
       </td>    
       </tr></table>
       </asp:Content>