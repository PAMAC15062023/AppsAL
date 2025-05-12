<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="TicketStatus.aspx.cs" Inherits="Pages_Helpdesk_TicketStatus" Title="Ticket Status" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table>
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <tr>
            <td colspan="9">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="9">
                &nbsp; Ticket Detail Info</td>
        </tr>
        <tr>
            <td style="width: 20px; height: 14px">
            </td>
            <td class="TableTitle" style="width: 191px; height: 14px">
                &nbsp;Ticket No</td>
            <td class="TableGrid" style="width: 39px; height: 14px">
                <asp:Label ID="lblTicketNo" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
            <td style="width: 132px; height: 14px;" class="TableTitle">
                &nbsp;Ticket RaiseDate&nbsp;</td>
            <td style="width: 100px; height: 14px;" class="TableGrid">
                <asp:Label ID="lblTicketRaiseDate" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
            <td style="width: 112px; height: 14px;">
                &nbsp;</td>
            <td style="width: 100px; height: 14px;">
            </td>
            <td style="width: 100px; height: 14px;">
            </td>
            <td style="width: 100px; height: 14px">
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 28px">
            </td>
            <td class="TableTitle" style="width: 191px; height: 28px">
                &nbsp;Ticket Raise By</td>
            <td class="TableGrid" style="width: 39px; height: 28px">
                <asp:Label ID="lblUserName" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
            <td style="width: 132px; height: 28px;" class="TableTitle">
                &nbsp;Branch</td>
            <td style="width: 100px; height: 28px;" class="TableGrid">
                <asp:Label ID="lblBranch" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
            <td style="width: 112px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 19px;">
            </td>
            <td class="TableTitle" style="width: 191px; height: 19px;">
                &nbsp;Department</td>
            <td class="TableGrid" style="width: 39px; height: 19px;">
                <asp:Label ID="lblDepartment" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>

                <%--Changed by sanket--%>
            <td class="TableGrid" style="height: 19px"></td>
            <td class="TableGrid"</td style="height: 19px">

<%--            <td style="width: 132px" class="TableTitle">
                &nbsp;Priority</td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblPriority" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
--%>            <td style="width: 112px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
            </td>
        </tr>


        <%--add by Rutu 06/11/23 start>>--%>
        <tr>
            <td style="width: 20px; height: 28px">
            </td>
            <td class="TableTitle" style="width: 191px; height: 28px">
                &nbsp;Problem Type</td>
            <td class="TableGrid" style="width: 39px; height: 28px">
                <asp:Label ID="lblProblemType" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
            <td style="width: 132px; height: 28px;" class="TableTitle">
                &nbsp;Problem Details</td>
            <td style="width: 100px; height: 28px;" class="TableGrid">
                <asp:Label ID="lblProblemDetails" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
            <td style="width: 112px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
        </tr>
        <%--<<add by Rutu 06/11/23 end--%>


        <tr>
            <td style="width: 20px">
            </td>
            <td class="TableTitle" style="width: 191px">
                &nbsp;Problem Description</td>
            <td class="TableGrid" colspan="3">
                <asp:Label ID="lblRemark" runat="server" Height="53px" SkinID="LabelSkin" Width="429px"></asp:Label></td>
            <td style="width: 112px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td class="TableTitle" style="width: 191px">
                &nbsp;Ticket Status</td>
            <td class="TableGrid" colspan="3">
                <asp:Label ID="lblTicketStatus" runat="server" SkinID="LabelSkin" Width="147px"></asp:Label></td>
            <td style="width: 112px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="9" style="height: 3px">
                &nbsp; Ticket Status Updated</td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td class="TableTitle" colspan="4">
                <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333">
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <ItemStyle BackColor="#EFF3FB" />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td class="TableTitle" style="width: 107px">
                                    &nbsp;AssignedBy</td>
                                <td class="TableGrid" style="width: 39px">
                                    <asp:Label ID="lblAssignedBy" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"AssignedBy")) %>'
                                        Width="131px"></asp:Label></td>
                                <td class="TableTitle" style="width: 132px">
                                    &nbsp;Date</td>
                                <td class="TableGrid" style="width: 100px">
                                    <asp:Label ID="lblStatusDate" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"StatusDate")) %>'
                                        Width="131px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TableTitle" style="width: 107px">
                                    &nbsp;AssignedTo</td>
                                <td class="TableGrid" style="width: 39px">
                                    <asp:Label ID="lblAssignedTo" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"AssignedTo")) %>'
                                        Width="131px"></asp:Label></td>

                                <td style="width: 132px" class="TableTitle">
                                    Ticket Status</td>
                                <td style="width: 100px" class="TableGrid">
                                    <asp:Label ID="lblTicketStatus" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"TicketStatus")) %>'
                                        Width="147px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TableTitle" style="width: 107px">
                                    &nbsp;Type</td>
                                <td class="TableGrid" style="width: 39px">
                                    <asp:Label ID="lblType" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"Type")) %>'
                                        Width="131px"></asp:Label></td>
 
                                <td class="TableTitle" style="width: 132px">
                                    &nbsp;Priority</td>
                                <td class="TableGrid" style="width: 100px">
                                    <asp:Label ID="lblPriority" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"Priority")) %>'
                                        Width="147px"></asp:Label></td>
                            </tr>

                             <tr>
                                <td class="TableTitle" style="width: 107px">
                                    &nbsp;Problem Type</td>
                                <td class="TableGrid" style="width: 39px">
                                    <asp:Label ID="lblProblemType" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"ProblemTypeName")) %>'
                                        Width="131px"></asp:Label></td>
 
                                <td class="TableTitle" style="width: 132px">
                                    &nbsp;Problem Details</td>
                                <td class="TableGrid" style="width: 100px">
                                    <asp:Label ID="lblProblemDetails" runat="server" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"ProblemDetailsName")) %>'
                                        Width="147px"></asp:Label></td>
                            </tr>
 
                            <tr>
                                <td class="TableTitle" style="width: 107px">
                                    &nbsp;Update Remark</td>
                                <td class="TableGrid" colspan="3">
                                    <asp:Label ID="lblUpdateRemark" runat="server" Height="53px" SkinID="LabelSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"Remark")) %>'
                                        Width="429px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="4" style="border-bottom: darkred thin dashed">
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemStyle BackColor="White" />
                </asp:DataList>
               


                     </td>                   
                


                
            <td style="width: 112px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 28px">
            </td>
            <td class="TableTitle" style="width: 191px; height: 28px">
                &nbsp;Assigned To</td>
            <td class="TableGrid" style="width: 39px; height: 28px">
                <asp:DropDownList ID="ddlAssignedTo" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 132px; height: 28px;" class="TableTitle">
                &nbsp;Ticket Status</td>
            <td style="width: 100px; height: 28px;" class="TableGrid">
                <asp:DropDownList ID="ddlTicketStatus" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Open</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                      <asp:ListItem>Hold</asp:ListItem>
                    <asp:ListItem>Close</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 112px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 28px">
            </td>
            <td class="TableTitle" style="width: 191px; height: 28px">
                &nbsp;Type
            </td>
            <td class="TableGrid" style="width: 39px; height: 28px">
                <asp:DropDownList ID="ddlTicketType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Incident</asp:ListItem>
                    <asp:ListItem>Problem</asp:ListItem>
                    <asp:ListItem>New Request</asp:ListItem>
                    <asp:ListItem>Root Cause</asp:ListItem>
                </asp:DropDownList></td>

<%--changed by sanket--%><%--changes end by sanket--%>
            <td style="width: 132px" class="TableTitle">&nbsp;Priority</td>
            <td style="width: 135px; height: 24px;" class="TableGrid">
                <asp:DropDownList ID="ddlPriority" runat="server"
                    SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Very High</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                   
                </asp:DropDownList></td>

   <%--changed by sanket--%>

            <td style="width: 112px; height: 28px">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
        </tr>

        <%--change by Rutu start--%>
        <tr>
            <td style="width: 20px; height: 28px">
            </td>
            <td class="TableTitle" style="width: 135px; height: 28px">
                &nbsp;Problem Type
            </td>
            <td class="TableGrid" style="width: 39px; height: 28px">
                <asp:UpdatePanel ID="UP_ddlProblemType" runat="server">
               <ContentTemplate>
                        <asp:DropDownList ID="ddlProblemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProblemType_SelectedIndexChanged" SkinID="ddlSkin">
                    </asp:DropDownList>
                    </ContentTemplate>
                     </asp:UpdatePanel>
                
            </td>


            <td style="width: 132px" class="TableTitle">&nbsp;Problem Detail</td>
            <td style="width: 135px; height: 24px;" class="TableGrid">
               <asp:UpdatePanel ID="UP_ddlProblemDetails" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlProblemDetails" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </td>

            <td style="width: 112px; height: 28px">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
            <td style="width: 100px; height: 28px">
            </td>
        </tr>
        <%--change by Rutu end--%>

        <tr>
            <td style="width: 20px">
            </td>
            <td class="TableTitle" style="width: 191px">
                &nbsp;Update Remark</td>
            <td class="TableGrid" colspan="3">
                <asp:TextBox ID="txtUpdateRemark" runat="server" Height="53px" MaxLength="200" SkinID="txtSkin"
                    TextMode="MultiLine" Width="425px"></asp:TextBox></td>
            <td style="width: 112px">
                
                <br />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="9" style="height: 32px">
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" OnClick="btnSave_Click"
                    Text="Update Status" Width="111px" />&nbsp;<asp:Button ID="btnClose" runat="server" BorderWidth="1px"
                        Text="Close" Width="69px" OnClick="btnClose_Click" />&nbsp;
                &nbsp;<asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 191px">
            </td>
            <td style="width: 39px">
            </td>
            <td style="width: 132px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

