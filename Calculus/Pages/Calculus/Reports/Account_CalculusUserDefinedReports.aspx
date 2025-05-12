<%@ Page Language="C#"  MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Account_CalculusUserDefinedReports.aspx.cs" Inherits="Pages_Calculus_Reports_Account_CalculusUserDefinedReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../../popcalendar.js" >
</script>
<script language="javascript" type="text/javascript" >

    function Reset_values() {
        var ddlReportList = document.getElementById("<%=ddlReportList.ClientID%>");
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate = document.getElementById("<%=txtToDate.ClientID%>");
        var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");

        ddlBranchList.selectedIndex = 0;
        ddlReportList.selectedIndex = 0;
        lblMessage.innerText = '';
        txtFromDate.value = '';
        txtToDate.value = '';


        return false;
    }

    function validate_Export() {

        var ReturnValue = true;
        var Message = '';
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

        var gvExportReport = document.getElementById("<%=gvExportReport.ClientID%>");
        if (gvExportReport != null) {
            if (gvExportReport.rows.length == 0) {
                Message = 'No Data Found!';
                ReturnValue = false;
            }
        }
        else {
            Message = 'No Data Found!';
            ReturnValue = false;
        }

        lblMessage.innerText = Message;
        return ReturnValue;
    }
    function validate_Search() {
        var ReturnValue = true;
        var Message = '';
        var ddlReportList = document.getElementById("<%=ddlReportList.ClientID%>");
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate = document.getElementById("<%=txtToDate.ClientID%>");
        var ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
        var ddlselectedIndex = ddlReportList.selectedIndex;
        if (ddlselectedIndex == 0) {
            Message = 'Please select Report Type!';
            ReturnValue = false;
        }
        else {
            if (((ddlselectedIndex == 3) && (ddlBranchList.selectedIndex == 0)) || ((ddlselectedIndex == 6) && (ddlBranchList.selectedIndex == 0))) {
                Message = 'Please select Branch From List!';
                ReturnValue = false;
                ddlBranchList.focus();
            }
        }

        if (txtFromDate.value == '') {
            Message = 'Please Enter from Date!';
            ReturnValue = false;
        }
        if (txtToDate.value == '') {
            Message = 'Please Enter To Date!';
            ReturnValue = false;
        }
        lblMessage.innerText = Message;
        return ReturnValue;
    }
    function ReportList() {

        var ddlReportList = document.getElementById("<%=ddlReportList.ClientID%>");
        var lblReportHeader = document.getElementById("<%=lblReportHeader.ClientID%>");

        var SelectedIndex = ddlReportList.selectedIndex;
        if (ddlReportList.selectedIndex != 0) {
            lblReportHeader.innerText = ddlReportList.options[SelectedIndex].innerText;
        }
    }

</script>

    <table>
        <tr>
            <td colspan="8" style="height: 14px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 24px">
                &nbsp;Calculus User Defined Reports 
                Accounts</td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Reports Name</td>
            <td style="width: 19px" class="TableGrid">
                 <asp:DropDownList ID="ddlReportList" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlReportList_SelectedIndexChanged">
                    <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetVendorPaymentReportBranchWiseAllCentreAccounts_SP">Accounts Vendor Payment Report</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetUTILITYPaymentReportBranchWiseAllCentreAccounts_SP">Accounts Utility Payment Report </asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans__Get__NormalPettyCashReport__SP">Petty Cash Report</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetOtherThanPettyCashReportNew_SP">Other Than PettyCash Report</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetTDSDetailsNew_SP">TDS Payment Report</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetUtilityPaymentReportBranchWiseAllNew_SP">Utility Payment Report HSU</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetVendorPaymentReportBranchWiseHSUNew_SP">Vendor Payment Report HSU</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_MIS__SP">NEFT Payment Report</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetEPMPaymentReportBranchWiseNewAccounts_SP">Accounts EPM Payment Report</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_GetSPVendorPaymentReportBranchWiseAllCentre_SP">PAMAC Rent Payment Report</asp:ListItem>
                    <asp:ListItem Value="CalOnlineTrans_Get_Cheque_Payout_Report__SP">Cheque Payment Report</asp:ListItem>  
                </asp:DropDownList></td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Branch
            </td>
            <td style="width: 100px" class="TableGrid"><asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
            </asp:DropDownList></td>
            <td style="width: 100px" class="TableTitle">
                Status :</td>
            <td style="width: 100px" class="TableHeader">
                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin">
                 <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Accept">Accept</asp:ListItem>
                     <asp:ListItem Value="Pending">Pending</asp:ListItem>
                      <asp:ListItem Value="Reject">Reject</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td class="TableTitle">
                &nbsp;Request &nbsp;From Date</td>
            <td style="width: 19px" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px; height: 20px">
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;Request To date</td>
            <td style="width: 100px" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox></td>
                        <td style="width: 100px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 30px" class="TableTitle">
                &nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" BorderColor="Black" BorderWidth="1px"
                    Text="Search" OnClick="btnSearch_Click" />&nbsp;<asp:Button ID="btnReset" runat="server" BorderColor="Black"
                        BorderWidth="1px" Text="Reset" Width="57px" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 2px">
                &nbsp;<asp:Label ID="lblReportHeader" runat="server" Width="302px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvExportReport" runat="server" Height="100px" Width="98%">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 35px;" class="TableTitle" colspan="8">
                &nbsp;<asp:Button ID="btnExporttoExcel" runat="server" BorderColor="Black" BorderWidth="1px"
                    Text="Export" Width="94px" OnClick="btnExporttoExcel_Click" />
                <asp:Button ID="btnCancel" runat="server" BorderColor="Black" BorderWidth="1px" Text="Cancel"
                    Width="59px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 19px">
                <span style="background-color:Gray"><span style="background-color: gray"></span></span></td>
            <td style="width: 100px">
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
            <td style="width: 17px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 19px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 19px">
            </td>
            <td style="width: 100px">
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
