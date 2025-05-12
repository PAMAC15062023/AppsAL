<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="Hr_UploadFile.aspx.cs" Inherits="HR_HR_Hr_UploadFile" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function CheckText()
 {
 debugger;
var empCode='';
var empName='';
 
empCode=document.getElementById("<%=txtEmpCode.ClientID%>");
empName=document.getElementById("<%=txtEmployeeName.ClientID%>");

 if((empCode.value=="") && (empName.value==""))
    {
    
   
    alert('-Please Enter any one either PAMACian Code or PAMACian Name');
    empCode.focus();
    return false;
    }
// else if((empCode.value!="") && (empName.value==""))
//  {
// 
//  } 
  else if (empName.value !="" )
  {
  if(isNaN(empName.value))
  {
   
   }
   else
   {
   alert('Please provide Non Numeric Value only...');
   empName.focus();
   return false;
   } 
  }
//  else
// { 
//  
// }  
 
    
 
    
 }
 function CheckNumericText()
 {
 debugger;

var empName='';
 

empName=document.getElementById("<%=txtEmployeeName.ClientID%>");
 if (isNaN(empName.value))
  {
   return true; 
  }   
 else
 { 
   alert('Please provide Non Numeric Value only...');
   empName.focus();
   return false; 
 }
 } 

function checkFields()
   {  
           
            
             
    chkRecord=false;
     debugger;
    var count='<%=Session["RowCount"]%>';
      if(count>0)
      {
        chk='';   
        var cnt;     
        chkRecord=false;
        cnt=2;  
            for(i=0; i<count; i++)
            {  
                      
                chk="ctl00_ContentPlaceHolder1_gvUpload_ctl0"+cnt+"_FileUpload1";        
                if(cnt > 9)
                {         
                chk="ctl00_ContentPlaceHolder1_gvUpload_ctl"+cnt+"_FileUpload1";
                }
                getFileUpload1='';
                getFileUpload1=document.getElementById(chk);                
                if(getFileUpload1.value != "")
                {
                  chkRecord = true;       
                }       
                cnt = cnt + 1; 
             }
         if( chkRecord==false)
         {
               alert('Please Browse  at least one ');
               return false;  
         }  
    }  
    
}

</script>





<fieldset><legend class="FormHeading"><b>Image Upload</b></legend>   

<table>  
    <tr>
        <td colspan="8">
            <asp:Label ID="lblMessage" runat="server" Text="" Width="590px" ForeColor="Red" Font-Bold="true"></asp:Label></td>
    </tr>
<tr>
<td >
</td>
<td style="width: 1%">
</td>
<td>
</td>
<td >
</td>
<td>
</td>
<td>
</td>
<td>
</td>
<td style="width: 13%">
</td>

</tr>
<tr>
<td >
    PAMACian Code</td>
<td >:</td>
<td >
<asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" Width="141px" MaxLength="15"></asp:TextBox></td>
<td>
</td>
<td>
</td>
<td >
</td>
<td ></td>
<td >
</td>

</tr>
<tr>    
<td valign="Middle" >
    PAMACian Name</td>
<td valign="Middle" style="width: 1%">
    :</td>
<td >
    <asp:TextBox ID="txtEmployeeName" runat="server" SkinID="txtSkin" Width="141px" MaxLength="300" ></asp:TextBox></td>
<td valign="Middle" >
    <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" Text="Search" OnClick="btnSearch_Click" OnClientClick="javascript:return CheckText();" /></td>
<td valign="Middle" >
</td>
<td  >
</td>
<td>
</td>
<td style="width: 13%">
</td>
</tr>
    
    <tr>
        <td valign="middle" >
       </td>
        <td valign="middle">
        </td>
        <td >
            </td>
        <td valign="middle">
           </td>
        <td valign="middle">
            </td>
        <td>
           </td>
        <td>
        </td>
        <td >
        </td>
    </tr>
</table>  
<table width="98%">
<tr>
   
        <td colspan="8">
            </td>
    </tr>
    <tr>
      
        <td  colspan="8">
            <asp:GridView ID="gvCheckSelect" runat="server" DataKeyNames="ID,Employee Code,Name,Cluster Name,Centre Name,Subcentre Name" AutoGenerateColumns="False" SkinID="gridviewSkin" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:RadioButton ID="rdoSelect"  AutoPostBack="true" runat="server" Width="90px" OnCheckedChanged="rdoSelect_CheckedChanged" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="Emp ID" Visible="False"></asp:BoundField>
                    
                   
			        <asp:BoundField DataField="Employee Code" HeaderText="PAMACian Code"></asp:BoundField>		
    			    <asp:BoundField DataField="Name" HeaderText="PAMACian Name"></asp:BoundField>
                    <asp:BoundField DataField="Cluster Name" HeaderText="Cluster Name" />
                    <asp:BoundField DataField="Centre Name" HeaderText="Centre Name" />
                    <asp:BoundField DataField="Subcentre Name" HeaderText="Sub Centre Name" />
                </Columns>
            </asp:GridView>
        
        </td>
    </tr>
    <tr>
        <td colspan="8">
        </td>
    </tr>
    </table>
    <table id="tblLable" runat="server">
<tr>
<td><b>Cluster Name</b></td>
<td width="1%"><b>:</b></td>
<td > <asp:Label ID="lblClusterName" runat="server" Width="126px"></asp:Label></td>
<td ><b>PAMACian Code</b></td>
<td width="1%"><b>:</b></td>
<td colspan="4"><asp:Label id="lblEmpCode" runat="server" Width="170px"></asp:Label></td>

</tr>
<tr>
<td><b>Centre Name</b></td>
<td width="1%"><b>:</b></td>
<td> <asp:Label ID="lblCentreName" runat="server" Width="126px"></asp:Label></td>
<td><b>PAMACian Name</b></td>
<td width="1%"><b>:</b></td>
<td colspan="4"><asp:Label ID="lblEmpName" runat="server" Width="207px"></asp:Label></td>

</tr>
        <tr>
            <td>
               <b> SubCentre Name</b></td>
            <td width="1%"><b>:</b>
            </td>
            <td>
                <asp:Label ID="lblSubCentreName" runat="server" Width="124px"></asp:Label></td>
            <td >
            </td>
            <td width="1%">
            </td>
            <td >
            </td>
            <td >
            </td>
            <td width="1%">
            </td>
            <td>
            </td>
        </tr>
</table>
    
    <table width="98%">
    <tr>
     
        <td colspan="8">
        </td>
    </tr>
        <tr>
            <td colspan="8">
            </td>
        </tr>
    <tr>
        
        <td colspan="8">
        </td>
    </tr>
    <tr>
       
        <td colspan="8">
        
     <asp:GridView ID="gvUpload" SkinID="gridviewSkin"  DataKeyNames="ID,Education_Qualification_Id,Employee Code,UploadFilePath" runat="server" AutoGenerateColumns="False" Width="100%" OnDataBound="gvUpload_DataBound" OnRowCommand="gvUpload_RowCommand" OnRowDataBound="gvUpload_RowDataBound" >
        <Columns>
			    <asp:BoundField DataField="ID" HeaderText="Emp ID" Visible="false"></asp:BoundField>
			  
			    <asp:BoundField DataField="Employee Code" HeaderText="Employee Code" Visible="false"></asp:BoundField>		
    			<asp:BoundField DataField="Name" HeaderText="Employee Name" Visible="false"></asp:BoundField>
    			<asp:BoundField DataField="DocType" HeaderText="Doc.Type"></asp:BoundField>
    			
    			<asp:BoundField DataField="Education_Qualification_Id" Visible="false" HeaderText="Qualification ID"></asp:BoundField>
    			<asp:BoundField DataField="Document name" HeaderText="Document Name"></asp:BoundField>
    			
    			<asp:TemplateField HeaderText="File Name">						
				    <ItemTemplate>
				    <asp:HyperLink ID="HyperLink1" runat="server"><%# Eval("UploadFilePath")%></asp:HyperLink> 	
                    
				    </ItemTemplate>
			    </asp:TemplateField>
    				
    			<asp:TemplateField HeaderText="View File">						
				    <ItemTemplate>
				    
                    <asp:HyperLink ID="lnkViewPhoto" runat="server" ForeColor="#B1005D" Font-Bold="true"  NavigateUrl='<%#"EmployeePhoto/" + Eval("UploadFilePath")%>' Target="_blank" Visible="False">View</asp:HyperLink> 
                    <asp:HyperLink ID="lnkViewDocument" runat="server" ForeColor="#B1005D" Font-Bold="true" NavigateUrl='<%#"EmployeeDocument/" + Eval("UploadFilePath")%>' Target="_blank" Visible="False">View</asp:HyperLink>                    						                        
				    </ItemTemplate>
			    </asp:TemplateField>
			    					
			    <asp:TemplateField HeaderText="Browse">						
				    <ItemTemplate>								
                        <asp:FileUpload ID="FileUpload1" runat="server" skinID="flup"/> 
                        
                      <%--  <asp:HyperLink ID="HyperLink1" runat="server"><%# Eval("UploadFilePath")%></asp:HyperLink>                       --%>
				    </ItemTemplate>
			    </asp:TemplateField>
			     <asp:TemplateField HeaderText="Delete">
                 <ItemTemplate>
                   <%--  <asp:LinkButton ID="lbDelete" runat="server" CommandName="Del" CommandArgument='<%# Eval("ID")+"-"+Eval("Education_Qualification_Id")+"-"+Eval("UploadFilePath")+"-"+Eval("Document name")+"-"+Eval("Employee Code")%>' OnClientClick="return confirm('Are you sure you want to delete this record?')" Text="Delete"></asp:LinkButton>--%>
                     <asp:LinkButton ID="lbDelete" runat="server" CommandName="Del" CommandArgument='<%# Eval("Employee Code")+"*"+Eval("ID")+"*"+Eval("Education_Qualification_Id")+"*"+Eval("Document name")+"*"+Eval("UploadFilePath")%>' OnClientClick="return confirm('Are you sure you want to delete this record?')" Text="Delete"></asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateField>
	    </Columns>
    </asp:GridView>
  
        </td>
    </tr>
        <tr>
            <td colspan="8" align="right">
            <asp:Button SkinID="btn"  id="btnBatchUpload"  OnClientClick="javascript:return checkFields();" runat="server" Text="Batch Upload" OnClick="btnBatchUpload_Click" ></asp:Button></td>
        </tr>
    </table>
    <table>
    
    <tr>
       
        <td colspan="8" align="right">
         <asp:HiddenField ID="hdnId" runat="server" Value="" />
         <asp:HiddenField id="hdnEmpCode" runat="server" Value=""></asp:HiddenField>
            </td>
    </tr>
</table>



<table>
<tr>
        
        <td colspan="8"><asp:HiddenField id="hidMessage" runat="server" Value=""/>
            <%-- <asp:RequiredFieldValidator ID="refEmpCode" runat="server" ControlToValidate="txtDate5thCall"
                Display="None" ErrorMessage="Enter Date in 5th call." SetFocusOnError="True"
                ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="vsAttempt" runat="server" ValidationGroup="grpAttempts" ShowMessageBox="True" ShowSummary="False" />--%>
                </td>
       
    </tr>
    <tr>
        <td align="left" colspan="8">
        </td>
    </tr>
    <tr>
     <td colspan="8" >
            </td>
                 </tr>
                 <tr>
                 <td colspan="8" >
                     </td></tr>

</table>


</fieldset>

</asp:Content>

