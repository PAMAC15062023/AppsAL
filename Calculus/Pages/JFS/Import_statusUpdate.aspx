<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Import_statusUpdate.aspx.cs" Inherits="Pages_JFS_Import_statusUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 688px;">
<tr>
        <td colspan="4">
 <asp:Label ID="lblMsgXls" runat="server" Text="Label" ForeColor="Red"></asp:Label>
 <br />
 </td>
 </tr>
 <tr>
        <td class="TableHeader" colspan="4" style="width: 690px;">
            &nbsp;IMPORT DATA FILE</td>
    </tr>
    

     <tr>
        
        <td style="width: 71px;" class="TableTitle" >
            <strong>Select File</strong></td>
        <td style="width: 95px;" class="TableGrid">

<asp:FileUpload ID="xslFileUpload" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="xslFileUpload" Display="None" 
        ErrorMessage="Select Import File" SetFocusOnError="True" 
        ValidationGroup="datavalidation"></asp:RequiredFieldValidator>
<br />
</td>
</tr>
    <asp:ValidationSummary ID="datavalidation" runat="server" ShowMessageBox="True" 
        ShowSummary="False" ValidationGroup="datavalidation" />
<br />

<tr >
        <td  class="TableTitle" colspan="4">
        
<asp:Button ID="Button2" runat="server" Text="Import" onclick="btnImport_Click" 
        ValidationGroup="datavalidation" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" />&nbsp;
      <asp:Button ID="Button1" runat="server" Text="Cancel" onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/>
          </td>
    </tr> 




<%--<asp:Button ID="btnImport" runat="server" Text="Import" onclick="btnImport_Click" 
        ValidationGroup="datavalidation" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/>--%>
</table>

</asp:Content>


