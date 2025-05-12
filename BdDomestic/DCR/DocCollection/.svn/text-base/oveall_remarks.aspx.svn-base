<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" CodeFile="oveall_remarks.aspx.cs" Inherits="CPV_CC_oveall_remarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<script language="javascript" type="text/javascript"></script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px; width: 3478px;">
<fieldset><legend class="FormHeading">Overall Status</legend>
    <table border="0" cellpadding="0" cellspacing="0" width="99%">
    <tr><td style="width: 379px; height: 38px;"><b>From Date:
    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    </b>
            <img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </td>
    <td style="width: 373px; height: 38px;"><b>&nbsp;To Date:
        <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    </b>
        <img id="imgToDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    </td>
    <td style="height: 38px"><asp:Button ID="btnsearch" runat="server" SkinID="btnsearchskin" Text="Search" OnClick="btnsearch_Click1" /><br />
    </td>
    </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 99%">
    <tr>
    <td> 
    <asp:GridView ID="GvOverall" SkinID="gridviewSkin" runat="server" Width="98%" AutoGenerateColumns="False" OnRowDataBound="GvOverall_RowDataBound" Height="153px" PageSize="20">
     <Columns>
         <asp:BoundField DataField="Case_id" HeaderText="CaseID" />
            <asp:BoundField HeaderText="Ref No" DataField="ref_no" >
                
            </asp:BoundField>
            <asp:BoundField HeaderText="Applicant Name" DataField="Applicant_name" >
                         </asp:BoundField>
           <asp:BoundField HeaderText="Overall Status" DataField="status_code" />
           <asp:BoundField HeaderText="Overall Comments" DataField="overall_comments" />
         <asp:TemplateField HeaderText="Overall Status">
                   <ItemTemplate>
                  <asp:Label ID="status" runat="server" Text="View Status"></asp:Label>
                   </ItemTemplate>
                   
            
         </asp:TemplateField>
       </Columns>
            </asp:GridView>
    </td>
    </tr>
   <tr><td><asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></td>
   </tr>
    </table>


</fieldset>
</td>
</tr>
</table>
</asp:Content>