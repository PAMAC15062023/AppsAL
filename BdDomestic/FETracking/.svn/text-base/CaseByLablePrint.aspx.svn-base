<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/FETracking/FETracking.master" Theme="SkinFile" CodeFile="CaseByLablePrint.aspx.cs" Inherits="FETracking_CaseByLablePrint" %>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
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
<fieldset>
<legend class="FormHeading">Case-Wise Lable Print</legend>
    <table width="100%" align="center">
        <tr>
            <td align="right" >
                CaseID</td>
            <td style="width: 4px" >
                :</td>
            <td >
                <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Rows="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" >
                ProductID</td>
            <td style="width: 4px" >
                :</td>
            <td >
                <asp:DropDownList ID="ddlProduc" runat="server" SkinID="ddlSkin" DataSourceID="sdsProduct" DataTextField="product_name" DataValueField="product_id" OnSelectedIndexChanged="ddlProduc_SelectedIndexChanged" AutoPostBack="True" OnDataBound="ddlProduc_DataBound">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" >
                ClientID</td>
            <td style="width: 4px" >
                :</td>
            <td >
                <asp:DropDownList ID="ddlClient" runat="server" SkinID="ddlSkin" DataSourceID="sdsClient" DataTextField="client_name" DataValueField="Client_id">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 16px" align="right" >
                VerificationType</td>
            <td style="width: 4px; height: 16px" >
                :</td>
            <td style="height: 16px" >
                <asp:DropDownList ID="ddlVeri" runat="server" SkinID="ddlSkin" DataSourceID="sdsVeri">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td >
            </td>
            <td style="width: 4px" >
            </td>
            <td >
                <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" SkinID="btn" Text="Print" ValidationGroup="grpVal" />
                </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
        </tr>
    </table>
   <asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select distinct pm.product_name,pm.product_id from product_master pm left outer join ce_ac_pr_ct_vw vw on(vw.product_id=pm.product_id) where vw.Centre_id=? and vw.product_id in (1011,1012,1014,1015,1016,1017)" >
                        <SelectParameters>
                            <asp:SessionParameter Name="?" SessionField="CentreID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsClient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsVeri" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" >
                    </asp:SqlDataSource>
    <asp:ValidationSummary ID="val" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpVal" />
    <asp:RequiredFieldValidator ID="valCaseID" runat="server" ErrorMessage="Please enter the Case ID" ControlToValidate="txtCaseID" Display="None" SetFocusOnError="True" ValidationGroup="grpVal"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="valProduct" runat="server" ControlToValidate="ddlProduc"
        Display="None" ErrorMessage="Please select the Product" SetFocusOnError="True" ClientValidationFunction="ClientValidate" ValidationGroup="grpVal"></asp:CustomValidator></fieldset>
</asp:Content>
