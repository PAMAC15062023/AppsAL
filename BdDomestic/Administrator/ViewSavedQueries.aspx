<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="ViewSavedQueries.aspx.cs" Inherits="Administrator_ViewSavedQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset>
<legend class="FormHeading">View Saved Query</legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  
  <tr>
  <td >

 <table width="100%" border="0" cellspacing="0" cellpadding="0">
 <tr>
 <td style="height: 20px;" colspan="8"></td>
 </tr>
 <tr>
 <td >
 Created Date
 </td>
  <td>
  :
 </td>
  <td >
  <asp:TextBox ID="txtCreatedDate" runat="Server" SkinID="txtSkin" Columns="80" Width="100px" MaxLength="10"></asp:TextBox>
   <img id="imgFromDate"  alt="Calendar" src="../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtCreatedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
 </td>
  <td >
  Query Defination
 </td>
  <td>
  :
 </td>
  <td >
  <asp:TextBox ID="txtQueryDefination" runat="Server" SkinID="txtSkin" Columns="80" Width="212px" MaxLength="100"></asp:TextBox>
 </td>
  <td >
 <asp:Button ID="btnSearch" runat="server"  Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" />
 </td>
  <td>
  <asp:Button ID="btnAddNew" runat="server" SkinID="btnAddNewSkin" Text="Add New" OnClick="btnAddNew_Click" />
 </td>
 </tr>
 <tr>
 <td style="height: 20px;" colspan="8"></td>
 </tr>
 <tr>
 <td colspan="8">
     <asp:GridView ID="gvSearch" SkinID="gridviewSkin" runat="server" AutoGenerateColumns="False" OnRowCommand="gvSearch_RowCommand" OnRowDataBound="gvSearch_RowDataBound">
         <Columns>
             <asp:BoundField HeaderText="Sr. No." DataField="Sr No" >
                 <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>
             <asp:BoundField HeaderText="Query Defination" DataField="Query Defination" />
             <asp:BoundField HeaderText="Created Date" DataField="Created Date" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False"/>
             <asp:TemplateField HeaderText="Edit/View">
                 <ItemTemplate>
                     <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Query_ID")%>' Text="Edit"></asp:LinkButton>
                     <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="/"></asp:Label>
                     <asp:LinkButton ID="lbView" runat="server" CommandName="View" CommandArgument='<%# Eval("Query_ID")%>' Text="View"></asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete">
                 <ItemTemplate>
                     <asp:LinkButton ID="lbDelete" runat="server" CommandName="Del" CommandArgument='<%# Eval("Query_ID")+"-"+Eval("Query_Text_File")%>' Text="Delete"></asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Assign Query">
                 <ItemTemplate>
                     <asp:LinkButton ID="lbAssign" runat="server" CommandName="Assign" CommandArgument='<%# Eval("Query_ID")%>' Text="Assign"></asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Query_ID" Visible="False">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Query_ID") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("Query_ID") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Query_Text_File" Visible="False">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Query_Text_File") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("Query_Text_File") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
     <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="486px"></asp:Label></td>
 </tr>
 <tr>
 <td colspan="8">
 <asp:ValidationSummary ID="vsummary" runat="server" DisplayMode="List" ShowMessageBox="True" 
     ShowSummary="False" ValidationGroup="GrpValidation" Height="57px" Width="138px" />
      
     <asp:RegularExpressionValidator ID="rfvCreatedDate" runat="server" ControlToValidate="txtCreatedDate"
     Display="None" ErrorMessage="Please Enter Valid Date Formate For Created Date" SetFocusOnError="True"
     ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
     ValidationGroup="GrpValidation"></asp:RegularExpressionValidator>
     
 </td>
 </tr>
 
  </table>
  </td>
  </tr>
  
</table>
</fieldset>
</asp:Content>

