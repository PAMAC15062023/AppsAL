<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin_MasterPage.master" Theme="SkinFile" CodeFile="ProductMaster.aspx.cs" Inherits="Administrator_ProductMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">

<fieldset><legend class="FormHeading">Product Master</legend>
    <table width="100%" cellpadding="1" cellspacing="0" runat="server" id="table1" border="0">
            <tr>
                <td align="right">
                        <asp:Label SkinID="lblErrorMsg" ID="lblMsg" runat="server"></asp:Label>
                    <asp:Button ID="AddNew" runat="server" OnClick="AddNew_Click" SkinID="btnAddNewSkin"
                        Text="Button" />
                </td>
            </tr>           
            <tr>
            <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView SkinID="gridviewSkin" ID="gvProductMaster" runat="server" AllowPaging="True" AllowSorting="True" PageSize="15"
                            AutoGenerateColumns="False" DataKeyNames="Product_ID" DataSourceID="sdsProductMaster"
                             Width="100%" OnRowCommand="gvProductMaster_RowCommand">
                             <HeaderStyle CssClass="GridHeader" />
                             <AlternatingRowStyle CssClass="GridAlternate" />                                                
                             <PagerStyle HorizontalAlign="Center" CssClass="Class1" />
                             <RowStyle CssClass="GridRow" />
                            <Columns>
                                <asp:BoundField DataField="Product_Code" HeaderText="Product Code" SortExpression="Product_Code" />
                                <asp:BoundField DataField="Product_Name" HeaderText="Product Name" SortExpression="Product_Name" />
                                <asp:TemplateField> 
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("Product_ID") %>'
                                        CommandName="Edit" ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="sdsProductMaster" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="Select Product_Id, Product_Code, Product_Name from Product_Master order by Product_Name"
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                    </asp:SqlDataSource>
                </td>
            </tr>
                <tr>
                    <td colspan="2">&nbsp;
                        </td>
                </tr>
        </table>
    
    </fieldset>
    </td></tr></table>
</asp:Content>

