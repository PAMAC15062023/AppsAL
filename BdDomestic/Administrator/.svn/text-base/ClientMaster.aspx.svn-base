<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Admin_MasterPage.master" Theme="SkinFile" CodeFile="ClientMaster.aspx.cs" Inherits="Administrator_ClientMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<fieldset><legend class="FormHeading">Client Master</legend>
    <%--<form id="form1" runat="server">
    <div>--%>
            <table width="100%" cellpadding="1" cellspacing="0" runat="server" id="table1" border="0">
            <tr>
               
                <td align="right">
                        <asp:Label SkinID="lblErrorMsg" ID="lblMsg" runat="server"></asp:Label>
                    <asp:Button ID="AddNew" runat="server" OnClick="AddNew_Click" SkinID="btnAddNewSkin"
                        Text="Button" />&nbsp;
                </td>
            </tr>
            <tr>
            <td>
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView SkinID="gridviewSkin" ID="gvClientMaster" runat="server" AllowPaging="True" AllowSorting="True" PageSize="15"
                            AutoGenerateColumns="False" DataKeyNames="Client_ID" DataSourceID="sdsClientMaster"
                             Width="100%" OnRowCommand="gvClientMaster_RowCommand">
                             <HeaderStyle CssClass="GridHeader" />
                             <AlternatingRowStyle CssClass="GridAlternate" />                                                
                             <PagerStyle HorizontalAlign="Center" CssClass="Class1" />
                             <RowStyle CssClass="GridRow" />
                            <Columns>
                                <asp:BoundField DataField="Client_Code" HeaderText="Client Code" SortExpression="Client_Code" />
                                <asp:BoundField DataField="Client_Name" HeaderText="Client Name" SortExpression="Client_Name" />
                                <asp:TemplateField> 
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("Client_ID") %>'
                                        CommandName="Edit" ><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="sdsClientMaster" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="Select Client_Id, Client_Code, Client_Name from Client_Master order by Client_Name"
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                    </asp:SqlDataSource>
                </td>
            </tr>
                <tr>
                    <td colspan="2">
                        </td>
                </tr>
        </table>
    <%--</div>
    </form>--%>
    </fieldset>
    </asp:Content>

