<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Pages_ICICIRPC_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="width: 854px;">
        <tr>
            <td style="width: 808px">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" style="width: 808px;">Case Tracking Page</td>
        </tr>
        <tr>
            <td style="width: 808px">Application Number:<asp:TextBox ID="txtlosno_search" runat="server" Width="124px" AutoPostBack="true"
                Height="22px" OnTextChanged="txtlosno_search_TextChanged"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                                   APS ID:<asp:TextBox ID="txtaps_id" runat="server" Width="124px" Height="22px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnsearch" runat="server" CssClass="button"
                                            OnClick="btnsearch_Click" SkinID="btnImport" Text="Search" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click"
                                            Text="Cancel" />
            </td>
        </tr>

    </table>
    <asp:Panel ID="pnllocation" runat="server"
        Height="71px" Width="855px" Visible="false">
        <table style="width: 100%; height: 73px;">
            <tr>
                <td style="font-size: 10pt; width: 131px;">
                    <strong>Location Details:</strong></td>
            </tr>
            <tr>
                <td style="width: 131px" class="TableTitle">HUB Location</td>
                <td style="width: 65px" class="TableGrid">
                    <asp:Label ID="lblhub" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 129px">PMS Location</td>
                <td class="TableGrid" style="width: 78px">
                    <asp:Label ID="lblspoke" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 129px">RPC Location</td>
                <td style="height: 42px;" class="TableGrid" style="width: 78px">
                    <asp:Label ID="lbllocation" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>



    <asp:Panel ID="pnlindexing" runat="server" Visible="false">
        <table style="width: 100%;">
            <tr>
                <td colspan="6" style="font-size: 10pt">
                    <strong>BDE Details:</strong></td>
            </tr>
            <tr>
                <td style="width: 92px" class="TableTitle">BDE Name</td>

                <td class="TableGrid" style="height: 42px; width: 78px">
                    <asp:Label ID="lblindexer_name" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 124px">Start Date</td>

                <td class="TableGrid" style="height: 42px; width: 100px">
                    <asp:Label ID="lblstart_time" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 98px">Completed Date</td>

                <td style="height: 42px; width: 80px" class="TableGrid">
                    <asp:Label ID="lblcompleted_date" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 127px">Final Status</td>
                <td class="TableGrid" style="height: 42px; width: 78px;">
                    <asp:Label ID="lblfinal_status" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 78px">Remark</td>
                <td class="TableGrid" style="height: 42px; width: 100px">
                    <asp:Label ID="lblremark" runat="server"></asp:Label>
                </td>
            </tr>

        </table>
    </asp:Panel>

    <asp:Panel ID="pnlqde" runat="server" Visible="false">
        <table style="width: 100%;">
            <tr>
                <td colspan="8" style="font-size: 10pt">
                    <strong>CAM Details:</strong></td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 69px">CAMUser:</td>
                <td class="TableGrid" style="height: 42px; width: 103px">
                    <asp:Label ID="lblqdeuser1" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 69px">Start Date:</td>
                <td class="TableGrid" style="height: 42px; width: 78px">
                    <asp:Label ID="lblqdes_date" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 102px">Completed Date:</td>
                <td class="TableGrid" style="height: 42px; width: 78px">
                    <asp:Label ID="lblqdecompleted_date" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 143px">Final Status:</td>
                <td class="TableGrid" style="height: 42px; width: 78px">
                    <asp:Label ID="lblqdefinal_status" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>







    <asp:Panel ID="Pnlcpvdetails" runat="server" Visible="false">
        <table style="width: 100%;">
            <tr>
                <td colspan="6" style="font-size: 10pt">
                    <strong>CPV Details:</strong></td>
            </tr>
            <tr>
                <td style="width: 46px" class="TableTitle">CPV USER</td>

                <td class="TableGrid" style="height: 42px; width: 78px">
                    <asp:Label ID="lblcpvuser" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 83px">Start Date</td>

                <td class="TableGrid" style="height: 42px; width: 78px">
                    <asp:Label ID="lblstartdate" runat="server"></asp:Label>
                </td>
                <td class="TableTitle" style="width: 83px">Completed Date</td>

                <td style="height: 42px; width: 69px" class="TableGrid">
                    <asp:Label ID="lblcpvc_date" runat="server"></asp:Label>
                </td>


                <td class="TableTitle" style="width: 83px">Final Status</td>
                <td class="TableGrid" class="TableGrid" style="width: 78px">
                    <asp:Label ID="lblcpvf_status" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        l
    </asp:Panel>



</asp:Content>

