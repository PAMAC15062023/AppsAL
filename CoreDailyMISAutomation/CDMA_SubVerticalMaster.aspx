<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="CDMA_SubVerticalMaster.aspx.cs" Inherits="CoreDailyMISAutomation.CDMA_SubVerticalMaster" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
<table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">Sub Vertical Master</span>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblSubVerticalName" runat="server">Sub Vertical</asp:Label>
            </td>
            
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtSubVerticalName" runat="server" MaxLength="100"></asp:TextBox>

            </td>
        </tr>


          <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblIsActive" runat="server">Active</asp:Label>
            </td>
            
            <td class="TableTitle" style="height: 27px" colspan="4">
              <asp:CheckBox ID="chkActive" runat="server"/>

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
        <asp:HiddenField runat="server" ID="hdnID" Value ="0" />
        <asp:GridView ID="gvSubVertical" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
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
  
                <asp:TemplateField HeaderText="Sub Vertical">
                    <ItemTemplate>
                        <asp:Label ID="lblSubVerticalName" runat="server" Text='<%#Eval("SubVertical") %>'></asp:Label>
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