<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile"  AutoEventWireup="true" CodeFile="StandardTATHour_View.aspx.cs" Inherits="Administrator_StandardTATHour_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
<fieldset><legend class="FormHeading">Standard Tat Hour</legend>
<table width=100%>
<tr><td><asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td></tr>
<tr><td colspan="9" align="right">
<asp:Button ID="btnNew" runat="server" SkinID=btnAddNewSkin OnClick="btnNew_Click" Text="New" />
</td></tr>
<tr><td colspan="9" >&nbsp;</td></tr>
<tr>        
            <td colspan="9" >
                <asp:GridView ID="GvView" runat="server"  SkinID="gridviewSkin" Height="108px" AutoGenerateColumns="False" Width="689px" 
                
                OnRowCommand="GvView_RowCommand"  OnRowDataBound="GvView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="STANDARD_TAT_ID" HeaderText="STANDARD_TAT_ID" />
                        <asp:BoundField DataField="Activity_name" HeaderText="Activity" />
                        <asp:BoundField DataField="Product_name" HeaderText="Product" />
                        <asp:BoundField DataField="Client_name" HeaderText="Client" />
                        <asp:BoundField DataField="STD_HRS1" HeaderText="Standard Tat Hour1" />
                        <asp:BoundField DataField="STD_HRS2" HeaderText="Standard Tat Hour2" />
                        <asp:BoundField DataField="STD_HRS3" HeaderText="Standard Tat Hour3" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtn" runat="server" ImageUrl="~/Images/icon_edit.gif" CommandArgument='<%# Eval("STANDARD_TAT_ID") %>' CommandName="Edi" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>  </td>
           
        </tr>
        <tr><td colspan="9" >&nbsp;</td></tr>
           </table>
    </fieldset>
</td></tr></table>
</asp:Content>

