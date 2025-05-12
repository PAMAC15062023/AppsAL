<%@ Page Language="C#" MasterPageFile="Admin_MasterPage.master" AutoEventWireup="true" CodeFile="UserRoleManage.aspx.cs" Inherits="UserRoleManage" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
    <fieldset><legend class="FormHeading">Manage Roles</legend>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">  
      <tr> 
          <td align="left">&nbsp;<asp:Label ID="lblMsg" runat="server" CssClass="txtError"></asp:Label></td></tr>  
        <tr> 
          <td align="right" >
           <asp:Button ID="btnAssign1" runat="server" Text="Assign" CssClass="button" OnClick="btnAssign_Click" ValidationGroup="vgrpRoleManage" SkinID="btn" /></td>
        </tr>
        <tr> 
          <td align="left"> 
          <table width="100%" border="0"  cellpadding="0" cellspacing="0" class="shadow">           
            <tr>                 
                <td align="left">     
                <!--View Start-->           
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr><td>Employee Name:&nbsp;</td>
                    <td><asp:DropDownList ID="ddlEmpName" runat="server" CssClass="combo" DataSourceID="sdsEmp" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlEmpName_DataBound" OnSelectedIndexChanged="ddlEmpName_SelectedIndexChanged" AutoPostBack="True" SkinID="ddlSkin">
                        </asp:DropDownList></td>
                    <td width="70%">&nbsp;</td>
                    </tr>                        
                    <tr><td>Emp Code:&nbsp;</td>
                    <td><asp:Label ID="lblEmpCode" runat="server" Text=""></asp:Label>
                    </td>
                    <td width="70%" align="right">
                        &nbsp;</td></tr>                   
                    <tr>
                    <td colspan="3">     
                <!--View Start-->           
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                        <tr>
                            <td width="50%" style="height: 15px">Role:</td>
                            <td width="5%" style="height: 15px"></td>
                            <td width="45%" style="height: 15px">
                                Hierarchy:</td>
                        </tr>
                        <tr>
                            <td align="left" valign="top"> 
                                <asp:GridView ID="gvRole" runat="server" 
                                 DataSourceID="sdsRole" Width="100%" 
                                 CellSpacing="1" CellPadding="2" GridLines="None" DataKeyNames="ROLE_ID" AutoGenerateColumns="False" AllowSorting="True" OnSorting="gvRole_Sorting" SkinID="gridviewNoSort">
                                    <Columns>
                                        <asp:BoundField DataField="ROLE_CODE" HeaderText="Role Code" SortExpression="ROLE_CODE" />
                                        <asp:BoundField DataField="ROLE_NAME" HeaderText="Role Name" SortExpression="ROLE_NAME" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRole" runat="server" />
                                                <asp:HiddenField ID="hidRoleID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ROLE_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>                            
                                    </Columns>                        
                                </asp:GridView>                        
                            </td>
                            <td>
                            </td>
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:TreeView Runat="Server" OnTreeNodePopulate="Node_Populate" ID="TreeView1" CssClass="label">
                                                <Nodes>
                                                    <asp:TreeNode Text="Centre" PopulateOnDemand="True" Value="0"/>
                                                </Nodes>
                                                <LeafNodeStyle BackColor="White" CssClass="label" />
                                                <NodeStyle BackColor="White" />
                                                <ParentNodeStyle CssClass="label" />
                                                <SelectedNodeStyle CssClass="label" />
                                                <RootNodeStyle CssClass="label" />
                                            </asp:TreeView> 
                                        </td>
                                    </tr>
                                </table>                           
                            </td>
                        </tr>
                    </table>
                    <!--View End-->   
                    </td></tr> 
                    </table>
                    <!--View End-->    
                </td>
              </tr>
           </table>
           </td>                
         </tr> 
         <tr>
         <td align="right"> <asp:Button ID="btnAssign" runat="server" Text="Assign" CssClass="button" OnClick="btnAssign_Click" ValidationGroup="vgrpRoleManage" SkinID="btn" />
             </td>
         </tr>                 
        </table>
      </fieldset>
      </td>
    </tr>
    <tr> 
      <td>&nbsp;<asp:SqlDataSource ID="sdsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
              SelectCommand="SELECT EMP_ID, EMP_CODE, FULLNAME FROM EMPLOYEE_MASTER WHERE (CENTRE_ID = ?) ORDER BY FULLNAME">
          <SelectParameters>
              <asp:SessionParameter Name="?" SessionField="CENTREID" />
          </SelectParameters>
      </asp:SqlDataSource>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
              ShowMessageBox="True" ShowSummary="False" ValidationGroup="vgrpRoleManage" />
          <asp:RequiredFieldValidator ID="RFVEmp" runat="server" ErrorMessage="Please select the Employee" ControlToValidate="ddlEmpName" SetFocusOnError="True" ValidationGroup="vgrpRoleManage"></asp:RequiredFieldValidator>
          <asp:SqlDataSource ID="sdsRole" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
              SelectCommand="SELECT [ROLE_ID], [ROLE_CODE], [ROLE_NAME] FROM [ROLE_MASTER] ORDER BY [ROLE_NAME]"></asp:SqlDataSource>
      </td>
    </tr>                
</table>  

</asp:Content>

