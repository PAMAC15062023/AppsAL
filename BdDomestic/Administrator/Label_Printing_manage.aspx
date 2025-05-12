<%@ Page Language="C#" MasterPageFile="Admin_MasterPage.master" AutoEventWireup="true"  Theme="SkinFile" CodeFile="Label_Printing_manage.aspx.cs" Inherits="Administrator_Label_Printing_manage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
        <tr><td style="padding-left:8px">
<fieldset><legend class="FormHeading">Label Template View</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">           
   <tr><td align="right"><asp:Button ID="btnnewtemplate" runat="server"   SkinID="btnAddNewSkin" OnClick="btnnewtemplate_Click"  /></td></tr>    
   <tr><td>&nbsp;</td></tr>
     <tr>
       <td> <asp:GridView ID="GridView1" SkinID="gridviewSkin" runat="server" AutoGenerateColumns="False" 
      OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="label_template_id" HeaderText="TemplateId" SortExpression="label_template_id" />
                                <asp:BoundField DataField="template_name" HeaderText="Template Name" SortExpression="template_name" />
                                <asp:BoundField DataField="client_name" HeaderText="Client Name" SortExpression="client_name" />
                                <asp:BoundField DataField="verification_type_code" HeaderText="Veriffication Type"
                                    SortExpression="verification_type_code" />
                                <asp:BoundField DataField="product_name" HeaderText="Produnt Name" SortExpression="product_name" />
                                <asp:BoundField DataField="activity_name" HeaderText="Activity Name" SortExpression="activity_name" />
                                <asp:TemplateField HeaderText="Edit" >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("label_template_id") %>'
                                            CommandName="Edit" ImageUrl="~/Images/icon_edit.gif" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("LABEL_TEMPLATE_ID") %>'
                                            ImageUrl="~/Images/icon_delete.gif" CommandName="del" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                   </asp:GridView> </td></tr>    
       
       
         
      <tr><td> <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT capcl.ACTIVITY_NAME, capcl.PRODUCT_NAME, vtm.VERIFICATION_TYPE_CODE, capcl.CLIENT_NAME, lptm.TEMPLATE_NAME, lptm.LABEL_TEMPLATE_ID FROM LABEL_PRINTING_TEMPLATE_MASTER AS lptm INNER JOIN ce_ac_pr_ct_vw AS capcl ON lptm.CLIENT_ID = capcl.client_id AND lptm.ACTIVITY_ID = capcl.activity_id AND lptm.PRODUCT_ID = capcl.product_id INNER JOIN VERIFICATION_TYPE_MASTER AS vtm ON lptm.VERIFICATION_TYPE_ID = vtm.VERIFICATION_TYPE_ID WHERE (lptm.IS_TYPE_SPECIFIC = '0') OR (lptm.IS_TYPE_SPECIFIC IS NULL) ORDER BY capcl.ACTIVITY_NAME"> </asp:SqlDataSource>
          &nbsp;
          <asp:Label ID="lblError" runat="server" Text=""></asp:Label></td></tr>
     
   </table>   
      </fieldset> 
      </td></tr></table>            
</asp:Content>

