<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Menu3.aspx.cs" Inherits="Pages_Menu" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Menu ID="tabs1" runat="server" BackColor="Silver" Orientation="Horizontal" Width="100%" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" StaticSubMenuIndent="10px" BorderWidth="1px">
        <Items>
            <asp:MenuItem Text="Master" Value="Master">
                <asp:MenuItem NavigateUrl="~/Pages/SouchBranchMaster.aspx" Text="Source Branch Add"
                    Value="Source Branch Add"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Entry Operation" Value="Entry Operation">
                <asp:MenuItem Text="Customer Application " Value="Customer Application Entry">
                    <asp:MenuItem NavigateUrl="~/Pages/FrmBasicEntry.aspx" Text="Application Add new"
                        Value="Customer Application Entry"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/UpdateFrmBasicEntry.aspx" Text="Application Modify"
                        Value="Customer Application Update"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Schedule Update" Value="Schedule Update">
                    <asp:MenuItem NavigateUrl="~/Pages/application.aspx" Text="Schedule Add New" Value="Schedule New Entry">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/UpdateSchedule.aspx" Text="Schedule Modify"
                        Value="Schedule Modify"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Discrepancy Update" Value="Discrepancy Update" NavigateUrl="~/Pages/DiscrepancyUpdate.aspx"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/ApplicationCoveringSheet.aspx" Text="Covering Letter"
                    Value="Covering Letter"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Reports" Value="Reports">
                <asp:MenuItem NavigateUrl="~/Pages/ApplicationDiscrepancyReport.aspx" Text="Application Discrepancy Report"
                    Value="Application Discrepancy Report"></asp:MenuItem>
                <asp:MenuItem Text="Cheque Process" Value="Cheque Process">
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/DropboxMIS.aspx" Text="Dropbox MIS"
                        Value="Dropbox MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/ProcessMIS.aspx"
                        Text="Final Process MIS" Value="Final Process MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/ClosureChequeMIS.aspx"
                        Text="ForClosure Cheque MIS" Value="ForClosure Cheque MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/InvalidChequeMIS.aspx"
                        Text="Invalid Cheque MIS" Value="Invalid Cheque MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/InvalidPhysicalChequeMIS.aspx"
                        Text="Invalid Physical Cheque MIS" Value="Invalid Physical Cheque MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/InwardBTChequeMIS.aspx"
                        Text="Inward BT Identification MIS" Value="Inward BT Identification MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/NonSBIChequeMIS.aspx"
                        Text="Non SBI Cheque MIS" Value="Non SBI Cheque MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/SuspenseChequeMIS.aspx"
                        Text="Suspense Cheque MIS" Value="Suspense Cheque MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/ReturnChequeMIS.aspx"
                        Text="Return Cheque MIS" Value="Returns Cheque MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/ReturnPhysicalChequeMIS.aspx"
                        Text="Return Physical Cheque MIS" Value="Return Physical Cheque MIS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/Reports/UpCountyChequeMIS.aspx"
                        Text="UpCountry Cheque MIS" Value="UpCountry Cheque MIS"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Reports/Nano_ModelList.aspx" Text="Nano MaodelList Report"
                    Value="Nano MaodelList Report"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Transactional" Value="Transactional">
                <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/ChequeAssignment.aspx" Text="Cheque Assignment"
                    Value="Cheque Assignment"></asp:MenuItem>
                <asp:MenuItem Text="Cheque Entry" Value="Cheque Entry" NavigateUrl="~/Pages/ChequeProcessing/ChequeEntryModule.aspx"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/ChequeUploadFILES.aspx" Text="DBF File Upload"
                    Value="DBF File Upload"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/ChequeEntryReport.aspx" Text="Non SBI Generate Cheque Entry Report"
                    Value="Generate Cheque Entry Report"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/ChequeEntryReport_SBI.aspx" Text="SBI Generate Cheque Entry Report"
                    Value="SBI Generate Cheque Entry Report"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/ChequeEntryReport_SOC.aspx" Text="SOC Generate Cheque Entry Report"
                    Value="SOC Cheuqe "></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/ChequeProcessing/ChequeContactUpdate.aspx" Text="Cheque Contact No"
                    Value="Cheque Contact No"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
        <DynamicMenuStyle BackColor="#E3EAEB" CssClass="style" />
        <StaticSelectedStyle BackColor="#1C5E55" />
        <DynamicSelectedStyle BackColor="#1C5E55" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
    </asp:Menu>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
<TABLE style="FONT-SIZE: 8pt; COLOR: gray; FONT-FAMILY: Verdana; TEXT-ALIGN: left"><TBODY><TR><TD style="WIDTH: 132px; TEXT-ALIGN: left" class="tabs1">User</TD><TD style="TEXT-ALIGN: left; width: 145px;" class="tabs1"><asp:Label id="lblUserName" runat="server" Font-Bold="False"></asp:Label></TD></TR><TR style="COLOR: #808080"><TD style="WIDTH: 132px; TEXT-ALIGN: left" class="tabs1">Branch</TD><TD style="TEXT-ALIGN: left; width: 145px;" class="tabs1"><asp:Label id="lblBranch" runat="server" Font-Bold="False"></asp:Label></TD></TR><TR><TD style="WIDTH: 132px; HEIGHT: 15px; TEXT-ALIGN: left" class="tabs1">Role</TD>
<TD style="HEIGHT: 15px; TEXT-ALIGN: left; width: 145px;" class="tabs1"><asp:Label id="lblRole" runat="server" Font-Bold="False"></asp:Label></TD></TR><TR>
<TD style="WIDTH: 132px; HEIGHT: 18px; TEXT-ALIGN: left" class="tabs1">Masters Lastupdate</TD>
<TD style="HEIGHT: 18px; TEXT-ALIGN: left; width: 145px;" class="tabs1">
<asp:Label id="lblMasterFileInfo" runat="server" Font-Bold="False"></asp:Label>
    <asp:Label ID="lblInfo" runat="server" BackColor="Red" ForeColor="White" Height="15px"
        Text="[?]" Visible="False" Width="6px" Font-Bold="False"></asp:Label></TD></TR>
        <tr>
            <TD style="WIDTH: 132px; HEIGHT: 18px; TEXT-ALIGN: left" class="tabs1">Client_Name</TD>
            
             <TD style="HEIGHT: 15px; TEXT-ALIGN: left; width: 145px;" class="tabs1">
            <asp:Label id="lblClient" runat="server" Font-Bold="False"></asp:Label></TD>
            </tr>
            
            
           
        
        </TBODY></TABLE>
<marquee ><SPAN>&nbsp;<asp:Label id="Label1" runat="server" Text="[Please Select Your Desire Operation From Menu]" __designer:wfdid="w5" CssClass="dropdown"></asp:Label></SPAN></marquee>  <br />
</asp:Content>

