<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true"  Theme="SkinFile" CodeFile="Label_Printing_manage_Cellular.aspx.cs" Inherits="Administrator_Label_Printing_manage_Cellular"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
<fieldset><legend class="FormHeading">Label Template View</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">           
     <tr><td align="right"><asp:Button ID="btnnewtemplate" runat="server"   SkinID="btnAddNewSkin" OnClick="btnnewtemplate_Click"  /></td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
      <td> <asp:GridView ID="GridView1" SkinID="gridviewSkin" runat="server" AutoGenerateColumns="False" 
      OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="LABEL_TEMPLATE_ID" HeaderText="LABEL_TEMPLATE_ID" SortExpression="LABEL_TEMPLATE_ID"
                                    Visible="False" />
                                <asp:BoundField DataField="TEMPLATE_NAME" HeaderText="TEMPLATE_NAME" SortExpression="TEMPLATE_NAME" />
                                <asp:BoundField DataField="CLIENT_NAME" HeaderText="CLIENT_NAME" SortExpression="CLIENT_NAME" />
                                <asp:BoundField DataField="CASE_TYPE" HeaderText="CASE_TYPE" SortExpression="CASE_TYPE" />
                                <asp:BoundField DataField="PRODUCT_NAME" HeaderText="PRODUCT_NAME" SortExpression="PRODUCT_NAME" />
                                <asp:BoundField DataField="ACTIVITY_NAME" HeaderText="ACTIVITY_NAME" SortExpression="ACTIVITY_NAME" />
                                <asp:TemplateField HeaderText="Delete" >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("LABEL_TEMPLATE_ID") %>'
                                            ImageUrl="~/Images/icon_delete.gif" CommandName="del" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("label_template_id") %>'
                                            CommandName="Edit" ImageUrl="~/Images/icon_edit.gif" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                   </asp:GridView> </td></tr>    
       
       
         
      <tr><td style="height: 38px"> <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT distinct ce_ac_pr_ct_vw.ACTIVITY_NAME, ce_ac_pr_ct_vw.PRODUCT_NAME, ce_ac_pr_ct_vw.CLIENT_NAME, CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE, LABEL_PRINTING_TEMPLATE_MASTER.TEMPLATE_NAME, LABEL_PRINTING_TEMPLATE_MASTER.LABEL_TEMPLATE_ID FROM LABEL_PRINTING_TEMPLATE_MASTER INNER JOIN ce_ac_pr_ct_vw ON LABEL_PRINTING_TEMPLATE_MASTER.ACTIVITY_ID = ce_ac_pr_ct_vw.activity_id AND LABEL_PRINTING_TEMPLATE_MASTER.CLIENT_ID = ce_ac_pr_ct_vw.client_id AND LABEL_PRINTING_TEMPLATE_MASTER.PRODUCT_ID = ce_ac_pr_ct_vw.product_id INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER ON LABEL_PRINTING_TEMPLATE_MASTER.VERIFICATION_TYPE_ID = CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE_ID WHERE (LABEL_PRINTING_TEMPLATE_MASTER.IS_TYPE_SPECIFIC = '1')"> </asp:SqlDataSource>
          &nbsp;
          <asp:Label ID="lblError" runat="server" Text=""></asp:Label></td></tr>
     
   </table>   
      </fieldset>    
      </td></tr></table>         
</asp:Content>

