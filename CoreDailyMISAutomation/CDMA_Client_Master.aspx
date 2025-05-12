<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="CDMA_Client_Master.aspx.cs" Inherits="CoreDailyMISAutomation.CDMA_Client_Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">Client Master</span>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
               <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblVertical" runat="server">Vertical</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtVertical" runat="server" Text="CPA" Enabled="false"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblSubVertical" runat="server">Sub Vertical</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlSubVertical" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblClientNamedd" runat="server">Client Name</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlClientName" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged"></asp:DropDownList>
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblClientName" runat="server">Client Name</asp:Label>
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtClientName" runat="server" MaxLength="100" OnTextChanged="txtClientName_TextChanged" AutoPostBack="true"></asp:TextBox>

            </td>
        </tr>

        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblActivity" runat="server">Activity</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlActivity" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblProduct" runat="server">Product</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlProduct" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblSubProduct" runat="server">Sub Product/process</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlSubProduct" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblIsActive" runat="server">Active</asp:Label>
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
        <asp:HiddenField runat="server" ID="hdnClientID" Value="0" />
        <asp:GridView ID="gvClientName" runat="server" AutoGenerateColumns="False" DataKeyNames="ClientID,AllMasterID,ActivityID,SubVerticalID,ProductID,SubProductID" OnPageIndexChanging="gvClientName_PageIndexChanging"
            EmptyDataText="No records has been added." BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True">


            <AlternatingRowStyle BackColor="#CCCCCC" />


            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Edit_Click" Text="Edit" /><%-- OnClick="btn_Edit_Click1"--%>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Sr No">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Sub Vertical">
                    <ItemTemplate>
                        <asp:Label ID="lblSubVertical" runat="server" Text='<%#Eval("SubVertical") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Client Name">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Activity">
                    <ItemTemplate>
                        <asp:Label ID="lblActivity" runat="server" Text='<%#Eval("Activity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Product") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Sub Product">
                    <ItemTemplate>
                        <asp:Label ID="lblSubProduct" runat="server" Text='<%#Eval("SubProduct") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Is Active">
                    <ItemTemplate>
                        <asp:Label ID="lblisActive" runat="server" Text='<%#Eval("IsActive") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" ForeColor="#ffffff" Font-Bold="True" />
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="next" PageButtonCount="5" PreviousPageText="Previous" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:HiddenField ID="hdnAMID" runat="server" />

    </div>


    <br />
    <br />
    <br />
</asp:Content>
