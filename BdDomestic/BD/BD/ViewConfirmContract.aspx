<%@ Page Language="C#" MasterPageFile="~/BD/BD/BDMasterPage.master" AutoEventWireup="true" CodeFile="ViewConfirmContract.aspx.cs" Inherits="BD_ViewConfirmContract" Theme="SkinFile" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <fieldset><legend class="legend">View Confirm Contract</legend>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
    <td>
        &nbsp;<asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
    </tr>
    <tr>
    <td>
        <asp:GridView ID="gvConfirmContract" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="CONT_PRESALE_ID" DataSourceID="sdsConfirmContract" OnRowCommand="gvConfirmContract_RowCommand" SkinID="gridviewNoSort">        
            <Columns>
                <asp:BoundField DataField="CONT_PRESALE_REF_NO" HeaderText="Contract Ref No"
                    SortExpression="CONT_PRESALE_REF_NO" />
                <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" SortExpression="CLIENT_NAME" />
                <asp:BoundField DataField="PRESALE_STATUS" HeaderText="Status" SortExpression="PRESALE_STATUS" />
                <asp:BoundField DataField="ORDER_NO" HeaderText="Order No" SortExpression="ORDER_NO" />
                <asp:BoundField DataField="ORDER_DATE" HeaderText="Order Date" SortExpression="ORDER_DATE" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                <asp:TemplateField HeaderText="Contract Detail"> 
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkContract" runat="server" CommandArgument='<%# Eval("CONT_PRESALE_ID") %>'
                        CommandName="EnterCotractDetail"><img  alt="Enter Contract Detail" src="../../Images/icon_edit.gif" border="0"/></asp:LinkButton>
                    </ItemTemplate>  
                    <ItemStyle HorizontalAlign="Center" />                      
                </asp:TemplateField>
            </Columns>
        </asp:GridView>    
    </td>
    </tr>
    </table>
    </fieldset>
    </div>
        <asp:SqlDataSource ID="sdsConfirmContract" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO, B.CLIENT_NAME, A.PRESALE_STATUS, A.ORDER_NO, A.ORDER_DATE FROM PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID WHERE A.IS_CONFIRMED='Y' ORDER BY A.LEAD_DATE DESC">
        </asp:SqlDataSource>
</asp:Content>