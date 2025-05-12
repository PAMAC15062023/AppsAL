<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="HDFCTM_ReasonMaster.aspx.cs" Inherits="Pages_Calculus_HDFC_HDFCTM_ReasonMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td colspan="5" rowspan="1" style="height: 17px">&nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="200px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">Reason&nbsp; Master
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">Reason<span style="color : red"> *</span></td>

            <td>
                <asp:TextBox ID="txtReason" runat="server" BorderWidth="1px" TextMode="MultiLine" MaxLength="2000" SkinID="txtSkin"></asp:TextBox></td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">
                <asp:Label ID="lblactive" runat="server">Active</asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkactive" runat="server" />

            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" OnClick="btnSave_Click" />&nbsp;
         
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="5" style="height: 17px">
                <asp:GridView ID="Gridview_HDFCTM" runat="server" Width="308px" AutoGenerateColumns="False" BorderColor="Black" Enabled="true" BorderStyle="Double">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Sr.No" />
                        <asp:BoundField DataField="Reason" HeaderText="Reason" />
                        <asp:BoundField DataField="IsActive" HeaderText="Active" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Edit_Click" Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnReasonId" runat="server" Value="0" />


            </td>
        </tr>

    </table>

</asp:Content>


