<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="~/pages/chequeprocessingnew/client_master.aspx.cs"  Inherits="Pages_Calculus_Client_Master" Title="Client Master" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">


function GV_RowSelection(RowNo,id)
{
  var RowNo=(parseInt(RowNo)+1);
  var hdnClientId=document.getElementById("<%=hdnClientId.ClientID%>");
  var txtClientName=document.getElementById("<%=txtClientName.ClientID%>");
  var txtClientCode=document.getElementById("<%=txtClientCode.ClientID%>");
  var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
  var Gv_Search=document.getElementById ("<%=Gv_Search.ClientID%>");
  
  hdnClientId.value=Gv_Search.rows[RowNo].cells[0].innerText; 
  txtClientName.value=Gv_Search.rows[RowNo].cells[1].innerText; 
  txtClientCode.value=Gv_Search.rows[RowNo].cells[2].innerText; 
  ddlIsActive.value=Gv_Search.rows[RowNo].cells[3].innerText;
  
    
   var i=0;
        for(i=0;i<=Gv_Search.rows.length-1;i++)       
        {
            if (i!=0)
            {
                if (hdnClientId.value==Gv_Search.rows[i].cells[0].innerText)
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
     
     var txtClientName=document.getElementById("<%=txtClientName.ClientID%>");
     var txtClientCode=document.getElementById("<%=txtClientCode.ClientID%>");
     var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
      
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
      
     if(txtClientName.value=='')
     {
       ErrorMessage="Client Name can't be blank";
       ReturnType=false;
     }
     if(txtClientCode.value=='' || txtClientCode.value.length > 3)
     {
       ErrorMessage="Client Code can't be blank OR More than three Character";
       ReturnType=false;
     }
     if(ddlIsActive.value=='-Select-')
     {
       ErrorMessage="Is Active can't be blank";
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
                Client Master</td>
        </tr>
        <tr>
            <td style="width: 178px;"  class="TableTitle">
                Client Name</td>
            <td style="width: 393px;">
                <asp:TextBox ID="txtClientName" runat="server" BorderWidth="1px" SkinID="txtSkin" OnKeyup="UpperLetter(this);" Height="38px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px; height: 24px;">
                Client Code</td>
            <td style="width: 393px; height: 24px;">
                <asp:TextBox ID="txtClientCode" runat="server" BorderWidth="1px" SkinID="txtSkin" MaxLength="3" OnKeyup="UpperLetter(this);" Width="208px"></asp:TextBox></td>
            <td style="width: 549px; height: 24px;">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                Is Active</td>
            <td style="width: 393px">
                <asp:DropDownList ID="ddlIsActive" runat="server" Width="126px" SkinID="ddlSkin">
                    <%--<asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="width: 549px" rowspan="">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 16px">
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
                <asp:BoundField DataField="ClientId" >
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="ClientName" HeaderText="Client" />
                <asp:BoundField DataField="ClientCode" HeaderText="Code" />
                <asp:BoundField DataField="Is_active" HeaderText="Active" />
                </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnClientId" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 178px; height: 17px">
                &nbsp;
            </td>
        </tr>
    </table>
    
</asp:Content>

