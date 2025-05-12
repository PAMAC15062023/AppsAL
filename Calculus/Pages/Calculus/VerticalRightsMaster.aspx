<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="VerticalRightsMaster.aspx.cs" Inherits="Pages_Calculus_VerticalRightsMaster"
    Title="Vertical Rights Master" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function Validate_SearchUserID() {
            Message = '';
            returnValue = true;
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var ddlUserList = document.getElementById("<%=ddlUserList.ClientID%>");



            if (ddlUserList.selectedIndex == 0) {
                Message = 'Please enter UserID Or Name to continue!';
                ddlUserList.focus();
                returnValue = false;
            }

            lblMessage.innerText = Message;
            lblMessage.className = 'ErrorMessage';
            return returnValue;
        }

        function Validate_Save() {
            Message = '';
            returnValue = true;
            var ddlUserList = document.getElementById("<%=ddlUserList.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var hdnVerticalRightsID = document.getElementById("<%=hdnVerticalRightsID.ClientID%>");
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            var chkPCPA = document.getElementById("<%=chkPCPA.ClientID%>");
            var chkPFRC = document.getElementById("<%=chkPFRC.ClientID%>");
            var chkPDCR = document.getElementById("<%=chkPDCR.ClientID%>");
            var chkPTPU = document.getElementById("<%=chkPTPU.ClientID%>");
            var chkPRSP = document.getElementById("<%=chkPRSP.ClientID%>");
            var chkPCPV = document.getElementById("<%=chkPCPV.ClientID%>");
            var chkAdmin = document.getElementById("<%=chkAdmin.ClientID%>");
            var chkEDP = document.getElementById("<%=chkEDP.ClientID%>");

            var chkAcct = document.getElementById("<%=chkAcct.ClientID%>");
            var chkHR = document.getElementById("<%=chkHR.ClientID%>");
            var CheckCollection = document.getElementById("<%=CheckCollection.ClientID%>");
            var ChkSSU = document.getElementById("<%=ChkSSU.ClientID%>");
            var ChkHSU = document.getElementById("<%=ChkHSU.ClientID%>");
            var ChkRCU = document.getElementById("<%=ChkRCU.ClientID%>");
            var ChkEBC = document.getElementById("<%=ChkEBC.ClientID%>");
            var ChkISO = document.getElementById("<%=ChkISO.ClientID%>");
            var ChkBD = document.getElementById("<%=ChkBD.ClientID%>");

            var Count = 0;

            if (ddlUserList.selectedIndex == 0) {
                Message = 'Please Select UserID to Continue!';
                ddlUserList.focus();
                returnValue = false;
            }
            if (ddlBranchList.selectedIndex == 0) {
                Message = 'Please Select Branch to Continue!';
                ddlBranchList.focus();
                returnValue = false;
            }
            if (chkPCPA.checked == true) {
                Count = Count + 1;
            }
            if (chkPFRC.checked == true) {
                Count = Count + 1;
            }
            if (chkPDCR.checked == true) {
                Count = Count + 1;
            }
            if (chkPTPU.checked == true) {
                Count = Count + 1;
            }
            if (chkPRSP.checked == true) {
                Count = Count + 1;
            }
            if (chkPCPV.checked == true) {
                Count = Count + 1;
            }

            if (chkAdmin.checked == true) {
                Count = Count + 1;
            }

            if (chkEDP.checked == true) {
                Count = Count + 1;
            }

            if (chkAcct.checked == true) {
                Count = Count + 1;
            }

            if (chkHR.checked == true) {
                Count = Count + 1;
            }
            if (CheckCollection.checked == true) {
                Count = Count + 1;
            }
            if (ChkSSU.checked == true) {
                Count = Count + 1;
            }
            if (ChkHSU.checked == true) {
                Count = Count + 1;
            }
            if (ChkRCU.checked == true) {
                Count = Count + 1;
            }
            if (ChkEBC.checked == true) {
                Count = Count + 1;
            }
            if (ChkISO.checked == true) {
                Count = Count + 1;
            }
            if (ChkBD.checked == true) {
                Count = Count + 1;
            }
            if (Count == 0) {
                Message = 'Please Assign any one Vertical Right to Continue!';
            }

            lblMessage.innerText = Message;
            lblMessage.className = 'ErrorMessage';
            return returnValue;
        }

        function hover(value, rowno, AutoNo) {

            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
            var hdnVerticalRightsID = document.getElementById("<%=hdnVerticalRightsID.ClientID%>");

            rowno = (parseInt(rowno) + 1);

            if (hdnVerticalRightsID.value == AutoNo) {

                grv_GroupInfo.rows[rowno].style.backgroundColor = "LightGrey";
            }

            if (value == 'in') {
                if (hdnVerticalRightsID.value != AutoNo) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "#ffff33";
                }
            }
            else {
                if (hdnVerticalRightsID.value != AutoNo) {
                    grv_GroupInfo.rows[rowno].style.backgroundColor = "white";
                }
            }
        }


        function Get_UserVerticalDetailsFor_Modify(UserID, BranchID, AutoNo, varPCPA, varPCPV, varPFRC, varPTPU, varPDCR, varPRSP, varAdmin, varEDP, varAcct, varHR, varCollection,varSSU,varHSU,varRCU,varEBC,varISO,varBD, rowno) {
            var ddlUserList = document.getElementById("<%=ddlUserList.ClientID%>");
            var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
            var hdnVerticalRightsID = document.getElementById("<%=hdnVerticalRightsID.ClientID%>");
            var chkPCPA = document.getElementById("<%=chkPCPA.ClientID%>");
            var chkPFRC = document.getElementById("<%=chkPFRC.ClientID%>");
            var chkPDCR = document.getElementById("<%=chkPDCR.ClientID%>");
            var chkPTPU = document.getElementById("<%=chkPTPU.ClientID%>");
            var chkPRSP = document.getElementById("<%=chkPRSP.ClientID%>");
            var chkPCPV = document.getElementById("<%=chkPCPV.ClientID%>");
            var chkAdmin = document.getElementById("<%=chkAdmin.ClientID%>");
            var chkEDP = document.getElementById("<%=chkEDP.ClientID%>");

            var chkAcct = document.getElementById("<%=chkAcct.ClientID%>");
            var chkHR = document.getElementById("<%=chkHR.ClientID%>");
            var CheckCollection = document.getElementById("<%=CheckCollection.ClientID%>");
            var ChkSSU = document.getElementById("<%=ChkSSU.ClientID%>");
            var ChkHSU = document.getElementById("<%=ChkHSU.ClientID%>");
            var ChkRCU = document.getElementById("<%=ChkRCU.ClientID%>");
            var ChkEBC = document.getElementById("<%=ChkEBC.ClientID%>");
            var ChkISO = document.getElementById("<%=ChkISO.ClientID%>");
            var ChkBD = document.getElementById("<%=ChkBD.ClientID%>");

            ddlUserList.value = UserID;
            ddlBranchList.value = BranchID;
            hdnVerticalRightsID.value = AutoNo;

            if (varPCPA != 0) {
                chkPCPA.checked = true;
            }
            else {
                chkPCPA.checked = false;
            }

            if (varPCPV != 0) {
                chkPCPV.checked = true;
            }
            else {
                chkPCPV.checked = false;
            }

            if (varPFRC != 0) {
                chkPFRC.checked = true;
            }
            else {
                chkPFRC.checked = false;
            }

            if (varPTPU != 0) {
                chkPTPU.checked = true;
            }
            else {
                chkPTPU.checked = false;
            }

            if (varPDCR != 0) {
                chkPDCR.checked = true;
            }
            else {
                chkPDCR.checked = false;
            }
            if (varPRSP != 0) {
                chkPRSP.checked = true;
            }
            else {
                chkPRSP.checked = false;
            }

            if (varAdmin != 0) {
                chkAdmin.checked = true;
            }
            else {
                chkAdmin.checked = false;
            }

            if (varEDP != 0) {
                chkEDP.checked = true;
            }
            else {
                chkEDP.checked = false;
            }

            if (varAcct != 0) {
                chkAcct.checked = true;
            }
            else {
                chkAcct.checked = false;
            }

            if (varHR != 0) {
                chkHR.checked = true;
            }
            else {
                chkHR.checked = false;
            }
            if (varCollection != 0) {
                CheckCollection.checked = true;
            }
            else {
                CheckCollection.checked = false;
            }
            if (varSSU != 0) {
                ChkSSU.checked = true;
            }
            else {
                ChkSSU.checked = false;
            }
            if (varHSU != 0) {
                ChkHSU.checked = true;
            }
            else {
                ChkHSU.checked = false;
            }
            if (varRCU != 0) {
                ChkRCU.checked = true;
            }
            else {
                ChkRCU.checked = false;
            }
            if (varEBC != 0) {
                ChkEBC.checked = true;
            }
            else {
                ChkEBC.checked = false;
            }
            if (varISO != 0) {
                ChkISO.checked = true;
            }
            else {
                ChkISO.checked = false;
            }
            if (varBD != 0) {
                ChkBD.checked = true;
            }
            else {
                ChkBD.checked = false;
            }

            var grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");

            var i = 0;
            for (i = 0; i <= grv_GroupInfo.rows.length - 1; i++) {
                if (i != 0) {

                    grv_GroupInfo.rows[i].style.backgroundColor = "white";

                }
            }

            rowno = (parseInt(rowno) + 1);

            if (hdnVerticalRightsID.value == AutoNo) {
                grv_GroupInfo.rows[rowno].style.backgroundColor = "LightGrey";
            }

        } 
    </script>
    <table>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="8" class="TableHeader">
                &nbsp; Vertical Rights Master
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;UserID /Name
            </td>
            <td class="TableGrid" colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 163px">
                    <tr>
                        <td style="height: 20px">
                            <asp:TextBox ID="txtUserID" runat="server" AutoPostBack="True" MaxLength="100" OnTextChanged="txtUserID_TextChanged"
                                SkinID="txtSkin"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 20px;">
                            <asp:DropDownList ID="ddlUserList" runat="server" SkinID="ddlSkin">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
                <asp:LinkButton ID="lnkUserDetails" runat="server" Width="69px">User Status</asp:LinkButton>
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnVerticalRightsID" runat="server" Value="0" />
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;" class="TableTitle">
                &nbsp;Branch
            </td>
            <td style="width: 100px; height: 15px;" class="TableGrid">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td style="height: 15px;" class="TableTitle">
            </td>
            <td style="width: 100px; height: 15px;" class="TableGrid">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 15px">
            </td>
            <td class="TableTitle" style="width: 100px; height: 15px">
                &nbsp;Vertical
            </td>
            <td class="TableGrid" colspan="3" style="height: 15px">
                <table border="1" cellpadding="2" bordercolor="gray" cellspacing="0">
                    <tr>
                        <td style="width: 102px; height: 26px;">
                            <asp:CheckBox ID="chkPCPA" runat="server" Text="PCPA" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkPCPV" runat="server" Text="PCPV" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkPTPU" runat="server" Text="PTPU" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkPFRC" runat="server" Text="PFRC" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkPDCR" runat="server" Text="PDCR" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkPRSP" runat="server" Text="PRSP" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkAdmin" runat="server" Text="Admin" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkEDP" runat="server" Text="EDP" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkAcct" runat="server" Text="Account" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="chkHR" runat="server" Text="HR" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="CheckCollection" runat="server" Text="Collection" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="ChkSSU" runat="server" Text="SSU" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="ChkHSU" runat="server" Text="HSU" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="ChkRCU" runat="server" Text="RCU" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="ChkEBC" runat="server" Text="EBC" />
                        </td>
                         <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="ChkISO" runat="server" Text="ISO" />
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:CheckBox ID="ChkBD" runat="server" Text="BD" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="height: 15px" class="TableGrid" colspan="2">
                &nbsp;
            </td>
            <td style="width: 100px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="height: 33px;" class="TableTitle" colspan="8">
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Save" Width="72px"
                    OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnAddNew" runat="server" BorderWidth="1px" Text="Add New" Width="72px"
                    OnClick="btnAddNew_Click" />
                <asp:Button ID="btnGo" runat="server" BorderWidth="1px" Font-Bold="False" OnClick="btnGo_Click"
                    Text="View Rights" Width="87px" />
                <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="72px"
                    OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 22px">
                &nbsp;Vertical Rights User Wise List
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:GridView ID="grv_GroupInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="grv_GroupInfo_RowDataBound"
                    CssClass="mGrid">
                    <Columns>
                        <asp:BoundField DataField="AutoNo" HeaderText="AutoNo" />
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name" HtmlEncodeFormatString="False"
                            InsertVisible="False" />
                        <asp:TemplateField HeaderText="Branch Code">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BranchCode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblBranchCode" runat="server" Text='<%# Bind("BranchCode") %>' ToolTip='<%# Bind("BranchID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                        <asp:BoundField DataField="UserId" HeaderText="User Id" />
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:TemplateField HeaderText="PCPA">
                            <ItemTemplate>
                                <asp:Label ID="lblPCPA" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"PCPA"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PCPV">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblPCPV" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"PCPV"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PFRC">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblPFRC" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"PFRC"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PDCR">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblPDCR" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"PDCR"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PTPU">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblPTPU" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"PTPU"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PRSP">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblPRSP" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"PRSP"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Admin">
                            <ItemTemplate>
                                <asp:Label ID="lblAdmin" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"Admin")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EDP">
                            <ItemTemplate>
                                <asp:Label ID="lblEDP" runat="server" Font-Names="Wingdings 2" Font-Size="12pt" Text="R"
                                    ToolTip='<%# (DataBinder.Eval(Container.DataItem,"EDP")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblAcct" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"Account"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HR">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblHR" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"HR"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Collection">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblCollection" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"Collection"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SSU">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblSSU" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"SSU"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HSU">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblHSU" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"HSU"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="EBC">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblEBC" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"EBC"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="RCU">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblRCU" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"RCU"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="ISO">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblISO" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ISO"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BD">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblBD" runat="server" Font-Names="Wingdings 2" Font-Size="12pt"
                                    Text="R" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"BD"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
