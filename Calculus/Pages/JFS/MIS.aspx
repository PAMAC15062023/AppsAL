<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="MIS.aspx.cs" Inherits="Pages_JFS_MIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>
    
    
    <table style="width: 100%">
    <tr>
        <td colspan="4" class="TableHeader">
    <asp:Label ID="Label1" runat="server" ForeColor="black" Text="Genrate MIS" Font-Size="Medium"></asp:Label>
    <br />
    </td>
    </tr>
        <tr>
            <td style="width: 78px" class="TableTitle">
                From Date</td>
            <td style="width: 195px" class="TableGrid">
                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                           <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
            <td style="width: 49px" class="TableTitle">
                To date</td>
            <td style="width: 315px" class="TableGrid">
                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                           <img id="ImgDate3rdCall0" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" 
                    style="width: 17px; height: 16px" /></td>
        </tr>
        <tr>
            <td style="width: 78px; height: 35px;" class="TableTitle">
                Select MIS</td>
            <td style="width: 195px; height: 35px;" class="TableGrid">
                <asp:DropDownList ID="ddlMIS" runat="server" Height="36px" Width="131px">
                    <asp:ListItem Value="sp_getdetails">JFS MIS</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
            <td style="width: 49px; height: 35px;">
                &nbsp;</td>
            <td style="height: 35px; width: 315px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Export" Width="80px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" BorderWidth="1px" OnClick="btncancel_Click"
                    Text="Cancel" Width="88px" /></td>
        </tr>
        <tr>
            <td colspan="4">    <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
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
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

