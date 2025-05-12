<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CPRT_Importfile.aspx.cs" Inherits="Pages_ICICIRPC_importfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel ID="pnlproduct" runat="server">
<table style="width: 688px;">


<tr>
<td class="TableTitle">
 
    &nbsp;</td>
<td   class="TableGrid">
    &nbsp;</td>
</tr>

</table>
</asp:Panel>



<asp:Panel ID="PnlAL" runat="server">

<table style="width: 688px;"> 
<tr>
        <td colspan="4">
    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
    <br />
    </td>
    </tr>
    
<tr>
        <td class="TableHeader" colspan="4" style="width: 690px;">
            &nbsp;IMPORT&nbsp; AL DATA FILE</td>
    </tr>


    <tr>
        
        <td style="width: 71px;" class="TableTitle" >
            <strong>Select File</strong></td>
        <td style="width: 95px;" class="TableGrid">
        
    <asp:FileUpload ID="xlsFileUpload" runat="server"  />
    </td>
    </td>
    <br />
    <br />

</tr> 


<tr >
        <td  class="TableTitle" colspan="4">
        <asp:Button ID="Button2" runat="server" Text="Import" 
        onclick="btnupload_Click" ValidationGroup="validdata"  BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/>&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" />
          
          </td>
    </tr> 
    </table>
    
     </asp:Panel>
    
   <%-- <asp:Button ID="btnupload" runat="server" Text="Import" 
        onclick="btnupload_Click" ValidationGroup="validdata"  BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/>&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" />
&nbsp;&nbsp;--%>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="xlsFileUpload" Display="None" 
        ErrorMessage="Select Import File" SetFocusOnError="True" 
        ValidationGroup="validdata"></asp:RequiredFieldValidator>
&nbsp;<asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True" 
        ShowSummary="False" ValidationGroup="validdata" />

</asp:Content>

