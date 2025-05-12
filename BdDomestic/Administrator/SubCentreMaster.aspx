<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="SubCentreMaster.aspx.cs" Inherits="Administrator_SubCentreMaster" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table id="tblMain" width="99%">
<tr>
<td  style="padding-left:8px">
  <fieldset ><legend class="FormHeading">Sub Centre Master</legend>
      <asp:Label ID="lblMsg1" runat="server" SkinID="lblErrorMsg" Text="Label" Visible="False"></asp:Label>
    
     <script type="text/javascript" language="javascript">
       <!--
       function ClusterValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
        function CentreValidate(source, arguments)
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
                    Cluster <strong><span style="color: #ff0000">*</span></strong></td>
                <td valign="top">
                    :</td>
                <td valign="top">
                    <asp:DropDownList ID="ddlCluster" SkinID="ddlSkin" runat="server"  DataSourceID="sdsddlcluster" DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" OnDataBound="ddlCluster_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td valign="top">
                    Centre <strong><span style="color: #ff0000">*</span></strong></td>
                <td valign="top">
                    :</td>
                <td valign="top">
                    <asp:DropDownList ID="ddlCentre" SkinID="ddlSkin" runat="server"  DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" OnDataBound="ddlCentre_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td valign="top">
                    Sub Centre Name <strong><span style="color: #ff0000">*</span></strong></td>
                <td valign="top">
                    :</td>
                <td valign="top">
                    <asp:TextBox ID="txtSubCentreName" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
            </tr>
           <%-- <tr>
                <td style="height: 15px" valign="top">
                    Sub Centre Code <strong><span style="color: #ff0000">*</span></strong></td>
                <td style="height: 15px" valign="top">
                    :</td>
                <td style="height: 15px" valign="top">
                    <asp:TextBox ID="txtSubCentreCode" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
            </tr>--%>
            <tr>
                <td valign="top">
                    Address
                </td>
                <td valign="top">
                    :</td>
                <td valign="top">
                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="200" SkinID="txtSkin" Width="666px"></asp:TextBox></td>
            </tr>
            	<tr>
                <td colspan="8" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
            </tr>
            <tr>
                <td valign="top" style="height: 26px">
                </td>
                <td valign="top" style="height: 26px">
                </td>
                <td valign="top" style="height: 26px">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Save" ValidationGroup="valSubCenter" SkinID="btn" Width="62px" />
                   
                    <%--<asp:Button ID="btnSave" SkinID="btnSaveSkin" runat="server" OnClick="btnSave_Click"  ValidationGroup="valSubCenter1" Text="Save" Visible="False" /></td>
          --%>  </tr>
            <tr>
                <td  valign="top" colspan="3" >
                    <asp:Label ID="lblMsg" SkinID="lblSkin" runat="server" ForeColor="Red" Text="Label" Width="361px" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" >
                    <asp:GridView ID="gvSubCentre" runat="server" HorizontalAlign="Center" Width="100%" OnRowCommand="gvSubCentre_RowCommand" SkinID="gridviewSkin" AutoGenerateColumns="False" OnRowEditing="gvSubCentre_RowEditing" OnRowDataBound="gvSubCentre_RowDataBound"  >
                        <Columns>
                            <asp:BoundField  DataField="SubCentreName" HeaderText="Sub Centre Name" />
                            <%--<asp:BoundField  DataField="SubCentreCode" HeaderText="Sub Centre Code" />--%>
                            <asp:BoundField  DataField="Address" HeaderText="Address" />
                           
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate1" runat="server" CausesValidation="False"
                                        CommandName="Edit" CommandArgument='<%# Eval("SubCentreId") %>'><img src="../images/icon_Edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                        
                                        
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                             <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" 
                                        CommandName="Delete1" CommandArgument='<%# Eval("SubCentreId") %>'><img src="../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                     
                                        
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
             
                           
                    </asp:GridView>
                  
                </td>
            </tr>
            
            <tr>
                <td colspan="3" >
                    <asp:CustomValidator ID="valddlCluster" runat="server" ErrorMessage="Please select Cluster" ClientValidationFunction="ClusterValidate" ControlToValidate="ddlCluster" Display="None" SetFocusOnError="True" ValidationGroup="valSubCenter"></asp:CustomValidator>
                     <asp:CustomValidator ID="valddlCentre" runat="server" ErrorMessage="Please select Centre" ClientValidationFunction="CentreValidate" ControlToValidate="ddlCentre" Display="None" SetFocusOnError="True" ValidationGroup="valSubCenter"></asp:CustomValidator>
                   
                   
                    <asp:ValidationSummary ID="valsummary" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="valSubCenter" />
                    
                    <asp:RequiredFieldValidator ID="valSubCenterName" runat="server" ErrorMessage="Please put the Sub Center Name" ControlToValidate="txtSubCentreName" Display="None" SetFocusOnError="True" ValidationGroup="valSubCenter"></asp:RequiredFieldValidator>
                     <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please select Cluster" ClientValidationFunction="ClusterValidate" ControlToValidate="ddlCluster" Display="None" SetFocusOnError="True" ValidationGroup="valSubCenter1"></asp:CustomValidator>
                     <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Please select Centre" ClientValidationFunction="CentreValidate" ControlToValidate="ddlCentre" Display="None" SetFocusOnError="True" ValidationGroup="valSubCenter1"></asp:CustomValidator>
                   <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="valSubCenter1" />
                    --%>
                    <%--<asp:RequiredFieldValidator ID="valSubCenterCode" runat="server" ErrorMessage="Please put the Sub Center Code" ControlToValidate="txtSubCentreCode" Display="None" SetFocusOnError="True" ValidationGroup="valSubCenter"></asp:RequiredFieldValidator>
                   --%>
                    
                    <%--<asp:RequiredFieldValidator ID="valDescription" runat="server" ErrorMessage="Please put the Descripton" ControlToValidate="txtDescription" Display="None" SetFocusOnError="True" ValidationGroup="valSubCenter"></asp:RequiredFieldValidator>
                   --%> <asp:SqlDataSource ID="sdsgvSubCentre" runat="server"></asp:SqlDataSource>
                   <asp:HiddenField ID="hidDupli" runat="server" />
                    <asp:HiddenField ID="hidSubCentre" runat="server" />
                    <asp:SqlDataSource ID="sdsddlCluster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select distinct CLUSTER_NAME,CLUSTER_ID from Cluater_view order by CLUSTER_NAME">
                    </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsddlCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="">
                    </asp:SqlDataSource>
                </td>                
            </tr>
        </table>
    
    </fieldset></td></tr></table>
</asp:Content>

