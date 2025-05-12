<%@ Page Language="C#" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" AutoEventWireup="true" CodeFile="KYC_QC_CASE_Allotment.aspx.cs" Inherits="CPV_KYC_KYC_QC_CASE_Allotment" Title="PAMAC Online Service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>


        <div>
        
        &nbsp<table cellpadding="1" cellspacing="0">
                <tr>
                    <td colspan="7">
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True"
                            Width="100%" CssClass="ErrorMessage"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TableHeader" colspan="7">
                        Quality Cheque Allotment&nbsp;
                    </td>
                </tr>
                <tr>
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
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;Case Receive
                        From Date</td>
                    <td style="width: 100px">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 100px">
                        <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td style="width: 100px">
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" /></td>
                            </tr>
                        </table>
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
                <tr>
                    <td>
                        &nbsp;Case Receive ToDate</td>
                    <td style="width: 100px">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 100px">
                        <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td style="width: 100px">
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" /></td>
                            </tr>
                        </table>
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
                <tr>
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
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click1" Text="Search"
                            Width="98px" SkinID="btnSearchSkin" /></td>
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
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:Panel ID="Panel2" runat="server" Height="346px" ScrollBars="Both" Width="958px">
                        <asp:GridView ID="gvQC" runat="server" Width="943px" CellPadding="4" OnDataBound="gvQC_DataBound" Font-Names="Tahoma" Font-Size="8pt" CssClass="GridViewStyle" Height="344px">
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <Columns>
                                <asp:TemplateField HeaderText="QC Verification type">
                                    <ItemTemplate>
                                        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                                            &nbsp;<table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="height: 20px">
                                                        <asp:CheckBox ID="chkQCRV" runat="server" Enabled="False" Text="QRV" SkinID="chkSkin" /></td>
                                                    <td style="height: 20px">
                                                        <asp:CheckBox ID="chkQCBV" runat="server" Enabled="False" Text="QBV" SkinID="chkSkin" /></td>
                                                    <td style="height: 20px">
                                                        <asp:CheckBox ID="chkQCRT" runat="server" Enabled="False" Text="QRT" SkinID="chkSkin" /></td>
                                                    <td style="width: 42px; height: 20px">
                                                        <asp:CheckBox ID="chkQCBT" runat="server" Enabled="False" Text="QBT" SkinID="chkSkin" /></td>
                                                    <td style="height: 20px">
                                                        <asp:CheckBox ID="chkQTRV" runat="server" Text="QTRV" SkinID="chkSkin" Enabled="False" /></td>
                                                    <td style="height: 20px">
                                                        <asp:CheckBox ID="chkQTBV" runat="server" Text="QTBV" SkinID="chkSkin" Enabled="False" /></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <EmptyDataTemplate>
                                &nbsp;
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        </asp:GridView>
                            <br />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="73px" SkinID="btnSaveSkin" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="73px" SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></td>
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
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;</div>

</asp:Content>

