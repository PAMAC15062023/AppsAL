<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ServiceTax.aspx.cs" Inherits="Pages_ServiceTax" Title="Service Tax" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="popcalendar.js"></script>
<script language="javascript" type="text/javascript">

function GV_RowSelection(RowNo,id)
{  ////debugger;
    var RowNo=(parseInt(RowNo)+1);
    var hdnServiceTaxID=document.getElementById("<%=hdnServiceTaxID.ClientID%>");
    var txtTaxName=document.getElementById("<%=txtTaxName.ClientID%>");
    var txtTaxCode=document.getElementById("<%=txtTaxCode.ClientID%>");
    var txtTax=document.getElementById("<%=txtTax.ClientID%>");
    var txtStartPeriod=document.getElementById("<%=txtStartPeriod.ClientID%>");
    var txtEndPeriod=document.getElementById("<%=txtEndPeriod.ClientID%>");
    var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
    var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
    var Gv_ServiceTax=document.getElementById("<%=Gv_ServiceTax.ClientID%>");
    
    hdnServiceTaxID.value=Gv_ServiceTax.rows[RowNo].cells[0].innerText; 
    txtTaxName.value=Gv_ServiceTax.rows[RowNo].cells[1].innerText; 
    txtTaxCode.value=Gv_ServiceTax.rows[RowNo].cells[2].innerText; 
    txtTax.value=Gv_ServiceTax.rows[RowNo].cells[3].innerText; 
    txtStartPeriod.value=Gv_ServiceTax.rows[RowNo].cells[4].innerText; 
    txtEndPeriod.value=Gv_ServiceTax.rows[RowNo].cells[5].innerText; 
    ddlIsActive.value=Gv_ServiceTax.rows[RowNo].cells[6].innerText; 
    txtRemark.value=Gv_ServiceTax.rows[RowNo].cells[7].innerText; 
    
     var i=0;
        for(i=0;i<=Gv_ServiceTax.rows.length-1;i++)       
        {
            if (i!=0)
            {
                if (hdnServiceTaxID.value==Gv_ServiceTax.rows[i].cells[0].innerText)
                {
                 Gv_ServiceTax.rows[i].style.backgroundColor = "DarkGray";
                }
                else 
                {
                   Gv_ServiceTax.rows[i].style.backgroundColor = "white";          
                }
          }
        }
        
   }
   
  function ValidationAllField()
  { 
     ////debugger;
     var ReturnType=true;
     var ErrorMessage="";
     
    var txtTaxName=document.getElementById("<%=txtTaxName.ClientID%>");
    var txtTaxCode=document.getElementById("<%=txtTaxCode.ClientID%>");
    var txtTax=document.getElementById("<%=txtTax.ClientID%>");
    var txtStartPeriod=document.getElementById("<%=txtStartPeriod.ClientID%>");
    var txtEndPeriod=document.getElementById("<%=txtEndPeriod.ClientID%>");
    var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
    var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
  
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
            
     if(txtTaxName.value=='')
     {
       ErrorMessage="Service Tax can't be blank";
       ReturnType=false;
     }
     if(txtTaxCode.value=='')
     {
       ErrorMessage="Service Tax Code can't blank";
       ReturnType=false;
     }
     
     if(txtTax.value=='')
     {
       ErrorMessage="Service Tax can't be blank OR Num Exceed";
       ReturnType=false;
     } 
     else
     {
       var regex1=/^\d{1,2}\056{1}\d{2}$/;  //this is the pattern of regular expersion
                if(regex1.test(txtTax.value)== false)
                {
                    ErrorMessage="Please enter valid tax";
                    ReturnType=false;
                    txtTax.focus();     
                }
     }
    
     if(txtStartPeriod.value=='')
     {
       ErrorMessage="Service Tax Start Period can't be blank";
       ReturnType=false;
     } 
     if(txtEndPeriod.value=='')
     {
       ErrorMessage="Service Tax End Period can't be blank";
       ReturnType=false;
     }    
     if(ddlIsActive.selectedIndex==0)
     {
       ErrorMessage="Is Active can't be blank";
       ReturnType=false;
     }    
     if(txtRemark.value=='')
     {
       ErrorMessage=" Remark can't be blank";
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

    <table style="height: 41px">
        <tr>
            <td colspan="4" style="height: 15px">
                <asp:Label ID="lblMessage" runat="server" Width="638px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4" style="height: 22px">
                &nbsp;Service Tax Master</td>
        </tr>
        <tr>
            <td style="width: 11px; height: 2px;">
            </td>
            <td class="TableTitle" style="height: 2px">
                Service Tax Name</td>
            <td style="width: 40px; height: 2px;">
                <asp:TextBox ID="txtTaxName" runat="server" Width="186px" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 390px; height: 2px;">
                <asp:HiddenField ID="hdnServiceTaxID" runat="server" Value="0"/>
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td class="TableTitle">
                Service Tax Code</td>
            <td style="width: 48px;">
                <asp:TextBox ID="txtTaxCode" runat="server" Width="184px" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 390px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td class="TableTitle">
                Service Tax
            </td>
            <td style="width: 48px;">
                <asp:TextBox ID="txtTax" runat="server" Width="76px" BorderWidth="1px" SkinID="txtSkin" ></asp:TextBox>%</td>
            <td style="width: 390px;" class="Tax_Message">
                &nbsp;e.g plz write ServiceTax like:10.00 OR 10.30</td>
        </tr>
        <tr>
            <td style="width: 11px; height: 23px;">
            </td>
            <td class="TableTitle" style="height: 23px">
                Service Period Start</td>
            <td style="height: 23px">
                <asp:TextBox ID="txtStartPeriod" runat="server" Width="96px" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calender" src="../ChequeProcessing/SmallCalendar.png"  onclick="popUpCalendar(this, document.all.<%=txtStartPeriod.ClientID%>, 'dd/mm/yyyy', 0, 0);"/></td>
            <td style="width: 390px; height: 23px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td class="TableTitle">
                Service Period End</td>
            <td>
                <asp:TextBox ID="txtEndPeriod" runat="server" Width="97px" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calender" src="../ChequeProcessing/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtEndPeriod.ClientID%>, 'dd/mm/yyyy', 0, 0);"/></td>
            <td style="width: 390px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td class="TableTitle">
                IsActive</td>
            <td style="width: 48px;">
                <asp:DropDownList ID="ddlIsActive" runat="server">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 390px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 22px;">
            </td>
            <td class="TableTitle" style="height: 22px">
                Remark</td>
            <td style="width: 48px; height: 22px">
                <asp:TextBox ID="txtRemark" runat="server" Width="325px" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 390px; height: 22px">
            </td>
        </tr>
        <tr>
            <td colspan="4" rowspan="1">
            </td>
        </tr>
        <tr>
            <td colspan="4" rowspan="1" style="height: 1px">
                <br />
                &nbsp; &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="63px" OnClick="btnSave_Click" BorderWidth="1px" />
                <asp:Button ID="btnAddNew" runat="server" Text="Add" Width="63px" BorderWidth="1px" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderWidth="1px" OnClick="btnCancel_Click" />
                &nbsp;&nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td class="TableTitle" colspan="4" rowspan="1" style="width: 11px"></td> 
        </tr>
        <tr>
            <td colspan="1" rowspan="1" style="width: 11px">
            </td>
            <td colspan="3" rowspan="1">
                <asp:GridView ID="Gv_ServiceTax" runat="server" 
                    OnRowDataBound="Gv_ServiceTax_RowDataBound" Width="459px" 
                    AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Double" 
                    CssClass="mGrid">
                <Columns>
                <asp:BoundField DataField="ServiceTaxID">
                    <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="ServiceTaxName" HeaderText="Name"/>
                <asp:BoundField DataField="ServiceTaxCode" HeaderText="Code"/>
                <asp:BoundField DataField="ServiceTaxPercentage"  HeaderText="Tax%"/>
                <asp:BoundField DataField="StartDate" HeaderText="StartD" />
                <asp:BoundField DataField="EndDate" HeaderText="EndDate" />
                <asp:BoundField DataField ="IsActive" HeaderText="Active"/>
                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="1" rowspan="2" style="width: 11px; height: 16px">
            </td>
            <td colspan="3" rowspan="2" style="height: 16px">
                &nbsp; &nbsp; &nbsp; &nbsp;</td>
        </tr>
        </table>
</asp:Content>

