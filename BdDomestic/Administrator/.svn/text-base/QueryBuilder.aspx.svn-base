<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master"  EnableEventValidation="false" Theme="SkinFile" AutoEventWireup="true" CodeFile="QueryBuilder.aspx.cs" Inherits="CPV_CC_QueryBuilder" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function LEGEND1_onclick() 
{
}

function Validate()
{  
    var FromDate=document.getElementById('<%=txtFromDate.ClientID %>');
    var ToDate=document.getElementById('<%=txtToDate.ClientID%>');
    var Product=document.getElementById('<%=ddlProduct.ClientID%>');  
    if((FromDate.value!="")&&(ToDate.value==""))
    {       
        alert('Select Both FromDate and ToDate !!');
        return false;
    }
    if((ToDate.value!="")&&(FromDate.value==""))
    {
        alert('Select Both FromDate and ToDate !!');
        return false;
    }
    if(Product.value=="0")
    {
        alert('-Select Product !!');
        return false;
    }
}

// ]]>
</script>

    <table width="100%">
        <tr>
            <td align="left" colspan="10" style="width: 1536px; height: 14px" valign="top">
                <fieldset>
                    <legend class="FormHeading" id="LEGEND1" onclick="return LEGEND1_onclick()">Query Builder</legend>
                    <table style="width: 103%">
                        <tr>
                            <td align="left" valign="top" style="height: 16px">
                            </td>
                            <td align="left" valign="top" style="height: 16px">
                            </td>
                            <td align="left" valign="top" style="height: 16px; width: 6px;">
                            </td>
                            <td align="left" colspan="2" valign="top" style="height: 16px">
                                <asp:Label ID="lblMsg" runat="server" Text="Label" ForeColor=Red Width="255px" Visible="False"></asp:Label></td>
                            <td align="left" valign="top" style="height: 16px; width: 195px;">
                            </td>
                            <td align="left" valign="top" style="height: 16px; width: 5px;">
                            </td>
                            <td align="left" style="width: 168px; height: 16px;" valign="top">
                            </td>
                            <td align="left" valign="top" style="height: 16px">
                            </td>
                            <td align="left" valign="top" style="height: 16px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="height: 26px">
                            </td>
                            <td align="left" valign="top" style="height: 26px">
                                Product &nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="left" valign="top" style="height: 26px; width: 6px;">
                                :</td>
                            <td align="left" valign="top" style="height: 26px">
                <asp:DropDownList ID="ddlProduct" runat="server" DataSourceID="SqlDataSourceProduct" DataTextField="PRODUCT_NAME" DataValueField="PRODUCT_ID" Width="160px" AppendDataBoundItems="True" SkinID="ddlSkin" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="0">Select Product</asp:ListItem>
                </asp:DropDownList></td>
                            <td align="left" style="width: 138px; height: 26px;" valign="top">
                                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show" Width="85px" SkinID="btn" ValidationGroup="Show" /></td>
                            <td align="left" valign="top" style="height: 26px; width: 195px;">
                            </td>
                            <td align="left" valign="top" style="width: 5px; height: 26px;">
                            </td>
                            <td align="left" style="width: 168px; height: 26px;" valign="top">
                            </td>
                            <td align="left" valign="top" style="height: 26px">
                            </td>
                            <td align="left" valign="top" style="height: 26px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="height: 92px">
                            </td>
                            <td align="left" valign="top" style="height: 92px">
                            </td>
                            <td align="left" valign="top" style="width: 6px; height: 92px;">
                            </td>
                            <td align="left" valign="top" style="height: 92px">
                                <asp:SqlDataSource ID="SqlDataSourceProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [PRODUCT_ID], [PRODUCT_NAME] FROM [PRODUCT_MASTER]">
                </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select name from syscolumns where id =(select id from sysobjects where name='cpv_cc_case_output_vw') order by name">
    </asp:SqlDataSource>
                                <asp:CompareValidator ID="CompareValidatorProduct" runat="server" ControlToValidate="ddlProduct"
                                    Display="None" ErrorMessage="Select Product !!" Operator="GreaterThan" ValidationGroup="Show"
                                    ValueToCompare="0"></asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_FrmDt" runat="server" ControlToValidate="txtFromDate"
                                    Display="None" ErrorMessage="Enter Valid From Date !!" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d" ValidationGroup="Show"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_ToDt" runat="server" ErrorMessage="Enter Valid To Date !!" ControlToValidate="txtToDate" Display="None" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d" ValidationGroup="Show"></asp:RegularExpressionValidator></td>
                            <td align="left" style="width: 138px; height: 92px;" valign="top">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="Show" />
                            </td>
                            <td align="left" valign="top" style="width: 195px; height: 92px;">
                            </td>
                            <td align="left" valign="top" style="width: 5px; height: 92px;">
                            </td>
                            <td align="left" style="width: 168px; height: 92px;" valign="top">
                            </td>
                            <td align="left" valign="top" style="height: 92px">
                            </td>
                            <td align="left" valign="top" style="height: 92px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                            </td>
                            <td align="left" colspan="9" valign="top">
                                
    <asp:Panel ID="pnlSelect" runat="server" Visible="false">
    <div id="dvSelect" style="overflow:scroll; border:1px; border-style:solid; border-color:Black; width:750px; height:200px;">
        <asp:CheckBoxList ID="CheckBoxListSelect" runat="server" Width="721px" RepeatColumns="2" Height="4px">
        </asp:CheckBoxList>
    </div>     
    </asp:Panel>                                                           
    </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                            </td>
                            <td align="left"  valign="top">
                Client</td>
                            <td align="left" valign="top" style="width: 6px">
                                :</td>
                            <td align="left"  valign="top">
                <asp:DropDownList ID="ddlClient" runat="server" DataSourceID="SqlDataSourceClient" DataTextField="CLIENT_NAME" DataValueField="CLIENT_ID" Width="160px" AppendDataBoundItems="True" SkinID="ddlSkin" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select Client</asp:ListItem>
                </asp:DropDownList></td>
                            <td align="left"  valign="top" style="width: 138px">
                            </td>
                            <td align="left" valign="top" style="width: 195px">
                Verification&nbsp; Type</td>
                            <td align="left" valign="top" style="width: 5px">
                                :</td>
                            <td align="left"  valign="top" style="width: 168px">
                                <asp:DropDownList ID="ddlVerification" runat="server" Width="160px" SkinID="ddlSkin">
                    <asp:ListItem Value="0">Select Verification Type</asp:ListItem>
                </asp:DropDownList></td>
                            <td align="left"  valign="top">
                            </td>
                            <td align="left"  valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left"  valign="top" style="height: 25px">
                            </td>
                            <td align="left"  valign="top" style="height: 25px">
                From Date</td>
                            <td align="left"  valign="top" style="height: 25px; width: 6px;">
                            </td>
                            <td align="left"  valign="top" style="height: 25px">
                                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkinWidth" Width="150px"></asp:TextBox>
                                </td>
                            <td align="left" style="width: 138px; height: 25px" valign="top">
                                <img id="Img1" alt="Calendar"  src="../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd-mmm-yyyy', 0, 0);" />[ddmmm-yyyy]</td>
                            <td align="left" style="width: 195px; height: 25px" valign="top">
                To Date</td>
                            <td align="left"  valign="top" style="width: 5px; height: 25px;">
                                :</td>
                            <td align="left"  valign="top" style="width: 168px; height: 25px;">
                                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkinWidth" Width="150px"></asp:TextBox></td>
                            <td align="left" colspan="2" valign="top" style="height: 25px">
                                <img id="Img2" alt="Calendar" src="../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd-mmm-yyyy', 0, 0);" />[ddmmmyyyy]</td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px" valign="top">
                            </td>
                            <td align="left" style="width: 135px" valign="middle">
                                Status</td>
                            <td align="left" valign="top" style="width: 6px">
                                :</td>
                            <td align="left" style="width: 99px" valign="top">
                                <asp:RadioButtonList ID="RbStatus" runat="server" RepeatDirection="Horizontal" Height="21px">
                                    <asp:ListItem Value="0">Positive</asp:ListItem>
                                    <asp:ListItem Value="1">Negative</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td align="left" style="width: 138px" valign="top">
                            </td>
                            <td align="left" style="width: 195px" valign="middle">
                                With In TAT</td>
                            <td align="left" style="width: 5px" valign="top">
                                :</td>
                            <td align="left" style="width: 168px" valign="top">
                                <asp:RadioButtonList ID="RbTAT" runat="server" Height="1px" RepeatDirection="Horizontal"
                                    Width="165px">
                                    <asp:ListItem Value="0">With In TAT</asp:ListItem>
                                    <asp:ListItem Value="1">Beyond TAT</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td align="left" style="width: 104px" valign="top">
                            </td>
                            <td align="left" style="width: 100px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px" valign="top">
                            </td>
                            <td align="left" style="width: 135px" valign="top">
                            </td>
                            <td align="left" valign="top" style="width: 6px">
                            </td>
                            <td align="left" style="width: 99px" valign="top">
                <asp:Button ID="btnExport_Excel" runat="server" OnClick="btnExport_Excel_Click" Text="Export to Excel" SkinID="btn" ValidationGroup="Show" /></td>
                            <td align="left" style="width: 138px" valign="top">
                <asp:Button ID="btnGetReport" runat="server" OnClick="btnGetReport_Click" Text="Get Report" SkinID="btn" OnClientClick="javascript:return Validate();" /></td>
                            <td align="left" style="width: 195px" valign="top">
                                <asp:Button ID="btnSaveResult" runat="server" SkinID="btn" Text="Save Result" OnClick="btnSaveResult_Click" /></td>
                            <td align="left" style="width: 5px" valign="top">
                            </td>
                            <td align="left" style="width: 168px" valign="top">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="65px" OnClick="btnCancel_Click" SkinID="btn" /></td>
                            <td align="left" style="width: 104px" valign="top">
                            </td>
                            <td align="left" style="width: 100px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px" valign="top">
                            </td>
                            <td align="left" style="width: 135px" valign="top">
                            </td>
                            <td align="left" valign="top" style="width: 6px">
                            </td>
                            <td align="left" style="width: 99px" valign="top">
                            </td>
                            <td align="left" style="width: 138px" valign="top">
                            </td>
                            <td align="left" style="width: 195px" valign="top">
                            </td>
                            <td align="left" style="width: 5px" valign="top">
                            </td>
                            <td align="left" style="width: 168px" valign="top">
                            </td>
                            <td align="left" style="width: 104px" valign="top">
                            </td>
                            <td align="left" style="width: 100px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px; height: 9px" valign="top">
                            </td>
                            <td id="TD1" runat="server" align="left" style="width: 135px; height: 9px" valign="top"
                                visible="false">
                                Template Name</td>
                            <td id="TD2" runat="server" align="left" style="width: 6px; height: 9px" valign="top"
                                visible="false">
                                :</td>
                            <td id="TD3" runat="server" align="left" style="width: 99px; height: 9px" valign="top"
                                visible="false">
                                <asp:TextBox ID="txtTemplate" runat="server" SkinID="txtSkin" Width="202px" ValidationGroup="TemplateName"></asp:TextBox></td>
                            <td id="TD4" runat="server" align="left" style="width: 138px; height: 9px" valign="top"
                                visible="false">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btn" Text="OK"
                                    Width="59px" ValidationGroup="TemplateName" /></td>
                            <td align="left" style="width: 195px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 5px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 168px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 104px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 100px; height: 9px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 135px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="height: 9px; width: 6px;" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                                <asp:SqlDataSource ID="SqlDataSourceClient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [CLIENT_ID], [CLIENT_NAME] FROM [CLIENT_MASTER]">
                </asp:SqlDataSource>
                                <asp:HiddenField ID="HF_ToDate" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTemplate"
                                    Display="None" ErrorMessage="Enter Template Name !!" ValidationGroup="TemplateName"></asp:RequiredFieldValidator>
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="TemplateName" />
                            </td>
                            <td align="left" style="width: 195px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 5px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                                <asp:SqlDataSource ID="SqlDataSourceVeriType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] FROM [VERIFICATION_TYPE_MASTER]">
                </asp:SqlDataSource>
                            </td>
                            <td align="left" style="width: 100px; height: 9px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="10" style="height: 9px" valign="top">
                    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%" Visible="False">
                    <div id="dvQCAssign" style="overflow:scroll;  width:800px; height:200px;"> 
                        <asp:GridView ID="gvdet" runat="server" SkinID="gridviewSkin" Width="745px" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvdet_PageIndexChanging" OnSorting="gvdet_Sorting">
                        </asp:GridView>
                    </div>
                    </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 135px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 6px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 195px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 5px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 100px; height: 9px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 135px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 6px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="3" style="height: 9px" valign="top">
                                <asp:GridView ID="gvTemplate" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_QueryBuilder"
                                    OnRowCommand="gvTemplate_RowCommand" SkinID="gridviewSkin" Width="406px">
                                    <Columns>
                                        <asp:BoundField DataField="TEMPLATE_NAME" HeaderText="TEMPLATE_NAME" SortExpression="TEMPLATE_NAME" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CommandArgument='<%# Eval("TEMPLATE_NAME") %>'
                                                    CommandName="btnEdit" ImageUrl="~/Images/icon_edit.gif" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgbtnSelect" runat="server" CommandArgument='<%# Eval("TEMPLATE_NAME") %>'
                                                    CommandName="btnSelect" ImageUrl="~/Images/img_SELECT.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgbtnDel" runat="server" CommandArgument='<%# Eval("TEMPLATE_NAME") %>'
                                                    CommandName="btnDel" ImageUrl="~/Images/icon_delete.gif" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource_QueryBuilder" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [TEMPLATE_NAME] FROM [QUERY_BUILDER]">
                                </asp:SqlDataSource>
                            </td>
                            <td align="left" style="width: 5px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 100px; height: 9px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 135px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 6px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 195px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 5px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 100px; height: 9px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 46px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 135px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 6px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 195px; height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 5px; height: 9px" valign="top">
                            </td>
                            <td align="left" colspan="2" style="height: 9px" valign="top">
                            </td>
                            <td align="left" style="width: 100px; height: 9px" valign="top">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    &nbsp;<br />
    </fieldset>
     
     </td>
        </tr>
    </table>
    <br />   
</asp:Content>

