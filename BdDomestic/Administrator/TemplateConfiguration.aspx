<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="TemplateConfiguration.aspx.cs" Inherits="TemplateConfiguration" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
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
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
    <fieldset><legend class="FormHeading" style="width: 157px">Template Configuration</legend>
       <table id="tblImport" width="100%">
            <tr>
                <td >
                </td>
                <td >
                </td>
                <td >
                <asp:Label ID="lblMassage" runat="server" ForeColor="Red" Text="Label" Visible="False"
                        Width="312px"></asp:Label></td>
                <td >
                    </td>
                <td >
                    </td>
                <td >
                </td>
                <td >
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right" >
                </td>
                <td >
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Visible="False" SkinID="btnSubmitSkin" /></td>
                <td >
                    &nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Visible="False" SkinID="btnCancelSkin" /></td>
                <td colspan="3" >
                </td>
            </tr>
            <tr>
                <td >
                    Template<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td >
                    :</td>
                <td >
                    <asp:TextBox ID="txtTemplate" runat="server" SkinID="txtSkin" MaxLength="20"></asp:TextBox></td>
                <td >
                    </td>
                <td >
                    Activity<asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td >
                    :</td>
                <td >
                    <asp:DropDownList ID="ddlActivity" SkinID="ddlSkin" runat="server" DataSourceID="sdsActivity" DataTextField="Activity_name"
                        DataValueField="activity_id" OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged" AutoPostBack="True" OnDataBound="ddlActivity_DataBound">
                    </asp:DropDownList>
                    <asp:Label ID="lblActivity" runat="server" Text="Label" Visible="False" Width="212px"></asp:Label></td>
                <td >
                </td>
            </tr>
            <tr>
                <td >
                    Product<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td >
                    :</td>
                <td >
                    <asp:DropDownList ID="ddlProduct" runat="server" DataSourceID="sdsProduct" DataTextField="product_name"
                        DataValueField="product_id" OnDataBound="ddlProduct_DataBound" SkinID="ddlSkin" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="lblProduct" runat="server" Text="Label" Visible="False" Width="216px"></asp:Label></td>
                <td >
                </td>
                <td >
                    Client<asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                <td >
                    :</td>
                <td >
                    <asp:DropDownList ID="ddlClient" SkinID="ddlSkin" runat="server" DataSourceID="sdsClient" DataTextField="client_name" DataValueField="client_id" OnDataBound="ddlClient_DataBound">
                    </asp:DropDownList>
                    <asp:Label ID="lblClient" runat="server" Text="Label" Visible="False" Width="222px"></asp:Label></td>
                <td >
                </td>
            </tr>
            <tr>
                <td >
                    Excel Sheet<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td >:
                </td>
                <td >
               <asp:FileUpload ID="xslFileupload" skinID="flup" runat="server" Width="366px" /></td>
                <td >
                    </td>
                <td >
                    </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" SkinID="btnUploadSkin" OnClick="btnUpload_Click" Width="68px" ValidationGroup="valgrp" /></td>
                <td >
                </td>
            </tr>
            <tr>
                <td colspan="3" >
                    &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Mandatory*"></asp:Label></td>
                <td >
                </td>
                <td >
                </td>
                <td >
                </td>
            </tr>
            <tr valign="top">
                <td colspan="3">
                    <asp:GridView ID="gvTemplate" runat="server" Width="189px" SkinID="gridviewSkin" OnRowDataBound="gvTemplate_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                            <asp:Label ID="lblSrNo" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 </td>
                 <td colspan="5">
                    <asp:GridView ID="gvTemplateMatchEdit" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin" DataSourceID="sdsgvTemplateMatchEdit">
                        <Columns>
                            <asp:BoundField DataField="template_head" HeaderText="Template Head" />
                            <asp:BoundField DataField="data_table" HeaderText="Data Table" />
                            <asp:BoundField DataField="data_field" HeaderText="Data Field" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvTemplateMatch" runat="server" DataSourceID="sdsgvTemplateMatch" OnRowDataBound="gvTemplateMatch_RowDataBound" SkinID="gridviewSkin" OnRowCommand="gvTemplateMatch_RowCommand" AutoGenerateColumns="False" >
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                            <asp:DropDownList ID="ddlSrNo" SkinID="ddlSkin" AutoPostBack="false"  runat="server" CausesValidation="false"></asp:DropDownList>
                             
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Table">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Table_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDataTable" runat="server" Text='<%# Bind("Table_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Field">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDataField" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            
        </table>
  
   
        <asp:SqlDataSource ID="sdsActivity" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select distinct activity_id,activity_name from ce_ac_pr_ct_vw where  activity_id is not null and centre_id=? " >
            <SelectParameters>
                <asp:SessionParameter Name="?" SessionField="Centreid" />
            </SelectParameters>
            
           
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        <asp:SqlDataSource ID="sdsClient" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"  ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  runat="server"></asp:SqlDataSource>
        <asp:HiddenField ID="hidSrNo" runat="server" />
        <asp:SqlDataSource ID="sdsgvTemplateMatch" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
        &nbsp;
        <asp:ValidationSummary ID="Valsumddl" runat="server" DisplayMode="List"
            ValidationGroup="valgrp" ShowMessageBox="True" ShowSummary="False" />
        &nbsp;&nbsp;
        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ClientValidate"
            ControlToValidate="ddlActivity" Display="None" ErrorMessage="Please Select Activity"
            SetFocusOnError="True" ValidationGroup="valgrp"></asp:CustomValidator>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="ClientValidate"
            ControlToValidate="ddlProduct" Display="None" ErrorMessage="Please Select Product"
            SetFocusOnError="True" ValidationGroup="valgrp"></asp:CustomValidator>
        <asp:SqlDataSource ID="sdsCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select distinct centre_id,centre_name from ce_ac_pr_ct_vw where activity_id is not null">
        </asp:SqlDataSource>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTemplate"
            Display="None" ErrorMessage="Template Name should not be blank" SetFocusOnError="True"
            ValidationGroup="valgrp"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="valclient" runat="server" ClientValidationFunction="ClientValidate"
            ControlToValidate="ddlClient" Display="None" ErrorMessage="Please select client"
            SetFocusOnError="True" ValidationGroup="valgrp"></asp:CustomValidator>
        <asp:RequiredFieldValidator ID="valbrowse" runat="server" ControlToValidate="xslFileupload"
            Display="None" ErrorMessage="Please browse the file" SetFocusOnError="True" ValidationGroup="valgrp"></asp:RequiredFieldValidator>
        <asp:SqlDataSource ID="sdsgvTemplateMatchEdit" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
          </fieldset>
          </td></tr></table>
    </asp:Content>
