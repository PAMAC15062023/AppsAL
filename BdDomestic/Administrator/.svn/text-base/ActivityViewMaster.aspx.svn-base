<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityViewMaster.aspx.cs" Theme="SkinFile"  MasterPageFile="Admin_MasterPage.master" Inherits="Administrator_ActivityViewMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
  <fieldset><legend class="FormHeading">Activity View Master</legend>
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
                   <asp:GridView ID="gvActivityMaster" SkinID="gridviewSkin"  runat="server" DataSourceID="sdsgvActivityMaster"  AutoGenerateColumns="False" OnRowCommand="gvActivityMaster_RowCommand"  Width="100%">
                           <Columns>
                           <asp:BoundField DataField="activity_name" HeaderText="Activity Name" ReadOnly="True" />
                            <asp:TemplateField>	
                             
                             <ItemTemplate>
                    
                     <asp:LinkButton ID="lnkcompanyname" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Eval("activity_id") %>'>
                      <img src="../Images/icon_edit.gif"alt="Edit" style="border:0" /></asp:LinkButton>
                               </ItemTemplate>
                  </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                
                </td>
            </tr>
            <asp:SqlDataSource ID="sdsgvActivityMaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select activity_id,activity_name from activity_master order by activity_name">
        </asp:SqlDataSource>
        </table>
        <br />
       </fieldset></td></tr></table>
       </asp:Content>

