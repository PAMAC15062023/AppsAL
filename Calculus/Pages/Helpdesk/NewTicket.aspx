<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="NewTicket.aspx.cs" Inherits="Pages_Helpdesk_NewTicket" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function validate_finalsave() {
            var ReturnValue = true;
            var ErrorMessage = "";

            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var ddlDepartment = document.getElementById("<%=ddlDepartment.ClientID%>");
            var ddlProblemType = document.getElementById("<%=ddlProblemType.ClientID%>");
            var ddlProblemDetails = document.getElementById("<%=ddlProblemDetails.ClientID%>");
            var txtUsermailId = document.getElementById("<%=txtUsermailId.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");


            if (ddlProblemDetails.selectedIndex == 0) {
                ErrorMessage = "Please select Problem Detail to continue...!";
                ReturnValue = false;
                ddlProblemDetails.focus();
            }
            if (ddlProblemType.selectedIndex == 0) {
                ErrorMessage = "Please select Problem Type to continue...!";
                ReturnValue = false;
                ddlProblemType.focus();
            }

            if (ddlDepartment.selectedIndex == 0) {
                ErrorMessage = "Please select Department to continue...!";
                ReturnValue = false;
                ddlDepartment.focus();
            }

            if (txtUserName.value == '') {
                ErrorMessage = "Please Enter User Name to Continue!";
                ReturnValue = false;
                txtUserName.focus();
            }
            if (txtUsermailId.value == '') {  //add on 07/05/2024
                ErrorMessage = "Please Enter Mail Id to Continue!";
                ReturnValue = false;
                txtUsermailId.focus();
            }
            window.scroll(0, 0);
            lblMessage.innerText = ErrorMessage;
            return ReturnValue;
        }

        function CheckSingleCheckbox(ob) {   /*add on 17/01/24*/
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
        
    </script>
    <table>
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <tr>
            <td colspan="10">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
                <asp:Label ID="lblMessage2" runat="server" CssClass="ErrorMessage"></asp:Label><br /> <%--//add on 23/01/24--%>
                &nbsp;<marquee><SPAN>&nbsp;<asp:Label id="Label1" runat="server" ForeColor="Red" Text="[Please Software related  ticket to be generated in (WWW.Pamaconline.com) link]" Font-Names="Verdana" Font-Size="7pt" __designer:wfdid="w1"></asp:Label></SPAN></marquee>
            </td>
            
        </tr>
        <tr>
            <td class="TableHeader" colspan="10">&nbsp;Generate Ticket Request</td>
        </tr>
        <tr>
            <td style="width: 12px"></td>
            <td class="TableTitle" style="width: 100px">&nbsp;Ticket No</td>
            <td choff="TableGrid" class="TableGrid" colspan="3">
                <asp:Label ID="lblTicketNo" runat="server" Width="250px"></asp:Label></td>
            <td choff="TableGrid" class="TableGrid" colspan="2">User Mail ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtUsermailId" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td choff="TableGrid" class="TableGrid" colspan="2">&nbsp;</td>
            <td style="width: 244px">
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 12px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;User Name</td>
            <td style="width: 100px" choff="TableGrid" class="TableGrid">
                <asp:TextBox ID="txtUserName" runat="server" SkinID="txtSkin" ReadOnly="true"></asp:TextBox></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Department</td>
            <td style="width: 100px" class="TableGrid" colspan="2">
                <asp:DropDownList ID="ddlDepartment" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>PCPA</asp:ListItem>
                    <asp:ListItem>PCPV</asp:ListItem>
                    <asp:ListItem>PTPU</asp:ListItem>
                    <asp:ListItem>PDCR</asp:ListItem>
                    <asp:ListItem>PFRC</asp:ListItem>
                    <asp:ListItem>PRSP</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>EDP</asp:ListItem>
                    <asp:ListItem>SSU</asp:ListItem>
                    <asp:ListItem>Account</asp:ListItem>
                    <asp:ListItem>HR</asp:ListItem>
                    <asp:ListItem>EBC</asp:ListItem>
                    <asp:ListItem>JSF</asp:ListItem>
                    <asp:ListItem>ISO Audit & BPR</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <%--changes done by Sanket--%><%--<td style="width: 80px" class="TableTitle">
                &nbsp;Ticket Type</td>
            <td style="width: 135px" class="TableGrid">
                <asp:DropDownList ID="ddlTicketType" runat="server"
                    SkinID="ddlSkin" Visible="False">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Incident</asp:ListItem>
                <asp:ListItem>Problem</asp:ListItem>
                <asp:ListItem>New Request</asp:ListItem>
                <asp:ListItem>Root Cause</asp:ListItem>
            </asp:DropDownList></td>--%><td style="width: 100px" class="TableGrid"
                colspan="2">&nbsp;</td>
            <td style="width: 100px" class="TableGrid">&nbsp;</td>
            <td style="width: 244px"></td>
        </tr>
        <tr>
            <td style="width: 12px; height: 24px;"></td>
            <td style="width: 100px; height: 24px;" class="TableTitle">&nbsp;Problem Type</td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:UpdatePanel ID="UP_ddlProblemType" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddlProblemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProblemType_SelectedIndexChanged"
                        SkinID="ddlSkin">
                    </asp:DropDownList>
                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlProblemType" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>

            <td style="width: 100px; height: 24px;" class="TableTitle">&nbsp;Problem Detail</td>
            <td style="width: 100px; height: 24px;" class="TableGrid" colspan="2">
                <asp:UpdatePanel ID="UP_ddlProblemDetails" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlProblemDetails" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            <%--changes done by Sanket--%><%--<td class="TableTitle" style="width: 80px; height: 24px">
                &nbsp;Priority 
            </td>
            <td style="width: 135px; height: 24px;" class="TableGrid">
                <asp:DropDownList ID="ddlPriority" runat="server"
                    SkinID="ddlSkin" Visible="False">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Very High</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                </asp:DropDownList></td>--%><%--<td style="width: 244px; height: 24px">
            </td>--%>
            <td style="width: 100px" class="TableGrid" colspan="2"></td>
            <td style="width: 100px" class="TableGrid"></td>
        </tr>
        <tr>
            <td style="width: 12px; height: 26px;"></td>
            <td style="width: 100px; height: 26px;" class="TableTitle">&nbsp;Remark</td>
            <td style="height: 26px;" class="TableGrid" colspan="7">
                <asp:TextBox ID="txtRemark" runat="server" Height="45px" MaxLength="200" SkinID="txtSkin"
                    TextMode="MultiLine" Width="568px"></asp:TextBox></td>
            <td style="width: 244px; height: 26px"></td>
        </tr>
        <tr>
            <td style="width: 12px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Attachment</td>
            <td class="TableGrid" colspan="7">
                <asp:FileUpload ID="FileUpload1" runat="server" BorderWidth="1px" Width="555px" /></td>
            <td style="width: 244px"></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="10" style="height: 31px">&nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" OnClick="btnSave_Click"
                    Text="Save" Width="73px" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" BorderWidth="1px"
                    OnClick="btnCancel_Click" Text="Cancel" Width="73px" />&nbsp;
                <asp:Button ID="btnexport" runat="server" BorderWidth="1px"
                    Text="Export" Width="73px" OnClick="btnexport_Click" /></td>
        </tr>
        <%--changed by sanket--%><tr>
            <td style="height: 16px;" class="TableHeader" colspan="10">&nbsp;&nbsp; Ticket Details</td>
        </tr>
        <tr>
            <td style="width: 12px"></td>
            <td colspan="9">
                <asp:GridView ID="grvUserFill" runat="server" AutoGenerateColumns="False"
                    Width="1105px" DataKeyNames="TicketNo,UserRemark">
                    <Columns>
                        <asp:BoundField DataField="TicketNo" HeaderText="Ticket No" />
                        <asp:BoundField DataField="AssignedTo" HeaderText="Assigned To" />
                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:BoundField DataField="Department" HeaderText="Department" />
                        <asp:BoundField DataField="Priority" HeaderText="Priority" />
                        <asp:BoundField DataField="Remark" HeaderText="User Remark" />
                        <asp:BoundField DataField="UpdateRemark" HeaderText="Supervisor Remark" />
                        <asp:BoundField DataField="RequestDate" HeaderText="Request Date" />
                        <asp:BoundField DataField="TicketStatus" HeaderText="Ticket Status" />
                        <asp:BoundField DataField="TicketCloseDate" HeaderText="Close Date" />
                       
                         <asp:TemplateField HeaderText="Remark" runat="server">  <%--add on 17/01/24--%>
                            <ItemTemplate runat="server">
                               <%--<asp:TextBox ID="UserRemark" runat="server"></asp:TextBox>--%>
                                 <asp:TextBox ID="UserRemark" runat="server" Text='<%# Eval("UserRemark") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                       <%-- <asp:TemplateField ShowHeader="False">  <%--add on 17/01/24
                            <ItemTemplate>
                                <asp:Button ID="btnApprove" runat="server" CausesValidation="false" CommandName="Approve"
                                    Text="Approve" PostBackUrl="NewTicket.aspx" OnClick="btnApprove_Click" />  <%--CommandArgument='<%# Eval("id") %>'
                            </ItemTemplate>
                        </asp:TemplateField>
                           
                           
                           
                           <asp:TemplateField ShowHeader="False">  <%--add on 17/01/24-
                            <ItemTemplate>
                                <asp:Button ID="btnReject" runat="server" CausesValidation="false" CommandName="Reject"
                                    Text="Reject" PostBackUrl="NewTicket.aspx" OnClick="btnReject_Click"/>  <%--CommandArgument='<%# Eval("id") %>'
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                         <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkbox" runat="server" onclick="CheckSingleCheckbox(this)" />
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Approve" runat="server" OnClick="Approve_Click" >Approve</asp:LinkButton>  <%--Visible = '<%#GetVisible(Eval("Approve").ToString())%>'--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Reject" runat="server" OnClick="Reject_Click">Reject</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                        
                       
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnID" runat="server" />  <%--add on 17/01/24--%>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:HiddenField ID="hdnUserName" runat="server" />
</asp:Content>

