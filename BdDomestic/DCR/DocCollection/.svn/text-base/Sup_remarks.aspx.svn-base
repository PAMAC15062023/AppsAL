<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" AutoEventWireup="True" CodeFile="Sup_remarks.aspx.cs" Inherits="CPV_CC_Sup_remarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <br />
<script language="javascript" type="text/javascript">
function TABLE1_onclick() {

}

function FIELDSET1_onclick() {

}

</script>
<table border="0" cellpadding="0" cellspacing="0" style="height: 259px; width: 100%;">
<tr><td style="padding-left:10px; width: 1013px;">
<fieldset style="width: 954px">
<legend class="FormHeading"> Supervisor Remarks</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr>
<td style="width: 201px; height: 24px"><b>Case ID<asp:TextBox ID="Txtcase" runat="server" MaxLength="15" SkinID="txtSkin" Font-Bold="true"></asp:TextBox></b></td>
<td style="height: 24px">
    &nbsp;</td>
<%--<td>
Applicant Name
</td>
<td><asp:TextBox ID="TxtappName" runat="server" MaxLength="150" SkinID="txtSkin"></asp:TextBox>
</td>--%>

</tr>
</table>
    <br />
<table border="0" cellpadding="0" cellspacing="0" style="width: 99%">
<tr>
<td style="height: 167px"> 
 <asp:GridView ID="gvsupervisor" SkinID="gridviewSkin" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvsupervisor_RowDataBound" Height="153px" >
     <Columns>
     
      <asp:TemplateField HeaderText="Verification Code">
            <ItemTemplate>
             <asp:Label ID="lblRV" runat="server" Text="RV" Visible="false" />
              
              <asp:Label ID="lblSlashRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
             <asp:Label ID="lblBV" runat="server" Text="BV" Visible="false" />
            
             <asp:Label ID="lblSlashBV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
             <asp:Label ID="lblRT" runat="server" Text="RT" Visible="false" />
             
             <asp:Label ID="lblSlashRT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
           <asp:Label ID="lblBT" runat="server" Text="BT" Visible="false" />
           
           <asp:Label ID="lblSlashBT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
            </ItemTemplate>
          <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="verification Code" DataField="veri_code" >
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Residance Address" DataField="residence_address" >
                <ItemStyle Width="12%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Staying Since" DataField="time_at_curr_residance" >
                <ItemStyle Width="8%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Residance Status" DataField="residance_is" >
            </asp:BoundField>
            <asp:BoundField HeaderText="residance Phone" DataField="res_phone" >
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="DOB" DataField="DOB" >
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Company Name." DataField="Company_name" >
                <ItemStyle Width="12%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Designation" DataField="designation" >
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Office Address" DataField="office_address" >
                <ItemStyle Width="15%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="office Phone" DataField="office_phone" >
                <ItemStyle Width="15%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Working Since" DataField="working_since" >
                <ItemStyle Width="8%" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Status" DataField="status_name" />
            <asp:BoundField HeaderText="Remarks" DataField="SUPERVISOR_REMARKS" />
            
            </Columns>
            </asp:GridView>
</td>
</tr>
<tr><td style="height: 15px; width: 797px;">
<asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
</td>
</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td><asp:Label ID="Overallstatus" runat="server" Text="Overall Status" Visible="false" SkinID="lblSkin"></asp:Label></td>
<td><asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
    <asp:ListItem>----SELECT----</asp:ListItem>
</asp:DropDownList>
    &nbsp;</td>
<td><asp:Label ID="OverallCommennt" runat="server" Text="Overall Comments" Visible="false" SkinID="lblSkin"></asp:Label></td>
<td style="width: 311px"><asp:TextBox ID="txtoverall" runat="server" SkinID="txtSkin"  TextMode="MultiLine" Visible="false" Width="215px"></asp:TextBox> </td>
<td> <asp:Button ID="btnapply" runat="server" Text="Submit" Visible="false" SkinID="btnSubmitSkin" OnClick="btnapply_Click"  /></td>
<td><asp:Label ID="msg" BorderStyle="Solid" BorderColor="#476085" BorderWidth="2" runat="server" Visible="false" ForeColor="red" Font-Bold="true" ></asp:Label></td>
<td><asp:TextBox ID="txtfdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox>
<asp:TextBox ID="txttdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox></td>
</tr>

</table>

</fieldset>
</td>
</tr>
</table>
           
        


</asp:Content>