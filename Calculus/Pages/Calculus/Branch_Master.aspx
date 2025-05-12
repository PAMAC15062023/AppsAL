<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Branch_Master.aspx.cs" Inherits="Pages_Calculus_Branch_Master" Title="Branch Master" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">


function GV_RowSelection(RowNo,id)
{
  var RowNo=(parseInt(RowNo)+1);
  var hdnServiceTaxID=document.getElementById("<%=hdnBranchId.ClientID%>");
  var txtBranchName=document.getElementById("<%=txtBranchName.ClientID%>");
  var txtBranchCode=document.getElementById("<%=txtBranchCode.ClientID%>");
  var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
  var ddlRegion=document.getElementById("<%=ddlRegion.ClientID%>");
  var Gv_Search=document.getElementById ("<%=Gv_Search.ClientID%>");
  
  hdnServiceTaxID.value=Gv_Search.rows[RowNo].cells[0].innerText; 
  txtBranchName.value=Gv_Search.rows[RowNo].cells[1].innerText; 
  txtBranchCode.value=Gv_Search.rows[RowNo].cells[2].innerText; 
  ddlIsActive.value=Gv_Search.rows[RowNo].cells[3].innerText;
  ddlRegion.value=Gv_Search.rows[RowNo].cells[5].innerText;
    
   var i=0;
        for(i=0;i<=Gv_Search.rows.length-1;i++)       
        {
            if (i!=0)
            {
                if (hdnServiceTaxID.value==Gv_Search.rows[i].cells[0].innerText)
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
     
     var txtBranchName=document.getElementById("<%=txtBranchName.ClientID%>");
     var txtBranchCode=document.getElementById("<%=txtBranchCode.ClientID%>");
     var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
     var ddlRegion=document.getElementById("<%=ddlRegion.ClientID%>");
    
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
      
     if(txtBranchName.value=='')
     {
       ErrorMessage="Branch Name can't be blank";
       ReturnType=false;
     }
     if(txtBranchCode.value=='' || txtBranchCode.value.length > 3)
     {
       ErrorMessage="Branch Code can't be blank OR More than three Character";
       ReturnType=false;
     }
     if(ddlIsActive.value=='-Select-')
     {
       ErrorMessage="Is Active can't be blank";
       ReturnType=false;
     } 
     if(ddlRegion.selectedIndex==0)
     {
       ErrorMessage="Region can't be blank";
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

</script>
    <table cellpadding="2" style="width: 696px">
        <tr>
            <td colspan="3" rowspan="1" style="height: 17px">
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" Height="11px" Width="253px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="3" rowspan="" style="width: 357px">
                Branch Master</td>
        </tr>
        <tr>
            <td style="width: 178px; height: 1px;"  class="TableTitle">
                Branch Name</td>
            <td style="width: 393px; height: 1px">
                <asp:TextBox ID="txtBranchName" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 549px; height: 1px">
                <asp:HiddenField ID="hdnBranchId" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                Branch Code</td>
            <td style="width: 393px">
                <asp:TextBox ID="txtBranchCode" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 549px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                Is Active</td>
            <td style="width: 393px">
                <asp:DropDownList ID="ddlIsActive" runat="server" Width="116px" SkinID="ddlSkin">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 549px">
            </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 17px;" class="TableTitle">
                Region</td>
            <td style="width: 393px; height: 17px">
                <asp:DropDownList ID="ddlRegion" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 549px; height: 17px;">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 17px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" 
                    OnClick="btnSave_Click" BorderWidth="1px" />&nbsp;
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Width="78px" 
                    OnClick="btnAdd_Click" BorderWidth="1px" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    OnClick="btnCancel_Click" BorderWidth="1px" />
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
                <asp:GridView ID="Gv_Search" runat="server" Width="308px" 
                    OnRowDataBound="Gv_Search_RowDataBound" AutoGenerateColumns="False" 
                    BorderColor="Black" BorderStyle="Double" CssClass="mGrid">
                <Columns>
                <asp:BoundField DataField="BranchId" >
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                <asp:BoundField DataField="BranchCode" HeaderText="Code" />
                <asp:BoundField DataField="Is_active" HeaderText="Active" />
                <asp:BoundField DataField="Region_name" HeaderText="Region" />
                <asp:BoundField DataField="Region_ID">
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="width: 178px; height: 17px">
                &nbsp;
            </td>
        </tr>
    </table>
    
</asp:Content>

