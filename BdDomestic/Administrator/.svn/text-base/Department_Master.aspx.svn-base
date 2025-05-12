<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master"  Theme="SkinFile"  EnableTheming="true" AutoEventWireup="true" CodeFile="Department_Master.aspx.cs" Inherits="Administrator_Department_Master" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
<tr>
<td  style="padding-left:8px">
    <fieldset>
        <legend class="FormHeading">Department Master</legend>

        <script language="javascript" type="text/javascript">
       
        </script>

        <script language="javascript" type="text/javascript">
       <!--
       function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       // -->
        </script>

        <table align="center" width="100%">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" Width="266px" ForeColor="Red"></asp:Label></td>
                <td>
                </td>
            </tr>

      
            <tr>
                <td style="width: 133px">
                    Department Name<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td>
                    :</td>
                <td>
                    <asp:TextBox ID="txtDeptName" runat="server" MaxLength="100" SkinID="txtSkinWidth"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDeptName"
                        ErrorMessage="Please enter Department Name." Display="none" SetFocusOnError="true" ValidationGroup="DeptName"></asp:RequiredFieldValidator></td>
                <td  >
                </td>
            </tr>
            	<tr>
                <td colspan="14" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
            </tr>
            
            <tr>
                <td  colspan="5" valign="top">
                   
                    <asp:GridView ID="gvDept" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDept" OnRowCommand="gvDept_RowCommand" Width="100%" SkinID="gridviewSkin" AllowPaging="True" AllowSorting="True" OnRowDataBound="gvDept_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DEPT_ID" HeaderText="DEPT_ID" SortExpression="DEPT_ID"
                                Visible="False" />
                            <asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" SortExpression="DEPARTMENT" >
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" CommandArgument='<%# Eval("DEPT_ID") %>'
                                        CommandName="ed" ImageUrl="~/Images/icon_edit.gif" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnDel" runat="server" CommandArgument='<%# Eval("DEPT_ID") %>'
                                        CommandName="del" ImageUrl="~/Images/icon_delete.gif" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                  
                    
                </td>
            </tr>
            <tr><td colspan="6">&nbsp;</td></tr>
            <tr>
                <td valign="top" align="right" colspan="5" >
                   <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Width="63px" SkinID="btnAddNewSkin" ValidationGroup="DeptName" />
                                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btnCancelSkin" /></td>
                
            </tr>
            <tr>
                <td style="width: 133px"  >
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DeptName" />
                </td>
                <td>
                </td>
                <td>
                    <asp:SqlDataSource ID="SqlDataSourceDept" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DEPT_ID, DEPARTMENT FROM DEPARTMENT_MASTER ORDER BY DEPARTMENT">
                    </asp:SqlDataSource>
                </td>
                <td>
                </td>
                <td >
                </td>
            </tr>
        </table>
        <br />      
       
    </fieldset>
    </td>
    </tr></table>
</asp:Content>
           

