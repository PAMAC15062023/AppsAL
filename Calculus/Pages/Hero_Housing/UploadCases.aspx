<%@ Page Title="Untitled Page" Language="C#" MasterPageFile="~/Pages/Hero_Housing/MasterPage.master" AutoEventWireup="true" CodeFile="UploadCases.aspx.cs" Inherits="Pages_Hero_Housing_UploadCases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../../StyleSheet.css" rel="stylesheet" type="text/css" />

    <table style="width: 688px;">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="2" style="width: 690px; height: 30px;">
            &nbsp;IMPORT&nbsp;DATA FILE</td>
        </tr>
        <tr>
            <td style="width: 75px;" class="TableTitle">
                 <strong >Select Branch</strong></td>
            <td style="width: 95px;" class="TableGrid">
            <asp:DropDownList ID="ddlBranch" runat="server" SkinID="ddlSkin">
           </asp:DropDownList>
            </td>

        </tr>


        <tr>
            <td style="width: 71px;" class="TableTitle" >
                <strong >Select File</strong></td>
            <td style="width: 95px;" class="TableGrid">
                <asp:FileUpload ID="xslFileUpload" runat="server"  />
            </td>
    </td >
            <br />
            <br  />
        </tr>
        <tr >
            <td  class="TableTitle" colspan="2" style="height: 48px" >
                <asp:Button ID="Button2" runat="server" Text="Import" 
        onclick="btnupload_Click" ValidationGroup="validdata"  BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/>
                &nbsp;
                <asp:Button ID="Button1" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" />
            </td>
        </tr>
    </table>
</asp:Content>

