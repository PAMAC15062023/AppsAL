<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="HR_ImportToExcel.aspx.cs" Inherits="HR_HR_HR_ImportToExcel" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function CheckText()
 {
 debugger;
var fileUpload='';

 
fileUpload=document.getElementById("<%=FileUpload1.ClientID%>");

 if(fileUpload.value=="")
    {
    
   
    alert('-Please Browse File');
    fileUpload.focus();
    return false;
    }
 }
 </script>
<fieldset><legend class="FormHeading"><b>HR Import</b></legend>  
 <div>
        <table width="100%">
            <tr>
                <td colspan="2">
    <asp:Label ID="lblMessage" runat="server" Text="" Width="687px" ForeColor="Red" Font-Bold="true"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" SkinID="flup"  /></td>
                <td >
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:GridView ID="GridView1" SkinID="gridviewNoSort" runat="server">
                    </asp:GridView>
                </td>
                <td >
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td >
                   <asp:Button ID="btnImport" SkinID="btnImport" runat="server"  Text="Import" Width="60px" OnClick="btnImport_Click" OnClientClick="javascript:return CheckText();" /></td>
                <td >
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    
    </div>
    </fieldset>
</asp:Content>

