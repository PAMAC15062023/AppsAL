<%@ Page Language="C#" MasterPageFile="~/CM.master" AutoEventWireup="true" CodeBehind="CM_UserMaster.aspx.cs" Inherits="ChangeManagement.CM_UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        function Validate_Save() {
            var ReturnValue = true;
            var ErrorMessage = '';
            var txtUserName = document.getElementById("<%=txtUserName.ClientID%>");
            var txtUserID = document.getElementById("<%=txtUserID.ClientID%>");
            var txtEmail = document.getElementById("<%=txtEmail.ClientID%>");
            var txtPassword = document.getElementById("<%=txtPassword.ClientID%>");
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            <%--var txtDOL = document.getElementById("<%=txtDOL.ClientID%>");--%>
            var ddlBranch = document.getElementById("<%=ddlBranch.ClientID%>");
            <%--var ddlProduct = document.getElementById("<%=ddlProduct.ClientID%>");--%>
            <%--var txtUserAPSID = document.getElementById("<%=txtUserAPSID.ClientID%>"); --%>
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblWait = document.getElementById("<%=lblWait.ClientID%>");
            var imgLoading = document.getElementById('imgLoading');

            if (txtUserName.value == '') {
                ErrorMessage = 'USER Name Cannot be left Blank!';
                ReturnValue = false;
            }
            if (txtLoginName.value == '') {
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
            //if (ddlBrabchMapping.selectedIndex == 0) {
            //    ErrorMessage = 'Please select  Processing HUB to Contine...!';
            //    ReturnValue = false;
            //}
            //if (ddlProduct.selectedIndex == 0) {
            //    ErrorMessage = 'Please select Product to Contine...!';
            //    ReturnValue = false;
            //}
            
            if (ddlBranch.selectedIndex == 0)
            {
                ErrorMessage = 'Please select  Processing HUB to Contine...!';
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
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
           <%-- var txtDOL = document.getElementById("<%=txtDOL.ClientID%>");--%>
            var ddlBranch = document.getElementById("<%=ddlBranch.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>");
            <%--var ddlProduct = document.getElementById("<%=ddlProduct.ClientID%>");--%>
            <%--var txtUserAPSID = document.getElementById("<%=txtUserAPSID.ClientID%>");--%>

            txtUserName.value = '';
            txtUserID.value = '';
            txtPassword.value = '';
            ddlRoleId.selectedIndex = 0;
            ddlIsActivate.selectedIndex = 0;
            /*txtDOL.text = '';*/
            ddlBranch.selectedIndex = 0;
            ddlProduct.selectedIndex = 0;
            ddlReportingManager.selectedIndex = 0;
            //txtUserAPSID.value = ''
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
            var ddlRoleId = document.getElementById("<%=ddlRoleId.ClientID%>");
            var ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            <%--var txtDOL = document.getElementById("<%=txtDOL.ClientID%>");--%>
            var ddlBranch = document.getElementById("<%=ddlBranch.ClientID%>");
            <%--var ddlProduct = document.getElementById("<%=ddlProduct.ClientID%>");--%>
            <%--var txtUserAPSID = document.getElementById("<%=txtUserAPSID.ClientID%>");--%>
            var hdnUserId = document.getElementById("<%=hdnUserId.ClientID%>");
            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var ddlReportingManager = document.getElementById("<%=ddlReportingManager.ClientID%>");

            //-/-if(rowno != null)

            //{  
            txtUserName.value = grv_GroupInfo.rows[rowno].cells[0].innerText;
            txtUserID.value = grv_GroupInfo.rows[rowno].cells[1].innerText;
            ddlRoleId.value = grv_GroupInfo.rows[rowno].cells[7].innerText;
            txtEmail.value = grv_GroupInfo.rows[rowno].cells[3].innerText;
            ddlIsActivate.value = grv_GroupInfo.rows[rowno].cells[4].innerText;
            /*ddlBrabchMapping.value = grv_GroupInfo.rows[rowno].cells[5].innerText*/;
            ddlBranch.value = grv_GroupInfo.rows[rowno].cells[6].innerText
            /*ddlProduct.value = grv_GroupInfo.rows[rowno].cells[6].innerText;*/

            //hdnUserId.value = grv_GroupInfo.rows[rowno].cells[7].innerText;

            // txtUserAPSID.value = grv_GroupInfo.rows[rowno].cells[8].innerText;

            ddlReportingManager.value = grv_GroupInfo.rows[rowno].cells[8].innerText
            ddlUserGroupList.value = grv_GroupInfo.rows[rowno].cells[10].innerText;
        }

        $(function () {
            $('#datetimepicker2').datetimepicker
                ({
                    autoclose: true
                });
        });
    </script>

     <%--add on 27/11/2024 start from here>>--%>
    <style> 

    /* Workflow container that holds all the steps */
    .workflow-container {
        display: flex;
        align-items: center;
    }

    /* Each workflow step with a box and an arrow */
    .workflow-step {
        display: flex;
        align-items: center;
        margin: 0 15px;
    }

    /* Style for the square boxes */
    .workflow-box {
        background-color: #0a263d; /*#4CAF50;*/
        color: white;
        padding: 30px;
        width: 120px;
        height: 10px;
        text-align: center;
        border-radius: 10px;
        font-size: 11.5px;
        font-weight: bold;
        box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
         display: flex;
        align-items: center;
        justify-content: center;
    }

    /* Insert arrows between steps using the ::after pseudo-element */
    .workflow-step::after {
    content: "→"; /* Arrow character */
    font-size: 50px; /* Large arrows */
    font-weight: bold;
    color: #333;
    margin: 0 05px;
    display: inline-block;
    }

    /* Hide the last arrow */
    .workflow-step:last-child::after {
        content: ""; /* Remove the arrow from the last step */

    </style> <%--add on 27/11/2024 end here<< --%>

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
                <asp:TextBox ID="txtUserID" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="7"></asp:TextBox></td>
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
                <asp:LinkButton ID="lnkAutoGenerate" runat="server" ToolTip="Click to Auto Generate" OnClick="lnkAutoGenerate_Click"> Auto Generate</asp:LinkButton></td>
            <td style="width: 100px; height: 26px"></td>
            <td style="width: 100px; height: 26px"></td>
        </tr>
       
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
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Branch</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px"> </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
         <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Reporting Manager</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlReportingManager" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px"> </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
       
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save"
                OnClick="btnSave_Click" ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" />&nbsp;
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click"
                    ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="False" OnClick="btnCancel_Click" />&nbsp;
                <asp:Label ID="lblWait" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;<strong>Search UserId</strong></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtSearchUserID" runat="server" BorderWidth="1px" MaxLength="50"
                    ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Text="Search" Width="67px" Font-Bold="True" OnClick="btnSearch_Click" /></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:HiddenField runat="server" ID="hdnUserId" Value="0" />
                <asp:GridView ID="grv_GroupInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="grv_GroupInfo_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:BoundField DataField="UserID" HeaderText="User Id" />
                        <asp:BoundField DataField="RoleDescription" HeaderText="Role" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email Id" />
                        <asp:BoundField DataField="Is_Active" HeaderText="Is Active" />
                        <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                        <asp:BoundField DataField="BranchId" HeaderText="Branch Id"/>
                        <asp:BoundField DataField="RoleID" HeaderText="Role ID"/>
                        <asp:BoundField DataField="ReportingManager" HeaderText="RM ID"/>
                        <asp:BoundField DataField="RM" HeaderText="RM Name"/>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

    
              <%--add on 27/11/2024 start from here>>--%>
          <!-- Add the workflow section here -->  
        <br>
     <div><p style="font-size:15px; color:navy"><i>Change Management workflow as follows:-</i></p></div>  
    <div class="workflow-container" >
        <div class="workflow-step">
            <div class="workflow-box">Change Request Initiation</div>
            
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Vertical Head Approval</div>
           
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Reviewer Approval</div>
           
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Development/IT Activities</div>
            
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Project Manager Approval</div>
        </div>
    </div> 
        <br> 
        <%--add on 27/11/2024 end here<< --%>

</asp:Content>

