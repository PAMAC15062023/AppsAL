<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="~/Pages/ChequeProcessingNEW/transaction_Master.aspx.cs" Inherits="Pages_Calculus_Transaction_Master" Title="Transaction Master" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">


    function GV_RowSelection(RowNo, id) {
        //debugger;
  var RowNo=(parseInt(RowNo)+1);
  var hdnBranchId = document.getElementById("<%=hdnBranchId.ClientID%>");
  var txtNormalTypeCode = document.getElementById("<%=txtNormalTypeCode.ClientID%>");
  var txtReturnWithFeeCode = document.getElementById("<%=txtReturnWithFeeCode.ClientID%>");
  var txtReturnWithoutFeeCode = document.getElementById("<%=txtReturnWithoutFeeCode.ClientID%>");
  var ddlBranchName = document.getElementById("<%=ddlBranchName.ClientID%>");
  
  var Gv_Search=document.getElementById ("<%=Gv_Search.ClientID%>");

  ddlBranchName.value = Gv_Search.rows[RowNo].cells[4].innerText;
  hdnBranchId.value = Gv_Search.rows[RowNo].cells[4].innerText;
  txtNormalTypeCode.value = Gv_Search.rows[RowNo].cells[1].innerText;
  txtReturnWithFeeCode.value = Gv_Search.rows[RowNo].cells[2].innerText;
  txtReturnWithoutFeeCode.value = Gv_Search.rows[RowNo].cells[3].innerText; 
     
   var i=0;
        for(i=0;i<=Gv_Search.rows.length-1;i++)       
        {
            if (i!=0)
            {
                if (hdnBranchId.value == Gv_Search.rows[i].cells[4].innerText)
                {
                 Gv_Search.rows[i].style.backgroundColor = "DarkGray";
                }
                else 
                {
                   Gv_Search.rows[i].style.backgroundColor = "white";          
                }
          }
        }
  }
  
  function ValidationAllField()
  {  
     
     var ReturnType=true;
     var ErrorMessage="";

     var txtNormalTypeCode = document.getElementById("<%=txtNormalTypeCode.ClientID%>");
     var txtReturnWithFeeCode = document.getElementById("<%=txtReturnWithFeeCode.ClientID%>");
     var txtReturnWithoutFeeCode = document.getElementById("<%=txtReturnWithoutFeeCode.ClientID%>");
    
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");

     if (txtNormalTypeCode.value == '')
     {
       ErrorMessage="Normal Type Code can't be blank";
       ReturnType=false;
   }
   if (txtReturnWithFeeCode.value == '') {
       ErrorMessage = "Return with fee Type Code can't be blank";
       ReturnType = false;
   }
   if (txtReturnWithoutFeeCode.value == '') {
       ErrorMessage = "Return Without fee Type Code can't be blank";
       ReturnType = false;
   }
                
    if (ReturnType)
    {
        var lblWait = document.getElementById("<%=lblWait.ClientID%>");   
        lblWait.innerText="Please wait.....";
    }    
    
        lblMessage.innerText=ErrorMessage;         
    
        return ReturnType;
  }

</script>
    <table cellpadding="2" style="width: 696px">
        <tr>
            <td colspan="3" rowspan="1" style="height: 17px">
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="594px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="3" rowspan="" style="width: 357px">
                Transaction Master</td>
        </tr>
        <tr>
            <td style="width: 402px;"  class="TableTitle">
                Branch</td>
            <td style="width: 393px;">
                <asp:DropDownList ID="ddlBranchName" runat="server" Width="161px" 
                    SkinID="ddlSkin" Height="20px">
                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>R</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 402px; height: 7px;">
                Normal Cheque Type Code</td>
            <td style="width: 393px; height: 7px;">
                <asp:TextBox ID="txtNormalTypeCode" runat="server" Width="145px"></asp:TextBox></td>
            <td style="width: 549px; height: 7px">
                </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 402px; height: 7px;">
                Return With Fee Type Code</td>
            <td style="width: 393px; height: 7px;">
                <asp:TextBox ID="txtReturnWithFeeCode" runat="server" Width="145px"></asp:TextBox></td>
            <td style="width: 549px; height: 7px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 402px; height: 7px;">
                Return Without FeeType Code</td>
            <td style="width: 393px; height: 7px;">
                <asp:TextBox ID="txtReturnWithoutFeeCode" runat="server" Width="145px"></asp:TextBox></td>
            <td style="width: 549px; height: 7px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 16px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" OnClick="btnSave_Click" />
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Width="78px" OnClick="btnAdd_Click" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="3" style="width: 178px; height: 17px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 17px">
                <asp:GridView ID="Gv_Search" runat="server" Width="308px" OnRowDataBound="Gv_Search_RowDataBound" AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Double">
                <Columns>
             <%--   <asp:BoundField DataField="BranchID">
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>--%>

                <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                <asp:BoundField DataField="NormalChequeType" HeaderText="NormalChequeType" />
                <asp:BoundField DataField="ReturnWithFeeType" HeaderText="ReturnWithFeeType" />
                <asp:BoundField DataField="ReturnWithouFeeType" HeaderText="ReturnWithoutFeeType" />
                
                <asp:BoundField DataField="BranchId" >
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                
                </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnBranchId" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="width: 178px; height: 17px">
                &nbsp;
            </td>
        </tr>
    </table>
    
</asp:Content>

