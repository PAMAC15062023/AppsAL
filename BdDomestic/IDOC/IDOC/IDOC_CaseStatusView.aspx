<%@ Page Language="C#" MasterPageFile="~/IDOC/IDOC/IDOC_MasterPage.master" AutoEventWireup="true" Theme="skinFile" CodeFile="IDOC_CaseStatusView.aspx.cs" Inherits="IDOC_IDOC_IDOC_CaseStatusView" Title="IDOC_IDOC_IDOC_CaseStatusView" %>
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
    &nbsp;</td>
</tr>
    <tr>
        <td>
            <asp:GridView ID="gvIDOCDedup" runat="server" AllowPaging="True" AllowSorting="True" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="Transparent" BorderStyle="Solid"
                BorderWidth="1px" CellPadding="1" CellSpacing="1" Font-Bold="False" Font-Names="Arial"
                Font-Size="8pt" ForeColor="Black" GridLines="None" meta:resourcekey="gvCCResource1"
                OnPageIndexChanging="gvIDOCDedup_PageIndexChanging" OnRowCommand="gvIDOCDedup_RowCommand"
                OnSorting="gvIDOCDedup_Sorting"
                 PageSize="15" Width="100%" OnRowDataBound="gvIDOCDedup_RowDataBound">
                <FooterStyle BackColor="#D0D5D8" ForeColor="White" Height="20px" />
                <RowStyle BackColor="#E5E5E5" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#D0D5D8" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#D0D5D8" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"
                    ForeColor="Black" Height="20px" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Case_ID" HeaderText="Case ID" ReadOnly="True" SortExpression="Case_ID" />
                    <asp:BoundField DataField="Ref_No" HeaderText="Bank RefNo" ReadOnly="True" SortExpression="Ref_No" />
                    <asp:BoundField DataField="VERIFICATION_TYPE" HeaderText="VERIFICATION TYPE" ReadOnly="True"
                        SortExpression="VERIFICATION_TYPE" />
                    <asp:BoundField DataField="APPLICANT_NAME" HeaderText="Applicant Name" ReadOnly="True"
                        SortExpression="APPLICANT_NAME" />
                    <asp:BoundField DataField="Client_Name" HeaderText="Client Name" ReadOnly="True"
                        SortExpression="Client_Name" />
                    <asp:BoundField DataField="RECD DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Received DateTime"
                        HtmlEncode="False" ReadOnly="True" SortExpression="RECD DATE" />
                    <asp:BoundField DataField="DOB" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date of Birth"
                        HtmlEncode="False" ReadOnly="True" SortExpression="DOB" />
                    <asp:BoundField DataField="STATUS_NAME" HeaderText="STATUS NAME" ReadOnly="True"
                        SortExpression="STATUS_NAME" />
                       <%-- Added By : Gargi Srivastava
                        Purpose  : For Opening the Pop up
                        Added Date: 11-Dec-2007--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnVerificationTypeID" runat="server" Value='<%# Bind("VERIFICATION_TYPE_ID") %>' />
                         <asp:Label ID="lblShowDetail" runat="server" Text="ShowDetail" Visible="false" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                   <%-- End--%>
                    
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




