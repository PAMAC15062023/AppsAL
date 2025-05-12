<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="UserMaster.aspx.cs" Inherits="CoreDailyMISAutomation.UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        function Validate_Save() {
            var ReturnValue = true;
            var ErrorMessage = '';
            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtUserId = document.getElementById("<%=txtUserId.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtPassword = document.getElementById("<%=txtPassword.ClientID%>");
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var ddlCPC = document.getElementById("<%=ddlCPC.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblWait = document.getElementById("<%=lblWait.ClientID%>");
            var imgLoading = document.getElementById('imgLoading');

            if (txtUserName.value == '') {
                ErrorMessage = 'USER Name Cannot be left Blank!';
                ReturnValue = false;
            }
            if (txtUserId.value == '') {
                ErrorMessage = 'Login Name Cannot be left Blank!';
                ReturnValue = false;
            }

            //var p = /[a-zA-Z]{1}[0-9]{6}$/;


            //if (!p.test(txtLoginName.value)) {
            //    ErrorMessage = 'Invalid Employee Code!';
            //    ReturnValue = false;
            //}



            if (txtPassword.value == '') {
                ErrorMessage = 'Password Cannot be left Blank!';
                ReturnValue = false;
            }
            if (ddlRoleId.selectedIndex == 0) {
                ErrorMessage = 'Please select RoleId  to Contine...!';
                ReturnValue = false;
            }
            if (ddlIsActivate.selectedIndex == 0) {
                ErrorMessage = 'Please select Activate Status to Contine...!';
                ReturnValue = false;
            }
            if (ddlCPC.selectedIndex == 0) {
                ErrorMessage = 'Please select  CPC to Contine...!';
                ReturnValue = false;
            }

            if (txtVertical.value == 0) {
                ErrorMessage = 'Please select  Vertical to Contine...!';
                ReturnValue = false;
            }


            lblMessage.innerText = ErrorMessage;
            if (ReturnValue == true) {
                lblWait.innerText = 'Please wait......';
                imgLoading.style.visibility = 'visible';
            }


            return ReturnValue;

        }

        function Validate_AddNEW() {

            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtUserId = document.getElementById("<%=txtUserId.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtPassword = document.getElementById("<%=txtPassword.ClientID%>");
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var ddlCPC = document.getElementById("<%=ddlCPC.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>"); /*add on 25/01/2025*/

            txtUserName.value = '';
            txtUserId.value = '';
            txtPassword.value = '';
            ddlRoleId.selectedIndex = 0;
            ddlIsActivate.selectedIndex = 0;
            ddlCPC.selectedIndex = 0;
            txtVertical.value = 0;
            txtEmail.value = '';
            ddlReportingManager.selectedIndex = 0;  /*add on 25/01/2025*/
            return false;
        }


        function hover(value, rowno) {
            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var txtUserId = document.getElementById("<%=txtUserId.ClientID%>");

            rowno = (parseInt(rowno) + 1);

            if (value == 'in') {
                if (txtUserId.value != grv_GroupInfo.rows[rowno].cells[0].innerText) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "#ffff33";
                }
            }
            else {
                if (txtUserId.value != grv_GroupInfo.rows[rowno].cells[0].innerText) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "white";
                }
            }

        }


        function Pro_SelectRow(rowno, id) {
            //alert(rowno);
            debugger;
            rowno = (parseInt(rowno) + 1);
            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtUserId = document.getElementById("<%=txtUserId.ClientID%>");
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var ddlCPC = document.getElementById("<%=ddlCPC.ClientID%>");
            //var hdnUserId = document.getElementById("<%=hdnId.ClientID%>");
            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>"); /*add on 25/01/2025*/

            //-/-if(rowno != null)

            //{  
            txtUserName.value = grv_GroupInfo.rows[rowno].cells[0].innerText;
            txtUserId.value = grv_GroupInfo.rows[rowno].cells[1].innerText;
            ddlRoleId.value = grv_GroupInfo.rows[rowno].cells[2].innerText;
            txtEmail.value = grv_GroupInfo.rows[rowno].cells[3].innerText;
            ddlIsActivate.value = grv_GroupInfo.rows[rowno].cells[4].innerText;
            ddlCPC.value = grv_GroupInfo.rows[rowno].cells[5].innerText;
            //txtVertical.value = grv_GroupInfo.rows[rowno].cells[6].innerText;
            //hdnUserId.value = grv_GroupInfo.rows[rowno].cells[7].innerText;
            ddlReportingManager.value = grv_GroupInfo.rows[rowno].cells[7].innerText; /*add on 25/01/2025*/
            ddlUserGroupList.value = grv_GroupInfo.rows[rowno].cells[8].innerText;
             
            grv_GroupInfo.rows[rowno].style.backgroundColor = "DarkGray";
        }
    </script>

    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;User Master</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Employee Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtUserName" runat="server" BorderWidth="1px" MaxLength="50" ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Employee Code</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtUserId" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="10"></asp:TextBox></td>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Employee Code Like [A123456]"
                ControlToValidate="txtLoginName" ValidationExpression='^[a-zA-Z]{1}[0-9]{6}$' ValidationGroup="valid" ForeColor="Red"></asp:RegularExpressionValidator>--%>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Email Id</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtEmail" runat="server" BorderWidth="1px" MaxLength="50" ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; height: 26px">&nbsp;Password</td>
            <td style="width: 100px; height: 26px">
                <asp:TextBox ID="txtPassword" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="100" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
                <asp:LinkButton ID="lnkAutoGenetae" runat="server" ToolTip="Click to Auto Generate" OnClick="lnkAutoGenetae_Click"> Auto Generate</asp:LinkButton></td>
            <td style="width: 100px; height: 26px"></td>
            <td style="width: 100px; height: 26px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;CPC</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlCPC" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>

            <asp:RequiredFieldValidator ID="rfvddlCPC" runat="server" ControlToValidate="ddlCPC" InitialValue="Please select" ErrorMessage="Please select something" />

        </tr>

       <%-- <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Vertical</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtVertical" runat="server" Text="CPA" Enabled="false" BorderWidth="1px" MaxLength="50" ValidationGroup="BranchENtry"></asp:TextBox>
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVertical" InitialValue="Please select" ErrorMessage="Please select something" />

        </tr>--%>
        <tr>
            <td class="TableTitle" style="width: 162px; height: 22px;">&nbsp;Is Active</td>
            <td style="width: 100px; height: 22px;">
                <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;"></td>
            <td style="width: 100px; height: 22px;"></td>
            <td style="width: 100px; height: 22px;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Role</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlRoleId" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr> <%--add on 25/01/2025--%>
            <td class="TableTitle" style="width: 162px">&nbsp;Reporting Manager</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlReportingManager" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save"
                ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="False" OnClick="btnCancel_Click" />&nbsp;
                <asp:Label ID="lblWait" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="8pt"></asp:Label>
                <%--<img src="Images/loading35.gif" style="visibility: hidden" id="imgLoading" />--%> </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;<strong>Search UserId</strong></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtSearchUserID" runat="server" BorderWidth="1px" MaxLength="50"
                    ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:Button ID="btnGo" runat="server" BorderWidth="1px" Text="Search" Width="67px" Font-Bold="True" OnClick="btnGo_Click" /></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:HiddenField runat="server" ID="hdnId" Value="0" />
                <asp:GridView ID="grv_GroupInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="grv_GroupInfo_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="USERNAME" HeaderText="User Name" />
                        <asp:BoundField DataField="UserId" HeaderText="User ID" />
                        <asp:BoundField DataField="RoleId" HeaderText="Role ID" />
                        <asp:BoundField DataField="Email" HeaderText="Email ID" />
                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                        <asp:BoundField DataField="CPC" HeaderText="Branch" />
                        <asp:BoundField DataField="RM" HeaderText="RM Name"/> <%--add on 25/01/2025--%>
                        <asp:BoundField DataField="ReportingManager" HeaderText="RM ID"/> <%--add on 25/01/2025--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
