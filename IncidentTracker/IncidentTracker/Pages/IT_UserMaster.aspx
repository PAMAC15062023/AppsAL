<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/IncidentTracker.Master" AutoEventWireup="true" CodeBehind="IT_UserMaster.aspx.cs" Inherits="IncidentTracker.Pages.IT_UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        function Validate_Save() {
            var ReturnValue = true;
            var ErrorMessage = '';
            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtUserID = document.getElementById("<%=txtUserID.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtPassword = document.getElementById("<%=txtPassword.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var ddlUserGroupList = document.getElementById("<%=ddlUserGroupList.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblWait = document.getElementById("<%=lblWait.ClientID%>");
            var imgLoading = document.getElementById('imgLoading');


            if (txtUserName.value == '') {
                ErrorMessage = 'USER Name Cannot be left Blank!';
                ReturnValue = false;
            }
            if (txtUserID.value == '') {
                ErrorMessage = 'USER ID Cannot be left Blank!';
                ReturnValue = false;
            }
            if (txtPassword.value == '') {
                ErrorMessage = 'Password Cannot be left Blank!';
                ReturnValue = false;
            }
            if (ddlBranchList.selectedIndex == 0) {
                ErrorMessage = 'Please select Branch to Contine...!';
                ReturnValue = false;
            }
            if (ddlIsActivate.selectedIndex == 0) {
                ErrorMessage = 'Please select Activate Status to Contine...!';
                ReturnValue = false;
            }
            if (ddlUserGroupList.selectedIndex == 0) {
                ErrorMessage = 'Please select UserGroup to Contine...!';
                ReturnValue = false;
            }
            if (ddlReportingManager.selectedIndex == 0) {
                ErrorMessage = 'Please select Reporting Manager to Contine...!';
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
            var txtUserID = document.getElementById("<%=txtUserID.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtPassword = document.getElementById("<%=txtPassword.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var ddlUserGroupList = document.getElementById("<%=ddlUserGroupList.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>"); /*add on 24/01/2025*/
            txtUserName.value = '';
            txtUserID.value = '';
            txtPassword.value = '';
            ddlBranchList.selectedIndex = 0;
            ddlIsActivate.selectedIndex = 0;
            ddlUserGroupList.selectedIndex = 0;
            ddlReportingManager.selectedIndex = 0;  /*add on 24/01/2025*/
            return false;
        }


        function hover(value, rowno) {
            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var txtUserID = document.getElementById("<%=txtUserID.ClientID%>");

            rowno = (parseInt(rowno) + 1);

            if (value == 'in') {
                if (txtUserID.value != grv_GroupInfo.rows[rowno].cells[0].innerText) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "#ffff33";
                }
            }
            else {
                if (txtUserID.value != grv_GroupInfo.rows[rowno].cells[0].innerText) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "white";
                }
            }

        }


        function Pro_SelectRow(rowno, id) {
            //alert(rowno);
            debugger;
            rowno = (parseInt(rowno) + 1);
            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtUserID = document.getElementById("<%=txtUserID.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var ddlUserGroupList = document.getElementById("<%=ddlUserGroupList.ClientID%>");
            var ddlProduct = document.getElementById("<%=ddlProduct.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>"); /*add on 24/01/2025*/
            //-/-if(rowno != null)

            //{  
            txtUserName.value = grv_GroupInfo.rows[rowno].cells[0].innerText;
            txtUserID.value = grv_GroupInfo.rows[rowno].cells[2].innerText;
            txtEmail.value = grv_GroupInfo.rows[rowno].cells[1].innerText;
            ddlBranchList.value = grv_GroupInfo.rows[rowno].cells[7].innerText;
            ddlUserGroupList.value = grv_GroupInfo.rows[rowno].cells[8].innerText;
            ddlIsActivate.value = grv_GroupInfo.rows[rowno].cells[5].innerText;
            ddlProduct.value = grv_GroupInfo.rows[rowno].cells[6].innerText;
            grv_GroupInfo.rows[rowno].style.backgroundColor = "DarkGray"; //"#E0E0E0";
            ddlReportingManager.value = grv_GroupInfo.rows[rowno].cells[10].innerText  /*add on 24/01/2025*/
            //ddlProduct.value = grv_GroupInfo.rows[rowno].cells[].innerText;
            //ddlProduct.value=grv_GroupInfo.row[rowno].cells[8].innerText;            
            //}

        }

    </script>

    <style type="text/css">
        .TableTitle {
            font-size: 11pt;
            color: #333333d6;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            border-right: #660000 1px solid;
            border-top: #660000 1px solid;
            border-left: #660000 1px solid;
            border-bottom: #660000 1px solid;
            white-space: no-wrap;
            border-color: #808080;
        }
    </style>
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
            <td class="TableTitle" style="width: 162px">&nbsp;User Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtUserName" runat="server" BorderWidth="1px" MaxLength="50" ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;User ID</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtUserID" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="50"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:LinkButton ID="lnkUserCheck" runat="server">UserID Status</asp:LinkButton></td>
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
            <td class="TableTitle" style="width: 162px">&nbsp;Branch Mapping </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlBranchList" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; height: 22px;">&nbsp;Is Active</td>
            <td style="width: 100px; height: 22px;">
                <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;"></td>
            <td style="width: 100px; height: 22px;"></td>
            <td style="width: 100px; height: 22px;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Role ID</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlUserGroupList" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px; text-align: right;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; height: 26px">&nbsp;<asp:Label ID="lblProduct" runat="server" Text="Product"></asp:Label></td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                    <asp:ListItem Text="--Select--"></asp:ListItem>
                    <asp:ListItem Text="SELF EMPLOYED PROFESSIONAL LOAN"></asp:ListItem>
                    <asp:ListItem Text="BUSINESS LOAN"></asp:ListItem>
                    <asp:ListItem Text="PERSONAL LOAN"></asp:ListItem>
                    <asp:ListItem Text="AL"></asp:ListItem>
                    <asp:ListItem Text="HL"></asp:ListItem>
                    <asp:ListItem Text="PL"></asp:ListItem>
                    <asp:ListItem Text="TWL"></asp:ListItem>
                    <asp:ListItem Text="Credit"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <%--add on 24/01/2025--%>
            <td class="TableTitle" style="width: 162px; height: 26px">&nbsp;<asp:Label ID="lblReportingManager" runat="server" Text="Reporting Manager"></asp:Label></td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlReportingManager" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="TableHeader" colspan="5">&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save"
                ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click"
                    ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="False" OnClick="btnCancel_Click" />&nbsp;
                <asp:Label ID="lblWait" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="8pt"></asp:Label>
                <img src="Images/loading35.gif" style="visibility: hidden" id="imgLoading" /></td>
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
                <asp:GridView ID="grv_GroupInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="grv_GroupInfo_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email Id" />
                        <asp:BoundField DataField="UserId" HeaderText="User Id" />
                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                        <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                        <asp:BoundField DataField="Is_Active" HeaderText="Is Active" />
                        <asp:BoundField DataField="Product" HeaderText="Product" />
                        <asp:BoundField DataField="BranchId" HeaderText="BranchId" />
                        <asp:BoundField DataField="RoleID" HeaderText="RoleID" />
                        <asp:BoundField DataField="RM" HeaderText="RM Name" />
                        <%--add on 24/01/2025--%>
                        <asp:BoundField DataField="ReportingManager" HeaderText="RM ID" />
                        <%--add on 24/01/2025--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
