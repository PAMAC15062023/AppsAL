<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" Theme="SkinFile" CodeFile="~/DCR/DocCollection/Dcr_Mis_Report.aspx.cs" Inherits="DcrMIS" %>

<asp:Content ID="Contant1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript" language="javascript">



/********************************************************
1-Function To Validate Date 
*********************************************************/
//function ValidateDate()
//{
//   debugger;            
//     var fromDate='';

//      
//                                 
//     fromDate = document.getElementById("ctl00_ContentPlaceHolder1_txtFromDate");
//   
//         if(fromDate.value=="" )
//         {
//         alert("Please provide from date and To date...");
//          return false;
//         }
//         else
//         {  
//                if(isDate(fromDate.value) == false)
//                     {
//                       alert("Please provide valid date format..");
//                       fromDate.focus();
//                       return false;
//                     }
//         }
//                else
//                 {
//               
//                 }

//                                              
//}
//function TABLE1_onclick() {

//}

</script>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td>
    <fieldset>
    <legend class="FormHeading">DCR MIS Report</legend>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="TABLE1">
        <tr>
            <td style="width: 494px; text-align: left; height: 16px;">
                <strong>From Date</strong><asp:TextBox ID="txtFromDate" runat="server" Columns="12" CssClass="textbox" MaxLength="12" Width="124px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;<strong>[dd/MM/yyyy]</strong>
            </td>
            <td style="width: 494px; text-align: left; height: 16px;">
                <strong>To Date</strong><asp:TextBox ID="txtToDate" runat="server" Columns="12" CssClass="textbox" MaxLength="12" Width="124px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;<strong>[dd/MM/yyyy]</strong>
                &nbsp; &nbsp;
                <asp:DropDownList ID="ddlVeriType" runat="server" Width="108px">
                    <asp:ListItem>(All)</asp:ListItem>
                    <asp:ListItem Value="20">Altc</asp:ListItem>
                    <asp:ListItem Value="21">PM</asp:ListItem>
                    <asp:ListItem Value="22">Alop</asp:ListItem>
                    <asp:ListItem Value="23">Blop</asp:ListItem>
                    <asp:ListItem Value="24">Stock</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 494px; text-align: left">
    <asp:Label ID="lblmsg" runat="server" Font-Bold="true" Visible="false" ForeColor="red" ></asp:Label></td>
            <td style="width: 494px; text-align: center">
            </td>
            <td>
            </td>
        </tr>
    <tr>
        <td style="width: 494px; height: 28px;">
            &nbsp;<asp:Button ID="btnsearch" Text="Search" runat="server" Width="105px" OnClick="btnsearch_Click" />
    <asp:Button ID="export" Text="Export" runat="server" Width="148px" OnClick="export_Click" /></td>
    <td style="width: 494px; height: 28px;">
        &nbsp;<br />
    </td>
    </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td>
    <asp:GridView ID="grdvw" AutoGenerateColumns="True" SkinID="gridviewNoSort" runat="server" Width="99%">
    <%--<Columns>
    <asp:BoundField HeaderText="User Name" DataField="uname" />
    <asp:BoundField HeaderText="Employee Code" DataField="emp_code" />
    <asp:BoundField HeaderText="Employee Name" DataField="fullname" />
    <asp:BoundField HeaderText="Login Date Time" DataField="login_date" />
    </Columns>--%>
    </asp:GridView>
    </td>
    </tr>
    </table>
    </fieldset>
    </td>
    </tr>
    </table>

</asp:Content>
