<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="~/Pages/ChequeProcessingNEW/Binlogo_Master.aspx.cs" Inherits="Pages_Calculus_Binlogo_Master" Title="Binlogo Master" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">


function GV_RowSelection(RowNo,id)
{
  var RowNo=(parseInt(RowNo)+1);
  var hdnBinID=document.getElementById("<%=hdnBinID.ClientID%>");
  var txtBinCode=document.getElementById("<%=txtBinCode.ClientID%>");
  var txtBinlogo=document.getElementById("<%=txtBinlogo.ClientID%>");
  var txtBinDescription=document.getElementById("<%=txtBinDescription.ClientID%>");
  var Gv_Search=document.getElementById ("<%=Gv_Search.ClientID%>");
  
  hdnBinID.value=Gv_Search.rows[RowNo].cells[0].innerText; 
  txtBinCode.value=Gv_Search.rows[RowNo].cells[1].innerText; 
  txtBinlogo.value=Gv_Search.rows[RowNo].cells[2].innerText; 
  txtBinDescription.value=Gv_Search.rows[RowNo].cells[3].innerText; 

   var i=0;
        for(i=0;i<=Gv_Search.rows.length-1;i++)       
        {
            if (i!=0)
            {
                if (hdnBinID.value==Gv_Search.rows[i].cells[0].innerText)
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
     
     var txtBinCode=document.getElementById("<%=txtBinCode.ClientID%>");
     var txtBinlogo=document.getElementById("<%=txtBinlogo.ClientID%>");
          
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
      
     if(txtBinCode.value=='')
     {
       ErrorMessage="Bin Code can't be blank";
       ReturnType=false;
     }
     if(txtBinlogo.value=='')
     {
       ErrorMessage="Bin Logo can't be blank";
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
            <td colspan="3" rowspan="1" style="height: 17px">
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="594px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="3" rowspan="" style="width: 357px">
                BinLogo &nbsp;Master</td>
        </tr>
        <tr>
            <td style="width: 331px;"  class="TableTitle">
                Bin Code</td>
            <td style="width: 393px;">
                <asp:TextBox ID="txtBinCode" runat="server" MaxLength="6"></asp:TextBox></td>
            <td style="width: 549px">
                </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 331px; height: 7px;">
                Logo Code</td>
            <td style="width: 393px; height: 7px;">
                <asp:TextBox ID="txtBinlogo" runat="server" MaxLength="3"></asp:TextBox></td>
            <td style="width: 549px; height: 7px">
                </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 331px; height: 24px;">
                Description</td>
            <td style="width: 393px; height: 24px;">
                <asp:TextBox ID="txtBinDescription" runat="server" Height="57px" TextMode="MultiLine"
                    Width="318px" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td rowspan="1" style="width: 549px; height: 24px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 64px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" OnClick="btnSave_Click" />&nbsp;
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Width="78px" OnClick="btnAdd_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="4" style="width: 178px; height: 17px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 17px">
                <asp:GridView ID="Gv_Search" runat="server" Width="308px" OnRowDataBound="Gv_Search_RowDataBound" AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Double">
                <Columns>
                <asp:BoundField DataField="binlogoID" >
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="BinCode" HeaderText="BinCode" />
                <asp:BoundField DataField="Logo_Code" HeaderText="LogoCode" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnBinID" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 178px; height: 17px">
                &nbsp;
            </td>
        </tr>
    </table>
    
</asp:Content>

