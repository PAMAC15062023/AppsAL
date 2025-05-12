<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Manualentry.aspx.cs" Inherits="Pages_ICICIRPC_Manualentry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<asp:Panel ID="pnldisplay" runat="server">
  <table >
  <tr >
        <td colspan="8" 
            style="font-weight: 700; text-decoration: underline; font-size: medium">
            Enter The Details<asp:Label ID="lblMsgXls" runat="server" 
                CssClass="ErrorMessage" Font-Bold="True" ForeColor="Red"></asp:Label>
        </td>
     </tr>
  <tr>
   
  <td>
  <asp:Label ID="lblapp_no" runat="server" Text="Application Number"></asp:Label>
  </td>
  <td style="width: 140px">
  <asp:TextBox ID="txtapp_no" runat="server" MaxLength="8" ></asp:TextBox>
  </td>
  
  <td>
  <asp:Label ID="lbl_scandate" runat="server" Text="Scanning Date" ></asp:Label>
  </td>
  <td style="width: 159px">
  <asp:TextBox ID="txtscan_date" runat="server" ></asp:TextBox>
  </td>

  <td>
  <asp:Label ID="lbl_cusname" runat="server" Text="Customer Name"></asp:Label>
  </td>
  <td style="width: 135px">
  <asp:TextBox ID="txtcus_name" runat="server"></asp:TextBox>
  </td>
  </tr>
  <tr>
  <td>
  <asp:Label ID="lbl_apsid" runat="server" Text="APS ID"></asp:Label>
  </td>
  
  <td style="width: 135px">
  <asp:TextBox ID="txt_apsid" runat="server"></asp:TextBox>
  </td>
  <td>
  <asp:Label ID="Lbl_location" runat="server" Text="Location"></asp:Label>
 
  </td>

   
  <td style="width: 135px">
  <asp:TextBox ID="txt_location" runat="server"></asp:TextBox>
  </td>
  <td>
  <asp:Label ID="lbl_submitedby" runat="server" Text="submited_by"></asp:Label>
 
  </td>
  
  <td style="width: 135px">
  <asp:TextBox ID="txt_submittedby" runat="server"></asp:TextBox>
  </td>


  
  </tr>
  <tr>
   <td>
  <asp:Label ID="lbl_remark" runat="server" Text="Remark Field"></asp:Label>
 
  </td>
  
  <td style="width: 135px">
  <asp:TextBox ID="txtremark_field" runat="server"></asp:TextBox>
  </td>

  
  
  </tr>

   </table>
  </asp:Panel>
   <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
        onclick="btnsubmit_Click" ValidationGroup="validlosno" />
  <asp:Button ID="btncancel" runat="server" Text="Cancel" 
        onclick="btncancel_Click" />
 

</asp:Content>

