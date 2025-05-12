<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="AssignRights.aspx.cs" Inherits="Administrator_AssignRights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
//Made By Gargi Srivastava at 1-Nov-2007
function Fun_Select()
{
    var ArrSelected = new Array(); 
    var SelObj = document.getElementById("<%=lstbSelectRole.ClientID%>");
    var hidCentreID = document.getElementById("<%=hidCentreID.ClientID%>");   
    
    var i;
    var count = 0;
    for (i=0; i<SelObj.options.length; i++)
    {
        if (SelObj.options[i].selected)
        {
        ArrSelected[count] = SelObj.options[i].value; 
        count++;
        }
    }
    
    hidCentreID.value=ArrSelected;    
    
} 
</script>
<fieldset>
<legend class="FormHeading">Assign Rights</legend>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td style="height: 20px;" colspan="2"></td>
</tr>
<%--<tr>
<td style="width: 135px" >
<b>
    <asp:RadioButton ID="RadioButton1" SkinID="rdbSkin" runat="server" Text="Pre Defined MIS"  /></b></td>
<td>
 <b><asp:RadioButton ID="RadioButton2" SkinID="rdbSkin" runat="server" Text="Saved Query" /></b>
</td>
</tr>--%>
<%--<tr>
<td style="height: 20px;" colspan="2"></td>
</tr>--%>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td style="width: 185px">
    <asp:ListBox ID="lstbSelectQuery" SkinID="lbSkin"  runat="server" SelectionMode="Multiple" Width="232px"></asp:ListBox>
</td>
<td ></td>
<td>
<asp:ListBox ID="lstbSelectRole" SkinID="lbSkin" runat="server"  SelectionMode="Multiple" Width="103px" ></asp:ListBox>
</td>
<td>
    <asp:Button ID="btnShowUsers" SkinID="btn" runat="server" Text="Show Users" OnClientClick="Fun_Select()" OnClick="btnShowUsers_Click" /></td>
<td>
<asp:ListBox ID="lstbAssignUsers" SkinID="lbSkin" runat="server" SelectionMode="Multiple" Width="180px" Height="103px"></asp:ListBox>
</td>
<td>
<asp:Button ID="btnAssign"  runat="server" Text="Assign" SkinID="btnAssingSkin" OnClick="btnAssign_Click" />
<asp:HiddenField ID="hidCentreID" runat="server" />
</td>
</tr>
<tr>
<td  style="height: 20px;" colspan="6" >
</td>
</tr>
<tr>
<td colspan="6" >
<asp:Button ID="btnCancel"  runat="server" Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click1"  />
    </td>
</tr>

<tr>
<td colspan="6" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ID="lblSearchForAssignedQuery" runat="server" Text="SEARCH FOR ASSIGNED QUERY"></asp:Label>
 </td>
</tr>
<tr>
<td style="height: 20px;" colspan="6">
</td>
</tr>
<tr>
<td>
<b>Query Wise:</b>
</td>
<td>
<asp:TextBox ID="txtQueryWiseSearch" runat="server" SkinID="txtSkin" MaxLength="100" Width="130px"></asp:TextBox>
</td>
<td>
</td>
<td>
<b>User Wise:</b>
</td>
<td>
<asp:TextBox ID="txtUserWiseSearch" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox>
</td>

<td>
<asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" /></td>
</tr>
<tr>
<td style="height: 20px;" colspan="6">
</td>
</tr>
<tr>
<td colspan="6">
 <asp:GridView ID="gvViewForAssignedUsers" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin" OnRowCommand="gvViewForAssignedUsers_RowCommand" OnRowEditing="gvViewForAssignedUsers_RowEditing" OnRowDataBound="gvViewForAssignedUsers_RowDataBound">
     <Columns>
         <asp:BoundField DataField="Sr No" HeaderText="Sr. No." >
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
         
         <asp:BoundField DataField="Query" HeaderText="Query Saved As" />
         <asp:BoundField DataField="Centre Name" HeaderText="Centre" />
         <asp:BoundField DataField="Assigned User" HeaderText="User Assigned" />
           <asp:BoundField DataField="Assign_ID" HeaderText="Assign_ID" Visible="False" />
             <asp:TemplateField HeaderText="Delete">
                 <ItemTemplate>
                     <asp:LinkButton ID="lbDelete" runat="server" CommandName="Del" CommandArgument='<%# Eval("Assign_ID")%>' Text="Delete"></asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateField>
     </Columns>
    </asp:GridView>
</td>
</tr>
<tr>
<td colspan="6">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="700px"></asp:Label>
    <asp:HiddenField  ID="hidQueryID" runat="Server"/>
    <asp:HiddenField  ID="hidMode" runat="Server"/>
    </td>
</tr>
</table>
</fieldset>
</asp:Content>

