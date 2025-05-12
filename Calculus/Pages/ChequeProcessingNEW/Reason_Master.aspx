<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="~/Pages/ChequeProcessingNEW/Reason_Master.aspx.cs" Inherits="Pages_Calculus_Reason_Master" Title="Reason Master" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">


        function GV_RowSelection(RowNo, id) {
            var RowNo = (parseInt(RowNo) + 1);
            var hdnReasonId = document.getElementById("<%=hdnReasonId.ClientID%>");
  var ddlReasonType = document.getElementById("<%=ddlReasonType.ClientID%>");
    var txtReasoncode = document.getElementById("<%=txtReasoncode.ClientID%>");
    var txtReasonName = document.getElementById("<%=txtReasonName.ClientID%>");
    var ddlFlag = document.getElementById("<%=ddlFlag.ClientID%>");
    var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
    var Gv_Search = document.getElementById("<%=Gv_Search.ClientID%>");

    hdnReasonId.value = Gv_Search.rows[RowNo].cells[0].innerText;
    ddlReasonType.value = Gv_Search.rows[RowNo].cells[1].innerText;
    txtReasoncode.value = Gv_Search.rows[RowNo].cells[2].innerText;
    txtReasonName.value = Gv_Search.rows[RowNo].cells[3].innerText;
    ddlFlag.value = Gv_Search.rows[RowNo].cells[4].innerText;
    ddlIsActive.value = Gv_Search.rows[RowNo].cells[5].innerText;


    var i = 0;
    for (i = 0; i <= Gv_Search.rows.length - 1; i++) {
        if (i != 0) {
            if (hdnReasonId.value == Gv_Search.rows[i].cells[0].innerText) {
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

    var txtReasonName = document.getElementById("<%=txtReasonName.ClientID%>");
     var txtReasoncode = document.getElementById("<%=txtReasoncode.ClientID%>");
      var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");

      var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

      if (txtReasonName.value == '') {
          ErrorMessage = "Reason Name can't be blank";
          ReturnType = false;
      }
      if (txtReasoncode.value == '') {
          ErrorMessage = "Reason Code can't be blank";
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
    <table cellpadding="2" style="width: 696px">
        <tr>
            <td colspan="5" rowspan="1" style="height: 17px">&nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="594px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5" rowspan="" style="width: 357px">Reason Master</td>
        </tr>
        <tr>
            <td style="width: 993px;" class="TableTitle">Reason Type</td>
            <td style="width: 393px;">
                <asp:DropDownList ID="ddlReasonType" runat="server" Width="129px" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="0">-Select-</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>R</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td class="TableTitle">Reason Code</td>
            <td>
                <asp:TextBox ID="txtReasoncode" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 993px; height: 7px;">Reason Name</td>
            <td style="width: 393px; height: 7px;">
                <asp:TextBox ID="txtReasonName" runat="server" BorderWidth="1px" SkinID="txtSkin" Height="62px" Width="268px" OnKeyup="UpperLetter(this);" TextMode="MultiLine"></asp:TextBox></td>
            <td class="TableTitle" style="width: 549px; height: 7px">Flag</td>
            <td style="width: 549px; height: 7px">
                <asp:DropDownList ID="ddlFlag" runat="server" Width="131px" SkinID="ddlSkin">
                    <%--<asp:ListItem>NULL</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                    <asp:ListItem>W</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="width: 549px; height: 7px;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 993px; height: 24px;">Is Active</td>
            <td style="width: 393px; height: 24px;">
                <asp:DropDownList ID="ddlIsActive" runat="server" Width="126px" SkinID="ddlSkin">
                   <%-- <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td rowspan="1" style="width: 549px; height: 24px"></td>
            <td rowspan="1" style="width: 549px; height: 24px"></td>
            <td style="width: 549px; height: 24px;" rowspan=""></td>
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
                        <asp:BoundField DataField="ReasonID">
                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                            <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Type" HeaderText="ReaType" />
                        <asp:BoundField DataField="Reason_code" HeaderText="ReaCode" />
                        <asp:BoundField DataField="Reason_name" HeaderText="ReaName" />
                        <asp:BoundField DataField="flag" HeaderText="flag" />
                        <asp:BoundField DataField="Is_active" HeaderText="Active" />
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnReasonId" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td colspan="6" style="width: 178px; height: 17px">&nbsp;
            </td>
        </tr>
    </table>

</asp:Content>

