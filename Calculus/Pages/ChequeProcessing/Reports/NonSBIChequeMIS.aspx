<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="NonSBIChequeMIS.aspx.cs" Inherits="NonSBIChequeMIS" Title="Non SBI Cheque MIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js">


</script>
    <table border="0" cellpadding="1" cellspacing="1">
        <tr>
            <td colspan="6" style="height: 13px">
                <asp:Label ID="lblMessage" runat="server" BackColor="Transparent" CssClass="ErrorMessage"
                    Font-Bold="True" ForeColor="Red" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 13px">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="6" headers="Y" style="height: 20px">
                &nbsp;Non SBI Cheque MIS (Other Bank)</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 135px; height: 29px">
                &nbsp;Pickup From Date</td>
            <td colspan="5" style="height: 29px; width: 789px;">
                &nbsp;<asp:TextBox ID="txtDepositFromDate" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    SkinID="txtSkin" Width="106px"></asp:TextBox>
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../SmallCalendar.png" style="width: 17px; height: 16px" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 135px">
                &nbsp;Pickup To Date</td>
            <td colspan="5" style="height: 29px; width: 789px;">
                &nbsp;<asp:TextBox ID="txtDepositToDate" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    SkinID="txtSkin" Width="106px"></asp:TextBox>
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../SmallCalendar.png" style="width: 17px; height: 16px" /></td>
        </tr>
        <tr>
            <td colspan="6">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="6">
                &nbsp; &nbsp;
                <asp:CheckBox ID="chkFileUploaded" runat="server" Font-Bold="True" Text="Already  Uploaded the DBF File "
                    Width="419px" /></td>
        </tr>
        <tr>
            <td style="width: 135px">
            </td>
            <td colspan="5" style="width: 789px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="6" style="height: 35px">
                &nbsp;&nbsp;
                <asp:Button ID="btnUpload" runat="server" BorderWidth="1px" Height="23px" OnClick="btnUpload_Click"
                    Text="Upload" Width="81px" /></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="800px">                   
                  <table border="0" id="tbExport" cellpadding="0" cellspacing="0" runat="server"  visible="true" width="100%">
                    <tr><td>               
                    <asp:GridView ID="gvUploadedDATA" runat="server" CssClass="GridViewStyle" Height="100px"
                         Width="98%">
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                    </asp:GridView>
                    </td></tr>
                    </table>                    
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="6" style="height: 33px">
                &nbsp; &nbsp;
                <asp:Button ID="btnGenerateReport" runat="server" BorderWidth="1px" OnClick="btnExport_Click"
                    Text="Generate" Width="122px" />
                <asp:Button ID="btnClose" runat="server" BorderWidth="1px" OnClick="btnClose_Click"
                    Text="Close" ToolTip="Back to Menu" Width="90px" /></td>
        </tr>
    </table>
</asp:Content>

