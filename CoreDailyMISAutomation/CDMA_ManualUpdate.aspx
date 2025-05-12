<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="CDMA_ManualUpdate.aspx.cs" Inherits="CoreDailyMISAutomation.CDMA_ManualUpdate" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">Core Manual Update</span>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
               <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlCommomDetails" runat="server">
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px; width: 130px;" colspan="4">
                <asp:Label ID="lblVertical" runat="server">Vertical</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtVertical" runat="server" Text="CPA" Width="150px" Enabled="false"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblSubVertical" runat="server">Sub Vertical</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlSubVertical" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlSubVertical_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px; width: 130px;" colspan="4">
                <asp:Label ID="lblClientNamedd" runat="server">Client Name</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlClientName" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged"></asp:DropDownList>
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblActivity" runat="server">Activity</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlActivity" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px; width: 130px;" colspan="4">
                <asp:Label ID="lblProduct" runat="server">Product</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlProduct" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList>
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblSubProduct" runat="server">Sub Product/process</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlSubProduct" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <%--<tr>
             <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Label ID="lblIsActive" runat="server">Active</asp:Label>
            </td>

            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:CheckBox ID="chkActive" runat="server"/>

            </td>
        </tr>--%>
    </table>
        </asp:Panel>

    <asp:Panel ID="pnlSpecificDetails" runat="server">
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblMISMonth" runat="server">MIS Month</asp:Label>
            </td>
             <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlMISMonth" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlMISMonth_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                 
            </td>
            </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblPreviousMonthName" runat="server">Previous Month Name</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtPreviousMonthName" runat="server" Width="175px" Enabled="false"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblPreviousMonthVolume" runat="server">Previous Month Volume</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtPreviousMonthVolume" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblCurrentMonthName" runat="server">Current Month Name</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtCurrentMonthName" runat="server" Width="175px" Enabled="false"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblCurrentMonthVolume" runat="server">Current Month Volume</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtCurrentMonthVolume" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblIncDecCount" runat="server">INCREASED/ DECREASED (Count)</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtIncDecCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblIncDecPer" runat="server">INCREASED/ DECREASED %</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtIncDecPer" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblDuplicateandHoldCaseCount" runat="server">Duplicate and Hold cases (Count)</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtDuplicateandHoldCaseCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblStaffCount" runat="server">Staff Count</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtStaffCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblWithinTATCaseCount" runat="server">Within TAT - Count of Cases (Count)</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtWithinTATCaseCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblOutOfTATCaseCount" runat="server">Out of  TAT - Count of Cases (Count)</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtOutOfTATCaseCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblQCCount" runat="server">QC COUNT</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtQCCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblErrorCount" runat="server">Error Count</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtErrorCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblComplaintsCount" runat="server">Complaints Count (Recd. From Client)</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtComplaintsCount" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblDeviation" runat="server">Deviation</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlDeviation" runat="server" Width="175px" AutoPostBack="true">
                     <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblCountOfCases" runat="server">Count of Cases - Billed to client (Approx Count )</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:TextBox ID="txtCountOfCases" runat="server" Width="175px" Enabled="true"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblCalculusData" runat="server">Calculus Data (Yes/No)</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:DropDownList ID="ddlCalculusData" runat="server" Width="175px" AutoPostBack="true">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:Label ID="lblRemark" runat="server">Remark</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="12">
                <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" Width="475px" Enabled="true"></asp:TextBox>
            </td>
        </tr>
      </table>
        </asp:Panel>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnCancel_Click"/>&nbsp;
            </td>
        </tr>
    </table>


   <%-- <div>
        <asp:HiddenField runat="server" ID="hdnClientID" Value="0" />
        <asp:GridView ID="gvClientName" runat="server" AutoGenerateColumns="False" DataKeyNames="ClientID,AllMasterID,ActivityID,SubVerticalID,ProductID,SubProductID" OnPageIndexChanging="gvClientName_PageIndexChanging"
            EmptyDataText="No records has been added." BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True">


            <AlternatingRowStyle BackColor="#CCCCCC" />


            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Edit_Click" Text="Edit" /> <%-- OnClick="btn_Edit_Click1"
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
    </div>--%>
    <br />
    <br />
    <br />
</asp:Content>
