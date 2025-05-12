<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="QCError.aspx.cs" Inherits="Pages_ICICIRPC_QCError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="width: 688px;">
        <tr>
            <td style="width: 691px;">
                <table style="width: 686px; height: 113px;">
                    <tr>
                        <td style="width: 690px;">
                            <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="TableHeader" style="width: 690px;">ERROR/QC UPDATE </td>
                    </tr>
                    <tr>
                        <td style="width: 690px;">

                            <asp:Label ID="lblmsg" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" align="left">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel1" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 121px">
                                                        <strong>APS ID</strong></td>
                                                    <td style="width: 11px">:</td>
                                                    <td style="width: 133px">
                                                        <asp:TextBox ID="txtlosno_search" runat="server" Width="182px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnsearch" runat="server" CssClass="button" SkinID="btnImport" Text="Search" OnClick="btnsearch_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel2" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 115px; height: 15px" align="left">BDE Name</td>
                                                    <td style="width: 16px; height: 15px">:</td>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblindexname" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 115px; height: 15px">BDE Status</td>
                                                    <td style="width: 16px; height: 15px">:</td>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblindst" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px" align="left">BDE Remark</td>
                                                    <td style="width: 16px">:</td>
                                                    <td>
                                                        <asp:Label ID="lblindremark" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px" align="left">Name Of Applicant</td>
                                                    <td style="width: 16px">:</td>
                                                    <td>
                                                        <asp:Label ID="lblnameofapp" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px" align="left">Application Number</td>
                                                    <td style="width: 16px">:</td>
                                                    <td>
                                                        <asp:Label ID="lblsmcode" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 115px; height: 15px;">Location</td>
                                                    <td style="width: 16px; height: 15px;">:</td>
                                                    <td style="height: 15px">
                                                        <asp:Label ID="lblddename" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px" align="left">CAM User Name </td>
                                                    <td style="width: 16px">:</td>
                                                    <td>
                                                        <asp:Label ID="lblddest" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 115px">CAM Status</td>
                                                    <td style="width: 16px">:</td>
                                                    <td>
                                                        <asp:Label ID="lblcamstatus" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 115px">CAM Remark</td>
                                                    <td style="width: 16px">:</td>
                                                    <td>
                                                        <asp:Label ID="lblcamremark" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 115px">Error Type</td>
                                                    <td style="width: 16px">:</td>
                                                    <td>
                                                        <asp:DropDownList ID="dderrortype" runat="server">
                                                           <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="Internal">Internal </asp:ListItem>
                                                            <asp:ListItem Value="External">External</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="dderrortype" Display="None"
                                                            ErrorMessage="Please Select Error Type " InitialValue="0" Font-Bold="True"
                                                            ForeColor="Red" SetFocusOnError="True" ValidationGroup="check"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px; height: 17px;">Error Remark</td>
                                                    <td style="width: 16px; height: 17px;">:</td>
                                                    <td style="height: 17px">
                                                        <asp:TextBox ID="txterrorup" runat="server" TextMode="MultiLine" Width="346px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">&nbsp;</td>
                                                    <td style="width: 16px">&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnedit" runat="server" CssClass="button" SkinID="btnImport"
                                                            Text="Update" OnClick="btnedit_Click" ValidationGroup="check" />
                                                        &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="button" SkinID="btnImport"
                                                            Text="Cancel" OnClick="btncancel_Click" />
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="check" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>

</asp:Content>

