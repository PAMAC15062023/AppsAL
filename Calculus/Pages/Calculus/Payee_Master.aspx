<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payee_Master.aspx.cs" Inherits="Pages_Calculus_Payee_Master" Title="Payee Info"
    StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js"> 
    </script>
    <script language="javascript" type="text/javascript">
        function UpperLetter(ID) {
            //            debugger
            ID.value = ID.value.toUpperCase();
        }
    </script>
    <script language="javascript" type="text/javascript">

        function Pro_SelectRow(rowno, ID) {

            rowno = parseInt(rowno) + 1;

            var hdnPayeeID = document.getElementById("<%=hdnPayeeID.ClientID%>");
            var ddlTransType = document.getElementById("<%=ddlTransType.ClientID%>");
            var txtChequeIssueTowhom = document.getElementById("<%=txtChequeIssueTowhom.ClientID%>");
            var txtAccountHolderName = document.getElementById("<%=txtAccountHolderName.ClientID%>");
            var txtAccountNo = document.getElementById("<%=txtAccountNo.ClientID%>");
            var txtBankName = document.getElementById("<%=txtBankName.ClientID%>");
            var txtBranchName = document.getElementById("<%=txtBranchName.ClientID%>");
            var grv_PayeeList = document.getElementById("<%=grv_PayeeList.ClientID%>");
            var txtPayeeName = document.getElementById("<%=txtPayeeName.ClientID%>");
            var txt_Address = document.getElementById("<%=txt_Address.ClientID%>");
            var ddlState = document.getElementById("<%=ddlState.ClientID%>");
            var txtContactNo = document.getElementById("<%=txtContactNo.ClientID%>");
            var txtPanNo = document.getElementById("<%=txtPanNo.ClientID%>");
            var txtEMailId = document.getElementById("<%=txtEMailId.ClientID%>");
            var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
            var txtIFSC_code = document.getElementById("<%=txtIFSC_code.ClientID%>");
            var ddlac_type = document.getElementById("<%=ddlac_type.ClientID%>");

            //////add by rani 25may2017
            var ddlndc = document.getElementById("<%=ddlND.ClientID%>");
            var txtNDvalidfrom = document.getElementById("<%=txtNDvalidfrom.ClientID %>");
            var txtNdvalidupto = document.getElementById("<%=txtNdvalidupto.ClientID %>");
            var ddlmou = document.getElementById("<%=ddlmou.ClientID %>");
            var txtMouvalidfrom = document.getElementById("<%=txtMouvalidfrom.ClientID %>");
            var txtMouvalidupto = document.getElementById("<%=txtMouvalidupto.ClientID %>");
            var ddlIsActiveGST = document.getElementById("<%=ddlIsActiveGST.ClientID %>");
            var txtGSTNo = document.getElementById("<%=txtGSTNo.ClientID %>");
            var txtgstprefx = document.getElementById("<%=txtgstprefx.ClientID %>");
            /////
            hdnPayeeID.value = ID;
            txtPayeeName.value = grv_PayeeList.rows[rowno].cells[1].innerText;
            txt_Address.value = grv_PayeeList.rows[rowno].cells[2].innerText;
            ddlState.value = grv_PayeeList.rows[rowno].cells[3].innerText;
            txtContactNo.value = grv_PayeeList.rows[rowno].cells[4].innerText;
            //Added By Avinash
            txtPanNo.value = grv_PayeeList.rows[rowno].cells[12].innerText.trim();
            //Added By Avinash

            txtEMailId.value = grv_PayeeList.rows[rowno].cells[5].innerText.trim();
            ddlIsActive.value = grv_PayeeList.rows[rowno].cells[14].innerText;

            ddlTransType.value = grv_PayeeList.rows[rowno].cells[17].innerText;
            txtChequeIssueTowhom.value = grv_PayeeList.rows[rowno].cells[7].innerText;
            txtAccountHolderName.value = grv_PayeeList.rows[rowno].cells[8].innerText.trim();
            txtAccountNo.value = grv_PayeeList.rows[rowno].cells[9].innerText.trim();
            txtBankName.value = grv_PayeeList.rows[rowno].cells[10].innerText.trim();
            txtBranchName.value = grv_PayeeList.rows[rowno].cells[11].innerText.trim();
            txtIFSC_code.value = grv_PayeeList.rows[rowno].cells[13].innerText.trim();
            ddlac_type.value = grv_PayeeList.rows[rowno].cells[19].innerText;

            ///        //////add by rani 25may2017
            ddlndc.value = grv_PayeeList.rows[rowno].cells[20].innerText;
            ddlmou.value = grv_PayeeList.rows[rowno].cells[21].innerText;
            txtNDvalidfrom.value = grv_PayeeList.rows[rowno].cells[22].innerText;
            txtNdvalidupto.value = grv_PayeeList.rows[rowno].cells[23].innerText;
            txtMouvalidfrom.value = grv_PayeeList.rows[rowno].cells[24].innerText;
            txtMouvalidupto.value = grv_PayeeList.rows[rowno].cells[25].innerText;
            ddlIsActiveGST.value = grv_PayeeList.rows[rowno].cells[26].innerText;
            txtGSTNo.value = grv_PayeeList.rows[rowno].cells[27].innerText;
            txtgstprefx.value = grv_PayeeList.rows[rowno].cells[28].innerText;

            //debugger;
            var i = 0;
            for (i = 0; i <= grv_PayeeList.rows.length - 1; i++) {
                if (i != 0) {
                    if (hdnPayeeID.value == grv_PayeeList.rows[i].cells[16].innerText) {
                        grv_PayeeList.rows[i].style.backgroundColor = "DarkGray";
                    }
                    else {
                        grv_PayeeList.rows[i].style.backgroundColor = "white";
                    }
                }
            }



        }

        function hover(value, rowno) {
            //debugger;
            var grv_PayeeList = document.getElementById("<%=grv_PayeeList.ClientID%>");
            var hdnPayeeID = document.getElementById("<%=hdnPayeeID.ClientID%>");

            rowno = (parseInt(rowno) + 1);

            if (value == 'in') {
                if (hdnPayeeID.value != grv_PayeeList.rows[rowno].cells[14].innerText) {
                    grv_PayeeList.rows[rowno].style.backgroundColor = "#ffff99";
                }
            }
            else {
                if (hdnPayeeID.value != grv_PayeeList.rows[rowno].cells[14].innerText) {
                    grv_PayeeList.rows[rowno].style.backgroundColor = "white";
                }
            }

        }

        function Validate_AddNew() {
            var hdnPayeeID = document.getElementById("<%=hdnPayeeID.ClientID%>");
            var ddlTransType = document.getElementById("<%=ddlTransType.ClientID%>");
            var txtChequeIssueTowhom = document.getElementById("<%=txtChequeIssueTowhom.ClientID%>");
            var txtAccountHolderName = document.getElementById("<%=txtAccountHolderName.ClientID%>");
            var txtAccountNo = document.getElementById("<%=txtAccountNo.ClientID%>");
            var txtBankName = document.getElementById("<%=txtBankName.ClientID%>");
            var txtBranchName = document.getElementById("<%=txtBranchName.ClientID%>");

            var txtPayeeName = document.getElementById("<%=txtPayeeName.ClientID%>");
            var txt_Address = document.getElementById("<%=txt_Address.ClientID%>");
            var ddlState = document.getElementById("<%=ddlState.ClientID%>");
            var txtContactNo = document.getElementById("<%=txtContactNo.ClientID%>");
            var txtPanNo = document.getElementById("<%=txtPanNo.ClientID%>");
            var txtEMailId = document.getElementById("<%=txtEMailId.ClientID%>");
            var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");

            hdnPayeeID.value = '0';
            txtPayeeName.value = '';
            txt_Address.value = '';
            ddlState.selectedIndex = 0;
            txtContactNo.value = '';
            txtPanNo.value = '';
            txtEMailId.value = '';
            ddlIsActive.selectedIndex = 0;

            ddlTransType.selectedIndex = 0;
            txtChequeIssueTowhom.value = '';
            txtAccountHolderName.value = '';
            txtAccountNo.value = '';
            txtBankName.value = '';
            txtBranchName.value = '';

            return false;

        }

        function Validate_Save() {
            //debugger;
            var ReturnValue = true;
            var strErrorMessage = "";
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var ddlTransType = document.getElementById("<%=ddlTransType.ClientID%>");
            var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
            var txtChequeIssueTowhom = document.getElementById("<%=txtChequeIssueTowhom.ClientID%>");
            var txtAccountHolderName = document.getElementById("<%=txtAccountHolderName.ClientID%>");
            var txtAccountNo = document.getElementById("<%=txtAccountNo.ClientID%>");
            var txtBankName = document.getElementById("<%=txtBankName.ClientID%>");
            var txtBranchName = document.getElementById("<%=txtBranchName.ClientID%>");
            var txtPanNo = document.getElementById("<%=txtPanNo.ClientID%>");
            var txtPayeeName = document.getElementById("<%=txtPayeeName.ClientID%>");
            var txt_Address = document.getElementById("<%=txt_Address.ClientID%>");
            var ddlState = document.getElementById("<%=ddlState.ClientID%>");
            var txtContactNo = document.getElementById("<%=txtContactNo.ClientID%>");
            var ddlIsActive = document.getElementById("<%=ddlIsActive.ClientID%>");
            var txtIFSC_code = document.getElementById("<%=txtIFSC_code.ClientID%>");

            if (ddlIsActive.selectedindex == 0) {
                strErrorMessage = "Please Select Payee Active Status!";
                ddlIsActive.focus();
                ReturnValue = false;
            }

            if (txtPayeeName.value == '') {
                strErrorMessage = "Please Enter Payee Name to Continue!";
                txtPayeeName.focus();
                ReturnValue = false;
            }
            else if (txt_Address.value == '') {
                strErrorMessage = "Please Enter Payee Address Name to Continue!";
                ReturnValue = false;
                txt_Address.focus();
            }
            else if (ddlState.selectedindex == 0) {
                strErrorMessage = "Please Select Payee State to Continue!";
                ReturnValue = false;
                ddlState.focus();
            }
            else if (txtContactNo.value == '') {
                strErrorMessage = "Please Enter Contact No to Continue!";
                ReturnValue = false;
                txtContactNo.focus();
            }
            else if (txtPanNo.value != '') {
                var regex1 = /^[A-Z]{5}\d{4}[A-Z]{1}$/;  //this is the pattern of regular expersion
                if (regex1.test(txtPanNo.value) == false) {
                    strErrorMessage = "Please enter valid pan number";
                    ReturnValue = false;
                    txtPanNo.focus();
                }
            }

            if (ddlTransType.selectedIndex == 0) {
                strErrorMessage = "Please Select Transaction Type to Continue!";
                ReturnValue = false;
                ddlTransType.focus();
            }
            else if (ddlTransType.value == '1') {

                if (txtChequeIssueTowhom.value == '') {
                    strErrorMessage = "Please enter Cheque Whom to Issue Details!";
                    ReturnValue = false;
                    txtChequeIssueTowhom.focus();
                }
            }
            else if (ddlTransType.value == '2') {

                if (txtAccountHolderName.value == '') {
                    strErrorMessage = "Please enter Account Holder Name!";
                    ReturnValue = false;
                    txtAccountHolderName.focus();
                }
                else if (txtAccountNo.value == '') {
                    strErrorMessage = "Please enter Account No!";
                    ReturnValue = false;
                    txtAccountNo.focus();

                }
                else if (txtBankName.value == '') {
                    strErrorMessage = "Please enter Bank Name !";
                    ReturnValue = false;
                    txtBankName.focus();

                }
                else if (txtBranchName.value == '') {
                    strErrorMessage = "Please enter Branch Name !";
                    ReturnValue = false;
                    txtBranchName.focus();

                }


            }
            else if (ddlTransType.value == "Both") {


            }

            else if (ddlTransType.value == '4') {

                if (txtIFSC_code.value == '') {
                    strErrorMessage = "Please enter IFSC Code!";
                    ReturnValue = false;
                    txtIFSC_code.focus();
                }
                else if (txtAccountNo.value == '') {
                    strErrorMessage = "Please enter Account No!";
                    ReturnValue = false;
                    txtAccountNo.focus();

                }
            }


            lblMessage.innerText = strErrorMessage;
            window.scrollTo(0, 0);

            return ReturnValue;
        }



    </script>

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="2">
        <tr>
            <td colspan="8" style="height: 21px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Visible="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 21px">&nbsp;Payee Master Info
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 19px"></td>
            <td class="TableTitle" style="width: 146px; height: 19px">&nbsp; Name <span style="color: #FF0000">*</span>
            </td>
            <td class="TableGrid" style="width: 89px; height: 19px">
                <asp:TextBox ID="txtPayeeName" runat="server" MaxLength="150" SkinID="txtSkin" ValidationGroup="Save_Validate"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 19px">&nbsp;
            </td>
            <td colspan="2" style="height: 19px">
                <asp:HiddenField ID="hdnPayeeID" runat="server" Value="0" />
            </td>
            <td style="width: 100px; height: 19px"></td>
        </tr>
        <tr>
            <td style="width: 8px; height: 13px"></td>
            <td class="TableTitle" style="width: 146px; height: 13px;">&nbsp;Address <span style="color: red">*</span>
            </td>
            <td class="TableGrid" colspan="4" style="height: 13px">
                <asp:TextBox ID="txt_Address" runat="server" Height="29px" MaxLength="200" SkinID="txtSkin"
                    TextMode="MultiLine" ValidationGroup="Save_Validate" Width="324px"></asp:TextBox>
            </td>
            <td class="TableTitle">&nbsp;State <span style="color: #FF0000">*</span>&nbsp;
            </td>
            <td class="TableGrid">
                <asp:UpdatePanel ID="up_ddlState" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlState" runat="server" SkinID="ddlSkin" ValidationGroup="Save_Validate"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 8px"></td>
            <td class="TableTitle" style="width: 146px">&nbsp;Contact No&nbsp;
            </td>
            <td class="TableGrid" style="width: 89px; color: #800000; background-color: #faebd7;">
                <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin" ValidationGroup="Save_Validate"></asp:TextBox>
            </td>
            <td class="TableTitle">&nbsp; Email ID
            </td>
            <td class="TableGrid" colspan="3" style="color: #800000; background-color: #faebd7;">
                <asp:TextBox ID="txtEMailId" runat="server" SkinID="txtSkin" Width="211px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="color: #800000; background-color: #faebd7">
            <td style="width: 8px; height: 22px"></td>
            <td class="TableTitle" style="width: 146px; height: 22px;">&nbsp;PAN No
            </td>
            <td class="TableGrid" colspan="1" style="height: 22px">
                <asp:TextBox ID="txtPanNo" runat="server" MaxLength="10" SkinID="txtSkin" ValidationGroup="Save_Validate"></asp:TextBox>
            </td>
            <td class="TableTitle">&nbsp;Is Active&nbsp;
            </td>
            <td class="TableGrid" style="width: 100px; height: 22px;">
                <asp:DropDownList ID="ddlIsActive" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="true">Yes</asp:ListItem>
                    <asp:ListItem Value="false">No</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr style="color: #800000; background-color: #faebd7">
            <td style="width: 8px; height: 22px">&nbsp;
            </td>
            <td class="TableTitle" style="width: 146px; height: 22px;">GST Active
            </td>
            <td class="TableGrid" colspan="1" style="height: 22px">
                <asp:UpdatePanel ID="UP_ddlIsActiveGST" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlIsActiveGST" runat="server" SkinID="ddlSkin" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlIsActiveGST_SelectedIndexChanged">
                            <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="true">Yes</asp:ListItem>
                    <asp:ListItem Value="false">No</asp:ListItem>--%>
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlIsActiveGST" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="TableTitle">GST No
            </td>
            <td class="TableGrid" style="width: 100px; height: 22px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; txtGST_code               
                <asp:UpdatePanel ID="Up_txtgstprefx" runat="server">                    
                    <ContentTemplate>
                        <asp:TextBox ID="txtgstprefx" runat="server" SkinID="txtSkin" Font-Bold="true" ForeColor="Black"
                            Width="30px" Enabled="false"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UP_txtGSTNo" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtGSTNo" runat="server" OnKeyup="UpperLetter(this);" SkinID="txtSkin"
                            MaxLength="14" ValidationGroup="Save_Validate" Width="102px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="TableTitle">HSN/SAC code
            </td>
            <td class="TableGrid" style="width: 100px; height: 22px;">&nbsp;
                <asp:UpdatePanel ID="UP_txtGST_code" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtGST_code" runat="server" MaxLength="6" SkinID="txtSkin" ValidationGroup="Save_Validate"
                            Width="111px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="color: #800000; background-color: #faebd7">
            <td style="width: 8px; height: 22px">&nbsp;
            </td>
            <td class="TableTitle" style="width: 146px; height: 22px;">NDC Signed
            </td>
            <td class="TableGrid" colspan="1" style="height: 22px">
                <asp:DropDownList ID="ddlND" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="true">Yes</asp:ListItem>
                    <asp:ListItem Value="false">No</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td class="TableTitle">valid From&nbsp;
            </td>
            <td class="TableGrid" style="width: 100px; height: 22px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtNDvalidfrom" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;
                        </td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img4" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtNDvalidfrom.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">valid Upto
            </td>
            <td class="TableGrid" style="width: 100px; height: 22px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtNdvalidupto" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;
                        </td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img5" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtNdvalidupto.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="color: #800000; background-color: #faebd7">
            <td style="width: 8px; height: 22px">&nbsp;
            </td>
            <td class="TableTitle" style="width: 146px; height: 22px;">MOU Signed
            </td>
            <td class="TableGrid" colspan="1" style="height: 22px">
                <asp:DropDownList ID="ddlmou" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="true">Yes</asp:ListItem>
                    <asp:ListItem Value="false">No</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td class="TableTitle">valid From&nbsp;
            </td>
            <td class="TableGrid" style="width: 100px; height: 22px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtMouvalidfrom" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;
                        </td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtMouvalidfrom.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">valid Upto
            </td>
            <td class="TableGrid" style="width: 100px; height: 22px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtMouvalidupto" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;
                        </td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtMouvalidupto.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px; height: 17px"></td>
            <td class="TableHeader" colspan="7" style="height: 17px;">&nbsp;Transaction Type Selection
            </td>
        </tr>
        <tr>
            <td style="width: 8px"></td>
            <td class="TableTitle" style="width: 146px">&nbsp;Transaction Types
            </td>
            <td class="TableGrid" style="width: 89px">
                <asp:DropDownList ID="ddlTransType" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">By Cheuqe</asp:ListItem>
                    <asp:ListItem Value="2">By Online Transfer</asp:ListItem>
                    <asp:ListItem Value="4">By NEFT</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px"></td>
            <td class="TableHeader" colspan="7">&nbsp;Cheque Transaction Details
            </td>
        </tr>
        <tr>
            <td style="width: 8px"></td>
            <td class="TableTitle" style="width: 146px">&nbsp;Cheque Issue to whom
            </td>
            <td class="TableGrid" colspan="2">
                <asp:TextBox ID="txtChequeIssueTowhom" runat="server" SkinID="txtSkin" Width="224px"></asp:TextBox>
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px"></td>
            <td class="TableHeader" colspan="7">&nbsp;NEFT/Online Payment Transaction Details
            </td>
        </tr>
        <tr>
            <td style="width: 8px"></td>
            <td class="TableTitle" style="width: 146px">&nbsp;Account Holder Name
            </td>
            <td class="TableGrid" style="width: 89px">
                <asp:TextBox ID="txtAccountHolderName" runat="server" SkinID="txtSkin" Width="123px"></asp:TextBox>
            </td>
            <td class="TableTitle" style="width: 100px">&nbsp;Account No
            </td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtAccountNo" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td class="TableTitle" style="width: 100px">&nbsp;A/C Type
            </td>
            <td class="TableGrid" style="width: 100px">
                <asp:DropDownList ID="ddlac_type" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="0">---Select----</asp:ListItem>
                    <asp:ListItem Value="1">Saving</asp:ListItem>
                    <asp:ListItem Value="2">Current</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 8px"></td>
            <td class="TableTitle" style="width: 146px">&nbsp;Bank Name
            </td>
            <td class="TableGrid" style="width: 89px">
                <asp:TextBox ID="txtBankName" runat="server" SkinID="txtSkin" Width="121px"></asp:TextBox>
            </td>
            <td class="TableTitle" style="width: 100px">&nbsp;Branch Name
            </td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtBranchName" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td class="TableTitle" style="width: 146px">&nbsp;IFSC Code
            </td>
            <td class="TableGrid" style="width: 89px">
                <asp:TextBox ID="txtIFSC_code" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 13px">&nbsp; &nbsp;
                <br />
                &nbsp;&nbsp;<asp:Button ID="btnSaveChanges" runat="server" BorderColor="#400000"
                    BorderWidth="1px" Font-Bold="False" OnClick="btnSaveChanges_Click" Text="Save Changes"
                    ValidationGroup="Save_Validate" Width="105px" />
                &nbsp;<asp:Button ID="btnAddnew" runat="server" BorderWidth="1px" Font-Bold="False"
                    Font-Italic="False" OnClick="btnAddnew_Click" Text="Add" Width="68px" />
                <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Font-Bold="False" OnClick="btnCancel_Click"
                    Text="Cancel" Width="83px" />
                <br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px; height: 13px"></td>
            <td colspan="7" style="height: 13px"></td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 13px">&nbsp; Search By Payee Name
            </td>
        </tr>
        <tr>
            <td style="width: 8px"></td>
            <td class="TableTitle" style="width: 146px">&nbsp;Payee Name
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtPayeeNameSearch" runat="server" SkinID="txtSkin"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" BorderColor="#400000" BorderWidth="1px"
                    Text="Search" OnClick="btnSearch_Click" />&nbsp;
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px"></td>
            <td colspan="7">
                <asp:Panel ID="pnlPayeeList" runat="server" Height="178px" ScrollBars="Both" Width="839px">
                    <asp:GridView ID="grv_PayeeList" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                        OnRowDataBound="grv_PayeeList_RowDataBound" Width="100%" Height="136px">
                        <Columns>
                            <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                            <asp:BoundField DataField="Payee_Name" HeaderText="Name" />
                            <asp:BoundField DataField="Payee_Address" HeaderText="Address" />
                            <asp:BoundField DataField="Payee_City" HeaderText="City" />
                            <asp:BoundField DataField="Payee_ContactNo" HeaderText="Contact No" />
                            <asp:BoundField DataField="Payee_EmailID" HeaderText="Email" />
                            <asp:BoundField DataField="Payee_TransactionType" HeaderText="Trans Type" />
                            <asp:BoundField DataField="Payee_Issue_Name" HeaderText="Chq Issue " />
                            <asp:BoundField DataField="Account_Holder_Name" HeaderText="Account Holder" />
                            <asp:BoundField DataField="Account_No" HeaderText="Account No" />
                            <asp:BoundField DataField="Bank_Name" HeaderText="Bank Name" />
                            <asp:BoundField DataField="Branch_Name" HeaderText="Branch Name" />
                            <asp:BoundField DataField="Pan_No" HeaderText="Pan No" />
                            <asp:BoundField DataField="IFSC_code" HeaderText="IFSC Code" />
                            <asp:BoundField DataField="Is_Active" HeaderText="Is Active" />
                            <asp:BoundField DataField="BranchID" HeaderText="BranchID"></asp:BoundField>
                            <asp:BoundField DataField="Payee_ID" HeaderText="Payee"></asp:BoundField>
                            <asp:BoundField DataField="TransactionTypeID" HeaderText="TypeID"></asp:BoundField>
                            <asp:BoundField DataField="Is_ActiveID" HeaderText="ActiveID"></asp:BoundField>
                            <asp:BoundField DataField="Account_type" HeaderText="Account_type"></asp:BoundField>
                            <asp:BoundField DataField="ND_status" HeaderText="ND status"></asp:BoundField>
                            <asp:BoundField DataField="MOU_status" HeaderText="MOU status"></asp:BoundField>
                            <asp:BoundField DataField="ND_validfrom" HeaderText="ND validfrom"></asp:BoundField>
                            <asp:BoundField DataField="ND_validupto" HeaderText="ND validupto" />
                            <asp:BoundField DataField="MOU_validfrom" HeaderText="MOU validfrom"></asp:BoundField>
                            <asp:BoundField DataField="MOU_validupto" HeaderText="MOU validupto"></asp:BoundField>
                            <asp:BoundField DataField="GST_Type" HeaderText="Is GST Active"></asp:BoundField>
                            <asp:BoundField DataField="GST_Amount" HeaderText="GST_NO"></asp:BoundField>
                            <asp:BoundField DataField="GST_prefx" HeaderText="GST_prefx"></asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="TableTitle" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="8">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px"></td>
            <td class="TableTitle" colspan="7"></td>
        </tr>
        <tr>
            <td style="width: 8px"></td>
            <td style="width: 146px">&nbsp;
            </td>
            <td style="width: 89px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
    </table>

</asp:Content>
