<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ICICI_MIS.aspx.cs" Inherits="Pages_ICICIRPC_ICICI_MIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>

<table style="width: 100%">
<tr>
<td>
<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</td>
</tr>
<tr>
<td colspan="2">
<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="NOTE-Please Select Any One Product For TAT Mis"></asp:Label>
</td>
</tr>
        <tr>
            <td style="width: 78px" class="TableTitle">
                From Date</td>
            <td style="width: 195px" class="TableGrid">
                <asp:TextBox ID="txtFromDate" runat="server" Width="125px"></asp:TextBox>
                           <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
            <td style="width: 49px" class="TableTitle">
                To date</td>
            <td style="width: 315px" class="TableGrid">
                <asp:TextBox ID="txtToDate" runat="server" Width="125px"></asp:TextBox>
                           <img id="ImgDate3rdCall0" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" 
                    style="width: 17px; height: 16px" /></td>
        </tr>
         <tr>
            <td style="width: 78px; height: 26px;" class="TableTitle">
                Select MIS</td>
            <td style="width: 195px; height: 26px;" class="TableGrid">
                <asp:DropDownList ID="ddlMIS" runat="server" Height="40px" Width="131px">
                    <%--<asp:ListItem Value="ICICI_tracknew">TRACKING MIS (PL)</asp:ListItem>--%>
                    <asp:ListItem Value="IRPC_ICICI_Track_AL_SP">TRACKING MIS(AL)</asp:ListItem>
                     <%--<asp:ListItem Value="HL_track">HL TRACKING MIS</asp:ListItem>--%>
                    <asp:ListItem Value="IRPC_Productivity_MIS_SP">Productivity MIS</asp:ListItem>
                     <asp:ListItem Value="IRPC_TATMIsNewICICI_PRODUCT_SP">TAT MIS</asp:ListItem>
                     <asp:ListItem Value="IRPC_Skewness_ICICIRPC_SP">Skewness Report</asp:ListItem>
               </asp:DropDownList>
            </td>
            
            <td style="width: 195px; height: 26px;" class="TableGrid">
                Select Product:</td>
            
            <td style="width: 195px; height: 26px;" class="TableGrid">
                <asp:DropDownList ID="ddlproduct" runat="server">
               <%-- <asp:ListItem Value="ALL">ALL</asp:ListItem>
                <asp:ListItem Value="PL">PL</asp:ListItem>--%>
                <asp:ListItem Value="AL">AL</asp:ListItem>
                <%--<asp:ListItem Value="HL">HL</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Export" Width="80px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" BorderWidth="1px" OnClick="btncancel_Click"
                    Text="Cancel" Width="88px" /></td>
        </tr>
        <tr>
            <td colspan="4">   
             <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvExportReport" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

