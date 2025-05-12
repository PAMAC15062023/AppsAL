<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChequePrinting_Report.aspx.cs" Inherits="Pages_ChequePrinting_Report"
    Title="Cheque Printing Report" StylesheetTheme="SkinFile" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>

    <script language="javascript" type="text/javascript">

    var ChequeNoCount=0;
    var count1 = 1;

    function Validation_UpdateStatus() {

        var ReturnValue = true;
        var ErrorMessage = "";

        var grvTransactionInfo = document.getElementById("<%=Grid_View_Cheque.ClientID%>");
        var hdnPrintChequeStatus = document.getElementById("<%=hdnPrintChequeStatus.ClientID%>");

        var lblMessage = document.getElementById("<%=lblMessage .ClientID%>");

        if (grvTransactionInfo == null) {

            ErrorMessage = "Please select atleast one record to continue! ";
            ReturnValue = false;
        }
        else if (grvTransactionInfo.rows.length == 0)
        {

            ErrorMessage = "Please select atleast one record to continue! ";
            ReturnValue = false;     
        
        }
        if (hdnPrintChequeStatus.value == '') {

            ErrorMessage = "Cannot continue, no cheque print done! ";
            ReturnValue = false;
        }


        lblMessage.innerText = ErrorMessage;
        lblMessage.className = 'ErrorMessage';

        window.scroll(0, 0);
        return ReturnValue;

    
    
    }

    function ChequeCountDisplay() {

        var TotalCheques=0;
        var SelectedCount=0;
        var lblChequeCount = document.getElementById("<%=lblChequeCount.ClientID%>");
        var grvTransactionInfo = document.getElementById("<%=Grid_View_Cheque.ClientID%>");
        if (grvTransactionInfo != null) {
            TotalCheques = grvTransactionInfo.rows.length-1;
            SelectedCount = Get_SelectedChequeCount();
      
        }

        lblChequeCount.innerText= SelectedCount + " of " + TotalCheques;
    }
    function Get_ChequeNo_Sequence()
    {    
        var ChequeSeries = 1;
        var chequeNo=0;
        var output='';
         
        var txtChkSeriesStart=document.getElementById("<%=txtChkSeriesStart.ClientID%>");
        var txtChkSeriesEnd=document.getElementById("<%=txtChkSeriesEnd.ClientID%>");
         
        for (chequeNo = txtChkSeriesStart.value; chequeNo <= txtChkSeriesEnd.value; chequeNo++)
        {
            if (count1 == ChequeSeries)
            {
                output=chequeNo;
                count1=count1+1;                
                break;
            }            
            ChequeSeries=ChequeSeries+1;  
        } 
        
        return chequeNo;
    } 
    
    function Final_PrintCheques()
    {
        
        var grvTransactionInfo=document.getElementById("<%=Grid_View_Cheque.ClientID%>");
        var hdnPrintReport=document.getElementById("<%=hdnPrintReport.ClientID%>");
        var hdnPrintChequeStatus=document.getElementById("<%=hdnPrintChequeStatus.ClientID%>");                          
        var ReportServerPath=document.getElementById("<%=ReportServerPath.ClientID%>");                          
         
        hdnPrintChequeStatus.value='';
        var chkSelectAll=document.getElementById('chkSelectAll');           
        var cell;
        
        var pCrossChequeValue="";
        var pChequeIssueTo="";
        var pChequeDate="";
        var pAmountInWord="";
        var pChequeAmount="";
        var pPaymentID="";
        var pChequeNo = "";
        var pChequeIssueToMain = "";

        if (grvTransactionInfo != null) {
            for (i = 0; i <= grvTransactionInfo.rows.length - 1; i++) {

                cell = grvTransactionInfo.rows[i].cells[0];
                if ((cell != null) && (cell.tagName == 'TD')) {
                    for (j = 0; j < cell.childNodes.length; j++) {

                        if (cell.childNodes[j].type == "checkbox") {
                            if (cell.childNodes[j].checked == true) {

                                pPaymentID = grvTransactionInfo.rows[i].cells[1].innerText;
                                pCrossChequeValue = grvTransactionInfo.rows[i].cells[13].innerText;
                                pChequeIssueTo = grvTransactionInfo.rows[i].cells[8].innerText;
                                pChequeDate = grvTransactionInfo.rows[i].cells[10].innerText;
                                pAmountInWord = grvTransactionInfo.rows[i].cells[7].innerText;
                                pChequeAmount = grvTransactionInfo.rows[i].cells[6].innerText;
                                pChequeIssueToMain = grvTransactionInfo.rows[i].cells[8].innerText;

                                pChequeNo = Get_ChequeNo_Sequence();

                                pChequeIssueTo = pChequeIssueTo.replace("&", " And ");
                                pChequeIssueTo = pChequeIssueTo.replace("#", " ");

                                window.showModalDialog('ReportViewer.aspx?1=' + pCrossChequeValue + '&2=' + pChequeIssueTo + '&3=' + pChequeDate + '&4=' + pAmountInWord + '&5=' + pChequeAmount + '&6=' + hdnPrintReport.value + '', '_blank', 'dialogHeight:360px;dialogWidth:800px;status:no;edge:sunken;scroll:no;help:no');

//                                var answer = confirm('Cheque Printed Correctly!');
//                                if (answer == true) {
                                    grvTransactionInfo.rows[i].cells[9].innerText = pChequeNo;
                                    Confirm_ChequePrint(pPaymentID, pChequeNo, pChequeAmount, pChequeIssueToMain, true);
//                                }
                            }
                            else {
                                grvTransactionInfo.rows[i].cells[9].innerText = '';
                            }
                        }
                    }
                }


            }
        }
    
    }

    function Confirm_ChequePrint(PaymentID, ChequeNo, Amount, ChequeIssueTo, Value) {
        
        var hdnBankID=document.getElementById("<%=hdnBankID.ClientID%>");                          
        var hdnBankBranchID=document.getElementById("<%=hdnBankBranchID.ClientID%>");                          
        
        var hdnPrintChequeStatus=document.getElementById("<%=hdnPrintChequeStatus.ClientID%>");                          
        hdnPrintChequeStatus.value=hdnPrintChequeStatus.value+PaymentID+'|'+ChequeNo+'|'+Amount+'|'+ChequeIssueTo+'|'+hdnBankID.value+'|'+hdnBankBranchID.value+'^';
    }
    
    function Page_load_validation()
    {
        Validation_Count();
        ChequeCountDisplay();
    }
    
    
    function Validate_PrintCheques()
    {  
         
        var returnValue=true;
        var ErrorMessage="";
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");      
        var hdnPrintReport=document.getElementById("<%=hdnPrintReport.ClientID%>");                  
        var txtChkSeriesStart=document.getElementById("<%=txtChkSeriesStart.ClientID%>");
        var txtChkSeriesEnd=document.getElementById("<%=txtChkSeriesEnd.ClientID%>");
        var grvTransactionInfo = document.getElementById("<%=Grid_View_Cheque.ClientID%>");
                 
        var chequeSelectedCount=0;
        if (grvTransactionInfo != null) {

            chequeSelectedCount = Get_SelectedChequeCount();
        }
      
        if ((chequeSelectedCount==0)||(ChequeNoCount==0))
        {
             ErrorMessage='Please select atleast one cheque to print!';
             returnValue=false;        
        } 
        
        if (chequeSelectedCount==ChequeNoCount)
        {
            if (hdnPrintReport.value=='')
            {
                ErrorMessage='Cheque Print Report not Set!, please ask your administrator!';
                returnValue=false;
            }
        }
        else
        {
            ErrorMessage='Selected Cheques and Cheque No Count are mismatch!'
            returnValue=false;
            
        } 
        if ((txtChkSeriesStart.value=='')||(txtChkSeriesEnd.value==''))
        {
            ErrorMessage='Please enter Cheque No (From-To) Continue...!';
            returnValue=false;
        
        }
        
        if (returnValue==true)
        {
            count1=1;
            Final_PrintCheques();
        }        
        
        lblMessage.innerText=ErrorMessage;
        lblMessage.className = 'ErrorMessage';

        window.scroll(0, 0);
        
        return false;
    }
    
    function Validation_Count()
    {
        var ErrorMessage="";
        var txtChkSeriesStart=document.getElementById("<%=txtChkSeriesStart.ClientID%>");
        var txtChkSeriesEnd=document.getElementById("<%=txtChkSeriesEnd.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var lblCount=document.getElementById("<%=lblCount.ClientID%>");
        
        var Count=0;//parseInt(txtChkSeriesEnd.value)-parseInt(txtChkSeriesStart.value);
        //lblCount.innerText=Count;
       
        if ((txtChkSeriesStart.value=='')&&(txtChkSeriesEnd.value==''))
        {
            ErrorMessage='Please Enter Cheque No (From-To), Only Numeric allow!';
            //txtChkSeriesStart.focus();
        }
        else
        {
            var i=0;
            for (i=parseInt(txtChkSeriesStart.value);i<=parseInt(txtChkSeriesEnd.value);i++)
            {
                Count=Count+1;            
                if(Count==100)
                {
                    ErrorMessage='You can Print One Hundred Cheques at One Time!';
                    break ;
                }
            }
            ChequeNoCount=Count;
            lblCount.innerText=Count;
        }

        lblMessage.innerText = ErrorMessage;
        lblMessage.className = 'ErrorMessage';
        window.scroll(0.0);
                          
    }

  function ValidationAllField()
  { 
   
    // //debugger;
     var ReturnType=true;
     var ErrorMessage="";
     
     var txtPaymentFrom=document.getElementById("<%=txtPaymentFrom.ClientID%>");
     var txtPaymentTo=document.getElementById("<%=txtPaymentTo.ClientID%>");
    
     var ddlBankList=document.getElementById("<%=ddlBankList.ClientID%>");
     var ddlBankBranchList=document.getElementById("<%=ddlBankBranchList.ClientID%>");
     var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
      
    
   

  
   if (ddlBankBranchList.selectedIndex == 0) {
       ErrorMessage = "Please Select Bank Branch !";
       ReturnType = false;
       ddlBankBranchList.focus();
   }
   if (ddlBankList.selectedIndex == 0) {
       ErrorMessage = "Please Select Bank Name";
       ReturnType = false;
       ddlBankList.focus();
   }
   if (txtPaymentTo.value == '') {
       ErrorMessage = "Please Select Payment Date To";
       ReturnType = false;
       txtPaymentTo.focus();
   }

   if (txtPaymentFrom.value == '') {
       ErrorMessage = "Please Select Payment Date From";
       ReturnType = false;
       txtPaymentFrom.focus();
   }
        
    if (ReturnType)
    {
        var lblWait = document.getElementById("<%=lblWait.ClientID%>");   
        lblWait.innerText="Please wait.....";
    }    
    
        lblMessage.innerText=ErrorMessage;         
        lblMessage.classname='ErrorMessage';
        return ReturnType;
  }
  
 
      
    function CheckAll()
    {    
     chequeBoxSelectedCount=0;
     var grvTransactionInfo=document.getElementById("<%=Grid_View_Cheque.ClientID%>");
     var chkSelectAll=document.getElementById('chkSelectAll');    
     var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                cell = grvTransactionInfo.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {                            
                             cell.childNodes[j].checked =chkSelectAll.checked;  
                             chequeBoxSelectedCount=chequeBoxSelectedCount+1;                           
                        }
                    }
                }

             }
        
        ChequeCountDisplay();
    }    
    
     function Get_SelectedChequeCount()
    {    
     
     chequeBoxSelectedCount=0;
     var grvTransactionInfo=document.getElementById("<%=Grid_View_Cheque.ClientID%>");
     var chkSelectAll=document.getElementById('chkSelectAll');    
     var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                 
                cell = grvTransactionInfo.rows[i].cells[0];
                if ((cell!=null)&&(cell.tagName=='TD'))
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {                            
                             if (cell.childNodes[j].checked==true)
                             {
                                chequeBoxSelectedCount=chequeBoxSelectedCount+1;                           
                             }
                        }
                    }
                }
            
             }  
             
         return chequeBoxSelectedCount;    
    }   
      
      
      
    </script>

    <table style="width: 734px">
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 11px">
                Printing Cheque Report</td>
        </tr>
        <tr>
            <td style="width: 17px; height: 25px">
            </td>
            <td class="TableTitle" style="width: 209px; height: 25px">
                &nbsp;Branch Name</td>
            <td style="width: 197px; height: 25px" class="TableGrid">
                <asp:DropDownList ID="ddlBranchName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle" style="width: 197px; height: 25px">
            </td>
            <td style="width: 197px; height: 25px" class="TableGrid">
            </td>
            <td colspan="3" style="height: 25px">
                <asp:HiddenField ID="hdnPrintChequeStatus" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 17px; height: 25px">
            </td>
            <td style="height: 25px; width: 209px;" class="TableTitle">
                &nbsp;Bank Name</td>
            <td style="width: 197px; height: 25px" class="TableGrid">
                <asp:DropDownList ID="ddlBankList" OnSelectedIndexChanged="ddlBankList_SelectedIndexChanged"
                    runat="server" AutoPostBack="True" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 197px; height: 25px" class="TableTitle">
                &nbsp;Bank Branch Name</td>
            <td style="width: 197px; height: 25px" class="TableGrid">
                <asp:DropDownList ID="ddlBankBranchList" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList></td>
            <td colspan="3" rowspan="2">
                <asp:HiddenField ID="hdnPrintReport" runat="server" />
                <asp:HiddenField ID="hdnBankID" runat="server" />
                <asp:HiddenField ID="hdnBankBranchID" runat="server" />
                <asp:HiddenField ID="ReportServerPath" runat="server" Value="http://pamacit3/ReportServer/Pages/ReportViewer.aspx?" />
            </td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td style="width: 209px" class="TableTitle">
                &nbsp;Payment DateFrom</td>
            <td style="width: 197px" class="TableGrid">
                <asp:TextBox ID="txtPaymentFrom" runat="server" Width="71px" SkinID="txtSkin"></asp:TextBox>
                <img src="../ChequeProcessing/SmallCalendar.png" alt="Calender" onclick="popUpCalendar(this, document.all.<%=txtPaymentFrom.ClientID%>,'dd/mm/yyyy', 0, 0);" /></td>
            <td style="width: 197px" class="TableTitle">
                &nbsp;Payment Date To</td>
            <td style="width: 197px" class="TableGrid">
                <asp:TextBox ID="txtPaymentTo" runat="server" Width="71px" SkinID="txtSkin"></asp:TextBox>
                <img src="../ChequeProcessing/SmallCalendar.png" alt="Calender" onclick="popUpCalendar(this, document.all.<%=txtPaymentTo.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 30px">
                &nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Search" OnClick="btnSubmit_Click"
                    BorderWidth="1px" Width="75px" />
                &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" BorderWidth="1px"
                    Width="69px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">
                <table>
                    <tr>
                        <td style="width: 175px">
                            &nbsp;Cheque No (From-To)</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtChkSeriesStart" runat="server" MaxLength="6" SkinID="txtSkin"
                                Width="87px"></asp:TextBox></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtChkSeriesEnd" runat="server" MaxLength="6" SkinID="txtSkin" Width="85px"></asp:TextBox></td>
                        <td id="TD_NO" style="width: 100px">
                            <asp:Label ID="lblCount" runat="server" ForeColor="#333333"></asp:Label></td>
                            <td id="TD1" class="GridViewRowStyle">&nbsp;Cheque Count&nbsp;<asp:Label ID="lblChequeCount" runat="server" ForeColor="#333333"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 21px">
                <div style="overflow: scroll; width: 846px; height: 230px">
                    <asp:GridView ID="Grid_View_Cheque" runat="server" AutoGenerateColumns="False" 
                        CssClass="mGrid" onrowdatabound="Grid_View_Cheque_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PaymentID" HeaderText="PaymentID" />
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" />
                            <asp:BoundField DataField="PaymentDate" HeaderText="PaymentDate" />
                            <asp:BoundField DataField="BankName" HeaderText="BankName" />
                            <asp:BoundField DataField="BankBranch" HeaderText="BankBranch" />
                            <asp:BoundField DataField="ChequeAmount" HeaderText="ChequeAmount" />
                            <asp:BoundField DataField="AmountInWord" HeaderText="AmountInWord" />
                            <asp:BoundField DataField="ChequeIssueTo" HeaderText="ChequeIssueTo" />
                            <asp:BoundField DataField="ChequeNo" HeaderText="ChequeNo" />
                            <asp:BoundField DataField="ChequeDate" HeaderText="ChequeDate" />
                            <asp:BoundField DataField="AccountHolderName" HeaderText="AccountHolderName" />
                            <asp:BoundField DataField="AccountNo" HeaderText="AccountNo" />
                            <asp:BoundField DataField="CrossCheque" HeaderText="CrossCheque" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 38px">
                &nbsp;<asp:Button ID="btnPrintCheque" runat="server" Text="PrintCheque" OnClick="btnPrintCheque_Click"
                    BorderWidth="1px" />
                &nbsp;<asp:Button ID="btnUpdateStatus" runat="server" Text="Update Status" OnClick="btnUpdateStatus_Click"
                    BorderWidth="1px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                    BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td colspan="8">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
