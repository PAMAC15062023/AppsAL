<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="~/Pages/ChequeProcessingNEW/MICR_Master.aspx.cs" Inherits="Pages_Calculus_MICR_Master" Title="MICR Master" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">


function GV_RowSelection(RowNo,id)
{
  var RowNo=(parseInt(RowNo)+1);
  var hdnMICRID=document.getElementById("<%=hdnMICRID.ClientID%>");
  var txtMICRCode=document.getElementById("<%=txtMICRCode.ClientID%>");
  var txtBankName=document.getElementById("<%=txtBankName.ClientID%>");
  var ddlBranchID=document.getElementById("<%=ddlBranchID.ClientID%>");
  var txtCity=document.getElementById("<%=txtCity.ClientID%>");
  var txtBranchName=document.getElementById("<%=txtBranchName.ClientID%>");
  var Gv_Search=document.getElementById ("<%=Gv_Search.ClientID%>");
  
  hdnMICRID.value=Gv_Search.rows[RowNo].cells[0].innerText; 
  txtMICRCode.value=Gv_Search.rows[RowNo].cells[1].innerText; 
  ddlBranchID.value=Gv_Search.rows[RowNo].cells[6].innerText; 
  txtBankName.value=Gv_Search.rows[RowNo].cells[3].innerText; 
  txtBranchName.value=Gv_Search.rows[RowNo].cells[4].innerText; 
  txtCity.value=Gv_Search.rows[RowNo].cells[5].innerText;
  
    
   var i=0;
        for(i=0;i<=Gv_Search.rows.length-1;i++)       
        {
            if (i!=0)
            {
                if (hdnMICRID.value==Gv_Search.rows[i].cells[0].innerText)
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
     
     var txtMICRCode=document.getElementById("<%=txtMICRCode.ClientID%>");
     var txtBranchName=document.getElementById("<%=txtBranchName.ClientID%>");
     
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
      
     if(txtMICRCode.value=='')
     {
       ErrorMessage="MICR Code can't be blank";
       ReturnType=false;
     }
     if(txtBranchName.value=='')
     {
       ErrorMessage="Branch Name can't be blank";
       ReturnType=false;
     }
                  
    if (ReturnType)
    {
        var lblWait = document.getElementById("<%=lblWait.ClientID%>");   
        lblWait.innerText="Please wait.....";
    }    
    
        lblMessage.innerText=ErrorMessage;         
    
        return ReturnType;
  }
  function UpperLetter(ID)
        {

        ID.value=ID.value.toUpperCase();

        }

  

</script>
    <table cellpadding="2" style="width: 696px">
        <tr>
            <td colspan="4" rowspan="1" style="height: 17px">
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="594px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4" rowspan="" style="width: 357px">
                MICR &nbsp;Master</td>
        </tr>
        <tr>
            <td style="width: 4758px;"  class="TableTitle">
                MICR Code</td>
            <td style="width: 393px; height: 24px;">
                <asp:TextBox ID="txtMICRCode" runat="server" SkinID="txtSkin" MaxLength="9"></asp:TextBox></td>
            <td class="TableTitle">
                Branch ID</td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlBranchID" runat="server" SkinID="ddlSkin" Width="149px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 4758px;">
                Bank Name</td>
            <td style="width: 393px; height: 7px;">
                <asp:TextBox ID="txtBankName" runat="server" SkinID="txtSkin" OnKeyup="UpperLetter(this);" Height="53px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
            <td class="TableTitle">
                Branch Name</td>
            <td style="width: 549px; height: 7px">
                <asp:TextBox ID="txtBranchName" runat="server" SkinID="txtSkin" OnKeyup="UpperLetter(this);" Height="53px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 4758px;">
                City</td>
            <td style="width: 393px; height: 24px;">
                <asp:TextBox ID="txtCity" runat="server" SkinID="txtSkin" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td rowspan="1" style="width: 6983px; height: 24px">
            </td>
            <td rowspan="1" style="width: 549px; height: 24px">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 16px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" OnClick="btnSave_Click" />&nbsp;
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Width="78px" OnClick="btnAdd_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="5" style="width: 178px; height: 17px">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 17px">
                <asp:GridView ID="Gv_Search" runat="server" Width="308px" OnRowDataBound="Gv_Search_RowDataBound" AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Double">
                <Columns>
                <asp:BoundField DataField="MICR_ID" >
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="MICR_Code" HeaderText="MICRCode" />
                <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                <asp:BoundField DataField="Bank_Name" HeaderText="BankName" />
                <asp:BoundField DataField="Branch_Name" HeaderText="BranchName" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="BranchID" >
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnMICRID" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="width: 178px; height: 17px">
                &nbsp;
            </td>
        </tr>
    </table>
    
</asp:Content>

