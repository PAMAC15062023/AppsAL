<%@ Page Language="C#" Theme="SkinFile" MasterPageFile="Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Summary_Panel_Mapping.aspx.cs" Inherits="Administrator_Summary_Panel_Mapping"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<table id="tblMain" width="99%">
        <tr><td style="padding-left:8px;">
<fieldset><legend class="FormHeading">Summary Panel Mapping</legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr> 
    <td>&nbsp;</td>
  </tr>
  <tr> 
    <td><table width="80%" border="0" cellspacing="0" cellpadding="0">
        <tr> 
          <td style="width:40%">&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr> 
          <td align="right">Activity * &nbsp;
          </td>
          <td>:</td>
          <td>
              <asp:DropDownList SkinID="ddlSkin"  ID="ddlActivity" runat="server" AutoPostBack="True"
                  OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged" >
              </asp:DropDownList>&nbsp;<asp:RequiredFieldValidator ID="rfvActivity"
                  runat="server" ErrorMessage="Select Activity" ControlToValidate="ddlActivity" Display="None" SetFocusOnError="True" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr> 
          <td align="right">Product * &nbsp;
          </td>
          <td>:</td>
          <td>
              <asp:DropDownList SkinID="ddlSkin" ID="ddlProduct" runat="server" OnDataBound="ddlProduct_DataBound"
                   OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" AutoPostBack="True">
              </asp:DropDownList>&nbsp;<asp:RequiredFieldValidator ID="rfvProduct"
                  runat="server" ErrorMessage="Select Product" ControlToValidate="ddlProduct" Display="None" SetFocusOnError="True" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="height: 22px">
                Client *&nbsp;
            </td>
            <td style="height: 22px">
                :</td>
            <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlClient" runat="server" OnDataBound="ddlClient_DataBound">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvClient" runat="server" ErrorMessage="Select Client" ControlToValidate="ddlClient" Display="None" SetFocusOnError="True" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr> 
          <td align="right">Verification Type * &nbsp;
          </td>
          <td>
              :</td>
          <td>
              <asp:DropDownList SkinID="ddlSkin" ID="ddlVerificationType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVerificationType_SelectedIndexChanged">
              </asp:DropDownList>&nbsp;<asp:RequiredFieldValidator ID="rfvVerification"
                  runat="server" ErrorMessage="Select Verification Type" ControlToValidate="ddlVerificationType" Display="None" SetFocusOnError="True" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr> 
          <td align="right">Template Name * &nbsp;
          </td>
          <td>:</td>
          <td>
              <asp:TextBox SkinID="txtSkin" ID="txtTemplateName" runat="server" MaxLength="30"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                  ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Template Name" ControlToValidate="txtTemplateName" Display="None" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr> 
          <td style="height: 14px">&nbsp;</td>
          <td style="height: 14px">&nbsp;</td>
          <td style="height: 14px">&nbsp;<asp:Label ID="lblError" SkinID="lblSkin" runat="server" ></asp:Label></td>
        </tr>
      </table></td>
  </tr>
    <tr>
        <td align="right">
            <asp:ValidationSummary ID="vsTemplate" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpTemplate" />
            <asp:Button SkinID="btnSaveSkin" ID="btnSave1" runat="server" OnClick="btnSave_Click" ValidationGroup="grpTemplate" /><asp:Button ID="btnCancel"  runat="server" SkinID="btncancelskin" OnClick="btnCancel_Click" /></td>
    </tr>
  <tr> 
    <td align="left">  <asp:GridView SkinID="gridviewSkin" ID="gvTemplateMatch" runat="server" DataSourceID="sdsgvTemplateMatch"
          OnRowDataBound="gvTemplateMatch_RowDataBound" AutoGenerateColumns="False" >
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="190px">
                            <ItemTemplate >
                            <%--<asp:DropDownList SkinID="ddlSkin" ID="ddlSrNo" AutoPostBack="false"  runat="server" CausesValidation="false"></asp:DropDownList>--%>
                            <asp:TextBox ID="txtSrNo" SkinID="txtSkin" Columns="3" MaxLength="3"  runat="server" CausesValidation="false"></asp:TextBox>
                            <asp:CompareValidator ID="cmpTxtSrNo" runat="server" ValidationGroup="grpTemplate" Operator="DataTypeCheck" ErrorMessage="Please Enter Numeric Values!" SetFocusOnError="true" ControlToValidate="txtSrNo" Type="Integer" />
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Panal ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblPanelID" runat="server" Text='<%# Bind("PANEL_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Panal Nane">
                                <ItemTemplate>
                                    <asp:Label ID="lblPanelName" runat="server" Text='<%# Bind("PANEL_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Panel Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblPanelDescription" runat="server" Text='<%# Bind("PANEL_DESCRIPTION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                    </asp:GridView>
                    </td>
  </tr>
  <tr>
    <td align="right">&nbsp;<asp:Button SkinID="btnSaveSkin" ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="grpTemplate" /><asp:Button ID="btnCancel2" OnClick="btnCancel_Click" runat="server" SkinID="btncancelskin"/></td>
  </tr>
    <tr>
        <td>
        </td>
    </tr>
</table>
    <asp:SqlDataSource ID="sdsgvTemplateMatch" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT PANEL_ID, VERIFICATION_TYPE_ID, PANEL_NAME, PANEL_DESCRIPTION FROM SUMMARY_DETAIL_PANEL_MASTER WHERE (VERIFICATION_TYPE_ID = ?) AND (PRODUCT_ID = ?)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlVerificationType" Name="VERIFICATION_TYPE_ID"
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ddlProduct" Name="PRODUCT_ID" PropertyName="SelectedValue"  Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="hidSrNo" runat="server" />
    <asp:HiddenField ID="hidTemplateID" runat="server" />
    </fieldset>
    </td></tr></table>
</asp:Content>

