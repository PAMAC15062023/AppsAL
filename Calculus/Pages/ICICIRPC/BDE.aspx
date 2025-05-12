<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="BDE.aspx.cs" Inherits="Pages_ICICIRPC_BDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

    </script>
    <table style="width: 100%">
        <tr>
            <td class="TableHeader" colspan="6" style="height: 22px">&nbsp;BDE Form </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="grdlos" runat="server" AutoGenerateColumns="False"
                    Height="36px" Width="750px" CssClass="mGrid">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkSelectAll" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkWIP" runat="server" OnClick="lnkWIP_Click1" Font-Bold="True" Width="52px">Start</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdiscripant" runat="server" OnClick="lnkdiscripant_Click" Font-Bold="True" Width="61px" Enabled="False">Discrepant</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="wipstatus" HeaderText="Status" />

                        <asp:BoundField DataField="LOSNO" HeaderText="ApplicationNo" />
                        <asp:BoundField DataField="scan_date" HeaderText="Scan Date" />
                        <asp:BoundField DataField="cus_name" HeaderText="Customer Name" />
                        <asp:BoundField DataField="aps_id" HeaderText="APS ID" />
                        <asp:BoundField DataField="location" HeaderText="location" />
                        <asp:BoundField DataField="Loan_Amt" HeaderText="Loan Amount" />
                        <asp:BoundField DataField="NewCarOrUsedCar" HeaderText="Car Status" />
                        <asp:TemplateField HeaderText="Product Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlProductStatus" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Individual</asp:ListItem>
                                    <asp:ListItem>Non-Individual</asp:ListItem>
                                    <asp:ListItem>Corporate</asp:ListItem>
                                    <%--<asp:ListItem>Not Processed</asp:ListItem>--%>                                    
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                    <asp:ListItem>Done by Bank</asp:ListItem>
                                    <asp:ListItem>Hold</asp:ListItem>
                                    <%--<asp:ListItem>Not Processed</asp:ListItem>--%>                                    
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Aps ID">
                            <ItemTemplate>
                                <asp:TextBox ID="txtapsid" runat="server" Height="30px" SkinID="txtSkin"
                                    TextMode="SingleLine" Width="217px" onkeypress="return isNumberKey(event)" MaxLength="8"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="30px" SkinID="txtSkin"
                                    TextMode="SingleLine" Width="217px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="loan amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtloanamount" runat="server" Height="30px" SkinID="txtSkin" 
                                    TextMode="SingleLine" Width="217px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="loan tenure">
                            <ItemTemplate>
                                <asp:TextBox ID="txtloantenure" runat="server" Height="30px" SkinID="txtSkin" 
                                    TextMode="SingleLine" Width="217px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleted" runat="server" OnClick="lnkCompleted_Click" Font-Bold="True" Width="40px">Complete & New Assign</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleteCPV" runat="server"
                                    OnClick="lnkCompleteCPV_Click">Completed & Assign CPV</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleteExit" runat="server" OnClick="lnkCompleteExit_Click" Font-Bold="True" Width="40px">Complete & Exit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grddata" runat="server"></asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 25px">
                <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click"
                    Text="Cancel" />
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>


</asp:Content>

