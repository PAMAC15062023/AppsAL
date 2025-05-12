<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/FETracking/FETracking.master" Theme="SkinFile" CodeFile="Total_Veri_Report.aspx.cs" Inherits="FETracking_Total_Veri_Report" %>

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
        <legend class="FormHeading">Verification-Wise Report</legend>
        <table width="100%" align="center">
            <tr>
                <td align="right" >
                    Date</td>
                <td style="width: 7px" >
                    :</td>
                <td style="width: 252px" >
                    <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img id="imgDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" />
                    [dd/mm/yyyy]</td>
                <td align="right" >
                    Product</td>
                <td >
                    :</td>
                <td >
                    <asp:DropDownList ID="ddlProduct" runat="server" SkinID="ddlSkin" DataSourceID="sdsProduct" DataTextField="product_name" DataValueField="product_id" OnDataBound="ddlProduct_DataBound">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" >
                    Verification Type</td>
                <td style="width: 7px" >
                    :</td>
                <td style="width: 252px" >
                    <asp:DropDownList ID="ddlVeri" runat="server" SkinID="ddlSkin" DataSourceID="sdsVeri" DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlVeri_DataBound">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="RvProduct" runat="server" ClientValidationFunction="ClientValidate"
                        ControlToValidate="ddlProduct" Display="None" ErrorMessage="Please select the Product"
                        SetFocusOnError="True" ValidationGroup="grpVal"></asp:CustomValidator></td>
                <td >
                </td>
                <td >
                </td>
                <td >
                    <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" SkinID="btn" Text="Show" ValidationGroup="grpVal" />
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    <asp:Button ID="btnExport1" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin"
                        Visible="False" /></td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    <asp:GridView ID="gvSow" runat="server" SkinID="gridviewNoSort" OnRowCommand="gvSow_RowCommand" AutoGenerateColumns="False" OnSelectedIndexChanged="gvSow_SelectedIndexChanged">
                    <Columns>
                                 
                                 <asp:BoundField DataField="Total No of Cases" HeaderText="Total No of Cases" SortExpression="Total No of Cases" />
                                 <asp:BoundField DataField="VERIFICATION TYPE" HeaderText="VERIFICATION TYPE" SortExpression="VERIFICATION TYPE" />
                                 <asp:BoundField DataField="CASE ISSUED ON FIELD" HeaderText="CASE ISSUED ON FIELD" SortExpression="CASE ISSUED ON FIELD" />
                                 
                             <asp:TemplateField HeaderText="NOT ISSUED">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbNotIssued" Text='<%# Eval("NOT ISSUED") %>' runat="server" CommandArgument='<%# Eval("VERIFICATION TYPE") %>'
                                    CommandName="NotIsuued"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" />
                        </asp:TemplateField>
                                                </Columns>
                    </asp:GridView>
                    
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    &nbsp;<asp:GridView ID="gvNotIssued" runat="server" SkinID="gridviewNoSort" EnableViewState="False">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    <asp:Button ID="btnExport2" runat="server" OnClick="btnExport1_Click" SkinID="btnExpToExlSkin" Visible="False" /></td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6" >
                    &nbsp;<asp:SqlDataSource ID="sdsVeri" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] FROM [VERIFICATION_TYPE_MASTER] where Parent_type_code in('vv','dv','tv')">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select distinct pm.product_name,pm.product_id from product_master pm left outer join ce_ac_pr_ct_vw vw on(vw.product_id=pm.product_id) where vw.Centre_id=? and vw.product_id in (1011,1012,1014,1015,1016,1017)">
                        <SelectParameters>
                            <asp:SessionParameter Name="?" SessionField="CentreID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;
                    <asp:ValidationSummary ID="ValSummary" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="grpVal" />
                    &nbsp; &nbsp;
                    <asp:RegularExpressionValidator ID="reDate" runat="server" ControlToValidate="txtDate"
                        CssClass="txtError" Display="None" ErrorMessage="Enter valid date format " SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpVal" Width="16px"></asp:RegularExpressionValidator></td>
            </tr>
        </table>
        </fieldset>
       </asp:Content>
