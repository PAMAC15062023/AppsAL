<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HR/HR/HRMasterPage.master" Theme="SkinFile" CodeFile="HRBRIDGINGIMPORT.aspx.cs" Inherits="HR_HR_HRBRIDGINGIMPORT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript">
function getextension(source,arguments)
{
var fileName=document.getElementById("<%=Xlsfile.ClientID%>").value;
var extName=fileName.split('.');
for(int i=0;i<extName.Length;i++)
{
    if(extName[i].toLowerCase()=='xls')
            {
                 arguments.IsValid=true;
            }
            else
            {
                arguments.IsValid=false;
            }
}
}

function TABLE1_onclick() {

}

</script>

<table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Import HR Dump</legend>
        <table align="center" border="0" cellpadding="2" cellspacing="1" width="100%">
        <tr><td style="width: 164px">
            &nbsp;&nbsp; Select Month<span style="color: #ff6666">*</span></td><td style="width: 128px">
        <asp:DropDownList ID="ddlmon" runat="server"  Width="111px">
            <asp:ListItem>-----SELECT-----</asp:ListItem>
            <asp:ListItem>JAN</asp:ListItem>
            <asp:ListItem>FEB</asp:ListItem>
            <asp:ListItem>MAR</asp:ListItem>
            <asp:ListItem>APR</asp:ListItem>
            <asp:ListItem>MAY</asp:ListItem>
            <asp:ListItem>JUN</asp:ListItem>
            <asp:ListItem>JUL</asp:ListItem>
            <asp:ListItem>AUG</asp:ListItem>
            <asp:ListItem>SEP</asp:ListItem>
            <asp:ListItem>OCT</asp:ListItem>
            <asp:ListItem>NOV</asp:ListItem>
            <asp:ListItem>DEC</asp:ListItem>
            </asp:DropDownList>
            <br />
            </td>
        <td style="width: 201px">
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;Select Year<span style="color: #ff6666">*</span></td><td style="width: 133px">
         <asp:DropDownList ID="ddlyear" runat="server" Width="91px"></asp:DropDownList> </td>
         <td style="width: 204px">
             &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;Select Centre<span style="color: #ff6666">*</span></td>
         <td style="width: 151px"><asp:DropDownList ID="ddlcentre" runat="server" OnSelectedIndexChanged="ddlcentre_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True">
         <asp:ListItem Value="0">----SELECT----</asp:ListItem></asp:DropDownList>
         </td>
         <td style="width: 236px">
             &nbsp;Select Payment Slot<span style="color: #ff6666">*</span></td>
         <td style="width: 169px"><asp:DropDownList ID="ddlpaid" runat="server">
         <asp:ListItem Value="0">----SELECT----</asp:ListItem>
         <asp:ListItem>Paid on Ist Lot</asp:ListItem>
         <asp:ListItem>Paid on 2nd Lot</asp:ListItem></asp:DropDownList></td>
                    </tr></table>
    &nbsp;

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
            <asp:Button ID="btnupload" runat="server" CssClass="button" OnClick="btnupload_Click" ValidationGroup="grpimport" SkinID="btnimport" />
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
</tr>
<tr><%--<td>
  <asp:SqlDataSource ID="SqlDataSourceDE_ALLCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT '0' AS centre_id, '--Select Centre--' AS Name FROM centre_MASTER">
                    </asp:SqlDataSource>
                  
</td>--%>
</tr></table>
<%--<asp:CustomValidator id="Hrimport" runat="server" ErrorMessage="Please Select .xls File" ValidationGroup="grpimport"
 Display="None" ClientValidationFunction="getextension" SetFocusOnError="true" ControlToValidate="Xlsfile"></asp:CustomValidator>--%>

</asp:Content>