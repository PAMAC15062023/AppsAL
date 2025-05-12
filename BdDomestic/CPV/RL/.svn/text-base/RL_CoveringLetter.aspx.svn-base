<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RL_CoveringLetter.aspx.cs" MasterPageFile="~/CPV/RL/RL_MasterPage.master" Theme="SkinFile" Inherits="CPV_RL_RL_CoveringLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<div>
<fieldset><legend class="FormHeading">Covering Letter</legend>
        <table align="center" width="100%">
            <tr>
                <td colspan="7">
                </td>
            </tr>
            <tr>
                <td >
                     From Date<font color="red"> *</font></td>
                <td >
                    :</td>
                <td >
                    <asp:TextBox ID="txtDateFrom" runat="server" Width="155px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                    <img alt="" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtDateFrom.ClientID %>,'dd/mm/yyyy',0,0);" />
                    [dd/MM/yyyy]</td>
                
                <td >
                    To Date<font color="red"> *</font><font color="red"></font></td>
                <td >
                    :</td>
                <td >
                    <asp:TextBox ID="txtDateTo" runat="server" Width="155px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                    <img alt="" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtDateTo.ClientID %>,'dd/mm/yyyy',0,0)";/>
                    [dd/MM/yyyy]</td>
                <td >
                <asp:Button ID="btnSubmit" runat="server" SkinID="btnReportSkin"
                        OnClick="btnSubmit_Click" ValidationGroup="valGrp" /></td>
                
            </tr>
            <tr>
            <td colspan="7"><asp:Label ID="lblMessage" runat="server" SkinID="lblError"></asp:Label> </td>
            </tr>
            <tr>
                <td colspan="7">
                    &nbsp;</td>
            </tr>
        </table>
   </fieldset> 
    </div>
    
    <asp:GridView ID="gvCoverLetter" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin">
        <Columns>
            <asp:BoundField HeaderText="Sr. No"  />
            <asp:BoundField DataField="Ref_no" HeaderText="Reference Nos" />
            <asp:BoundField DataField="Case_rec_dateTime" HeaderText="Received Date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False" />
            <asp:BoundField HeaderText="Types of Verification" DataField="Verification_code" />
            <asp:BoundField DataField="Name" HeaderText="Full Name" />
            <asp:BoundField DataField="send_Datetime" HeaderText="Send Date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False"  />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsgvCoverLetter" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
    </asp:SqlDataSource>
                    <asp:ValidationSummary ID="vsDate" runat="server" ShowMessageBox="True" ShowSummary="False" Width="152px" ValidationGroup="valGrp" />
    &nbsp;
                    <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom"
                        ErrorMessage="Please Select a Start Date." Display="None" ValidationGroup="valGrp"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtDateTo"
                        ErrorMessage="Please Select a  End Date " Display="None" ValidationGroup="valGrp"></asp:RequiredFieldValidator>&nbsp;
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtDateFrom"
        Display="None" ErrorMessage="Please enter valid date format for Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="valGrp"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtDateTo"
        Display="None" ErrorMessage="Please enter valid date format for Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="valGrp"></asp:RegularExpressionValidator>
</asp:Content>