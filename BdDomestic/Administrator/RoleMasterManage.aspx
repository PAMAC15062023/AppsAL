<%@ Page Language="C#" MasterPageFile="Admin_MasterPage.master" AutoEventWireup="true" CodeFile="RoleMasterManage.aspx.cs" Inherits="RoleMasterManage" Theme="skinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
<fieldset><legend class="FormHeading">Edit Role Permissions</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">    
<tr><td >&nbsp;<asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
<tr><td > 
    <table width="100%" border="0" cellpadding="0" cellspacing="0">    
        
        <tr> 
        <td>           
           <table class="tblBorder" cellpadding="2" cellspacing="0" style="width: 100%">
            <tr valign="top">
                <td style="width: 69px"></td>
                <td colspan="2" align="right">
                    <asp:Label ID="lblMode" runat="server" Text="" Visible="false" ForeColor="red"></asp:Label></td>
            </tr>
            <tr valign="top">
                <td style="width: 69px">
                    Role Name<span></span></td>
                <td>
                :
                </td>
                <td>
                    <asp:TextBox ID="txtRoleName" SkinID="txtSkin" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ErrorMessage="Please enter Role Name" ControlToValidate="txtRoleName"  ValidationGroup="grpRoleMaster" Display="None"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlProduct" SkinID="ddlSkin" runat="server" DataSourceID="sdsProduct" DataTextField="PRODUCT_NAME" DataValueField="product_id" OnDataBound="ddlProduct_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                    </asp:DropDownList></td>
              
        <td align="left">
        <asp:Button ID="btnSave"  ValidationGroup="grpRoleMaster" SkinID="btnsaveskin" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
        
            </tr>                    
               <tr valign="top">
                   <td style="width: 69px">
                    Operation</td>
                   <td>
                       :</td>
                   <td>
                   <asp:GridView ID="gvRoleOperation" runat="server"  AutoGenerateColumns="False"
                        DataKeyNames="OPERATION_ID" DataSourceID="sdsRoleOperation"
                         Width="100%" OnRowDataBound="gvRoleOperation_RowDataBound" CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="OPERATION_NAME" HeaderText="Operation Name"/>
                            <asp:TemplateField HeaderText = "Add">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsAdd" runat="server" /><asp:HiddenField ID="hidAdd" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "isAdd") %>'/><asp:HiddenField ID="hidOperationId" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "OPERATION_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText = "Edit">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsEdit" runat="server" /><asp:HiddenField ID="hidEdit" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "isEdit") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText = "Delete">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsDelete" runat="server" /><asp:HiddenField ID="hidDelete" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "isDelete") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText = "View">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsView" runat="server" /><asp:HiddenField ID="hidView" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "isView") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                     <HeaderStyle CssClass="GridHeader" />
                     <AlternatingRowStyle CssClass="GridAlternate" />                                                
                     <PagerStyle HorizontalAlign="Center" CssClass="Class1" />
                     <RowStyle CssClass="GridRow" />
                    </asp:GridView>
                   </td>
                   <td align="left">
                   </td>
               </tr>
               <tr valign="top">
                   <td style="height: 53px">
                   </td>
                   <td style="height: 53px">
                   </td>
                   <td style="height: 53px">
                    <asp:SqlDataSource ID="sdsRoleOperation" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
                    </asp:SqlDataSource>                  
                    <asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [product_id], [PRODUCT_NAME] FROM [activity_product_vw] ORDER BY [PRODUCT_NAME]"></asp:SqlDataSource>
                   </td>
                   <td align="left" style="height: 53px">
        <asp:Button ID="btnSave1"  ValidationGroup="grpRoleMaster" runat="server" SkinID="btnsaveskin" Text="Save" OnClick="btnSave_Click" CssClass="button"/></td>
               </tr>
        </table>                            
            </td>                 
        </tr>       
        <tr>
        <td align="right" style="height: 13px">
        &nbsp;
    </td></tr> 
    </table>
    </td></tr>
</table> </fieldset> 
</td></tr></table>
                    <asp:ValidationSummary ID="vsRoleMaster" CssClass="compulsary" runat="server" ValidationGroup="grpRoleMaster" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" />

  </asp:Content>

