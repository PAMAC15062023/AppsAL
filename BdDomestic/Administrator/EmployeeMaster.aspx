<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeMaster.aspx.cs" Inherits="EmployeeMaster" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function Access()
{
    alert('Access denied!');
    return false;
}
</script>
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
    <fieldset><legend class="FormHeading">View Employee Master</legend>
    <table width="100%" border="0" cellspacing="0" cellpadding="0"> 
    <tr><td>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">              
                 <!--Search Table Start-->                  
                    <tr>                               
                        <td>Employee Name
                        </td>
                        <td><asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                        <td>
                            Department
                        </td>
                        <td><asp:DropDownList ID="ddlDept" runat="server" SkinID="ddlSkin" DataSourceID="sdsDept" DataTextField="DEPARTMENT" DataValueField="DEPT_ID" OnDataBound="ddlDept_DataBound">
                            </asp:DropDownList></td>
                        <td width="20%" align="right"><asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="btnSearchSkin" />&nbsp;
                        <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" SkinID="btnAddNewSkin" />&nbsp;</td>
                    </tr>
                    
                </table>
                <!--Search Table End-->   
           </td>
        </tr>
        <tr> 
          <td align="left">&nbsp;
              <asp:Label ID="lblMsg" runat="server" CssClass="txtError"></asp:Label>&nbsp;</td>
        </tr>
        <tr> 
          <td> 
          <table width="100%" border="0" cellpadding="0" cellspacing="0">            
            <tr> 
                <td>                
                <!--View Start-->           
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr><td>
                    <asp:GridView ID="gvEmployeeView" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin" 
                     DataSourceID="SDSEmployee" Width="100%" AllowPaging="True" 
                     PageSize="15" CellSpacing="1"  CellPadding="2" GridLines="None" 
                     OnRowCommand="gvEmployeeView_RowCommand" OnPageIndexChanged="gvEmployeeView_PageIndexChanged" 
                     AllowSorting="True" OnSorting="gvEmployeeView_Sorting" OnRowDataBound="gvEmployeeView_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="EMP_CODE" HeaderText="EMP Code" SortExpression="EMP_CODE" />
                            <asp:BoundField DataField="FULLNAME" HeaderText="Full Name" SortExpression="FULLNAME" />
                            <asp:BoundField DataField="DEPARTMENT" HeaderText="Department" SortExpression="DEPARTMENT" />
                            <asp:TemplateField> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                CommandName="Edit" ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SDSEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
                    SelectCommand="SELECT A.EMP_ID, A.EMP_CODE, A.FULLNAME, B.DEPARTMENT FROM EMPLOYEE_MASTER AS A INNER JOIN DEPARTMENT_MASTER AS B ON A.DEPARTMENT_ID = B.DEPT_ID AND A.CENTRE_ID = ? ORDER BY FULLNAME">
                        <SelectParameters>
                            <asp:SessionParameter Name="?" SessionField="CENTREID" />
                        </SelectParameters>
                    </asp:SqlDataSource> 
                        <asp:SqlDataSource ID="sdsDept" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
                            SelectCommand="SELECT [DEPT_ID], [DEPARTMENT] FROM [DEPARTMENT_MASTER] ORDER BY DEPARTMENT"></asp:SqlDataSource>                        
                    </td></tr></table>
                    <!--View End-->    
                </td>             
              </tr>              
           </table>
           </td>                
         </tr> 
         <tr><td>&nbsp;</td></tr>                 
        </table>
      </fieldset>
    </td>
    </tr>           
</table>  
</asp:Content>

