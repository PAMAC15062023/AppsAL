<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" CodeFile="RL_QC_CaseStatusView.aspx.cs" Inherits="CPV_RL_RL_QC_CaseStatusView" Theme="skinFile" Title="PAMAC Online Service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%" >
<tr>
<td style="padding-left:10px">
<fieldset><legend class="FormHeading">QC Case Status View</legend>
<table  border="0" cellpadding="0" cellspacing="0" width="99%">
<tr>
<td>
Ref No.
</td>
<td>
<asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox>
</td>
<td>
Case ID
</td>
<td>
<asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox>
</td>
<td>
Applicant Name
</td>
<td>
<asp:TextBox ID="txtApplicantName" runat="server" SkinID="txtSkin" MaxLength="150"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click"/>
</td>
</tr>
</table>
<table  border="0" cellpadding="0" cellspacing="0" width="99%">
<tr></tr>
<tr>
<td>
    <asp:GridView ID="gvCaseStatusView" SkinID="gridviewSkin" runat="server" Width="99%" AutoGenerateColumns="False" OnRowCommand="gvCaseStatusView_RowCommand" OnRowCreated="gvCaseStatusView_RowCreated" OnRowDataBound="gvCaseStatusView_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvCaseStatusView_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Case ID" DataField="CASE_ID" />
            <asp:BoundField HeaderText="Ref No" DataField="REF_NO" />
            <asp:BoundField HeaderText="Applicant Name" DataField="Applicant_Name" />
            <asp:BoundField HeaderText="Verification Type" DataField="VERIFICATION_CODE" />
            <asp:TemplateField HeaderText="Select Verification Type">
                <ItemTemplate>
                    <asp:Label ID="lblRV" runat="server" Text="RV" Visible="false" />
                    
                    <asp:Label ID="lblSlashRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    <asp:Label ID="lblBV" runat="server" Text="BV" Visible="false" />
                    
                    <asp:Label ID="lblSlashBV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    <asp:Label ID="lblRT" runat="server" Text="RT" Visible="false" />
                   
                    <asp:Label ID="lblSlashRT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    <asp:Label ID="lblBT" runat="server" Text="BT" Visible="false" />
                   
                    <asp:Label ID="lblSlashBT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblPRV" runat="server" Text="PRV" Visible="false" />
                    <asp:Label ID="lblSlashPRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblREF1" runat="server" Text="REF1" Visible="false" />
                    <asp:Label ID="lblSlashREF1" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblREF2" runat="server" Text="REF2" Visible="false" />
                    <asp:Label ID="lblSlashREF2" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblRCO" runat="server" Text="RCO" Visible="false" />
                    <asp:Label ID="lblSlashRCO" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                     <%--New link add for QC - santosh--%> 
                    <asp:Label ID="lblQRV" runat="server" Text="QRV" Visible="false" />
                    <asp:Label ID="lblSlashQRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                   
                    <asp:Label ID="lblQBV" runat="server" Text="QBV" Visible="false" />
                    <asp:Label ID="lblSlashQBV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                   
                    <asp:Label ID="lblQRT" runat="server" Text="QRT" Visible="false" />
                    <asp:Label ID="lblSlashQRT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblQBT" runat="server" Text="QBT" Visible="false" />
                    <asp:Label ID="lblSlashQBT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblQTRV" runat="server" Text="QTRV" Visible="false" />
                    <asp:Label ID="lblSlashQTRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblQTBV" runat="server" Text="QTBV" Visible="false" />
                    <asp:Label ID="lblSlashQTBV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    <%--end code for QC - santosh--%> 
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
</td>
</tr>
</table>
    <asp:HiddenField ID="hidCurrentIndex" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeCode" runat="server"  />
</fieldset>
</td>
</tr>
</table>

</asp:Content>

