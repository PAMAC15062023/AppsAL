<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="FEPincodeMapping_View.aspx.cs" Inherits="Administrator_FEPincodeMapping_View" Theme="skinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
//Made By Gargi Srivastava at 29-Nov-2007
function Fun_Select()
{
    var ArrSelected = new Array(); 
    var SelObj = document.getElementById("<%=lstClient.ClientID%>");
    var hidClientID = document.getElementById("<%=hidClientID.ClientID%>");   
    
    var i;
    var count = 0;
    for (i=0; i<SelObj.options.length; i++)
    {
        if (SelObj.options[i].selected)
        {
        ArrSelected[count] = SelObj.options[i].value; 
        count++;
        }
    }
    
    hidClientID.value=ArrSelected;    
    
} 
</script>
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
<fieldset><legend class="FormHeading">FE Pincode Mapping View</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td colspan="5">
        <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td></tr>
         <tr><td colspan="5"></td></tr>
        <tr>
       
        <td>
        Client </td>
         <td>
                :</td>
                <td >
                    <asp:ListBox ID="lstClient" SelectionMode="Multiple" runat="server" DataSourceID="sdsClient" SkinID="lbSkin" DataTextField="CLIENT_NAME" DataValueField="CLIENT_ID" Width="200px"></asp:ListBox>&nbsp;
                    <asp:SqlDataSource ID="sdsClient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
                    SelectCommand="SELECT '0' as [CLIENT_ID],'--All--' as [CLIENT_NAME] UNION SELECT DISTINCT [CLIENT_ID], [CLIENT_NAME] FROM [ce_ac_pr_ct_vw] WHERE [CENTRE_ID]=? AND CLIENT_ID IS NOT NULL order by CLIENT_NAME">
                     <SelectParameters>
                        <asp:SessionParameter Name="?" SessionField="CENTREID" />
                    </SelectParameters>
                    </asp:SqlDataSource>
            </td>
            <td><asp:Button ID="btnSearch" runat="server"  SkinID="btnSearchSkin"
                Text="Search" ValidationGroup="grpFEPinMapping" OnClientClick="Fun_Select()" OnClick="btnSearch_Click" /></td>
                 <td>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="btnAddNewSkin"
                Text="Add" ValidationGroup="grpFEPinMapping" /></td>
        </tr> 
                
   
    <tr>
        <td align="right" colspan="5">
        </td>
    </tr>
        <tr><td colspan="5">&nbsp;</td></tr> 
<tr><td colspan="5">
<asp:GridView ID="gvFEPincode" runat="server" AutoGenerateColumns="False"  OnRowCommand="gvFEPincode_RowCommand" SkinID="gridviewSkin" Width="100%" OnRowDataBound="gvFEPincode_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvFEPincode_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="FULLNAME" SortExpression="FULLNAME">               
                <ItemTemplate>
                    <asp:Label ID="lblFullname" runat="server" Text='<%# Bind("FULLNAME") %>'></asp:Label>
                    <asp:HiddenField ID="hdnFE_ID" runat="server" Value='<%# Bind("FE_ID") %>'></asp:HiddenField>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Client" SortExpression="CLIENT_NAME">                
                <ItemTemplate>
                    <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("CLIENT_NAME") %>'></asp:Label>
                    <asp:HiddenField ID="hdnClient_Id" runat="server" Value='<%# Bind("CLIENT_ID") %>'></asp:HiddenField>
                </ItemTemplate>
            </asp:TemplateField>                
             <asp:TemplateField HeaderText="PINCODE" SortExpression="PINCODE">                
                <ItemTemplate>
                    <asp:Label ID="lblPincode" runat="server" Text='<%# Bind("PINCODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField> 
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                    CommandName="EditMapping" ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField> 
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkFEPinDelete" runat="server" CausesValidation="False" CommandName="DeleteMapping" CommandArgument='<%# Container.DataItemIndex %>' Text="Delete">
                    <img src="../Images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>     
        </Columns>
        </asp:GridView>
    </td></tr>
    <tr><td >&nbsp;</td></tr> 
    </table>
    </fieldset>
 </td></tr>
    <tr>
        <td style="padding-left: 8px">
           <%-- <asp:SqlDataSource ID="sdsFEPincode" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
                SelectCommand="SELECT D.PINCODE,FE_VW.FULLNAME,D.FE_ID,CL.CLIENT_ID,CL.CLIENT_NAME FROM FE_PINCODE_MAPPING AS D 
                INNER JOIN FE_VW ON D.FE_ID = FE_VW.EMP_ID INNER JOIN CLIENT_MASTER CL ON D.CLIENT_ID = CL.CLIENT_ID 
                AND FE_VW.CENTRE_ID = ? ORDER BY FULLNAME">
                <SelectParameters>
                    <asp:SessionParameter Name="?" SessionField="CENTREID" />
                </SelectParameters>
            </asp:SqlDataSource>--%>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 8px">
        <asp:HiddenField ID="hidClientID" runat="server"/>
        </td>
    </tr>
</table>
</asp:Content>

