<%@ Page Language="C#" MasterPageFile="Admin_MasterPage.master" AutoEventWireup="true" CodeFile="RoleMaster.aspx.cs" Inherits="Admin_RoleMaster" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/jscript">
function Access()
{
    alert("Access denied!");
    return false;
}
</script>
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
    <fieldset><legend class="FormHeading">View Role Master</legend>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr> 
               <td>
                <!--Search Table Start-->                  
                <table width="100%" border="0"  cellpadding="0" cellspacing="1" >
                    <tr>                               
                        <td align="left" width="10%">
                            Role Name </td>
                        <td align="left" width="90%"><asp:TextBox ID="txtEmpName" runat="server" CssClass="textbox" SkinID="txtSkin"></asp:TextBox>&nbsp;<asp:Button ID="btnSearch" runat="server" class="button" OnClick="btnSearch_Click" SkinID="btnSearchSkin" /></td>
                    </tr>
                </table>
                <!--Search Table End-->
                </td>                                 
            </tr>
        <tr> 
          <td>
              <asp:Label ID="lblMsg" runat="server"></asp:Label>&nbsp;</td>
        </tr>         
        <tr> 
          <td> 
          <table width="100%" border="0"  cellpadding="0" cellspacing="0">           
            <tr> 
                <td>
                <!--View Start-->           
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr><td>
                    <asp:GridView ID="gvRoleMaster" runat="server" AllowPaging="True" AllowSorting="True" PageSize="15"
                            AutoGenerateColumns="False" DataKeyNames="Role_ID" DataSourceID="sdsRoleMaster"
                             Width="100%" OnRowCommand="gvRoleMaster_RowCommand" OnRowDataBound="gvRoleMaster_RowDataBound" SkinID="gridviewSkin">                             
                            <Columns>
                                <asp:BoundField DataField="Role_Name" HeaderText="Role Name" SortExpression="Role_Name" />
                                <asp:TemplateField> 
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("Role_ID") %>'
                                        CommandName="Edit" ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="sdsRoleMaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
                            SelectCommand="SELECT [Role_Id], [Role_Name] FROM [Role_Master] order by Role_Name">
                    </asp:SqlDataSource>
                    </td></tr></table>
                    <!--View End-->    
                </td>                
              </tr>              
           </table>
           </td>                
         </tr>                  
        </table>
      </fieldset>
      </td>
    </tr>            
</table>  
</asp:Content>