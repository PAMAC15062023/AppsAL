<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LNT_CommonMaster.Master" AutoEventWireup="true" CodeBehind="LNT_UserMaster.aspx.cs" Inherits="LNTFinance.Pages.LNT_UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        function Validate_Save() {
            var ErrorMessage = '';
            var ReturnValue = true;
            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtLoginName = document.getElementById("<%=txtLoginName.ClientID%>");
            var txtPassword = document.getElementById("<%=txtPassword.ClientID%>");
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblWait = document.getElementById("<%=lblWait.ClientID%>");
            var imgLoading = document.getElementById('imgLoading');

            if (txtUserName.value == '') {
                ErrorMessage = 'Employee Name Cannot be left Blank!';
                ReturnValue = false;
            }
            if (txtLoginName.value == '') {
                ErrorMessage = 'Employee Code Cannot be left Blank!';
                ReturnValue = false;
            }

            //var p = /[a-zA-Z]{1}[0-9]{7}$/;


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
            var txtLoginName = document.getElementById("<%=txtLoginName.ClientID%>");
            var txtPassword = document.getElementById("<%=txtPassword.ClientID%>");
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>");
            txtUserName.value = '';
            txtLoginName.value = '';
            txtPassword.value = '';
            ddlRoleId.selectedIndex = 0;
            ddlIsActivate.selectedIndex = 0;
            ddlReportingManager.selectedIndex = 0;
            return false;
        }


        function hover(value, rowno) {
            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var txtLoginName = document.getElementById("<%=txtLoginName.ClientID%>");

            rowno = (parseInt(rowno) + 1);

            if (value == 'in') {
                if (txtLoginName.value != grv_GroupInfo.rows[rowno].cells[0].innerText) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "#ffff33";
                }
            }
            else {
                if (txtLoginName.value != grv_GroupInfo.rows[rowno].cells[0].innerText) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "white";
                }
            }

        }


        function Pro_SelectRow(rowno, id) {
            //alert(rowno);
            debugger;
            rowno = (parseInt(rowno) + 1);
            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtLoginName = document.getElementById("<%=txtLoginName.ClientID%>");
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            var hdnUserId = document.getElementById("<%=hdnUserId.ClientID%>");
            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>");

            //-/-if(rowno != null)

            //{  
            txtUserName.value = grv_GroupInfo.rows[rowno].cells[0].innerText;
            txtLoginName.value = grv_GroupInfo.rows[rowno].cells[1].innerText;
            ddlRoleId.value = grv_GroupInfo.rows[rowno].cells[2].innerText;
            ddlIsActivate.value = grv_GroupInfo.rows[rowno].cells[3].innerText;

            hdnUserId.value = grv_GroupInfo.rows[rowno].cells[4].innerText;
            ddlReportingManager.value = grv_GroupInfo.rows[rowno].cells[6].innerText

        }
    </script> 


    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5" style="width: 162px; font-size:medium">&nbsp;User Master</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; font-size:small">&nbsp;Employee Code</td>
            <td style="width: 100px" class="TableTitle">
                <asp:TextBox ID="txtLoginName" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="7" OnTextChanged="txtLoginName_TextChanged" AutoPostBack="true"></asp:TextBox></td>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; font-size:small">&nbsp;Employee Name</td>
            <td style="width: 100px" class="TableTitle">
                <asp:TextBox ID="txtUserName" runat="server" BorderWidth="1px" MaxLength="50" ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; font-size:small; height: 26px">&nbsp;Password</td>
            <td style="width: 100px; height: 26px" class="TableTitle">
                <asp:TextBox ID="txtPassword" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="100" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
                <asp:LinkButton ID="lnkAutoGenetae" runat="server" ToolTip="Click to Auto Generate" OnClick="lnkAutoGenetae_Click"> Auto Generate</asp:LinkButton></td>
            <td style="width: 100px; height: 26px"></td>
            <td style="width: 100px; height: 26px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; font-size:small; height: 22px;">&nbsp;Is Active</td>
            <td style="width: 100px; height: 22px;" class="TableTitle">
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
            <td class="TableTitle" style="width: 162px; font-size:small">&nbsp;Role Id</td>
            <td style="width: 100px" class="TableTitle">
                <asp:DropDownList ID="ddlRoleId" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
         <tr> <%--add on 23/01/2025--%>
            <td class="TableTitle" style="width: 162px">&nbsp;Reporting Manager</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlReportingManager" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px"> </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save"
                ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click"
                    ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="False" OnClick="btnCancel_Click" />&nbsp;
                <asp:Label ID="lblWait" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="8pt"></asp:Label>
                <%--<img src="Images/loading35.gif" style="visibility: hidden" id="imgLoading" />--%> </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; font-size:small">&nbsp;<strong>Search UserId</strong></td>
            <td style="width: 100px" class="TableTitle">
                <asp:TextBox ID="txtSearchUserID" runat="server" BorderWidth="1px" MaxLength="50"
                    ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:Button ID="btnGo" runat="server" BorderWidth="1px" Text="Search"
                    Width="67px" Font-Bold="True" OnClick="btnGo_Click" /></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:HiddenField runat="server" ID="hdnUserId" Value="0" />
                <asp:GridView ID="grv_GroupInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="grv_GroupInfo_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="USERNAME" HeaderText="User Name" />
                        <asp:BoundField DataField="LoginName" HeaderText="User Id" />
                        <asp:BoundField DataField="RoleId" HeaderText="Role Id" />
                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="RM" HeaderText="RM Name"/>
                        <asp:BoundField DataField="ReportingManager" HeaderText="RM ID"/>
                        

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
