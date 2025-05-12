<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="DropboxMIS.aspx.cs" Inherits="DropboxMIS" Title="UpCountry Cheque MIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js">


</script>
    <table border="0" cellpadding="0" cellspacing="2">
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
                &nbsp; DropBox Cheque MIS</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 166px">
                &nbsp;&nbsp; <strong>Upload File (Drobox DBF)</strong></td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    Height="25px" Width="485px" /></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 166px; height: 29px">
                &nbsp;&nbsp; Pickup Date From</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:TextBox ID="txtDepositFromDate" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    SkinID="txtSkin" Width="106px"></asp:TextBox>
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../SmallCalendar.png" style="width: 17px; height: 16px" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 166px">
                &nbsp;&nbsp; Pickup Date To</td>
            <td colspan="5" style="height: 29px">
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
            <td style="width: 166px">
            </td>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="6" style="height: 35px">
                &nbsp;&nbsp;
                <asp:Button ID="btnUpload" runat="server" BorderWidth="1px" Height="23px" OnClick="btnUpload_Click"
                    Text="Upload" Width="97px" /></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="800px">
                    <table border="0" id="tbExport" cellpadding="0" cellspacing="0" runat="server"  visible="true" width="100%">
                    <tr><td>                
                    <asp:GridView ID="gvUploadedDATA" runat="server" CssClass="GridViewStyle" Height="100px"
                         Width="98%" AutoGenerateColumns="False" DataKeyNames="Dropcode" DataMember="Dropcode">
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                        <Columns>
                            <asp:BoundField DataField="DropCode" HeaderText="DropBox Code" />
                            <asp:BoundField DataField="Dropboxname" HeaderText="DropBox Name" />
                            <asp:BoundField DataField="Adddress" HeaderText="Address" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                            
                            <asp:BoundField DataField="Total_Cheques" HeaderText="Cheque Count (Day)" />                           
                            <asp:BoundField DataField="CUTCARD" HeaderText="CUTCARD" />
                            <asp:BoundField DataField="UNCUTCR" HeaderText="UNCUTCR" />
                            
                            <asp:BoundField DataField="BTRE" HeaderText="BTRE" />
                            <asp:BoundField DataField="QCORR" HeaderText="QCORR" />
                            <asp:BoundField DataField="CASH" HeaderText="CASH" />
                            <asp:BoundField DataField="APPL" HeaderText="APPL" />
                            <asp:BoundField DataField="NonSBIUpCntryChqs" HeaderText="NonSBIUpCntryChqs" />
                            <asp:TemplateField HeaderText="Total Count (Month) ">
                               <ItemTemplate>
                                    <asp:Label ID="lblTotalCounts" runat="server" Text='<%#Get_TotalMonthCount((string)DataBinder.Eval(Container.DataItem,"Dropcode")) %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CUTCARD" HeaderText="CUTCARD" />
                            <asp:BoundField DataField="UNCUTCR" HeaderText="UNCUTCR" />                            
                            <asp:BoundField DataField="BTRE" HeaderText="BTRE" />
                            <asp:BoundField DataField="QCORR" HeaderText="QCORR" />
                            <asp:BoundField DataField="CASH" HeaderText="CASH" />
                            <asp:BoundField DataField="APPL" HeaderText="APPL" />
                            <asp:BoundField DataField="NonSBIUpCntryChqs" HeaderText="NonSBIUpCntryChqs" />
                            
                             
                        </Columns>
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

