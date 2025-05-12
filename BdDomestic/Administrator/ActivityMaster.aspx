<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile"  MasterPageFile="Admin_MasterPage.master" CodeFile="ActivityMaster.aspx.cs" Inherits="ActivityMaster" %>

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
    <tr>
    <td style="padding-left:10px">
  <fieldset ><legend class="FormHeading">Activity Master</legend>    
    
            <table cellpadding="3" class="tblBorder" width="100%" cellspacing="1" align="center" id="TABLE1">
            <tr  class="rowSeparator">
            <td align="center" class="txtError" colspan="14"  valign="top" >
                <asp:Label ID="lblMsg" SkinID="lblSkin" runat="server" ForeColor="Red" Visible="False" Width="233px"></asp:Label>
            </td>
            </tr>
            <tr  >
                <td class="label" colspan="2">
                    Activity
                    Code<asp:Label ID="Label1" SkinID="lblSkin" runat="server" ForeColor="Red" Height="12px" Text="*" Width="8px"></asp:Label></td>
                <td class="label" colspan="1">
                    :</td>
                <td ><asp:TextBox ID="txtActivityCode" runat="server" CssClass="textbox" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
                <td class="label" colspan="2" >
                    <span class="txtError">
                        Activity
                        Name<asp:Label ID="Label2" SkinID="lblSkin" runat="server" ForeColor="Red" Height="12px" Text="*" ></asp:Label></span></td>
                <td class="separator">:</td>
                <td ><asp:TextBox ID="txtActivityName" runat="server" CssClass="textbox" MaxLength="100" SkinID="txtSkin"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td colspan="6" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
                </tr>
                <tr>
                    <td class="label" colspan="8" valign="top">
                        
                <asp:GridView ID="gvCompany" SkinID="gridviewSkin" runat="server" AutoGenerateColumns="False" DataKeyNames="centre_ID"
                                            DataSourceID="sdsCentremaster" width="100%"   OnRowDataBound="gvCompany_RowDataBound" OnDataBound="gvCompany_DataBound" >
                                            <Columns>
                                                <asp:BoundField DataField="centre_name" HeaderText="Centre"  />
                                                  <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="center">
                                                  <HeaderTemplate>
                                                   <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                                                   </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkHierID" align="centre" runat="server" /><asp:HiddenField ID="hidHierId" runat="server"
                                                            Value='<%# DataBinder.Eval(Container.DataItem, "keycolumn") %>' /><asp:HiddenField ID="HiddenCentreID" runat="server"
                                                            Value='<%# DataBinder.Eval(Container.DataItem, "centre_id") %>' />
                                                            
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                </Columns>
                                                </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="label" colspan="8" valign="top" align="center">
                        <asp:Button ID="btnsave" SkinID="btnSaveSkin" runat="server" Text="Save" Width="54px" OnClick="btnsave_Click" ValidationGroup="valgrpActivity" />
                        <asp:Button ID="btncalcel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btncalcel_Click" /></td>
                </tr>
           </table>
              <br />
                          
                <asp:RequiredFieldValidator ID="valActivityCode" runat="server" ControlToValidate="txtActivityCode"
                    Display="None" ErrorMessage="Activity Code Should be Entered" SetFocusOnError="True"
                    ValidationGroup="valgrpActivity"></asp:RequiredFieldValidator>&nbsp;
                
                <asp:RequiredFieldValidator ID="valActivityName" runat="server" ControlToValidate="txtActivityName"
                    Display="None" ErrorMessage="Activity Name Should be Entered" SetFocusOnError="True"
                    ValidationGroup="valgrpActivity"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="Valcl" runat="server" DisplayMode="List" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="valgrpActivity" />
               
            
        
           
       
        <asp:HiddenField ID="HiddenField1" runat="server" />
      &nbsp;&nbsp;&nbsp;
      <asp:HiddenField ID="hidAllReadyChecked" runat="server" />
        <asp:SqlDataSource ID="sdsgvActivityMaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select activity_id,activity_name from activity_master order by activity_name">
        </asp:SqlDataSource>
      <asp:HiddenField ID="hidallredyuncheacked" runat="server" />
   
    <asp:SqlDataSource ID="sdsCentremaster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
     SelectCommand=""></asp:SqlDataSource>
    </fieldset></td></tr></table>
     </asp:Content>
