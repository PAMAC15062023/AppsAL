<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CentreViewMaster.aspx.cs" Theme="SkinFile" MasterPageFile="Admin_MasterPage.master" Inherits="Administrator_CentreViewMaster" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
 <table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
  <fieldset><legend class="FormHeading">Centre View Master</legend>
        <table width="100%" cellpadding="1" class="tblBorder" style="border:0" cellspacing="0">
            <tr>
                <td colspan="2" valign="top" align="right"  >
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Black" SkinID="lblErrorMsg"></asp:Label>
                  
                    <asp:Button ID="btnSddNew" runat="server" 
                        SkinID="btnAddNewSkin" Text="Add" OnClick="btnAddMultiColumn_Click" /></td>
                        
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td valign="top" >
                 <asp:GridView ID="gvCentreMaster" SkinID="gridviewSkin" runat="server" AutoGenerateColumns="False" DataSourceID="sdsCentreMaster" OnRowCommand="gvCentreMaster_RowCommand" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="centre_name" HeaderText="Centre Name" SortExpression="centre_name" ReadOnly="True"/>
                                      <asp:TemplateField>	
                  <ItemTemplate>
                    
                     <asp:LinkButton ID="lnkcompanyname" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Eval("centre_id") %>'
                                            ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                  </ItemTemplate>
                  
                  <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>  
                                </Columns>
                            </asp:GridView>
                
                </td>
            </tr>
        </table>
            <asp:SqlDataSource ID="sdsCentreMaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select  centre_id,centre_name from centre_master order by centre_name">
                </asp:SqlDataSource>
        <br />
       </fieldset>
       </td></tr></table>    
       
       </asp:Content>