<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile"  MasterPageFile="Admin_MasterPage.master" CodeFile="ClusterMaster.aspx.cs" Inherits="Administrator_ClusterMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script type="text/javascript" language="javascript">
            <!--
               function ChangeCheckBoxState(id, checkState)
               {
                  var cb = document.getElementById(id);
                  if (cb != null)
                     cb.checked = checkState;
               }
               function ChangeAllCheckBoxStates(checkState)
               {
                  // Toggles through all of the checkboxes defined in the CheckBoxIDs array
                  // and updates their value to the checkState input parameter
                  if (CheckBoxIDs != null)
                  {
                     for (var i = 0; i < CheckBoxIDs.length; i++)
                        ChangeCheckBoxState(CheckBoxIDs[i], checkState);
                  }
               }
            -->
        </script>
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
  <fieldset ><legend class="FormHeading">Cluster Master</legend>
   <table cellpadding="1"   cellspacing="0"  id="TABLE1" runat="server" border="0" width="100%" >
               <tr>
                   <td align="center" class="txtError" colspan="9"  valign="top" style="height: 16px" >
                    <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
             </tr>
              <tr>
                    <td align="center" class="txtError" colspan="14" valign="top">
                    </td>
              </tr>
            <tr  >
                <td >
                    Cluster Code<asp:Label SkinID="lblSkin" ID="Label1" runat="server" ForeColor="Red"  Text="*" Width="8px"></asp:Label></td>
                <td  >
                    :</td>
                <td ><asp:TextBox SkinID="txtSkin" ID="txtClusterCode" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox></td>
                <td  >
                    Cluster Name<asp:Label ID="Label2" SkinID="lblSkin" runat="server" ForeColor="Red" Height="12px" Text="*" ></asp:Label></td>
                <td  >:</td>
                <td ><asp:TextBox ID="txtClusterName" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td colspan="6" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
            </tr>
                <tr>
                <td colspan="6">
                             <asp:GridView SkinID="gridviewSkin" ID="gvCompany" runat="server" AutoGenerateColumns="False" DataKeyNames="company_Id"
                                            DataSourceID="sdsClustermaster" Width="100%"  CellPadding="2" CellSpacing="1" OnRowDataBound="gvCompany_RowDataBound" OnDataBound="gvCompany_DataBound1"  >
                                                <Columns>
                                                
                                                <asp:BoundField DataField="company_name" HeaderText="Company Name"  />
                                                  <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="center">
                                                  <HeaderTemplate>
                                                 <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                                 </HeaderTemplate>
                                                    <ItemTemplate>
                                                       <asp:CheckBox ID="chkHierID" align="centre" runat="server" /><asp:HiddenField ID="hidHierId" runat="server"
                                                            Value='<%# DataBinder.Eval(Container.DataItem, "keycolumn") %>' /><asp:HiddenField ID="HiddenCompanyID" runat="server"
                                                            Value='<%# DataBinder.Eval(Container.DataItem, "company_id") %>' />
                                                            
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                </Columns>
                                                </asp:GridView>
                    </td>
                </tr>
                <tr><td colspan="8">&nbsp;</td></tr>                
                <tr>
                <td colspan="8" align="center">
                  <asp:Button SkinID="btnSaveSkin" ID="btnsave" runat="server" Text="Save"  OnClick="btnsave_Click" ValidationGroup="valgrpCluster" />
                        &nbsp; 
                        <asp:Button SkinID="btnCancelSkin" ID="btncalcel" runat="server" Text="Cancel" OnClick="btncalcel_Click" /></td>
                </tr>
                <tr>
                <td colspan="6">
                   </td>
               </tr>
                         
                </table>
              <br />
                
                <asp:RequiredFieldValidator ID="valClusterCode" runat="server" ControlToValidate="txtClusterCode"
                    Display="None" ErrorMessage="Please enter Cluster Code." SetFocusOnError="True"
                    ValidationGroup="valgrpCluster"></asp:RequiredFieldValidator>&nbsp;
                
                <asp:RequiredFieldValidator ID="valClusterName" runat="server" ControlToValidate="txtClusterName"
                    Display="None" ErrorMessage="Please enter Cluster Name." SetFocusOnError="True"
                    ValidationGroup="valgrpCluster"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="Valcl" runat="server" DisplayMode="List" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="valgrpCluster" />
      &nbsp;
               
            
        
            </fieldset>
            </td></tr></table>
           <%-- </asp:Panel>--%>
       
        <asp:HiddenField ID="HiddenField1" runat="server" />
    
        <asp:SqlDataSource ID="sdsClustermaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="System.Data.OleDb"
            SelectCommand="select ch.hier_id,co.company_name  from  company_hierarchy_master ch inner join company_master co on(ch.ref_id=co.company_id) where ch.type='co' order by company_name"></asp:SqlDataSource>
    &nbsp;
    <asp:HiddenField ID="hidAllreadychecked" runat="server" />
    <asp:HiddenField ID="hidAllreadunchecked" runat="server" />
   
       
       </asp:Content>