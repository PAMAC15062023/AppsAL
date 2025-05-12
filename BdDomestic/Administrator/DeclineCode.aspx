<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile"  MasterPageFile="Admin_MasterPage.master" CodeFile="DeclineCode.aspx.cs" Inherits="Administrator_DeclineCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<table id="tblMain" width="99%">
<tr>
<td  style="padding-left:8px">
  <fieldset ><legend class="FormHeading">Decline Code Master</legend>
      <asp:Label ID="lblMsg1" runat="server" SkinID="lblErrorMsg" Text="Label" Visible="False"></asp:Label>
    
     <script type="text/javascript" language="javascript">
       <!--
       function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       // -->
    </script>
        <table align="center" width="100%">
            <tr>
                <td  valign="top">
                    Client<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td valign="top">
                    :</td>
                <td valign="top">
                    <asp:DropDownList ID="ddlClient" SkinID="ddlSkin" runat="server" DataSourceID="sdsddlclient" DataTextField="client_name" DataValueField="client_id" OnDataBound="ddlClient_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td  valign="top">
                    Decline Code<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td style="width: 9px" valign="top">
                    :</td>
                <td  valign="top">
                    &nbsp;<asp:TextBox ID="txtDeclineCode" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 4px" valign="top">
                    Description<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td style="width: 4px" valign="top">
                    :</td>
                <td >
                    &nbsp;<asp:TextBox ID="txtDescription" runat="server" MaxLength="200" SkinID="txtSkin"></asp:TextBox></td>
            </tr>
            	<tr>
                <td colspan="14" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
            </tr>
            <tr>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                <td style="width: 9px" valign="top">
                </td>
                <td valign="top">
                    &nbsp;</td>
                <td style="width: 4px" valign="top">
                </td>
                <td style="width: 4px" valign="top">
                </td>
                <td  align="right">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="valdeclined" SkinID="btnAddNewSkin" />
                   
                    <asp:Button ID="btnSave" SkinID="btnSaveSkin" runat="server" OnClick="btnSave_Click" Text="Save" Visible="False" /></td>
            </tr>
            <tr>
                <td  valign="top" colspan="9" >
                    <asp:Label ID="lblMsg" SkinID="lblSkin" runat="server" ForeColor="Red" Text="Label" Width="361px" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="9" >
                    <asp:GridView ID="gvDeclineCode" runat="server" OnRowDeleting="gvDeclineCode_RowDeleting" HorizontalAlign="Center" Width="100%" OnRowCommand="gvDeclineCode_RowCommand" SkinID="gridviewSkin" OnRowEditing="gvDeclineCode_RowEditing">
                        <Columns>
                            <asp:TemplateField>
                             <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" 
                                        CommandName="Delete"><img src="../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                     
                                        
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate1" runat="server" CausesValidation="False"
                                        CommandName="Edit" CommandArgument='<%# Eval("DECLINE CODE") %>'><img src="../images/icon_Edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                        
                                        
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
             
                           
                    </asp:GridView>
                  
                </td>
            </tr>
            
            <tr>
                <td colspan="4" >
                    <asp:CustomValidator ID="valddlclient" runat="server" ErrorMessage="Please select client" ClientValidationFunction="ClientValidate" ControlToValidate="ddlClient" Display="None" SetFocusOnError="True" ValidationGroup="valdeclined"></asp:CustomValidator>
                    <asp:ValidationSummary ID="valsummary" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="valdeclined" />
                    
                    <asp:RequiredFieldValidator ID="valDeclinedcode" runat="server" ErrorMessage="Please put the Declined Code" ControlToValidate="txtDeclineCode" Display="None" SetFocusOnError="True" ValidationGroup="valdeclined"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="valDescription" runat="server" ErrorMessage="Please put the Descripton" ControlToValidate="txtDescription" Display="None" SetFocusOnError="True" ValidationGroup="valdeclined"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="sdsgvDeclineCode" runat="server"></asp:SqlDataSource>
                    <asp:HiddenField ID="hidDupli" runat="server" />
                    <asp:HiddenField ID="hidDeclinedCode" runat="server" />
                    <asp:SqlDataSource ID="sdsddlclient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select client_name,client_id from client_master order by client_name">
                    </asp:SqlDataSource>
                </td>                
            </tr>
        </table>
    
    </fieldset></td></tr></table>
    </asp:Content>