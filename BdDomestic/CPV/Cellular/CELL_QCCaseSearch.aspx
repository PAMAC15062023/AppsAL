<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/CPV/Cellular/CEL_MasterPage.master" Theme="SkinFile" CodeFile="CELL_QCCaseSearch.aspx.cs" Inherits="CPV_Cellular_CELL_QCCaseSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<fieldset><legend class="FormHeading">Cellular QC Case&nbsp; Search</legend>
<table width="100%">
<tr>
    <td style="height: 21px" >
        <asp:Label ID="lblMobNo" runat="server" SkinID="lblSkin" Text="Mobile No." Width="52px"></asp:Label></td>
<td style="height: 21px" >
    :</td>
    <td style="height: 21px" >
        <asp:TextBox ID="txtMobNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
<td style="height: 21px" >
    <asp:Label ID="lblConNo" runat="server" SkinID="lblSkin" Text="Can No." Width="39px"></asp:Label></td>
    <td style="width: 3px; height: 21px;">
        :</td>
<td style="height: 21px" >
    <asp:TextBox ID="txtCanNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
<td style="height: 21px">
</td>
</tr>
    <tr>
        <td style="height: 28px" >
            <asp:Label ID="lblApplicantName" runat="server" SkinID="lblSkin" Text="Applicant Name" Width="81px"></asp:Label></td>
        <td style="height: 28px" >
            :</td>
        <td style="height: 28px" >
            <asp:TextBox ID="txtApplName" runat="server" SkinID="txtSkin"></asp:TextBox>
            <asp:CheckBox ID="chkName" runat="server" Text="Absolute" /></td>
        <td style="height: 28px" >
            </td>
        <td style="width: 3px; height: 28px;">
        </td>
        <td style="height: 28px" >
            <asp:Button ID="btnsearch" runat="server" Text="Button" SkinID="btnSearchSkin" OnClick="btnsearch_Click" /></td>
    </tr>
    <tr>
        <td colspan="7">
            <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="7">
           <asp:GridView ID="GridView1" runat="server" width="100%" AutoGenerateColumns="False" SkinID="gridviewSkin" AllowPaging="True" AllowSorting="True" DataSourceID="sdsgv" OnRowCommand="GridView1_RowCommand">
                <Columns>
                 <asp:TemplateField HeaderText="CaseID">
                    <ItemTemplate>
                         <asp:LinkButton ID="lkCaseID" runat="server" CommandArgument='<%# Eval("case_id") %>' CommandName="Select" Text='<%# Eval("case_id") %>'></asp:LinkButton>
                     </ItemTemplate>
                     </asp:TemplateField>
                    <asp:BoundField DataField="CELLNO" HeaderText="CELLNO" SortExpression="CELLNO" />
                    <asp:BoundField DataField="Applicant Name" HeaderText="Applicant Name" ReadOnly="True"
                        SortExpression="Applicant Name" />
                    <asp:BoundField DataField="Can No" HeaderText="Can No" SortExpression="Can No" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sdsgv" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select Qc.Case_ID  , cell.CELLNO, ISNULL(cell.APP_FNAME,'') + ' ' + ISNULL(cell.APP_MNAME,'') + ' ' + ISNULL(cell.APP_LNAME,'') AS  [Applicant Name],Qc.Ref_No as [Can No]&#13;&#10; from CPV_CELLULAR_CASES cell left outer join cpv_qc_case_details Qc On cell.case_id=Qc.case_id where Qc.client_id=? and Qc.centre_id=?">
                <SelectParameters>
        <asp:SessionParameter Name="Qc.ClientId" SessionField="ClientId" Type="String" />                            
        <asp:SessionParameter Name="Qc.CentreId" SessionField="CentreId" Type="String" />                             
      </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
</table>
</fieldset>
</asp:Content>