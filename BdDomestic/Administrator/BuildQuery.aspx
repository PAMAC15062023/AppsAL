<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="BuildQuery.aspx.cs" Inherits="Administrator_BuildQuery" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" type="text/javascript">

//Done by gargi srivastava at 12-Nov-2007
//function pannelVisibility(id)
//{
//  var getPannelId='';
//      getPannelId = document.getElementById("<%=tr_hide.ClientID%>");

//     if(id.checked==true)
//     {   
//      getPannelId.style.visibility='visible';//visible row panel row.
//     }
//     else
//     {
//      
//      getPannelId.style.visibility='hidden';// hide row which contain pannel
//     } 
//}
function showMessage(txtid)
{
if(txtid.value=="")
{
alert('If you are giving alias than please put the same alias after the Table Name(for which u defined @ONWHICHDATE) In the Text Box Write Query..');
}
}
</script>

<fieldset>
<legend class="FormHeading">Build Query</legend>

 
                <table >
                <tr>
                    <td>Query Defination</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtQueryDefination" runat="Server" SkinID="txtSkin" Columns="80" MaxLength="100"></asp:TextBox></td>
                </tr>
                </table>
                <table>
                <tr>
                    <td style="width: 81px" valign="top">Write Query</td>
                    <td valign="top">:</td>
                    <td>
                         <asp:TextBox ID="txtWriteQuery" runat="Server" SkinID="txtSkin" 
                         TextMode="MultiLine" Columns="120" Rows="15"  Width="546px"></asp:TextBox>
                         </td>
                </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    
                    <td><asp:CheckBox ID="chkIsCriteria" AutoPostBack="true" SkinID="chkSkin" Text="Is Criteria" runat="server" OnCheckedChanged="chkIsCriteria_CheckedChanged" /></td>
                    <td></td>
                    <td></td>
                </tr>
                </table>
                 
                
                <table id="tblCreteria" width="100%" border="0" cellspacing="0" cellpadding="0">
                
                <tr id="tr_hide" runat="server">
                <td>
               
                 <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                <td  style="width: 84px">
                Alise
                </td>
                
                <td>:</td>
                <td style="width: 143px"><asp:TextBox ID="txtAlise" onclick="showMessage(this)" onblur="showMessage(this)"  runat="server" SkinID="txtSkin" Columns="10" Width="100px" MaxLength="50"></asp:TextBox></td>
                <td style="width: 90px">Creteria Based On</td>
                <td>:</td>
                <td><asp:DropDownList ID="ddlDateType" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>Received Date</asp:ListItem>
                            <asp:ListItem>Send Date</asp:ListItem>
                        </asp:DropDownList></td>
                        <td></td>
                </tr>
                <tr>
                <td style="height: 20px;" colspan="6"></td>
                </tr>
                
                <tr>
                <td  style="width: 84px">From Date </td>
                <td>:</td>
                <td style="width: 143px"><asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Columns="12" MaxLength="10" Width="100px"></asp:TextBox>
                <img id="imgFromDate"  alt="Calendar" src="../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
                <td style="width: 83px">To Date</td>
                <td>:</td>
                <td><asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Columns="12" MaxLength="10" Width="100px"></asp:TextBox>
                <img id="imgToDate"  alt="Calendar" src="../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAppend" SkinID="btn" runat="server" Text="Test" OnClick="btnAppend_Click" ValidationGroup="GrpValidation" /></td>
                <td></td>
                </tr>
              
                </table>
                 
                </td>
                </tr>
                 </table>
                 <table style="height: 20px;" width="100%">
                 <tr>
                 <td></td>
                 </tr>
                 </table>
                 
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                
                <tr>
                <td colspan="7"> 
                <asp:Button ID="btnExecuteQuery" runat="server" SkinID="btn"  Text="Execute Query" OnClick="btnExecuteQuery_Click" ValidationGroup="GrpValidation"/>
                <asp:Button ID="btnSaveQuery" runat="server" SkinID="btn"  Text="Save Query" OnClick="btnSaveQuery_Click" ValidationGroup="GrpValidation"/>
                <asp:Button ID="btnReset" runat="server" SkinID="btn"  Text="Reset" OnClick="btnReset_Click" />
                <asp:Button ID="btnExporttoExcel" runat="server"  Text="Export To Excel" SkinID="btnExpToExlSkin" OnClick="btnExporttoExcel_Click" />
                <asp:Button ID="btnAssignedQuery" runat="server"  Text="Assigned Query" SkinID="btn" OnClick="btnAssignedQuery_Click" /></td>
                </tr>
                <tr>
                <td style="height: 20px;" colspan="7"></td>
                </tr>
                    <tr>
                        <td colspan="7">
                            <asp:Label ID="lblMessage" runat="server" Width="504px" ForeColor="Red"></asp:Label></td>
                    </tr>
                    </table>
                 <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                <td colspan="7" style="width: 728px">
                
                    <asp:GridView ID="gvExecuteQuery" runat="server" SkinID="gridviewSkin" Width="362px">
                    </asp:GridView>
              
                </td>
                </tr>
                </table>
          
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><asp:HiddenField ID="hidQueryID" runat="server" />
    <asp:HiddenField ID="hidMode" runat="server" />
    <asp:Label ID="lblreport" runat="server" Text="Build Query Report" Font-Bold="True" Visible="False"></asp:Label>
   <%--  <asp:CustomValidator ID="cvRemark" runat="server"  ValidationGroup="GrpSend" ControlToValidate="TxtRemark" Display="none" ClientValidationFunction="validation" ErrorMessage="Please Enter Sub Was available or Sub was not available in Remark" ></asp:CustomValidator>--%>
     <asp:ValidationSummary ID="vsummary" runat="server" DisplayMode="List" ShowMessageBox="True" 
     ShowSummary="False" ValidationGroup="GrpValidation" Height="57px" Width="138px" />
    <asp:RequiredFieldValidator ID="rfvvisitdate" runat="server" ControlToValidate="txtQueryDefination"
     Display="None" ErrorMessage="Please Enter Query Defination" SetFocusOnError="True" TabIndex="0"  ValidationGroup="GrpValidation"></asp:RequiredFieldValidator>
     
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWriteQuery"
     Display="None" ErrorMessage="Please Enter Query Text" SetFocusOnError="True" TabIndex="0"  ValidationGroup="GrpValidation"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="rfvFromDate" runat="server" ControlToValidate="txtFromDate"
     Display="None" ErrorMessage="Please Enter Valid Date Formate For From Date" SetFocusOnError="True"
     ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
     ValidationGroup="GrpValidation"></asp:RegularExpressionValidator>
      <asp:RegularExpressionValidator ID="rfvToDate" runat="server" ControlToValidate="txtToDate"
     Display="None" ErrorMessage="Please Enter Valid Date Formate For To Date" SetFocusOnError="True"
     ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
     ValidationGroup="GrpValidation"></asp:RegularExpressionValidator>
    </td>
  </tr>
</table>


</fieldset>
</asp:Content>

