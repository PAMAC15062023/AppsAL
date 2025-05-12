<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveOpeBalReq.aspx.cs" Inherits="Pages_Calculus_ApproveOpeBalReq" Title="ApproveRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 
    function checkSelected(chkSelect_ID)
      {
        ////debugger;
        var GridApproval=document.getElementById("<%=GridApproval.ClientID%>");
        var chkSelect=document.getElementById(chkSelect_ID);
         
         
        var cell;
           for (i=0;i<=GridApproval.rows.length - 1; i++)
            {
                cell = GridApproval.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {
                            if (cell.childNodes[j].checked ==true)
                            {
                                cell.childNodes[j].checked =false;
                            }
                            
                            
                        }
                    }
                }
            
             }
            
           
            chkSelect.checked=true;  
      } 
        
    function Get_SelectedTransactionID(ID)
    {
        ////debugger;
        var GridApproval=document.getElementById("<%=GridApproval.ClientID%>");
        var hdnOperationID=document.getElementById("<%=hdnOperationID.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var ReturnValue=true;
        var ErrorMessage='';
        
    
            var cell;
           for (i=0;i<=GridApproval.rows.length - 1; i++)
            {
                cell = GridApproval.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {
                            if (cell.childNodes[j].checked ==true)
                            {    
                                   
                                    if((GridApproval.rows[i].cells[8].innerText!='Pending')&&(ID==1))
                                    {
                                        ErrorMessage="you cannot modify selected entry!";
                                        ReturnValue=false;
                                    }
                                   
                                     hdnOperationID.value=GridApproval.rows[i].cells[1].innerText;                                                                      
                                    
                                     break;
                            }
                        }
                    }
                }
            
             }
        
        
        
        //if (hdnOperationID.value=='')
        //{
        //    ErrorMessage="Please select atleast one record to continue!";
        //    ReturnValue=false;    
        
        //}       
        lblMessage.innerText=ErrorMessage;
        window.scroll(0,0);
        return ReturnValue;
        
    }
  
</script>
    <table style="width: 870px; height: 32px">
        <tr>
            <td colspan="3" class="TableHeader">
                Approval Data Form</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMessage" runat="server" Width="726px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableTitle">
                BranchID</td>
            <td>
                <asp:DropDownList ID="ddlBranchID" runat="server">
                </asp:DropDownList></td>
            <td style="height: 8px">
                <asp:HiddenField ID="hdnOperationID" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 41px; height: 18px" class="TableTitle">
                Status</td>
            <td style="width: 48px">
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <%--<asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">Pending</asp:ListItem>
                    <asp:ListItem Value="2">Accept</asp:ListItem>
                    <asp:ListItem Value="3">Reject</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td colspan="3" rowspan="1">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /></td>
        </tr>
        <tr>
            <td colspan="3" rowspan="1">
                <asp:GridView ID="GridApproval" runat="server" AutoGenerateColumns="False" 
                    BorderColor="Black" BorderStyle="Double" 
                    OnRowDataBound="GridApproval_RowDataBound" CssClass="mGrid">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                                <asp:HiddenField ID="hdfOperationID" runat="server" Value='<%# Bind("openingBalanceID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="openingBalanceID" >
                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                CssClass="grv_Column_hidden" />
                            <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                        <asp:BoundField DataField="openingBalanceMonth" HeaderText="Month" />
                        <asp:BoundField DataField="openingBalanceYear" HeaderText="Year" />
                        <asp:BoundField DataField="OpeningBalanceAmount" HeaderText="Amount"/>
                        <asp:BoundField DataField="RequestType" HeaderText="RequestType" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />     
                        <asp:BoundField DataField="StatusId" >
                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                CssClass="grv_Column_hidden" />
                            <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3" rowspan="1">
                &nbsp;
                <asp:Button ID="btnAccept" runat="server" Text="Accept" OnClick="btnAccept_Click" />&nbsp;
                <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" rowspan="2" style="width: 155px; height: 18px">
                &nbsp; &nbsp;
            </td>
        </tr>
        </table>
</asp:Content>

