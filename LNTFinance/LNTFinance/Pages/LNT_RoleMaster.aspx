<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LNT_CommonMaster.Master" AutoEventWireup="true" CodeBehind="LNT_RoleMaster.aspx.cs" Inherits="LNTFinance.Pages.LNT_RoleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function ValidateAddNew() {
            hdnID = document.getElementById("<%=hdnID.ClientID%>");
            txtRoleName = document.getElementById("<%=txtRoleName.ClientID%>");
            ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            grv_Data = document.getElementById("<%=grv_Data.ClientID%>");

            hdnID.value = "0";
            txtRoleName.value = "";
            ddlIsActivate.selectedIndex = 0;

            return false;
        }

        function ValidateSave() {
            var ReturnValue = true;
            var ErrorMessage = "";

            hdnID = document.getElementById("<%=hdnID.ClientID%>");
            txtRoleName = document.getElementById("<%=txtRoleName.ClientID%>");
            ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");

            lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            
     if (txtRoleName.value == '') {
         ErrorMessage = "Please enter Role Name to continue....";
         ReturnValue = false;
            }

     if (ddlIsActivate.selectedIndex == 0) {
         ErrorMessage = "Please select Activate  Status to continue....";
         ReturnValue = false;
     }

     if (ReturnValue) {
         lblWait = document.getElementById("<%=lblWait.ClientID%>");
                lblWait.innerText = "Please wait.....";
            }

            lblMessage.innerText = ErrorMessage;

            return ReturnValue;
        }

        function hover(value, rowno) {
            //debugger;
            grv_Data = document.getElementById("<%=grv_Data.ClientID%>");
     hdnID = document.getElementById("<%=hdnID.ClientID%>");

            rowno = (parseInt(rowno) + 1);

            if (value == 'in') {
                if (hdnID.value != grv_Data.rows[rowno].cells[0].innerText) {
                    grv_Data.rows[rowno].style.backgroundColor = "#ffff33";
                }
            }
            else {
                if (hdnID.value != grv_Data.rows[rowno].cells[0].innerText) {
                    grv_Data.rows[rowno].style.backgroundColor = "white";
                }
            }

        }


        function Pro_SelectRow(rowno, id) {
            //debugger;
            //alert(rowno);
            rowno = (parseInt(rowno) + 1);
            hdnID = document.getElementById("<%=hdnID.ClientID%>");
            txtRoleName = document.getElementById("<%=txtRoleName.ClientID%>");
            ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
            grv_Data = document.getElementById("<%=grv_Data.ClientID%>");


            //-/-if(rowno != null)
            //{

            hdnID.value = grv_Data.rows[rowno].cells[0].innerText;
            txtRoleName.value = grv_Data.rows[rowno].cells[1].innerText;
            ddlIsActivate.value = grv_Data.rows[rowno].cells[2].innerText;
            grv_Data.rows[rowno].style.backgroundColor = "DarkGray";//"#E0E0E0";


            //}



        }

    </script>

    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>&nbsp;
            
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;User Role Master</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Role Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtRoleName" runat="server" ValidationGroup="BranchENtry" BorderWidth="1px"></asp:TextBox></td>
            <td style="width: 100px"></td>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Is Active</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save"
                ValidationGroup="BranchENtry" Width="67px" OnClick="btnSave_Click" />
                <asp:Button ID="btnAddNew" runat="server" Text="Add New"
                    ValidationGroup="BranchENtry" Width="67px" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />&nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="5">
                <br />
                <asp:GridView ID="grv_Data" runat="server" OnRowDataBound="grv_Data_RowDataBound">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
