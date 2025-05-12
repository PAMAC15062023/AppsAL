<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="~/Pages/ChequeProcessingNEW/DropBox_Master.aspx.cs" Inherits="Pages_Calculus_DropBox_Master" Title="DropBox Master" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">


        function GV_RowSelection(RowNo, id) {
            var RowNo = (parseInt(RowNo) + 1);
            var hdnDropBoxId = document.getElementById("<%=hdnDropBoxId.ClientID%>");
  var ddlBranchName = document.getElementById("<%=ddlBranchName.ClientID%>");
    var txtLocation = document.getElementById("<%=txtLocation.ClientID%>");
    var txtDropBoxName = document.getElementById("<%=txtDropBoxName.ClientID%>");
    var txtDropCode = document.getElementById("<%=txtDropCode.ClientID%>");
    var txtContactPerson = document.getElementById("<%=txtContactPerson.ClientID%>");
    var txtAddress1 = document.getElementById("<%=txtAddress1.ClientID%>");
    var txtAddress2 = document.getElementById("<%=txtAddress2.ClientID%>");
    var txtcity = document.getElementById("<%=txtcity.ClientID%>");
    var txtPincode = document.getElementById("<%=txtPincode.ClientID%>");
    var txtPhoneNo = document.getElementById("<%=txtPhoneNo.ClientID%>");
    var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");
    var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
    var Gv_Search = document.getElementById("<%=Gv_Search.ClientID%>");

    hdnDropBoxId.value = Gv_Search.rows[RowNo].cells[0].innerText;
    ddlBranchName.value = Gv_Search.rows[RowNo].cells[1].innerText;
    txtLocation.value = Gv_Search.rows[RowNo].cells[3].innerText;
    txtDropCode.value = Gv_Search.rows[RowNo].cells[4].innerText;
    txtDropBoxName.value = Gv_Search.rows[RowNo].cells[5].innerText;
    txtContactPerson.value = Gv_Search.rows[RowNo].cells[6].innerText;
    txtAddress1.value = Gv_Search.rows[RowNo].cells[7].innerText;
    txtAddress2.value = Gv_Search.rows[RowNo].cells[8].innerText;
    txtcity.value = Gv_Search.rows[RowNo].cells[9].innerText;
    txtPincode.value = Gv_Search.rows[RowNo].cells[10].innerText;
    txtPhoneNo.value = Gv_Search.rows[RowNo].cells[11].innerText;
    txtRemark.value = Gv_Search.rows[RowNo].cells[12].innerText;
    ddlIsActive.value = Gv_Search.rows[RowNo].cells[13].innerText;


    var i = 0;
    for (i = 0; i <= Gv_Search.rows.length - 1; i++) {
        if (i != 0) {
            if (hdnDropBoxId.value == Gv_Search.rows[i].cells[0].innerText) {
                Gv_Search.rows[i].style.backgroundColor = "DarkGray";
            }
            else {
                Gv_Search.rows[i].style.backgroundColor = "white";
            }
        }
    }
}

function ValidationAllField() {

    var ReturnType = true;
    var ErrorMessage = "";

    var txtLocation = document.getElementById("<%=txtLocation.ClientID%>");
     var txtDropBoxName = document.getElementById("<%=txtDropBoxName.ClientID%>");
      var txtDropCode = document.getElementById("<%=txtDropCode.ClientID%>");
      var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");

      var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

      if (txtLocation.value == '') {
          ErrorMessage = "Branch Name can't be blank";
          ReturnType = false;
      }
      if (txtDropBoxName.value == '') {
          ErrorMessage = "Drop Box Name can't be blank";
          ReturnType = false;
      }
      if (txtDropCode.value == '') {
          ErrorMessage = "Drop Code can't be blank";
          ReturnType = false;
      }
      if (ddlIsActive.value == '-Select-') {
          ErrorMessage = "Is Active can't be blank";
          ReturnType = false;
      }

      if (ReturnType) {
          var lblWait = document.getElementById("<%=lblWait.ClientID%>");
        lblWait.innerText = "Please wait.....";
    }

    lblMessage.innerText = ErrorMessage;

    return ReturnType;
}
function UpperLetter(ID) {

    ID.value = ID.value.toUpperCase();

}


    </script>
    <table cellpadding="2" style="width: 777px">
        <tr>
            <td colspan="5" rowspan="1" style="height: 17px">&nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="772px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5" rowspan="" style="width: 357px">Drop Box Master</td>
        </tr>
        <tr>
            <td style="width: 1349px; height: 1px;" class="TableTitle">Branch Name</td>
            <td style="width: 393px; height: 1px">
                <asp:DropDownList ID="ddlBranchName" runat="server" Width="227px" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle" style="width: 549px; height: 1px">Location</td>
            <td style="width: 714px; height: 1px">
                <asp:TextBox ID="txtLocation" runat="server" SkinID="txtSkin" Width="224px" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td style="width: 549px; height: 1px">&nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 1349px">DropBox Code</td>
            <td style="width: 393px">
                <asp:TextBox ID="txtDropCode" runat="server" SkinID="txtSkin" Width="225px" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td class="TableTitle" style="width: 549px">DropBox Name</td>
            <td style="width: 714px">
                <asp:TextBox ID="txtDropBoxName" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="229px" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td style="width: 549px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 1349px; height: 38px;">Address 1</td>
            <td style="width: 393px; height: 38px;">
                <asp:TextBox ID="txtAddress1" runat="server" TextMode="MultiLine" Width="228px" SkinID="txtSkin" OnKeyup="UpperLetter(this);" Height="50px"></asp:TextBox></td>
            <td class="TableTitle" style="width: 549px; height: 38px;">Address 2</td>
            <td style="width: 714px; height: 38px;">
                <asp:TextBox ID="txtAddress2" runat="server" TextMode="MultiLine" Width="228px" SkinID="txtSkin" OnKeyup="UpperLetter(this);" Height="51px"></asp:TextBox></td>
            <td style="width: 549px; height: 38px;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 1349px; height: 28px;">City</td>
            <td style="width: 393px; height: 28px;">
                <asp:TextBox ID="txtcity" runat="server" SkinID="txtSkin" Width="149px" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td class="TableTitle" style="width: 549px; height: 28px;">Pincode</td>
            <td style="width: 714px; height: 28px;">
                <asp:TextBox ID="txtPincode" runat="server" SkinID="txtSkin" Width="149px"></asp:TextBox></td>
            <td style="width: 549px; height: 28px;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 1349px; height: 36px;">Phone No</td>
            <td style="width: 393px; height: 36px;">
                <asp:TextBox ID="txtPhoneNo" runat="server" SkinID="txtSkin" Width="149px"></asp:TextBox></td>
            <td class="TableTitle">Remark</td>
            <td style="width: 714px; height: 36px;">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="228px" SkinID="txtSkin" OnKeyup="UpperLetter(this);" Height="47px"></asp:TextBox></td>
            <td style="width: 549px; height: 36px;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 1349px; height: 24px;">Contact Person</td>
            <td style="width: 393px; height: 24px;">
                <asp:TextBox ID="txtContactPerson" runat="server" Width="149px" SkinID="txtSkin" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td style="width: 549px; height: 24px;" class="TableTitle">Is Active</td>
            <td style="width: 714px; height: 24px;">
                <asp:DropDownList ID="ddlIsActive" runat="server" Width="149px" SkinID="ddlSkin">
                    <%--<asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="width: 549px; height: 24px;"></td>
        </tr>
        <tr>
            <td colspan="5" style="height: 16px">&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" OnClick="btnSave_Click" />&nbsp;
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Width="78px" OnClick="btnAdd_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="6" style="width: 178px; height: 17px"></td>
        </tr>
        <tr>
            <td colspan="5" style="height: 17px">
                <asp:GridView ID="Gv_Search" runat="server" Width="308px" OnRowDataBound="Gv_Search_RowDataBound" AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Double">
                    <Columns>
                        <asp:BoundField DataField="dropBoxId">
                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BranchID">
                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                        <asp:BoundField DataField="Location" HeaderText="Location" />
                        <asp:BoundField DataField="DropBox_Code" HeaderText="DBCode" />
                        <asp:BoundField DataField="DropBox_Name" HeaderText="DBName" />
                        <asp:BoundField DataField="Contact_Person" HeaderText="ContPer" />
                        <asp:BoundField DataField="Address_Line1" HeaderText="Add1" />
                        <asp:BoundField DataField="Address_line2" HeaderText="Add2" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                        <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        <asp:BoundField DataField="Is_active" HeaderText="Active" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="width: 178px; height: 17px">&nbsp;
                <asp:HiddenField ID="hdnDropBoxId" runat="server" Value="0" />
            </td>
        </tr>
    </table>

</asp:Content>

