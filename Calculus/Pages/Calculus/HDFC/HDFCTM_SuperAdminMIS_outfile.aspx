<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="HDFCTM_SuperAdminMIS_outfile.aspx.cs" Inherits="Pages_Calculus_HDFC_HDFCTM_SuperAdminMIS_outfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
     <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    <asp:Panel ID="Panel1" runat="server" Visible="true" >
    <table>
                   <tr>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Label ID="Label1" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Request From Date<span style="color : red"> *</span></asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
            </td>
            <td style="width: 100px; height: 20px" class="TableTitle">
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
            <td style="width: 100px; height: 20px"></td>


            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Label ID="Label2" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Request To date<span style="color : red"> *</span></asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            <td style="width: 100px" class="TableTitle">
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
        </tr>
    </table>
     <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           
                <asp:Button ID="btnExport" runat="server" Text="Export" BorderColor="#400000" 
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnExport_Click"  />&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" Width="105px" OnClick="btnBack_Click"
                     />&nbsp;&nbsp;
                    
            </td>
        </tr>
    </table>
   
    </asp:Panel>
    <br />

        <table style="width: 688px;">
    
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:GridView ID="GridAdminMIS" runat="server" Height="16px" Width="1200px" AutoGenerateColumns="true" CssClass="mGrid" style="display:none">
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

