<%@ Page Language="C#" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" AutoEventWireup="true" Theme="skinFile" CodeFile="EBC_CaseStatusView.aspx.cs" Inherits="CPV_EBC_EBC_CaseStatusView"  %>
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
<fieldset><legend class="FormHeading">Case Status View</legend>
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
                    <asp:Label ID="lblPV" runat="server" Text="PV" Visible="false" />
                    
                    <asp:Label ID="lblSlashPV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    <asp:Label ID="lblDGV" runat="server" Text="DGV" Visible="false" />
                   
                    <asp:Label ID="lblSlashDGV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    <asp:Label ID="lblGV" runat="server" Text="GV" Visible="false" />
                   
                    <asp:Label ID="lblSlashGV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                   
                    <asp:Label ID="lblEV" runat="server" Text="EV" Visible="false" />
                  
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

