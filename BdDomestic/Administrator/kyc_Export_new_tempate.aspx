<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile" CodeFile="kyc_Export_new_tempate.aspx.cs" Inherits="Administrator_kyc_Export_new_tempate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/jscript">

function validation(source, arguments)
{

var gvID=document.getElementById("<%=gv.ClientID %>");

var length=gvID.rows.length;

var i;
var nCount="Y";

  for(i=1;i<length;i++)
   {
  
 
  if((document.getElementById(gvID.rows[i].cells[0].firstChild.id).value !="") && (document.getElementById(gvID.rows[i].cells[2].firstChild.id).value ==""))
  {
   
   var j= i;
   nCount="N";
  }
   if((document.getElementById(gvID.rows[i].cells[0].firstChild.id).value =="") && (document.getElementById(gvID.rows[i].cells[2].firstChild.id).value !=""))
  {
 
  var j= i;
  nCount="N";
  }
 
}
if( nCount=="N" )
{
arguments.IsValid=false;

}
else
{

arguments.IsValid=true;
}

}
 
</script>
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
<fieldset><legend class="FormHeading">Export Template</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr><td style="height: 14px">&nbsp;
    </td></tr>
<tr><td>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td align="left" valign="top">
            Template</td>
        <td align="left" valign="top">
            :</td>
        <td align="left" valign="top">
            <asp:TextBox ID="txtTemplate" runat="server" MaxLength="20" SkinID="txtSkin"></asp:TextBox></td>
        <td align="left"  valign="top">
            Type</td>
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
            :<asp:DropDownList ID="ddlClient" runat="server" DataSourceID="sdsClient" DataTextField="Client_name"
                DataValueField="Client_id" SkinID="ddlSkin">
            </asp:DropDownList></td>
        
    </tr>
    <tr><td colspan="7">&nbsp;</td></tr>
    <tr>
        <td align="right" colspan="6" valign="top" style="height: 24px">
            &nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"   SkinID="btnSaveSkin"
                Text="Save" ValidationGroup="valTemplate" />&nbsp;
            <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin"
                Text="Cancel" OnClick="btnCancel_Click"  />
            </td>
       
    </tr>

    <tr><td colspan="9" ><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label></td></tr>  
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td colspan="9" style="height: 195px" >
            &nbsp;<asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"  DataSourceID="sdsgv"  Width="100%" SkinID="gridviewSkin">
            <Columns>
            
            <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                            <asp:TextBox ID="txtSrNo" SkinID="txtSkin" Width="64px" MaxLength="3"  runat="server" CausesValidation="false"></asp:TextBox><asp:HiddenField ID="HiddenFieldName" runat="server"
                                                            Value='<%# DataBinder.Eval(Container.DataItem, "name") %>' />
                             <asp:CompareValidator ID="cmpTxtSrNo" runat="server" ValidationGroup="valTemplate" Operator="DataTypeCheck" ErrorMessage="Please Enter Numeric Values!" SetFocusOnError="true" ControlToValidate="txtSrNo" Type="Integer" />
                            </ItemTemplate>
                           
                            </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="FIELD NAME"  />
                             <asp:TemplateField HeaderText="Alias">
                            
                              <ItemTemplate>
                            <asp:TextBox ID="txtalias" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox>
                            </ItemTemplate>
                             </asp:TemplateField>
                            
            </Columns>
            </asp:GridView>
            <br />
            </td>
    </tr>   
    <tr>
        <td colspan="9" align="right">
            &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                Text="Save" ValidationGroup="valTemplate" />&nbsp;
            <asp:Button ID="Button2" runat="server"  SkinID="btnCancelSkin"
                Text="Cancel" OnClick="btnCancel_Click"  /></td>
    </tr>
    <tr>
        <td colspan="9" >
             <asp:SqlDataSource ID="sdsClient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select distinct client_id,client_name from ce_ac_pr_ct_vw where product_id='1015' ">
            </asp:SqlDataSource>
            &nbsp;
            <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="valTemplate" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please put the template name" ControlToValidate="txtTemplate" Display="None" SetFocusOnError="True" ValidationGroup="valTemplate"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" SetFocusOnError="true" runat="server"  ClientValidationFunction="validation" ValidationGroup="valTemplate" Display="None" ErrorMessage="Please select  both  Sr No and  alias ."></asp:CustomValidator>
            <asp:SqlDataSource ID="sdsgv" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select name from syscolumns WHERE id =(select id from sysobjects where name='CPV_KYC_CASE_EXPORT_VW') order by name">
            </asp:SqlDataSource>
            &nbsp;
        </td>
    </tr>
    </table>
    </td></tr>
    
     </table>
     </fieldset></td></tr></table>   
   </asp:Content>
