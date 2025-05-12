<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/FETracking/FETracking.master" CodeFile="FEWise_CaseDetail_Report.aspx.cs" Inherits="FETracking_FEWise_CaseDetail_Report" Theme="SkinFile" %>

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
        <legend class="FormHeading">FE-Wise Case Detail Report</legend>
        <table width="100%" align="center">
            <tr>
                <td align="right" >
                    Date</td>
                <td style="width: 5px">
                    :</td>
                <td style="width: 253px">
                    <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                    <img id="imgDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" />[dd/mm/yyyy]
                        <asp:RegularExpressionValidator ID="reDate" runat="server" ControlToValidate="txtDate"
                        CssClass="txtError" Display="None" ErrorMessage="Enter valid date format " SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpVal"></asp:RegularExpressionValidator>
                        </td>
                <td align="right" >
                    FE-Code</td>
                <td style="width: 2px" >
                    :</td>
                <td >
                    <asp:TextBox ID="txtFECode" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" >
                    Product</td>
                <td style="width: 5px">
                    :</td>
                <td style="width: 253px">
                    <asp:DropDownList ID="ddlProdct" runat="server" DataSourceID="sdsProduct" SkinID="ddlSkin" DataTextField="product_name" DataValueField="Product_id" OnDataBound="ddlProdct_DataBound">
                    
                    </asp:DropDownList>
                    </td>
                <td >
                </td>
                <td style="width: 2px" >
                </td>
                <td >
                    <asp:Button ID="btnShow" runat="server" Text="Show" SkinID="btn" OnClick="btnShow_Click" ValidationGroup="grpVal" />
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin"
                        Visible="False" /></td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView ID="gvShow" runat="server" SkinID="gridviewNoSort" EnableViewState="False">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="btnExport2" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin" Visible="False" /></td>
            </tr>
            <tr>
                <td colspan="6" >
                    &nbsp;<asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select distinct pm.product_name,pm.product_id from product_master pm left outer join ce_ac_pr_ct_vw vw on(vw.product_id=pm.product_id) where vw.Centre_id=? and vw.product_id in (1011,1012,1014,1015,1016,1017)">
                        <SelectParameters>
                            <asp:SessionParameter Name="?" SessionField="CentreID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:ValidationSummary ID="ValSummary" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="grpVal" />
                    </td>
            </tr>
        </table>
        
        </fieldset>
  </asp:Content>
