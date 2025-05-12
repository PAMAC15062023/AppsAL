<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="HDFCTM_SuperAdminDashboard.aspx.cs" Inherits="Pages_Calculus_HDFC_HDFCTM_SuperAdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

    <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>


    <table style="width: 688px;">
       <tr>
            <td>
                     <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" Width="105px" OnClick="BtnRefresh_Click" />&nbsp;&nbsp;
            </td>
       </tr>
        
         <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:GridView ID="GridDeshboard" runat="server" AutoGenerateColumns="true" Height="16px" Width="1200px" CssClass="mGrid">
                    <Columns>
                        
                   <%--     <asp:BoundField DataField="Case_Date_Recd"    HeaderText="Date of Cases Recd" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="OpeningBalance"    HeaderText="Opening Balance" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="NEWCases"    HeaderText="New Cases" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="FTNR"              HeaderText="FTNR" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="FTR"               HeaderText="FTR" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ALREADYDISBURSED"  HeaderText="ALREADY DISBURSED" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="LOCK"              HeaderText="LOCK" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="OPS_H"             HeaderText="OPS_H" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="Hold"             HeaderText="HOLD" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Total"             HeaderText="Total" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Pending"           HeaderText="Pending" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                   --%>

                    </Columns>
                </asp:GridView>
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
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnExport_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" Width="105px" OnClick="btnBack_Click" />&nbsp;&nbsp;
                    
            </td>
        </tr>
    </table>
    
    
    
    </asp:Panel>



























</asp:Content>

