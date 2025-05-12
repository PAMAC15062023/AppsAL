<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="CDMA_SubProduct_Master.aspx.cs" Inherits="CoreDailyMISAutomation.CDMA_SubProduct_Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <style type="text/css">
        .TableTitle {
            font-size: 1pt;
            color: #333333;
            font: family- Verdana, Tahoma;
            background-color: #C0C0C0;
            border-right: #660000 1px solid;
            border-top: #660000 1px solid;
            border-left: #660000 1px solid;
            border-bottom: #660000 1px solid;
            border-color: #808080;
        }
    </style>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">Sub Product Master</span>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
               
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Black" Height="16px" Text="Sub Product" Width="122px"></asp:Label>
               
                </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtSubProduct" runat="server" MaxLength="100"></asp:TextBox>

            </td>
        </tr>


        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
               
                <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="Black" Height="16px" Text="Active" Width="122px"></asp:Label>
               
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:CheckBox ID="chkActive" runat="server" />

            </td>
        </tr>
    </table>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSubmit_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnCancel_Click" />&nbsp;
            </td>
        </tr>
    </table>


    <div>
        <asp:HiddenField runat="server" ID="hdnID" Value="0" />
        <asp:GridView ID="gvSubProduct" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            EmptyDataText="No records has been added." BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Edit_Click" Text="Edit" /><%-- OnClick="btn_Edit_Click1"--%>
                    </ItemTemplate>

                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Sr.No">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1%>
                            </ItemTemplate>
                        </asp:TemplateField>

                <asp:TemplateField HeaderText="Activity">
                    <ItemTemplate>
                        <asp:Label ID="lblSubProduct" runat="server" Text='<%#Eval("SubProduct") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Is Active">
                    <ItemTemplate>
                        <asp:Label ID="lblIsActive" runat="server" Text='<%#Eval("IsActive") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" ForeColor="#ffffff" Font-Bold="True" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </div>


    <br />
    <br />
    <br />
</asp:Content>
