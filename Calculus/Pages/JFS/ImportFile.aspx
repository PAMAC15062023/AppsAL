<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ImportFile.aspx.cs" Inherits="Pages_JFS_ImportFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 688px;"> 
<tr>
<td colspan="4">
<asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
    
<tr>
<td colspan="4">
<asp:Label ID="lblMsgXls1" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>

<tr>
<td class="TableHeader" colspan="4" style="width: 690px;">
            IMPORT DATA FILE</td>
</tr>
    
<tr>
<td style="width: 100px;" class="TableTitle" >
            select Case Type</td>
<td style="width: 71px;" class="TableTitle" >
<asp:DropDownList ID="ddlcasetype" runat="server">
<asp:ListItem Value="0">--Select--</asp:ListItem>
<asp:ListItem Value="1">Fresh Case</asp:ListItem>
<asp:ListItem Value="2">Query Resolve Case</asp:ListItem>
</asp:DropDownList>
</td>
        
<td style="width: 71px;" class="TableTitle" >
<strong>Select File</strong></td>
<td style="width: 95px;" class="TableGrid">
<asp:FileUpload ID="xslFileUpload" runat="server" />
 </td>
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
     
    
   <%-- <asp:Button ID="btnupload" runat="server" Text="Import" 
        onclick="btnupload_Click" ValidationGroup="validdata"  BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/>&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" />
&nbsp;&nbsp;--%>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="xslFileUpload" Display="None" 
        ErrorMessage="Select Import File" SetFocusOnError="True" 
        ValidationGroup="validdata"></asp:RequiredFieldValidator>
&nbsp;<asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True" 
        ShowSummary="False" ValidationGroup="validdata" />



</asp:Content>

