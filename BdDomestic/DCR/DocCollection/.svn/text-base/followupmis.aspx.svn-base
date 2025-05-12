<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" CodeFile="followupmis.aspx.cs" Inherits="followupmis" %>
<asp:Content ID="Contant1" ContentPlaceHolderID="C1" runat="server">

<script type="text/javascript" language="javascript">

/********************************************************
1-Function To Validate Date 
*********************************************************/
 function ValidateFromToDateTime(source,arguments)
 {      
      
            if(document.getElementById("<%=txtFromDate.ClientID%>").value=="" )
            {                  
                  arguments.IsValid=false;
            }
         
 }
</script>

<script type="text/javascript" language="javascript">

/********************************************************
1-Function To Validate Date 
*********************************************************/
</script>

<fieldset><legend class="FormHeading">FEMU FollowUP Detailed MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 198px" >
<strong>
        <asp:Label ID="lblFromDate" runat="server" Text="Date:" Width="33px" Font-Bold="True"></asp:Label></strong>
 <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="90px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;<br />
    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; [dd/MM/yyyy]</strong>
</td>
<td style="width: 212px" > <b> Product</b><span style="color:#ff6666">*</span>&nbsp;
 <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" AppendDataBoundItems="True" Width="140px" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" >
 </asp:DropDownList></td>
<td style="width: 177px" > <b> Client</b><span style="color:#ff6666">*</span>&nbsp;
 <asp:DropDownList ID="ddlclients" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="124px" >
 <asp:ListItem Value="0">---All Clients---</asp:ListItem>
 </asp:DropDownList></td>
    <td >
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnsearch" Text="Detail" runat="server" Width="76px" OnClick="btnsearch_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="export" Text="Export Detail" runat="server" Width="102px" OnClick="export_Click" /><br />
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnSearchall" Text="Summary" runat="server" Width="78px" OnClick="btnSearchall_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;
        &nbsp; &nbsp;
        &nbsp;&nbsp; <asp:Button ID="btnexportall" Text="Export Summary" runat="server" Width="104px" OnClick="btnexportall_Click" Height="26px"  /></td>
</tr>
</table>
</fieldset>
    &nbsp;<br />
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 830px">
<asp:Label ID="grdlabel" runat="server" ForeColor="red" Font-Bold="true" Visible="false"></asp:Label>
</td>
</tr>
<tr>
<td style="width: 830px">
<asp:GridView ID="grdvw" AutoGenerateColumns="true" runat="server" SkinID="gridviewNoSort" width="99%"></asp:GridView>
</td>
</tr>
<tr>
<td style="width: 830px">
<asp:Label ID="lbl" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>

</td>
</tr>
</table>
</asp:Content>