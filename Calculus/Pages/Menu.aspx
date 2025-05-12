<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Pages_Menu" Title="Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:Menu ID="mnu_Dynamic" runat="server"   DataSourceID="XmlDataSource1" BackColor="Silver" Orientation="Horizontal" Width="100%" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" StaticSubMenuIndent="10px" BorderWidth="1px" BorderColor="#404040" BorderStyle="Groove">
        <DataBindings>
            <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text"
                ToolTipField="ToolTip" />
        </DataBindings>
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
        <DynamicMenuStyle BackColor="#E3EAEB" CssClass="style" />
        <StaticSelectedStyle BackColor="#1C5E55" />
        <DynamicSelectedStyle BackColor="#1C5E55" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
    </asp:Menu>
     
    <br />
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Pages/Images/Calender.gif"
        Height="32px" Width="47px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 9%">
            <tr>
                <td style="width: 100px; height: 20px; text-align: center">
                    <asp:Label ID="lblMonth" runat="server" Font-Bold="True" ForeColor="White" Text="Sep"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center">
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True" Text="17"></asp:Label></td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table style="font-size: 8pt; color: gray; font-family: Verdana; text-align: left">
        <tbody>
            <tr>
                <td style="text-align: left; width: 130px;">
                    &nbsp; &nbsp;&nbsp;
                </td>
                <td style="text-align: left">
                </td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle" style="text-align: left; width: 130px;">
                    &nbsp;
                    User</td>
                <td class="TableGrid" style="text-align: left">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr style="color: #808080">
                <td class="GridViewPagerStyle" style="text-align: left; width: 130px;">
                    &nbsp;
                    Branch</td>
                <td class="TableGrid" style="text-align: left">
                    <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle" 
                    style="height: 15px; text-align: left; width: 130px;">
                    &nbsp;
                    Group-Role</td>
                <td class="TableGrid" style="height: 15px; text-align: left">
                    <asp:Label ID="lblRole" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle" 
                    style="text-align: left; width: 130px; height: 14px;">
                    &nbsp;
                    Masters Updated</td>
                <td class="TableGrid" style="text-align: left; height: 14px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 36px">
                        <tr>
                            <td>
                    <asp:Label ID="lblMasterFileInfo" runat="server" Font-Bold="False" Height="16px" 
                                    Width="147px"></asp:Label></td>
                            <td style="width: 100px">
                    <asp:Label ID="lblInfo" runat="server" BackColor="Red" Font-Bold="False" ForeColor="White"
                        Height="15px" Text="[?]" Visible="False" Width="18px"></asp:Label></td>
                </tr>
                   
                    </table>
                       <tr>
            <td class="GridViewPagerStyle" 
                    style="text-align: left; width: 130px; height: 14px;">
                    &nbsp; Client_Name</td>
                        <td class="TableGrid" style="height: 15px; text-align: left">
                    <asp:Label ID="lblClient" runat="server" Font-Bold="False"></asp:Label></td>
                   </tr>
                </td>
            </tr>
        </tbody>
    </table>
    &nbsp;
    <marquee><SPAN>&nbsp;<asp:Label id="Label1" runat="server" ForeColor="Gray" Font-Size="7pt" Font-Names="Verdana" Text="[Please Select Your Desire Operation From Menu]"></asp:Label></SPAN></marquee>
    <br />
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" TransformFile="~/Pages/TransformXSLT.xsl"
        XPath="MenuItems/MenuItem"></asp:XmlDataSource>
</asp:Content>

