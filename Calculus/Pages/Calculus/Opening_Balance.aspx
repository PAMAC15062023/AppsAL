<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Opening_Balance.aspx.cs" Inherits="Pages_Calculus_Opening_Balance" Title="Opening Balance" StyleSheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">

function GV_RowSelection(RowNo,id)
{
  var RowNo=(parseInt(RowNo)+1);
  var hndBranchId=document.getElementById("<%=hndBranchId.ClientID%>");
  var ddlBranchName=document.getElementById("<%=ddlBranchName.ClientID%>");
  var ddlMonth=document.getElementById("<%=ddlMonth.ClientID%>");
  var ddlYear=document.getElementById("<%=ddlYear.ClientID%>");
  var txtAmount=document.getElementById("<%=txtAmount.ClientID%>");
  var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
  var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
  var Gr_Ope_Bal=document.getElementById("<%=Gr_Ope_Bal.ClientID%>");
  
  hndBranchId.value=Gr_Ope_Bal.rows[RowNo].cells[0].innerText; 
  ddlBranchName.value=Gr_Ope_Bal.rows[RowNo].cells[1].innerText; 
  ddlYear.value=Gr_Ope_Bal.rows[RowNo].cells[3].innerText; 
  ddlMonth.value=Gr_Ope_Bal.rows[RowNo].cells[8].innerText;
  txtAmount.value=Gr_Ope_Bal.rows[RowNo].cells[5].innerText; 
  ddlIsActive.value=Gr_Ope_Bal.rows[RowNo].cells[6].innerText; 
  txtRemark.value=Gr_Ope_Bal.rows[RowNo].cells[7].innerText;
  
   var i=0;
        for(i=0;i<=Gr_Ope_Bal.rows.length-1;i++)       
        {
            if (i!=0)
            {
                if (hndBranchId.value==Gr_Ope_Bal.rows[i].cells[0].innerText)
                {
                 Gr_Ope_Bal.rows[i].style.backgroundColor = "DarkGray";
                }
                else 
                {
                   Gr_Ope_Bal.rows[i].style.backgroundColor = "white";          
                }
          }
        }
  }
  
  function Validation_AllField()
  {
    // //debugger;
     var ReturnType=true;
     var ErrorMessage="";
     
     var hndBranchId=document.getElementById("<%=hndBranchId.ClientID%>");
     var ddlBranchName=document.getElementById("<%=ddlBranchName.ClientID%>");
     var ddlMonth=document.getElementById("<%=ddlMonth.ClientID%>");
     var ddlYear=document.getElementById("<%=ddlYear.ClientID%>");
     var txtAmount=document.getElementById("<%=txtAmount.ClientID%>");
     var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
     var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
     var Gr_Ope_Bal=document.getElementById("<%=Gr_Ope_Bal.ClientID%>");
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
    
        if(ddlBranchName.selectedIndex==0)
        {
            ErrorMessage="Plz Select Branch Name";
            ReturnType=false;
        }
        if(ddlMonth.selectedIndex==0)
        {
          ErrorMessage="Plz Select Proper Month";
          ReturnType=false;
        }
        if(ddlYear.selectedIndex==0)
        { 
          ErrorMessage="Plz Select Current Year";
          ReturnType=false;
        }
        //if(txtAmount.value=="" || txtAmount.value==0)
        //{ 
         // ErrorMessage="Plz Enter Amount";
         // ReturnType=false;
        //}
        if(txtAmount.value==''|| txtAmount.value==0)
             {
               ErrorMessage="Plz Enter Amount";
               ReturnType=false;
             } 
        else
             {
               var regex1=/^((\d{1,9})(|\056{1}\d{1,2}))$/;  //this is the pattern of regular expersion
                        if(regex1.test(txtAmount.value)== false)
                        {
                            ErrorMessage="Please enter valid tax";
                            ReturnType=false;
                            txtAmount.focus();     
                        }
             }
        
        if(ddlIsActive.selectedIndex==0)
        { 
          ErrorMessage="Plz Select IsActive";
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
  
function dropdown_validator()
{ ////debugger;
  var ddlMonth=document.getElementById("<%=ddlMonth.ClientID%>");
  var ddlYear=document.getElementById("<%=ddlYear.ClientID%>");
     
    var right_now=new Date();
    var the_year=right_now.getYear();
    var the_month=right_now.getMonth();

   if (ddlYear.value > the_year)
        {
            alert("Please check the year of your request.");
            return(false);
        }
        return(true);
}
 
</script>
    <table>
        <tr>
            <td class="TableHeader" colspan="4">
                Monthly BranchWise Opening Balance</td>
        </tr>
        <tr>
            <td colspan="4" style="width: 268px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="857px"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableTitle">
                &nbsp;Branch Name</td>
            <td style="width: 264px;" class="TableGrid">
                <asp:DropDownList ID="ddlBranchName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 101px;">
                <asp:HiddenField ID="hndBranchId" runat="server" Value="0" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="TableTitle">
                &nbsp;Opening Year &amp; Month</td>
            <td style="width: 264px; height: 15px" class="TableGrid">
                <asp:DropDownList ID="ddlMonth" runat="server" Width="78px" SkinID="ddlSkin">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" Width="78px" SkinID="ddlSkin">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 101px">
            </td>
            <td style="width: 105px; height: 15px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 17px">
                &nbsp;Amount</td>
            <td style="width: 264px; height: 17px" class="TableGrid">
                <asp:TextBox ID="txtAmount" runat="server" CssClass="txtSkin" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 101px; height: 17px">
            </td>
            <td style="width: 105px; height: 17px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Is Active</td>
            <td style="width: 264px; height: 24px" class="TableGrid">
                <asp:DropDownList ID="ddlIsActive" runat="server" Width="112px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 101px; height: 24px;">
            </td>
            <td style="width: 105px; height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 29px" class="TableTitle">
                &nbsp;Remark</td>
            <td style="width: 264px; height: 29px" class="TableGrid">
                <asp:TextBox ID="txtRemark" runat="server" Width="232px" Columns="4" Rows="4" 
                    SkinID="txtSkin"></asp:TextBox>
            </td>
            <td style="height: 29px">
            </td>
            <td style="height: 29px">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 30px" class="TableTitle">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="24px" Width="79px" BorderWidth="1px" />
                <asp:Button ID="btnAdd" runat="server" Text="Add" Height="24px" Width="79px" OnClick="btnAdd_Click" BorderWidth="1px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="24px" Width="79px" OnClick="btnCancel_Click" BorderWidth="1px" />
                &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" class="TableHeader">
            &nbsp;&nbsp; Branch Opening View
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="Gr_Ope_Bal" runat="server" AutoGenerateColumns="False" 
                    OnRowDataBound="Gv_Opening_Balance_RowDataBound" BorderStyle="Double" 
                    BorderColor="Black" CssClass="mGrid">
                <Columns>
                 <asp:BoundField DataField="openingBalanceID">
                     <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                     <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                 </asp:BoundField>
                 <asp:BoundField DataField="BranchID">
                     <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                     <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Region_Name" HeaderText="Branch"/>
                 <asp:BoundField DataField="openingBalanceYear" HeaderText="Year"/>
                 <asp:BoundField DataField="openingBalanceMonth" HeaderText="Month"/>
                 <asp:BoundField DataField="OpeningBalanceAmount" HeaderText="Amount" />
                 <asp:BoundField DataField="IsActive" HeaderText="Active" />
                 <asp:BoundField DataField="Remark" HeaderText="Remark"/>
                 <asp:BoundField DataField="MonthId" >
                     <HeaderStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                     <ItemStyle CssClass="grv_Column_hidden" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                 </asp:BoundField>           
                </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

