<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="MDBDetails_master.aspx.cs" Inherits="Pages_ChequeProcessingNEW_MDBDetails_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">


    function GV_RowSelection(RowNo, id) {
        //debugger;
        var RowNo = (parseInt(RowNo) + 1);
        var hdnBranchId = document.getElementById("<%=hdnBranchId.ClientID%>");
        var ddlBranchName = document.getElementById("<%=ddlBranchName.ClientID%>");
        var txtBranchCode = document.getElementById("<%=txtBranchCode.ClientID%>");
        var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
      
        var Gv_Search = document.getElementById("<%=Gv_Search.ClientID%>");

        var txtCityCode = document.getElementById("<%=txtCityCode.ClientID%>");
        var txtDSLimit = document.getElementById("<%=txtDSLimit.ClientID%>");

        var txtSBICode = document.getElementById("<%=txtSBICode.ClientID%>");
        var txtNonSBICode = document.getElementById("<%=txtNonSBICode.ClientID%>");

        hdnBranchId.value = Gv_Search.rows[RowNo].cells[0].innerText;
        ddlBranchName.value = Gv_Search.rows[RowNo].cells[0].innerText;
        txtBranchCode.value = Gv_Search.rows[RowNo].cells[2].innerText;
        ddlIsActive.value = Gv_Search.rows[RowNo].cells[3].innerText;
      
        txtCityCode.value = Gv_Search.rows[RowNo].cells[4].innerText;
        txtDSLimit.value = Gv_Search.rows[RowNo].cells[5].innerText;

        txtSBICode.value = Gv_Search.rows[RowNo].cells[6].innerText;
        txtNonSBICode.value = Gv_Search.rows[RowNo].cells[7].innerText;

        var i = 0;
        for (i = 0; i <= Gv_Search.rows.length - 1; i++) {
            if (i != 0) {
                if (hdnBranchId.value == Gv_Search.rows[i].cells[0].innerText) {
                    Gv_Search.rows[i].style.backgroundColor = "DarkGray";
                }
                else {
                    Gv_Search.rows[i].style.backgroundColor = "white";
                }
            }
        }
    }

    function ValidationAllField() {
        //debugger;
        var ReturnType = true;
        var ErrorMessage = "";

        var ddlBranchName = document.getElementById("<%=ddlBranchName.ClientID%>");
        var txtBranchCode = document.getElementById("<%=txtBranchCode.ClientID%>");
        var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");

        var txtCityCode = document.getElementById("<%=txtCityCode.ClientID%>");
        var txtDSLimit = document.getElementById("<%=txtDSLimit.ClientID%>");

        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

        if (ddlBranchName.value == '-Select-') {
            ErrorMessage = "Branch Name can't be blank";
            ReturnType = false;
        }
        if (txtBranchCode.value == '' || txtBranchCode.value.length > 3) {
            ErrorMessage = "Branch Code can't be blank OR More than three Character";
            ReturnType = false;
        }
        if (ddlIsActive.value == '-Select-') {
            ErrorMessage = "Is Active can't be blank";
            ReturnType = false;
        }
        if (txtCityCode.value == '' || txtCityCode.value == null || txtCityCode.value.length > 3) {
            ErrorMessage = "City Code cannot be blank OR City code should be integer value";
            ReturnType = false;
        }
        if (txtDSLimit.value == '' || txtDSLimit.value == null || txtDSLimit.value.length > 3) {
            ErrorMessage = "Deposit Slip limit can't be blank OR it should have integer value";
            ReturnType = false;
        }

        if (ReturnType) {
            var lblWait = document.getElementById("<%=lblWait.ClientID%>");
            lblWait.innerText = "Please wait.....";
        }

        lblMessage.innerText = ErrorMessage;

        return ReturnType;
    }

</script>
    <table cellpadding="2" style="width: 739px">
        <tr>
            <td colspan="3" rowspan="1" style="height: 17px">
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="253px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="3" rowspan="" style="width: 357px">
                MDB Details Master</td>
        </tr>
        <tr>
            <td style="width: 319px; height: 1px;"  class="TableTitle">
                Branch Name</td>
            <td style="width: 407px; height: 1px">
                <asp:DropDownList ID="ddlBranchName" runat="server" SkinID="ddlskin">
                </asp:DropDownList>
            </td>
            <td style="width: 10px; height: 1px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 319px">
                Branch/MDB Code</td>
            <td style="width: 407px">
                <asp:TextBox ID="txtBranchCode" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox>
                e.g MUM for MUMBAI</td>
            <td style="width: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 319px">
                Is Active</td>
            <td style="width: 407px">
                <asp:DropDownList ID="ddlIsActive" runat="server" Width="116px" SkinID="ddlSkin">
                    <%--<asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="width: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 319px; height: 17px;" class="TableTitle">
                City Code</td>
            <td style="width: 407px; height: 17px">
                <asp:TextBox ID="txtCityCode" runat="server" BorderWidth="1px" SkinID="txtskin"></asp:TextBox>
                e.g 400 for MUMBAI</td>
            <td style="width: 10px; height: 17px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 319px; height: 17px;" class="TableTitle">
                DS Limit</td>
            <td style="width: 407px; height: 17px">
                <asp:TextBox ID="txtDSLimit" runat="server" BorderWidth="1px" SkinID="txtskin"></asp:TextBox>
                e.g 200 for MUMBAI</td>
            <td style="width: 10px; height: 17px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 319px; height: 17px;" class="TableTitle">
                SBI Branch Code for ADI</td>
            <td style="width: 407px; height: 17px">
                <asp:TextBox ID="txtSBICode" runat="server" BorderWidth="1px" SkinID="txtskin" 
                    MaxLength="5"></asp:TextBox>
                e.g 00539 for MUMBAI</td>
            <td style="width: 10px; height: 17px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 319px; height: 17px;" class="TableTitle">
                Non SBI BranchCode for ADI</td>
            <td style="width: 407px; height: 17px">
                <asp:TextBox ID="txtNonSBICode" runat="server" BorderWidth="1px" 
                    SkinID="txtskin" MaxLength="5"></asp:TextBox>
                e.g 07074 for MUMBAI</td>
            <td style="width: 10px; height: 17px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 17px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" 
                    OnClick="btnSave_Click" BorderWidth="1px" />&nbsp;
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Width="78px" 
                    OnClick="btnAdd_Click" BorderWidth="1px" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    OnClick="btnCancel_Click" BorderWidth="1px" />
                &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
                <asp:HiddenField ID="hdnBranchId" runat="server" />
                </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="3" style="width: 178px; height: 17px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 17px">
                <asp:GridView ID="Gv_Search" runat="server" Width="308px" 
                    OnRowDataBound="Gv_Search_RowDataBound" AutoGenerateColumns="False" 
                    BorderColor="Black" BorderStyle="Double" CssClass="mGrid">
                <Columns>
                <asp:BoundField DataField="BranchId" >
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                <asp:BoundField DataField="BranchCode" HeaderText="Code" />
                <asp:BoundField DataField="Is_active" HeaderText="Active" />
                <asp:BoundField DataField="CityCode" HeaderText="City Code" />
                <asp:BoundField DataField="DS_Limit" HeaderText="DS Limit" />
                <asp:BoundField DataField="LocCodeSBI" HeaderText="SBI BranchCode for ADI" />
                <asp:BoundField DataField="LocCodeNonSBI" HeaderText="SBI BranchCode for ADI" />
               
                  
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="width: 178px; height: 17px">
                &nbsp;
            </td>
        </tr>
    </table>
    
</asp:Content>

