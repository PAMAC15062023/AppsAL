
<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="TicketAssignment.aspx.cs" Inherits="Pages_Helpdesk_TicketAssignment" Title="Ticket Assigments" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">     
    </script>
 <script language="javascript" type="text/javascript">             
    </script>   
    <table style="width: 903px">
        <tr>
            <td id="TD5" runat="server" colspan="11" style="height: 18px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td runat="server" class="TableHeader" colspan="11">
                &nbsp;Requested Ticket Assignment</td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td class="TableTitle">
                &nbsp;Ticket No</td>
            <td class="TableGrid">
                <asp:TextBox ID="txtTicketNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;Department</td>
            <td class="TableGrid">
                <asp:TextBox ID="txtDepartment" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <%--Changed by sanket--%>
<%--            <td class="TableTitle">
                &nbsp;Priority
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlPriority" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Very High</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                </asp:DropDownList></td>
--%>            <td class="TableTitle">
                &nbsp;Request By</td>
            <td class="TableGrid">
                <asp:TextBox ID="txtRequestBy" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
 
<%--Changed by sanket--%>
 
           <td class="TableTitle"></td>
           <td class="TableTitle"></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td class="TableTitle">
                &nbsp;Branch</td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle">
                &nbsp;Vender Name</td>
            <td class="TableGrid"><asp:DropDownList ID="ddlProblemTypeList" runat="server" SkinID="ddlSkin" AutoPostBack="True" OnSelectedIndexChanged="ddlProblemTypeList_SelectedIndexChanged">
            </asp:DropDownList></td>
            <td class="TableTitle">
        Vender problem&nbsp; type</td>
            <td class="TableGrid"><asp:DropDownList ID="ddlProblemDetailList" runat="server" 
                    SkinID="ddlSkin" AutoPostBack="True"
                    onselectedindexchanged="ddlProblemDetailList_SelectedIndexChanged1">
            </asp:DropDownList></td>
            <td class="TableTitle">
                Vender sevices</td>
            <td class="TableGrid">
               
                <br />
                
                <asp:DropDownList ID="ddlvender_provider" runat="server">
                </asp:DropDownList>
              
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 36px;">
            </td>
            <td class="TableTitle">
                &nbsp;RequestFrom</td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtRequestFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;Request DateTo
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtRequestToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;Ticket Status</td>
            <td class="TableGrid"><asp:DropDownList ID="ddlTicketStatus" runat="server" SkinID="ddlSkin">
                <asp:ListItem>Open</asp:ListItem>
                <asp:ListItem>Pending</asp:ListItem>
                <asp:ListItem>Close</asp:ListItem>
            </asp:DropDownList></td>
            <td class="TableTitle">
                &nbsp;</td>
            <td class="TableGrid">&nbsp;</td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 34px;" class="TableTitle" colspan="11">
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Text="Search" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnReset" runat="server" BorderWidth="1px" Text="Reset" 
                    Width="53px"   />
                <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" OnClick="btnCancel_Click"
                    Text="Cancel" Width="64px" />
                <asp:Button ID="btnExport" runat="server" BorderWidth="1px" OnClick="btnExport_Click"
                    Text="Export" Width="65px" /></td>
        </tr>
        <tr>
            <td style="height: 16px;" class="TableHeader" colspan="11">
                &nbsp;&nbsp; Requested Ticket Search Details</td>
        </tr>
        <tr>
            <td colspan="9" style="height: 15px">
                <div style="overflow: scroll; width: 887px; height: 217px">
                 
                    <asp:GridView ID="grv_TicketList" runat="server" AutoGenerateColumns="False" 
                        OnRowDataBound="grv_TicketList_RowDataBound" Font-Overline="False" 
                        Font-Size="7.5pt" CssClass="mGrid" >
                        <Columns>
                            <asp:TemplateField HeaderText="TicketNo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TicketNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTicketNo" runat="server" OnClick="lnkTicketNo_Click" Text='<%# (DataBinder.Eval(Container.DataItem,"TicketNo")) %>' Width="170px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" />--%>
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                            <asp:BoundField DataField="vender_name" HeaderText="vender name" />
                         <asp:BoundField DataField="vender_prob_provider" HeaderText="vender problem provider" />
                         <asp:BoundField DataField="vender_services" HeaderText="vender services" />
                            <%--<asp:BoundField DataField="ProblemTypeName" HeaderText="ProblemType" />
                            <asp:BoundField DataField="ProblemDetailsName" HeaderText="ProblemDetails" />--%>
<%--                            <asp:BoundField DataField="Priority" HeaderText="Priority" />
--%>                            <asp:TemplateField HeaderText="Remark">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>' ToolTip='<%# Bind("RemarkComplate") %>' Width="189px"></asp:Label><br />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" />
                            <asp:BoundField DataField="TicketStatus" HeaderText="TicketStatus" />
                            <asp:BoundField DataField="TicketCloseDate" HeaderText="TicketCloseDate" />
                            <%--<asp:BoundField DataField="TAT" HeaderText="TAT(Hours) " />
                            <asp:BoundField DataField="TAT remark" HeaderText="TAT remark" />--%>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                        <tr>
                                            <td style="width: 100px">
                                                <img alt="Down" src="../../Pages/Calculus/Images/donload.JPG" /></td>
                                            <td style="width: 100px">
                                                <asp:LinkButton ID="lnkDownloadFile" runat="server" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"DownloadFilePath"))%>'
                                                    OnClick="lnkDownloadFile_Click" ToolTip="Click to Download Attach Documents">Download</asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                </div>
                </td>
                </tr>
                <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td style="height: 200px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                            <asp:BoundField DataField="TicketNo" HeaderText="TicketNo" />                           
                            <%--<asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" />--%>
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                           <%-- <asp:BoundField DataField="ProblemTypeName" HeaderText="ProblemType" />
                            <asp:BoundField DataField="ProblemDetailsName" HeaderText="ProblemDetails" />--%>
<%--                            <asp:BoundField DataField="Priority" HeaderText="Priority" />

3 feild added by suraksha (vender_name,vender_prob_provider,vender_services
--%> 


                                 <asp:BoundField DataField="vender_name" HeaderText="vender name" />
                         <asp:BoundField DataField="vender_prob_provider" HeaderText="vender problem provider" />
                         <asp:BoundField DataField="vender_services" HeaderText="vender services" />

                           <asp:BoundField DataField="RemarkComplate" HeaderText="Remark" />
                          <%--  <asp:BoundField DataField="UpdateRemark" HeaderText="UpdateRemark" />--%>
                            <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" />
                            <asp:BoundField DataField="TicketStatus" HeaderText="TicketStatus" />
                            <asp:BoundField DataField="TicketCloseDate" HeaderText="TicketCloseDate" />
                      </Columns>   
                </asp:GridView>
                </td>
                     </tr>
                            
                    </table>
           
       
        <tr>
            <td style="width: 13px">
            </td>
            <td style="width: 2065px">
            </td>
            <td>
            </td>
            <td style="width: 904px">
            </td>
            <td style="width: 233px">
            </td>
            <td style="width: 1447px">
            </td>
            <td style="width: 401px">
            </td>
            <td style="width: 6684px">
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

