<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="GenerateBatchFileNew.aspx.cs" Inherits="Pages_ChequeProcessingNEW_GenerateBatchFileNew" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js">     
    </script>

    <script language="javascript" type="text/javascript">

        function GV_RowSelection(RowNo, id) {
            // debugger;

            var RowNo = (parseInt(RowNo) + 1);

            var txtBatchNo = document.getElementById("<%=txtBatchNo.ClientID%>");
            var txtDropBoxName = document.getElementById("<%=txtDropBoxName.ClientID%>");
            var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");
            var txtChequeCount = document.getElementById("<%=txtChequeCount.ClientID%>");
            var Gv_Search = document.getElementById("<%=Gv_Search.ClientID%>");
            //          
            var hdnDropCountID = document.getElementById("<%=hdnDropCountID.ClientID%>");
            //  var ddlDropBoxList2=0;
            //         

            ddlDropBoxList.value = Gv_Search.rows[RowNo].cells[3].innerText;
            txtDropBoxName.value = Gv_Search.rows[RowNo].cells[1].innerText;
            txtChequeCount.value = Gv_Search.rows[RowNo].cells[2].innerText;
            txtBatchNo.value = Gv_Search.rows[RowNo].cells[4].innerText;
            hdnDropCountID.value = Gv_Search.rows[RowNo].cells[5].innerText;
            //
            ddlDropBoxList.value = Gv_Search.rows[RowNo].cells[3].innerText + ':' + txtDropBoxName.value;
            var i = 0;
            for (i = 0; i <= Gv_Search.rows.length - 1; i++) {
                if (i != 0) {
                    if (ddlDropBoxList.value == Gv_Search.rows[i].cells[3].innerText + ':' + Gv_Search.rows[RowNo].cells[1].innerText) {
                        Gv_Search.rows[i].style.backgroundColor = "DarkGray";
                    }
                    else {
                        Gv_Search.rows[i].style.backgroundColor = "white";
                    }
                }
            }
        }


        function TotalCheuqeCount() {
            //  debugger;
            var lblCount = document.getElementById("<%=lblCount.ClientID%>");

            var MainTab = document.getElementById("MainTab");
            var i = 0;
            var TotalAmt = 0;

            for (i = 0; i <= MainTab.rows.length - 1; i++) {
                if (i != 0) {
                    TotalAmt = TotalAmt + parseFloat(MainTab.rows[i].cells[3].innerText);
                }
            }

            lblCount.innerText = TotalAmt;

        }


        function Validate_Save() {
            //   debugger;
            var ReturnValue = true;
            var ErrorMessage = "";
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var hdnDropBoxDetails = document.getElementById("<%=hdnDropBoxDetails.ClientID%>");
            var ddlClientList = document.getElementById("<%=ddlClientList.ClientID%>");
            var txtDepositdate = document.getElementById("<%=txtDepositdate.ClientID%>");
            var txtPickupDate = document.getElementById("<%=txtPickupDate.ClientID%>");


            //            if (hdnDropBoxDetails.value == '') {
            //                ErrorMessage = "Drop Box Count Details Found!";
            //                ReturnValue = false;
            //            }
            if (ddlClientList.selectedIndex == 0) {
                ErrorMessage = "Please select Client To Continue!";
                ReturnValue = false;
                ddlClientList.focus();
            }
            if (txtDepositdate.value == '') {
                ErrorMessage = "Please Enter Deposit Date!";
                ReturnValue = false;
                txtDepositdate.focus();
            }
            else {
                var strtxtDepositdate = txtDepositdate.value;
                var strtxtDepositdate = strtxtDepositdate.split('/', strtxtDepositdate.length);

                if (strtxtDepositdate.length > 0) {
                    var Depositdate = new Date(strtxtDepositdate[2], strtxtDepositdate[1] - 1, strtxtDepositdate[0]);
                    var Day = Depositdate.getDay();

                    if (Day == 0) {
                        ErrorMessage = "Entered Date is on Sunday, Not valid!";
                        ReturnValue = false;
                        txtDepositdate.focus();
                    }

                }
                else {
                    ErrorMessage = "Invalid Pickup Date format Entered, please Enter dd/MM/yyyy !";
                    ReturnValue = false;
                    txtDepositdate.focus();
                }
            }

            if (txtPickupDate.value == '') {
                ErrorMessage = "Please Enter Pickup Date!";
                ReturnValue = false;
                txtPickupDate.focus();
            }


            lblMessage.innerText = ErrorMessage;
            window.scroll(0, 0);

            return ReturnValue;
        }

        function Page_load_validation() {
            //  debugger;
            var hdnDropBoxDetails = document.getElementById("<%=hdnDropBoxDetails.ClientID%>");
            RenderTable(hdnDropBoxDetails.value);
            TotalCheuqeCount();

        }

        function ShowDropBoxName() {
            //   debugger;
            var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");
            var txtDropBoxName = document.getElementById("<%=txtDropBoxName.ClientID%>");

            var SelectIndex = parseInt(ddlDropBoxList.selectedIndex);

            var strDropBoxName = '';
            var strRowDetails = "";


            if (ddlDropBoxList.selectedIndex != 0) {

                strDropBoxName = ddlDropBoxList.value;
                strRowDetails = strDropBoxName.split(':', strDropBoxName.length);

            }

            txtDropBoxName.innerText = strRowDetails[1];
        }


        function AddColumnToGrid() {

            if (Validate_DropBoxCount()) {
                var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");
                var txtChequeCount = document.getElementById("<%=txtChequeCount.ClientID%>");
                var hdnDropBoxDetails = document.getElementById("<%=hdnDropBoxDetails.ClientID%>");
                var MainTab = document.getElementById("MainTab");

                var SelectIndex = parseInt(ddlDropBoxList.selectedIndex);

                var strhdvValue = "";
                strhdvValue = hdnDropBoxDetails.value;


                var strDropBoxName = "";
                var strRowDetails = "";
                strDropBoxName = ddlDropBoxList.value;
                strRowDetails = strDropBoxName.split(':', strDropBoxName.length);

                strhdvValue = strhdvValue + ddlDropBoxList.options[SelectIndex].innerText + "|" + strRowDetails[1] + "|" + txtChequeCount.value + "|" + strRowDetails[0] + "^";

                RenderTable(strhdvValue);

                hdnDropBoxDetails.value = "";
                hdnDropBoxDetails.value = strhdvValue;

                ddlDropBoxList.selectedIndex = 0;
                txtChequeCount.value = "";
                TotalCheuqeCount();
            }
            return false;
        }
        function Validate_DropBoxCount() {
            //  debugger;
            var ReturnValue = true;
            var ErrorMessage = "";
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var MainTab = document.getElementById("MainTab");
            var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");
            var txtChequeCount = document.getElementById("<%=txtChequeCount.ClientID%>");

            if (ddlDropBoxList.selectedIndex == 0) {
                ErrorMessage = "Please select dropbox to continue...";
                ReturnValue = false;

            }
            else {
                var SelectedIndex_DropBoxId = parseInt(ddlDropBoxList.selectedIndex);
                for (i = 0; i <= MainTab.rows.length - 1; i++) {

                    var Value = ddlDropBoxList.options[SelectedIndex_DropBoxId].innerText;
                    if (MainTab.rows[i].cells[1].innerText == Value) {
                        ErrorMessage = 'Drop Box entry already Added!';
                        ddlDropBoxList.focus();
                        ReturnValue = false;
                    }
                }
            }
            if (txtChequeCount.value == '') {
                ErrorMessage = "Please enter cheque count...";
                ReturnValue = false;
            }

            lblMessage.innerText = ErrorMessage;
            window.scroll(0, 0);
            return ReturnValue;

        }

        function SelectAll() {

            var MainTab = document.getElementById("MainTab");
            var chkSelectAll = document.getElementById("chkSelectAll");
            var i = 0;

            for (i = 0; i <= MainTab.rows.length - 1; i++) {
                var row = MainTab.rows[i];
                var chkObj = row.cells[0].childNodes[0];

                if (chkObj != null) {
                    chkObj.checked = chkSelectAll.checked;
                }
            }

        }
        function RenderTable(strhdvValue) {

            var MainTab = document.getElementById("MainTab");

            var Totalrows = MainTab.rows.length;


            for (i = MainTab.rows.length - 1; i > 0; i--) {

                MainTab.deleteRow(i);

            }

            var strOutPut = "";
            var strRowDetails = "";
            var strColDetails = "";

            strRowDetails = strhdvValue.split('^', strhdvValue.length);
            var i = 0;
            var j = 0;
            var strRowlength = 0;

            for (i = 0; i <= strRowDetails.length - 2; i++) {
                var rowCount = MainTab.rows.length;

                rowCount = rowCount;
                var row = document.getElementById('MainTab').insertRow(rowCount);

                strColDetails = strRowDetails[i];
                strColDetails = strColDetails.split('|', strColDetails.length);

                var ColChkObj = row.insertCell(0);
                ColChkObj.innerHTML = "<input id='Chk_" + rowCount + "' type='checkbox' />";
                for (j = 0; j <= strColDetails.length - 1; j++) {

                    ColChkObj = row.insertCell(j + 1);
                    ColChkObj.innerHTML = strColDetails[j];
                    if (j >= 3) {
                        ColChkObj.style.display = "none";
                    }

                }
            }

        }
        function Remove_DropBoxCount() {
            var hdnDropBoxDetails = document.getElementById("<%=hdnDropBoxDetails.ClientID%>");


            var MainTab = document.getElementById("MainTab");
            var i = 0;
            var strhdvValue = "";

            for (i = MainTab.rows.length - 1; i > 0; i--) {

                var row = MainTab.rows[i];
                var chkObj = row.cells[0].childNodes[0];

                if (chkObj != null) {
                    if (chkObj.checked == true) {
                        MainTab.deleteRow(i);
                    }

                }
            }
            hdnDropBoxDetails.value = "";
            for (i = 0; i <= MainTab.rows.length - 1; i++) {

                if (i == 0) {
                }
                else {
                    hdnDropBoxDetails.value = "";
                    strhdvValue = strhdvValue + MainTab.rows[i].cells[1].innerText + "|" + MainTab.rows[i].cells[2].innerText + "|" + MainTab.rows[i].cells[3].innerText + "|" + MainTab.rows[i].cells[4].innerText + "^";
                    hdnDropBoxDetails.value = strhdvValue;
                }
            }

            RenderTable(strhdvValue);
            return false;
        }

    </script>
    <table>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="8" class="TableHeader" style="height: 18px">&nbsp;Batch Generate
            </td>
        </tr>
        <tr>
            <td style="width: 14px">&nbsp;</td>
            <td style="width: 100px" class="TableTitle">
                <asp:Label ID="lblBatchNo" runat="server" Text="Batch No" Visible="False"></asp:Label>
            </td>
            <td class="TableGrid" colspan="4">
                <asp:TextBox ID="txtBatchNo" runat="server" Visible="False" SkinID="txtSkin"
                    Width="283px" ReadOnly="True"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:HiddenField ID="hdnDropCountID" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 14px"></td>
            <td style="width: 100px" class="TableTitle">Location</td>
            <td class="TableGrid" colspan="2">
                <asp:Label ID="lblLocation" runat="server"></asp:Label>
            </td>
            <td class="TableTitle" style="width: 100px">&nbsp;Client
            </td>
            <td class="TableGrid" style="width: 100px">
                <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td style="width: 14px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Pickup Date</td>
            <td style="width: 290px" class="TableGrid">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtPickupDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid" style="width: 100px"></td>
            <td style="width: 100px;" class="TableTitle">&nbsp;Deposit Date</td>
            <td style="width: 100px;" class="TableGrid">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtDepositdate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="70px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <asp:HiddenField ID="hdnDropBoxDetails" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">&nbsp;Dropbox Cheque Counts Add</td>
        </tr>
        <tr>
            <td style="width: 14px; height: 20px"></td>
            <td class="TableTitle" style="width: 100px; height: 20px">&nbsp;Dropbox Code</td>
            <td class="TableTitle" style="width: 290px; height: 20px">&nbsp;DropBox Name</td>
            <td class="TableTitle" style="width: 100px; height: 20px">&nbsp;Total Cheques</td>
            <td class="TableTitle" style="height: 20px"></td>
            <td style="width: 100px; height: 20px"></td>
            <td style="width: 100px; height: 20px"></td>
            <td style="width: 100px; height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 14px; height: 16px"></td>
            <td class="TableGrid" style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlDropBoxList" runat="server" SkinID="ddlSkin"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="ddlDropBoxList_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td class="TableGrid" style="width: 290px; height: 16px">
                <asp:TextBox ID="txtDropBoxName" runat="server" ReadOnly="True"
                    SkinID="txtSkin" Width="287px"></asp:TextBox>
            </td>
            <td class="TableGrid" style="width: 100px; height: 16px">
                <asp:TextBox ID="txtChequeCount" runat="server" SkinID="txtSkin" Width="92px"></asp:TextBox></td>
            <td class="TableGrid">&nbsp;&nbsp;<asp:Button
                ID="btnRemove" runat="server" BorderWidth="1px" Text="Remove" Width="64px"
                Visible="False" /></td>
            <td style="width: 100px; height: 16px"></td>
            <td style="width: 100px; height: 16px"></td>
            <td style="width: 100px; height: 16px"></td>
        </tr>
        <tr>
            <td style="width: 14px; height: 16px"></td>
            <td colspan="7" style="height: 16px">
                <table id="MainTab" class="GridViewStyle" style="width: 380">
                    <%--<tr>
                        <th class="TableGrid" style="width: 21px">
                            <input id="chkSelectAll"   onclick="javascript:SelectAll();"   type="checkbox" /></th>
                        <th class="TableGrid" style="width: 65px">
                            DropBoxCode</th>
                        <th class="TableGrid" style="width: 279px">
                            DropBox Name</th>
                        <th class="TableGrid">
                            &nbsp;ChequeCount</th>
                        <th>
                        </th>
                    </tr>--%>

                    <tr>
                        <td colspan="3" style="height: 17px">
                            <asp:GridView ID="Gv_Search" runat="server" Width="500"
                                OnRowDataBound="Gv_Search_RowDataBound" AutoGenerateColumns="False"
                                BorderColor="Black" CssClass="mGrid">
                                <Columns>

                                    <asp:BoundField DataField="Dropbox_Code" HeaderText="DropBox Code" />
                                    <asp:BoundField DataField="DropBox_Name" HeaderText="DropBox Name" />
                                    <asp:BoundField DataField="totalCount" HeaderText="Cheque Count" />
                                    <asp:BoundField DataField="DropBoxID">
                                        <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                                        <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BatchNo">
                                        <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                                        <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DropCountID">
                                        <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                                        <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 14px"></td>
            <td style="width: 100px" class="TableTitle">&nbsp;Total Counts</td>
            <td style="width: 290px" class="TableGrid">
                <asp:Label ID="lblCount" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="height: 38px;" class="TableTitle" colspan="8">&nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Save"
                    Width="60px" OnClick="btnSave_Click" Style="font-weight: 700" />
                <asp:Button ID="btnAdd" runat="server"
                    BorderWidth="1px" Text="Add New" Width="64px" Font-Bold="False"
                    OnClick="btnAdd_Click" />
                <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="60px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">&nbsp; Batch Generate Search</td>
        </tr>
        <tr>
            <td colspan="8"></td>
        </tr>
        <tr>
            <td style="width: 14px"></td>
            <td style="width: 100px"></td>
            <td style="width: 290px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
    </table>

</asp:Content>
