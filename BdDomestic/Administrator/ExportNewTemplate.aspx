<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="ExportNewTemplate.aspx.cs" Inherits="Administrator_ExportNewTemplate" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
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
        <td align="left" valign="top" colspan="4">
            :<asp:DropDownList ID="ddlCaseType" runat="server" DataSourceID="sdsCaseType" DataTextField="CASE_TYPE"
                DataValueField="CASE_TYPE_ID" SkinID="ddlSkin">
            </asp:DropDownList></td>
             
        
        
    </tr>
    <tr><td colspan="9"></td></tr>
    <tr>
        <td align="left" colspan="5" valign="top">
            </td>
                <td colspan="3">
                
                </td>
                <td align="right" valign="top">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                Text="Save" ValidationGroup="valTemplate" />&nbsp;
            <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin"
                Text="Cancel" OnClick="btnCancel_Click"  /></td>
                
       
    </tr>

    <tr><td colspan="9" ><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label></td></tr>  
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td colspan="9" >
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataSourceID="sdsgv"
                SkinID="gridviewSkin" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtSrNo" runat="server" Width="64px" SkinID="txtSkin" Columns="3" MaxLength="3" CausesValidation="false"></asp:TextBox>
                            <asp:CompareValidator ID="cmpTxtSrNo" runat="server" ValidationGroup="valTemplate" Operator="DataTypeCheck" ErrorMessage="Please Enter Numeric Values!" SetFocusOnError="true" ControlToValidate="txtSrNo" Type="Integer" />
                            <asp:HiddenField ID="HiddenFieldName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="FIELD NAME" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
   
    <tr>
        <td colspan="8">
            &nbsp;&nbsp;</td>
                <td colspan="1" align="right">
                <asp:Button ID="Button1" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                Text="Save" ValidationGroup="valTemplate" />&nbsp;
            <asp:Button ID="Button2" runat="server"  SkinID="btnCancelSkin"
                Text="Cancel" OnClick="btnCancel_Click"  />
                </td>
                
    </tr>
    <tr>
        <td colspan="9" >
             <asp:SqlDataSource ID="sdsCaseType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [CASE_TYPE_ID], [CASE_TYPE] FROM [CPV_CELLULAR_CASE_TYPE_MASTER]">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsgv" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select name from syscolumns WHERE id =(select id from sysobjects where name='CPV_CEL_CASE_EXPORT_VW') order by name">
            </asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="revTemplate" runat="server" ControlToValidate="txtTemplate"
            Display="None" ErrorMessage="Template Name should not be blank" SetFocusOnError="True"
            ValidationGroup="valTemplate"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="valTemplate" />
        </td>
    </tr>
    </table>
    </td></tr>
    
     </table>
     </fieldset></td></tr></table>   
   </asp:Content>