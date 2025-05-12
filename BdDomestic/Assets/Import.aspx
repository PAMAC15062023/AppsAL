<%@ Page Language="C#" MasterPageFile="~/Assets/AssetMasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="Import.aspx.cs" Inherits="Assets_Import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript" language="javascript">
//function getextension(source,arguments)
//{
//var fileName=document.getElementById("<%=Xlsfile.ClientID%>").value;
//var extName=fileName.split('.');
//for(int i=0;i<extName.Length;i++)
//{
//    if(extName[i].toLowerCase()=='xls')
//            {
//                 arguments.IsValid=true;
//            }
//            else
//            {
//                arguments.IsValid=false;
//            }
//}
//}

function TABLE1_onclick() {

}

</script>

<table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px">
<fieldset>
<legend class="FormHeading">Import Asset Dump</legend>
            <table border="0" cellpadding="0" cellspacing="0" width="98%">
        <tr>
        <td class="txtError" colspan="1" style="width: 148px; height: 35px;">
        <span class="Label">&nbsp; &nbsp; &nbsp; Select File To Import</span><span class="txtRed"><span style="color: #ff6666">*</span>&nbsp; &nbsp;</span></td>
        <td style="width: 367px; height: 35px;">
            &nbsp; &nbsp;
            <asp:FileUpload ID="Xlsfile" runat="server" CssClass="textbox" Width="268px" SkinID="flup" />[Only*.Xls]
            <br />
        <asp:RequiredFieldValidator id="RFVimport" runat="server" ControlToValidate="Xlsfile" CssClass="txtError" Display="None"
                        ErrorMessage="Please Select a File To Import" SetFocusOnError="true" ValidationGroup="grpimport"></asp:RequiredFieldValidator>   
        </td>
        <td style="width: 52px; height: 35px;">
            <asp:Button ID="btnupload" runat="server" CssClass="button"  ValidationGroup="grpimport" SkinID="btnimport" OnClick="btnupload_Click" />
        </td>
        
        </tr>
        <tr><td colspan="7"><span class="txtRed">&nbsp; &nbsp; &nbsp;<span style="color: #ff6666"> *</span></span>Indicate Mendatory Fields.</td></tr>
        </table>
</fieldset>
<asp:Label ID="LblXls" runat="server" CssClass="txtRed" Font-Bold="true"></asp:Label>
<asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>
<asp:ValidationSummary id="validationsummary1" runat="server" CssClass="txtError" DisplayMode="List" ShowMessageBox="true" ShowSummary="false" ValidationGroup="grpimport" />
<asp:GridView ID="grdviw" runat="server" SkinID="gridviewNoSort"></asp:GridView>
</td>


</tr></table>

</asp:Content>