<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Assets/AssetMasterPage.master" Theme="SkinFile" CodeFile="Export.aspx.cs" Inherits="Assets_Export" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" id="content1" runat="server">
<script language="javascript" type="text/jscript">
//function vaidation(source, arguments)
//{

//var gvID=document.getElementById("<%=grdview.ClientID%>");
//var length=gvID.rows.length;
//var i;
//var nCount="Y";
//for(i=1;i<length;i++)
//{

//if( document.getElementById(gvID.rows[i].cells[0].firstChild.id).checked )
//{

//nCount="N";
//break;
//}

//}
//if(nCount=="Y")
//{
//arguments.IsValid=false;
//}
//else
//{
//arguments.IsValid=true;
//}
//}

</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
<fieldset>
<legend class="FormHeading">Export Asset Dump</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td><asp:Button ID="export" SkinID="btnExpToExlSkin" Text="Export To Excel" runat="server" OnClick="export_Click" />
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblmsg" Visible="false" SkinID="lblErrorMsg" runat="server"></asp:Label>
</td>
</tr>
</table>
 <table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr>
<td>
<asp:GridView ID="grdview" runat="server"  SkinID="gridviewSkin" OnDataBound="grdview_DataBound"  DataSourceID="sdsasset" AutoGenerateColumns="false">

<Columns>
<asp:BoundField DataField="Dept_code" HeaderText="Dept Code" />
<asp:BoundField DataField="dept" HeaderText="Dept" />
<asp:BoundField DataField="name" HeaderText="Name" />
<asp:BoundField DataField="location" HeaderText="Location" />
<asp:BoundField  DataField="dept_location" HeaderText="Dept Location" />
<asp:BoundField DataField="Asset_Type" HeaderText="Asset Type" />
<asp:BoundField DataField ="Asset_code" HeaderText="Asset Code" />
<asp:BoundField DataField="Asset_description" HeaderText="Asset Description" />
<asp:BoundField DataField="Asset_description_code" HeaderText="Asset Description Code" />
<asp:BoundField DataField="Asset_srno" HeaderText="Asset Sr No" />
<asp:BoundField DataField="barcode" HeaderText="Barcode" />
<asp:TemplateField>
<HeaderTemplate>
<asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkname" runat="server" />
<asp:HiddenField ID="hdnfld" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"Barcode") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
</Columns>
</asp:GridView>

</td>
</tr>
<tr>
<td>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="true" SkinID="gridviewNoSort" Visible="false"></asp:GridView>
</td>
</tr>
</table>
</fieldset>
</td>
</tr>
</table>
<asp:SqlDataSource id="sdsasset" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="Select Top 100 * from asset_summary"></asp:SqlDataSource>
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
<asp:CustomValidator ID="valgv" runat="server" ClientValidationFunction="vaidation"
        Display="None" ErrorMessage="Please select at least one Case. " SetFocusOnError="True"
        ValidationGroup="vgrpFE"></asp:CustomValidator>

</asp:Content>