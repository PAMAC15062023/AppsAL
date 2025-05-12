<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile" MasterPageFile="Admin_MasterPage.master" CodeFile="CenterMaster.aspx.cs" Inherits="CenterMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
  <fieldset ><legend class="FormHeading">Centre Master</legend>

<script type="text/javascript" language="javascript">
       
    </script>
   
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
    
            <table cellpadding="3" class="tblBorder" width="100%"  cellspacing="1" align="center">
            <tr  class="rowSeparator">
                <td align="center" class="txtError" colspan="17"  valign="top" >
                    <asp:Label ID="lblMsg" SkinID="lblSkin" runat="server" ForeColor="Red" Visible="False" ></asp:Label>
                </td>
            </tr>
            <tr  >
                <td class="label" colspan="2" valign="top">
             Center Code<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" ></asp:Label></td>
                <td class="separator" valign="top" style="width: 1px" >:</td>
                <td valign="top" ><asp:TextBox ID="txtCenterCode" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox></td>
                <td valign="top" >
                        Cluster<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td valign="top">
                    :</td>
                <td valign="top" >
                        <asp:DropDownList ID="ddlCluster" runat="server" SkinID="ddlSkin" DataSourceID="sdsCluster" DataTextField="cluster_name"
                            DataValueField="cluster_id" OnDataBound="ddlCluster_DataBound">
                        </asp:DropDownList></td>
                <td class="label" colspan="5" >
                    <span class="txtError">CenterName<asp:Label ID="Label2" runat="server" ForeColor="Red"  Text="*" ></asp:Label>
                        &nbsp;&nbsp; </span></td>
                <td class="label" colspan="1">
                    :</td>
                <td class="label" colspan="1">
                    <asp:TextBox ID="txtCenterName" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox></td>
            </tr>                
                <tr>
                    <td class="label" colspan="2" valign="top">
                        Correspondence Address</td>
                    <td class="separator" style="width: 1px" valign="top">
                        :</td>
                    <td valign="top">
                     <asp:TextBox ID="txtCorAdd1" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="200" ></asp:TextBox></td>
                    <td  valign="top">
                        PinCode</td>
                    <td valign="top">
                        :</td>
                    <td valign="top" >
                     <asp:TextBox ID="txtCorPin" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
                    <td class="label" colspan="5">
                        City &nbsp; &nbsp;</td>
                    <td class="label" colspan="1" valign="top">
                        :</td>
                    <td class="label" colspan="1">
                     <asp:TextBox ID="txtCorCity" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label" colspan="2" valign="top">
                        Registered Address</td>
                    <td class="separator" style="width: 1px" valign="top">
                        :</td>
                    <td valign="top">
                    <asp:TextBox ID="txtRegAdd1" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox></td>
                    <td  valign="top">
                        PinCode</td>
                    <td valign="top">
                        :</td>
                    <td valign="top" >
                    <asp:TextBox ID="txtRegPin" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
                    <td class="label" colspan="5">
                        City</td>
                    <td class="label" colspan="1">
                        :</td>
                    <td class="label" colspan="1">
                    <asp:TextBox ID="txtRegCity" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                <td colspan="6" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
                </tr>
                <tr>
                    <td class="label" colspan="14" valign="top" align="center">
                    <asp:Button ID="btnSave" SkinID="btnSaveSkin" runat="server" Text="Save" Width="62px" OnClick="btnSave_Click" ValidationGroup="valgrpCenterMaster" />
                    <asp:Button ID="btnCancel" SkinID="btnCancelSkin" runat="server" Text="Cancel" Width="67px" OnClick="btnCancel_Click" /></td>
                </tr>

            </table>
                <asp:SqlDataSource ID="sdsCluster" runat="server"  ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="System.Data.OleDb"
                    SelectCommand="select cluster_id,cluster_name from cluster_master order by cluster_name">
                </asp:SqlDataSource>
     
                           
                <asp:HiddenField ID="HiddenField1" runat="server" />
      
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="valgrpCenterMaster" />
                <asp:SqlDataSource ID="sdsCentreMaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select  centre_id,centre_name from centre_master order by centre_name">
                </asp:SqlDataSource>
                &nbsp;
                <asp:RequiredFieldValidator ID="valCentreCode" runat="server" ControlToValidate="txtCenterCode"
                    Display="None" ErrorMessage="Please enter Centre Code." SetFocusOnError="True"
                    ValidationGroup="valgrpCenterMaster"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="valCentreName" runat="server" ControlToValidate="txtCenterName"
                    Display="None" ErrorMessage="Please enter Centre Name." SetFocusOnError="True"
                    ValidationGroup="valgrpCenterMaster"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="valddlCluster" runat="server" ControlToValidate="ddlCluster"
                    Display="None" ErrorMessage="Please select Cluster." SetFocusOnError="True" ValidationGroup="valgrpCenterMaster" ClientValidationFunction="ClientValidate"></asp:CustomValidator></fieldset>
                    </td></tr></table>
          
         
            </asp:Content>
   
