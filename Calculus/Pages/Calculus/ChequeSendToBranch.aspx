<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChequeSendToBranch.aspx.cs" Inherits="Pages_Calculus_ChequeSendToBranch"
    Title="Cheque SentTo Branch" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>

    <script language="javascript" type="text/javascript">
    
    function ValidateGenerate() 
    {
        var ErrorMessage="";
        var returnValue=true;
        
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var txtFromDate=document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
        
        if (txtFromDate.value=="")
        {
            returnValue=false;
            ErrorMessage='Please select FromDate to continue!';
        }
        else if(txtToDate.value=="") 
        {
            returnValue=false;
            ErrorMessage='Please select ToDate to continue!';
        }     
        window.scroll(0,0);
        lblMessage.innerText=ErrorMessage;    
        return returnValue;
    }    
    
    function ValidateSave()
    {
        ////debugger;
        var ErrorMessage="";
        var returnValue=true;
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var SelectedCount=0;
        
        var grvTransactionInfo=document.getElementById("<%=grvTransactionInfo.ClientID%>");
        if (grvTransactionInfo!=null)
        {
        var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                cell = grvTransactionInfo.rows[i].cells[1];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {                            
                             if ((cell.childNodes[j].checked ==true)&&(grvTransactionInfo.rows[i].cells[9].innerText=="Payment Dispatch"))
                             {
                                returnValue=false;
                                ErrorMessage='Payment Entry Already Dispatched!';
                                SelectedCount=SelectedCount+1;
                                break;  
                             }
                            else if ((cell.childNodes[j].checked == true) && (grvTransactionInfo.rows[i].cells[9].innerText == "Cheque Printed"))
                             {
                                 SelectedCount=SelectedCount+1;
                             } 
                        }
                    }
                }
            
             }   
             
         }
         else 
         {
            returnValue=false;
         }
             
             
        if (SelectedCount==0)     
        {
            returnValue=false;
            ErrorMessage='No Entry Selected for Payment Dispatch!';
        }
        lblMessage.innerText=ErrorMessage;
        window.scroll(0,0);        
        return returnValue;
    
    }    
    function CheckAll()
    {    
     var grvTransactionInfo=document.getElementById("<%=grvTransactionInfo.ClientID%>");
     var chkSelectAll=document.getElementById('chkSelectAll');    
     var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                cell = grvTransactionInfo.rows[i].cells[1];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {                            
                             cell.childNodes[j].checked =chkSelectAll.checked;                             
                        }
                    }
                }
            
             }
            
    
    }    
    function switchViews(obj,row)
        {       
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);
            
            if (div.style.display=="none")
                {
                    div.style.display = "inline";
                    if (row=='alt')
                       {
                           img.src="Images/close.png" ;
                            mce_src="Images/close.png";
                       }
                   else 
                    
                       {
                           img.src="Images/close.png" ;
                           mce_src="Images/close.png";
                       }
                   img.alt = "Close to view other customers";
               }
           else
               {
                   div.style.display = "none";
                   if (row=='alt')
                       {
                          
                           img.src="Images/open.png" ;
                           mce_src="Images/open.png";
                      }
                   else
                       {
                        img.src="Images/open.png";
                         mce_src="Images/open.png";
                           
                       }
                   img.alt = "Expand to show Transactions";
               }
       }

    </script>

    <table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7">
                &nbsp;Cheque Send to Branch</td>
        </tr>
        <tr>
            <td style="width: 5px">
            </td>
            <td class="TableTitle" style="width: 125px">
                &nbsp;Branch
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle" style="width: 109px">
                &nbsp;Status</td>
            <td class="TableGrid" style="width: 100px">
                <asp:DropDownList ID="ddlPaymentStatus" runat="server" SkinID="ddlSkin">
                    <%--<asp:ListItem Value="Cheque Printed">Cheque Printed</asp:ListItem>
                    <asp:ListItem Value="Payment Dispatch">Payment Dispatched</asp:ListItem>--%>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 5px;">
            </td>
            <td class="TableTitle" style="width: 125px;">
                &nbsp;Payment From Date</td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px; height: 20px">
                            </td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="width: 109px;">
                &nbsp;Payment To Date</td>
            <td style="width: 100px;" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 17px" /></td>
                        <td style="width: 100px">
                            </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 31px">
                &nbsp;&nbsp;
                <asp:Button ID="btnGeneRate" runat="server" AccessKey="G" BorderWidth="1px"
                    Text="Generate" ToolTip="Alt+S to Generate" Width="78px" OnClick="btnGeneRate_Click"
                    ValidationGroup="ValGenReport" />
                <asp:Button ID="btnReset" runat="server" AccessKey="R" BorderWidth="1px" Text="Reset"
                    ToolTip="Alt+R for Reset" Width="53px" /></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7">
                &nbsp; Cheque Pending for Sent To Branch</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="overflow: scroll; width: 823px; height: 201px">
                 
                    <asp:GridView ID="grvTransactionInfo" runat="server" 
                        AutoGenerateColumns="False" DataKeyNames="TransactionID" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                        PageSize="20" CssClass="mGrid">
                        <RowStyle Font-Names="Tahoma" Font-Size="8pt" />
                        <Columns>
                            <asp:TemplateField>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'alt');">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="Images/open.png" style="border-top-style: none; border-right-style: none;
                                            border-left-style: none; border-bottom-style: none" />
                                    </a>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'one');" style="border-top-style: none;
                                        border-right-style: none; border-left-style: none; background-color: #ffffff;
                                        border-bottom-style: none">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="Images/open.png" style="border-top-style: none; border-right-style: none;
                                            border-left-style: none; border-bottom-style: none" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PaymentID" HeaderText="PaymentID" />
                            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
                            <asp:BoundField DataField="BranchName" HeaderText="Branch" SortExpression="BranchName" />
                            <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" SortExpression="PaymentRequestDate" />
                            <asp:BoundField DataField="TotalPaymentAmount" HeaderText="Total Payment Amt" SortExpression="RequestedAmount" />
                            <asp:BoundField DataField="No_Of_Request" HeaderText="Request (Nos)" SortExpression="Status" />
                            <asp:BoundField DataField="No_Of_Payment_Made" HeaderText="Payment (Nos)" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("AutoNo") %>' style="display: none; position: inherit; left:15px; overflow: scroll;">
                                                <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="TransactionID"
                                                    EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                    GridLines="Horizontal" Width="80%">
                                                    <Columns>
                                                        <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" />
                                                        <asp:BoundField DataField="CRSNo" HeaderText="CRS No" />
                                                        <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                                                        <asp:BoundField DataField="RequestDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="RequestDate"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="AutorizeDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="AutorizeDate"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="Authorizeby" HeaderText="AutorizeDate" />
                                                        <asp:BoundField DataField="BillNo" HeaderText="BillNo" />
                                                        <asp:BoundField DataField="BillDate" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="BillDate"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="PaymentDate" DataFormatString="{0:MMM-dd-yyyy}" HtmlEncode="False"
                                                            HeaderText="PaymentDate" />
                                                        <asp:BoundField DataField="ChequeNo" HeaderText="ChequeNo" />
                                                        <asp:BoundField DataField="ChequeAmt" HeaderText="ChequeAmt" />
                                                        <asp:BoundField DataField="ChequeIssueTo" HeaderText="ChequeIssueTo" />
                                                        <asp:BoundField DataField="BankName" HeaderText="BankName" />
                                                        <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                                                        <asp:BoundField DataField="PaymentBy" HeaderText="PaymentBy" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                                                        Font-Overline="False" Font-Size="7.5pt" Font-Underline="False" ForeColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Font-Names="Tahoma" Font-Size="8pt" />
                    </asp:GridView>
                   
                    
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 33px;" class="TableTitle" colspan="7">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" AccessKey="S" BorderWidth="1px" Text="Save"
                    ToolTip="Alt+S for Save" Width="53px" OnClick="btnSave_Click" />
                <asp:Button ID="btnExport" runat="server" AccessKey="E" BorderWidth="1px" Text="Export"
                    ToolTip="Alt+E for Export to Excel" Width="53px" OnClick="btnExport_Click" />&nbsp;<asp:Button ID="btnCancel"
                        runat="server" AccessKey="C" BorderWidth="1px" Text="Cancel" ToolTip="Alt+C for Cancel "
                        Width="53px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>            
            <td colspan="7">
            <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                    width="100%">
                    <tr>
                        <td style="height: 145px">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TransactionID" Font-Size="8pt"
                        PageSize="20" CssClass="grv_Column_hidden">
                <RowStyle Font-Names="Tahoma" Font-Size="8pt" />
                <Columns>
                    <asp:BoundField DataField="PaymentID" HeaderText="PaymentID" />
                    <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="BranchName" HeaderText="Branch" SortExpression="BranchName" />
                    <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" SortExpression="PaymentRequestDate" />
                    <asp:BoundField DataField="TotalPaymentAmount" HeaderText="Total Payment Amt" SortExpression="RequestedAmount" />
                    <asp:BoundField DataField="No_Of_Request" HeaderText="Request (Nos)" SortExpression="Status" />
                    <asp:BoundField DataField="No_Of_Payment_Made" HeaderText="Payment (Nos)" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
                <HeaderStyle Font-Names="Tahoma" Font-Size="8pt" />
            </asp:GridView>
             </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
</asp:Content>
