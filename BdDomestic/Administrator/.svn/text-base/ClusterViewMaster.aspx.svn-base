<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClusterViewMaster.aspx.cs" MasterPageFile="Admin_MasterPage.master" Theme="SkinFile" Inherits="Administrator_ClusterViewMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
  <fieldset><legend class="FormHeading">Cluster View Master</legend>
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
                   <asp:GridView SkinID="gridviewSkin" ID="gvClusterMaster" runat="server" DataSourceID="sdsgvClusterMaster" AutoGenerateColumns="False" OnRowCommand="gvClusterMaster_RowCommand" Width="100%" OnRowDataBound="gvClusterMaster_RowDataBound">
                              <Columns>
                                 
                               <asp:BoundField DataField="cluster_name" HeaderText="Cluster Name" ReadOnly="True" />
                                      <asp:TemplateField>	
                                    <ItemTemplate>
                    
                                       <asp:LinkButton ID="lnkcompanyname" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Eval("cluster_id") %>'
                                            ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                      </ItemTemplate>
                  
                                    <ItemStyle VerticalAlign="Top" />
                               </asp:TemplateField>  
                                </Columns>
                            </asp:GridView>
                </td>
            </tr>
        </table>
            <asp:SqlDataSource ID="sdsgvClusterMaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT CLUSTER_ID,CLUSTER_NAME FROM CLUSTER_MASTER order by cluster_name">
        </asp:SqlDataSource>
        <br />
       </fieldset>
       </td></tr></table>    
       
       </asp:Content>