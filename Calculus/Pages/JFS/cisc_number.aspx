<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="cisc_number.aspx.cs" Inherits="Pages_JFS_cisc_number" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">

</script>
<asp:Panel ID="pnlTextBoxes" runat=server >
<table>
<tr>
<td class="TableHeader"  style="width: 858px" >
<asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Size="Medium" Text="CISC NUMBER"></asp:Label>

</td>
</tr>
<tr>
<td>
<asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblapp" Text="Application Number" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblapp_number" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblno" runat="server" Text="Number Of Customer"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtno_cust" runat="server" Enabled="false"></asp:TextBox>
&nbsp;<asp:Button ID="txtsave" runat="server" onclick="txtsave_Click" Text="Save" />
    &nbsp;&nbsp;
    <asp:Button ID="btncancel" runat="server" onclick="btncancel_Click" 
        Text="Cancel" />
</td>
</tr>
<tr>
<td><strong>Sacnning Status:</strong> 
<asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlstatus_SelectedIndexChanged" 
           >
   <asp:ListItem>Received</asp:ListItem>
   <asp:ListItem>Received with Query</asp:ListItem>
   </asp:DropDownList>
</td>
</tr>

<tr>
<td><strong>Sacnning Remark:</strong> 
<asp:TextBox ID="txtremark" runat="server" Visible="false"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Panel ID="pnldemo" runat="server" ></asp:Panel>
</td>
</tr>
    <tr>
        <td>
            <asp:GridView ID="grddata" runat="server" AutoGenerateColumns="True">                
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Panel>
</asp:Content>

