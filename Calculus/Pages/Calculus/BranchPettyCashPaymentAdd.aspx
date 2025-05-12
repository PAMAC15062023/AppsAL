<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/Pages/Calculus/BranchPettyCashPaymentAdd.aspx.cs" Inherits="BranchPettyCashPaymentAdd"
    Title="Make Payment " StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>

    <script language="javascript" type="text/javascript">
    
    function Validate_BankBranchList()
    {
         
         var ddlBankBranchList=document.getElementById("<%=ddlBankBranchList.ClientID%>");
         var txtAccountNo=document.getElementById("<%=txtAccountNo.ClientID%>");
         var txtAccountHolderName=document.getElementById("<%=txtAccountHolderName.ClientID%>");
         
         var Index=ddlBankBranchList.selectedIndex;           
         
         if (ddlBankBranchList.selectedIndex!=0)
         {
                var valueAssign=ddlBankBranchList.value;
                var strRowDetails="";
                strRowDetails=valueAssign.split('|', valueAssign.length);                 
                
                txtAccountNo.value=strRowDetails[2];
                txtAccountHolderName.value=strRowDetails[1]; 
         }         
         else
         {
                txtAccountNo.value="";
                txtAccountHolderName.value="";
         }
    
    }   
        
     function Validate_PaymentMode()   
     {
         
        var ddlIsChequePrint=document.getElementById("<%=ddlIsChequePrint.ClientID%>");
        var ddlPaymentType=document.getElementById("<%=ddlPaymentType.ClientID%>");
        var ddlIsBearer=document.getElementById("<%=ddlIsBearer.ClientID%>");
        
        if (ddlPaymentType.selectedIndex==2)
        {
            ddlIsChequePrint.selectedIndex=2;
            ddlIsChequePrint.disabled=true;
            ddlIsBearer.disabled=true;
            ddlIsBearer.selectedIndex=2;
            
        }
        else
        {
            ddlIsBearer.disabled=false;
            ddlIsChequePrint.disabled=false;          
        }
        Validate_ChequePrint();
     
     }       
        
      function Validate_ChequePrint()
      {
      
        var ddlIsChequePrint=document.getElementById("<%=ddlIsChequePrint.ClientID%>");
        var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>");
        var txtChequeDate=document.getElementById("<%=txtChequeDate.ClientID%>");  
        var Img2=document.getElementById("Img2");   
      
        
        if (ddlIsChequePrint.selectedIndex==1)
        {
             txtChequeNo.value="000000"; 
             txtChequeNo.disabled=true;
             txtChequeDate.value="01/01/1900"; 
             txtChequeDate.disabled=true;
             Img2.disabled=true;
        }
        else 
        {
            //txtChequeNo.value="";            
            txtChequeNo.disabled=false;
            
            txtChequeDate.value=""; 
            txtChequeDate.disabled=false; 
            Img2.disabled=false;
        }
        
      }     
    
      function ValidateSave()
      {
         var hdnIssuePaymentDetails=document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");
         var hdnPaymentID=document.getElementById("<%=hdnPaymentID.ClientID%>");
         var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");        
         var ReturnValue=true;
         var ErrorMessage="";                         
         if (hdnIssuePaymentDetails.value=='')
         {
            ErrorMessage='No Record found for save!';
            ReturnValue=false;
         }
           
        
         lblMessage.innerText=ErrorMessage;
         window.scroll(0,0);
         return ReturnValue;
      }
    
     function SelectAll()
                {

                    var MainTab=document.getElementById("MainTab");
                    var chkSelectAll=document.getElementById("chkSelectAll");            
                    var i=0;

                    for(i=0;i<=MainTab.rows.length-1;i++)
                    {                  
                        var row = MainTab.rows[i];                
                        var chkObj=row.cells[0].childNodes[0];              
                       
                        if (chkObj!=null)
                        {  
                             chkObj.checked= chkSelectAll.checked; 
                        }
                    }
                    //chkSelectAll.checked=false;
                }
             
    
     function TotalReqAmountCalculation()
         { 
            var lblTotalPaymentAmount=document.getElementById("<%=lblTotalPaymentAmount.ClientID%>");                                                 
            var hdnSavingPaymentDetails=document.getElementById("<%=hdnSavingPaymentDetails.ClientID%>");                                                 
            var MainTab=document.getElementById("MainTab");                       
            var i=0;
            var TotalAmt=0;

               for(i =0;i<=MainTab.rows.length - 1; i++)
                { 
                    if (i!=0)
                    {
                        TotalAmt=TotalAmt+parseFloat(MainTab.rows[i].cells[14].innerText);
                    }
                }
          
           lblTotalPaymentAmount.innerText=TotalAmt;
           hdnSavingPaymentDetails.value=TotalAmt;
         }  
    
    
        function Page_load_validation()
        {
            var hdnIssuePaymentDetails=document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");                                                 
            RenderTable(hdnIssuePaymentDetails.value);
            AssignValues();
            Validate_PaymentMode();
        }
        
        function ClearGrid()
        {
            var ddlPaymentRequestList=document.getElementById("<%=ddlPaymentRequestList.ClientID%>");             
            ddlPaymentRequestList.selectedIndex=0; 
            AssignValues();       
  
        }    
      function RemoveColumnFromGrid()
        {   
            var hdnChequeDetails=document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");                                      
            var MainTab=document.getElementById("MainTab");                       
            var i=0;
            var strhdvValue="";
           
           for(i = MainTab.rows.length - 1; i > 0; i--)
            { 
           
                var row = MainTab.rows[i];                
                var chkObj=row.cells[0].childNodes[0];              
               
                if (chkObj!=null)
                {
                    if (chkObj.checked==true)
                    {
                       
                        MainTab.deleteRow(i);
                    }
                    
                }
             }  
            hdnChequeDetails.value="";
           for(i=0;i<=MainTab.rows.length-1;i++)
           { 
               
                if (i==0)
                {
                }
                else
                {
                   hdnChequeDetails.value="";   
                   strhdvValue=strhdvValue+MainTab.rows[i].cells[1].innerText+"|"+MainTab.rows[i].cells[2].innerText+"|"+MainTab.rows[i].cells[3].innerText+"|"+MainTab.rows[i].cells[4].innerText+"|"+MainTab.rows[i].cells[5].innerText+"|"+MainTab.rows[i].cells[6].innerText+"|"+MainTab.rows[i].cells[7].innerText+"|"+MainTab.rows[i].cells[8].innerText+"|"+MainTab.rows[i].cells[9].innerText+"|"+MainTab.rows[i].cells[10].innerText+"|"+MainTab.rows[i].cells[11].innerText+"|"+MainTab.rows[i].cells[12].innerText+"|"+MainTab.rows[i].cells[13].innerText+"|"+MainTab.rows[i].cells[14].innerText+"|"+MainTab.rows[i].cells[15].innerText+"|"+MainTab.rows[i].cells[16].innerText+"|"+MainTab.rows[i].cells[17].innerText+"|"+MainTab.rows[i].cells[18].innerText+"|"+MainTab.rows[i].cells[19].innerText+"|"+MainTab.rows[i].cells[20].innerText+"|"+MainTab.rows[i].cells[21].innerText+"|"+MainTab.rows[i].cells[22].innerText+"|"+MainTab.rows[i].cells[23].innerText+"|"+MainTab.rows[i].cells[24].innerText+"|"+MainTab.rows[i].cells[25].innerText+"|"+MainTab.rows[i].cells[26].innerText+"|"+MainTab.rows[i].cells[27].innerText+"|"+MainTab.rows[i].cells[28].innerText+"^";
                   hdnChequeDetails.value=strhdvValue; 
                }            
            }            
                
                
                RenderTable(strhdvValue);               
                return false; 
        }
    
     
                        function RenderTable(strhdvValue)
                        {

                            var MainTab=document.getElementById("MainTab"); 
                            var Totalrows=MainTab.rows.length;
                                for(i = MainTab.rows.length - 1; i > 0; i--)
                                { 
                                    MainTab.deleteRow(i);
                                }

                            var strOutPut="";
                            var strRowDetails="";
                            var strColDetails="";

                            strRowDetails=strhdvValue.split('^', strhdvValue.length); 
                            var i=0;
                            var j=0;
                            var strRowlength=0;

                                for (i=0;i<=strRowDetails.length-2;i++)            
                                {
                                    var rowCount=MainTab.rows.length;

                                    rowCount=rowCount;
                                    var row=document.getElementById('MainTab').insertRow(rowCount);

                                    strColDetails=strRowDetails[i];
                                    strColDetails=strColDetails.split('|', strColDetails.length);

                                    var ColChkObj=row.insertCell(0); 
                                    ColChkObj.innerHTML="<input id='Chk_"+rowCount + "' type='checkbox' />";                      

                                    for (j=0;j<=strColDetails.length-1;j++)            
                                    {                 

                                            ColChkObj=row.insertCell(j+1); 
                                            ColChkObj.innerHTML=strColDetails[j];
                                            if (j>=21) 
                                            {
                                                ColChkObj.style.display = "none";
                                            } 
                                    }
                                } 
                                TotalReqAmountCalculation();    
                        }
    
                        function AddColumnToGrid()
                        {
                         
                            if (ValidateAddPayment())
                            {  
                                    var ddlPaymentRequestList=document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
                                    var hdnIssuePaymentDetails=document.getElementById("<%=hdnIssuePaymentDetails.ClientID%>");
                                    
                                    var ddlPaymentType=document.getElementById("<%=ddlPaymentType.ClientID%>");
                                    var txtPaymentAmount=document.getElementById("<%=txtPaymentAmount.ClientID%>");
                                    var txtChequeIssueTo=document.getElementById("<%=txtChequeIssueTo.ClientID%>");
                                    var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>");
                                    var txtChequeDate=document.getElementById("<%=txtChequeDate.ClientID%>");
                                    var txtAccountHolderName=document.getElementById("<%=txtAccountHolderName.ClientID%>");
                                    var txtAccountNo=document.getElementById("<%=txtAccountNo.ClientID%>");
                                     
                                    var ddlBankList=document.getElementById("<%=ddlBankList.ClientID%>");
                                    var ddlBankBranchList=document.getElementById("<%=ddlBankBranchList.ClientID%>");         
                                    var ddlIsChequePrint=document.getElementById("<%=ddlIsChequePrint.ClientID%>");
                                    var ddlIsBearer=document.getElementById("<%=ddlIsBearer.ClientID%>"); 
  
                                    var valueBankBranchID=ddlBankBranchList.value;
                                    var strRowBankBranchID="";
                                    strRowBankBranchID=valueBankBranchID.split('|', valueBankBranchID.length);  
                                      
                                    var valueAssign=ddlPaymentRequestList.value;
                                    var strRowDetails="";
                                    strRowDetails=valueAssign.split('|', valueAssign.length); 
                                                    
                                    var selectedPaymentType=parseInt(ddlPaymentType.selectedIndex);
                                    var selectedTransactionID=parseInt(ddlPaymentRequestList.selectedIndex); 
                                    var selectedBankList=parseInt(ddlBankList.selectedIndex);
                                    var selectedBankBranchList=parseInt(ddlBankBranchList.selectedIndex);
                                
                                    var strhdvValue="";            
                                    strhdvValue=hdnIssuePaymentDetails.value;
                                    strhdvValue = strhdvValue + ddlPaymentRequestList.options[selectedTransactionID].innerText + "|" + strRowDetails[1] + "|" + strRowDetails[2] + "|" + strRowDetails[3] + "|" + strRowDetails[4] + "|" + strRowDetails[5] + "|" + strRowDetails[6] + "|" + strRowDetails[7] + "|" + ddlPaymentType.options[selectedPaymentType].innerText + "|Not Applicable|Not Applicable|0.00|0.00|" + txtPaymentAmount.value + "|" + txtChequeIssueTo.value + "|" + txtChequeNo.value + "|" + txtChequeDate.value + "|" + txtAccountHolderName.value + "|" + txtAccountNo.value + "|" + ddlBankList.options[selectedBankList].innerText + "|" + ddlBankBranchList.options[selectedBankBranchList].innerText + "|" + strRowDetails[0] + "|" + ddlPaymentType.value + "|" + ddlIsChequePrint.value + "|" + ddlIsBearer.value + "|1|" + ddlBankList.value + "|" + strRowBankBranchID[0] + "^";
                                    RenderTable(strhdvValue);
                                    hdnIssuePaymentDetails.value=strhdvValue;
                                    ClearGrid();
                                }
                        
                            return false;
                        }
                        function ValidateAddPayment()
                        {
                                ////debugger; 
                                var MainTab=document.getElementById("MainTab");                     
                                var ddlPaymentRequestList=document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
                                var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
                                var txtPaymentAmount=document.getElementById("<%=txtPaymentAmount.ClientID%>");
                                var txtChequeIssueTo=document.getElementById("<%=txtChequeIssueTo.ClientID%>");        
                                var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>");
                                var txtChequeDate=document.getElementById("<%=txtChequeDate.ClientID%>");
                                var txtAccountHolderName=document.getElementById("<%=txtAccountHolderName.ClientID%>");
                                var txtAccountNo=document.getElementById("<%=txtAccountNo.ClientID%>");
                                var ddlPaymentType=document.getElementById("<%=ddlPaymentType.ClientID%>");
                                var lblTotalBillAmt=document.getElementById("<%=lblTotalBillAmt.ClientID%>");
                                var ddlIsChequePrint=document.getElementById("<%=ddlIsChequePrint.ClientID%>");
                                var ddlIsBearer=document.getElementById("<%=ddlIsBearer.ClientID%>");
                                
                                
                                var ReturnValue=true;
                                var ErrorMessage=""; 
                                
                                if (ddlPaymentRequestList.selectedIndex==0)
                                {
                                    ErrorMessage='Please Select Payment Request to continue!';
                                    ddlPaymentRequestList.focus();    
                                    ReturnValue=false;
                                }
                                if (ddlPaymentRequestList.selectedIndex!=0)
                                {
                                    var SelectedIndex_PaymentRequestList=parseInt(ddlPaymentRequestList.selectedIndex);
                                    for(i=0;i<=MainTab.rows.length-1;i++)
                                    { 
                                        ////debugger;
                                        var Value=ddlPaymentRequestList.options[SelectedIndex_PaymentRequestList].innerText;
                                        if (MainTab.rows[i].cells[1].innerText==Value)
                                        {
                                            ErrorMessage='Entry already Added!';
                                            ddlPaymentRequestList.focus();    
                                            ReturnValue=false;
                                        } 
                                    } 
                                }

                                if (ddlPaymentType.selectedIndex==0)
                                {
                                    ErrorMessage='Please Select Payment Type to continue!';
                                    ddlPaymentType.focus();    
                                    ReturnValue=false;
                                }  

                                if (ddlPaymentType.value==1)
                                {
                                         if (ddlIsChequePrint.selectedIndex==2)
                                        {
                                            var strChequeNo=txtChequeNo.value;
                                            if (strChequeNo.length<6)
                                            {
                                                ErrorMessage='Please enter Cheque No to continue!';
                                                txtChequeNo.focus();            
                                                ReturnValue=false;
                                            }
                                            if (strChequeNo=='000000')
                                            {
                                                ErrorMessage='Please enter Valid Cheque No to continue!';
                                                txtChequeNo.focus();            
                                                ReturnValue=false;
                                            }
                                            
                                        }    
                                
                                        if (txtChequeNo.value=='')
                                        {
                                            ErrorMessage='Please enter Cheque No to continue!';
                                            txtChequeNo.focus();            
                                            ReturnValue=false;
                                        }
                                        else if (txtChequeDate.value=='')
                                        {
                                            ErrorMessage='Please enter Cheque Date to continue!';
                                            txtChequeDate.focus();            
                                            ReturnValue=false;
                                        }
                                        else if (txtChequeIssueTo.value=='')
                                        {
                                            ErrorMessage='Please enter Cheque Issue Details to continue!';
                                            txtChequeIssueTo.focus();            
                                            ReturnValue=false;
                                        }
                                }      

                                else if (ddlPaymentType.value==2)
                                {       
                                        if (txtAccountHolderName.value=='')
                                        {
                                            ErrorMessage='Please enter Account Holder Name to continue!';
                                            txtAccountHolderName.focus();                        
                                            ReturnValue=false;
                                        }
                                        else if (txtAccountNo.value=='')
                                        {
                                            ErrorMessage='Please enter AccountNo to continue!';
                                            txtAccountNo.focus();            
                                            ReturnValue=false;
                                        } 
                                } 

                                if(txtPaymentAmount.value=='')
                                {
                                    ErrorMessage='Please enter Payment Amount to continue!';
                                    txtPaymentAmount.focus();        
                                    ReturnValue=false;    
                                }
                                if(txtPaymentAmount.value=='0.00')
                                {

                                    ErrorMessage='Please enter Payment Amount to continue!';
                                    txtPaymentAmount.focus();        
                                    ReturnValue=false;    
                                }
                                if(txtPaymentAmount.value=='0')
                                {

                                    ErrorMessage='Please enter Payment Amount to continue!';
                                    txtPaymentAmount.focus();        
                                    ReturnValue=false;    
                                }

                                if(parseFloat(txtPaymentAmount.value)>parseFloat(lblTotalBillAmt.innerText))
                                {  
                                    ErrorMessage='You cannot Enter cheque amount more than actual bill amount!';
                                    txtPaymentAmount.focus();        
                                    ReturnValue=false;                   
                                }  
                                 if (ddlIsBearer.selectedIndex==0)
                                {   
                                    ErrorMessage='Please Select Cross Cheque Details to continue!';
                                    ddlIsBearer.focus();            
                                    ReturnValue=false;
                                }
                                
                                
                                  
                                    lblMessage.innerText=ErrorMessage;
                                    window.scroll(0,0);
                                    return ReturnValue;

                       }    
                        function AssignValues()
                        {
                                var ddlPaymentRequestList=document.getElementById("<%=ddlPaymentRequestList.ClientID%>");
                                var lblPayeeName=document.getElementById("<%=lblPayeeName.ClientID%>");
                                var lblBillNo=document.getElementById("<%=lblBillNo.ClientID%>");
                                var lblBillDate=document.getElementById("<%=lblBillDate.ClientID%>");
                                var lblBillAmount=document.getElementById("<%=lblBillAmount.ClientID%>");

                                var lblServiceTaxPercent=document.getElementById("<%=lblServiceTaxPercent.ClientID%>");
                                var lblServiceTaxAmt=document.getElementById("<%=lblServiceTaxAmt.ClientID%>");
                                var lblTotalBillAmt=document.getElementById("<%=lblTotalBillAmt.ClientID%>");
                                
                                var ddlPaymentType=document.getElementById("<%=ddlPaymentType.ClientID%>");
                                var txtPaymentAmount=document.getElementById("<%=txtPaymentAmount.ClientID%>");
                                var txtChequeIssueTo=document.getElementById("<%=txtChequeIssueTo.ClientID%>");
                                
                                var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>");
                                var txtChequeDate=document.getElementById("<%=txtChequeDate.ClientID%>");
                                var txtAccountHolderName=document.getElementById("<%=txtAccountHolderName.ClientID%>");
                                var txtAccountNo=document.getElementById("<%=txtAccountNo.ClientID%>");

                                var lblAccountHead = document.getElementById("<%=lblAccountHead.ClientID%>");
                                var lblRemark = document.getElementById("<%=lblRemark.ClientID%>");         
                                

                               // //debugger;
                                if (ddlPaymentRequestList.selectedIndex!=0)
                                {
                                    var valueAssign=ddlPaymentRequestList.value;
                                    var strRowDetails="";
                                    strRowDetails=valueAssign.split('|', valueAssign.length); 
                                    
                                    lblPayeeName.innerText=strRowDetails[1];
                                    lblBillNo.innerText=strRowDetails[2];
                                    lblBillDate.innerText=strRowDetails[3];
                                    lblBillAmount.innerText=strRowDetails[4];
                                    lblServiceTaxPercent.innerText=strRowDetails[5];
                                    lblServiceTaxAmt.innerText=strRowDetails[6];
                                    lblTotalBillAmt.innerText=strRowDetails[7];
                                    
                                    //ddlPaymentType.value=strRowDetails[8];
                                    //txtPaymentAmount.value=strRowDetails[9];
                                    //txtChequeIssueTo.value=strRowDetails[10];
                                    
                                    //txtChequeNo.value=strRowDetails[11];
                                    //txtChequeDate.value=strRowDetails[12];
                                    //txtAccountHolderName.value=strRowDetails[13];
                                    //txtAccountNo.value=strRowDetails[14];
                                    //txtBankName.value=strRowDetails[15];    
                                    //txtBranchName.value=strRowDetails[16];    
                                    lblAccountHead.innerText = strRowDetails[19];
                                    lblRemark.innerText = strRowDetails[20];
                                     
                                 }
                                 else
                                 {
                                    lblPayeeName.innerText="";
                                    lblBillNo.innerText="";
                                    lblBillDate.innerText="";
                                    lblBillAmount.innerText="";
                                    lblServiceTaxPercent.innerText="";
                                    lblServiceTaxAmt.innerText="";
                                    lblTotalBillAmt.innerText="";
                                    
                                    ddlPaymentType.selectedIndex=0;
                                    txtPaymentAmount.value="0.00";
                                    txtChequeIssueTo.value="";
                                    
                                    txtChequeNo.value="";
                                    txtChequeDate.value="";
                                    txtAccountHolderName.value="";
                                    txtAccountNo.value="";
                                    //txtBankName.value="";
                                    //txtBranchName.value="";
                                    lblAccountHead.innerText = "";
                                    lblRemark.innerText = "";
                                }
                                 
                            
                      }    
    </script>

    <table style="width: 167px">
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 16px">
                &nbsp; Branch Petty Cash Voucher Payment Add</td>
        </tr>
        <tr>
            <td colspan="7">
                <table>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="TableTitle" colspan="5">
                            &nbsp;
                            <asp:Label ID="lblPaymentID" runat="server" SkinID="LabelSkin" Width="500px" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td class="TableTitle">
                            &nbsp;TransactionID</td>
                        <td class="TableGrid" colspan="2">
                            &nbsp;<asp:Label ID="lblTransctionID" runat="server" SkinID="LabelSkin" Width="224px"></asp:Label>&nbsp;</td>
                        <td class="TableTitle" style="width: 100px">
                            Total Amount
                        </td>
                        <td class="TableGrid">
                            <asp:Label ID="lblTotalAmount" runat="server" SkinID="LabelSkin"></asp:Label></td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px">
                            &nbsp;</td>
                        <td class="TableTitle">
                            &nbsp;Branch</td>
                        <td class="TableGrid" colspan="2">
                            &nbsp;<asp:Label ID="lblBranchName" runat="server" SkinID="LabelSkin"></asp:Label>&nbsp;</td>
                        <td class="TableTitle" style="width: 100px">
                            Payout Date</td>
                        <td class="TableGrid">
                            <asp:Label ID="lblPayoutDate" runat="server" SkinID="LabelSkin"></asp:Label></td>
                        <td>
                        </td>
                        <td colspan="2">
                            <a href="javascript:openwindow();" title="View Opening Balance">ViewOpeningBudgetBalance</a></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnIssuePaymentDetails" runat="server" />
                <asp:HiddenField ID="hdnSavingPaymentDetails" runat="server" />
                <asp:HiddenField ID="hdnBranchID" runat="server" />
                <asp:HiddenField ID="hdnPaymentID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 6px">
                &nbsp; Payment Add Details</td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td class="TableTitle">
                &nbsp;PaymentRequest</td>
            <td class="TableTitle">
                &nbsp;Client Name</td>
            <td class="TableTitle">
                VoucherNo</td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;VoucherDate</td>
            <td class="TableTitle">
                &nbsp;Voucher Amt</td>
            <td class="TableTitle">
                &nbsp;ST%</td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlPaymentRequestList" runat="server" SkinID="ddlSkin" AccessKey="N">
                </asp:DropDownList></td>
            <td class="TableGrid">
                &nbsp;<asp:Label ID="lblPayeeName" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td class="TableGrid">
                &nbsp;<asp:Label ID="lblBillNo" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td class="TableGrid" style="width: 100px">
                <asp:Label ID="lblBillDate" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td class="TableGrid">
                &nbsp;<asp:Label ID="lblBillAmount" runat="server" SkinID="LabelSkin" Width="31px">0.00</asp:Label></td>
            <td class="TableGrid">
                <asp:Label ID="lblServiceTaxPercent" runat="server" SkinID="LabelSkin">0.00</asp:Label></td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td class="TableTitle">
                ST Amt</td>
            <td class="TableTitle">
                &nbsp;Total Voucher Amt</td>
            <td class="TableTitle">
                &nbsp;Payment Type</td>
            <td class="TableTitle" style="width: 100px">
                PaymentAmt
            </td>
            <td class="TableTitle">
                Cheque Issue To</td>
            <td class="TableTitle">
                &nbsp;Cheque Print</td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td class="TableGrid">
                <asp:Label ID="lblServiceTaxAmt" runat="server" SkinID="LabelSkin">0.00</asp:Label></td>
            <td class="TableGrid">
                <asp:Label ID="lblTotalBillAmt" runat="server" SkinID="LabelSkin">0.00</asp:Label></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlPaymentType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">ByCheuqe</asp:ListItem>
                    <asp:ListItem Value="2">ByOnlineTransfer</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableGrid" style="width: 100px">
                <asp:TextBox ID="txtPaymentAmount" runat="server" MaxLength="10" SkinID="txtSkin"
                    Width="86px"></asp:TextBox></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtChequeIssueTo" runat="server" MaxLength="30" SkinID="txtSkin"
                    Width="113px"></asp:TextBox></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlIsChequePrint" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 15px; height: 15px;">
            </td>
            <td class="TableTitle" style="height: 15px">
                &nbsp;Cheque No</td>
            <td class="TableTitle" style="height: 15px">
                &nbsp;Cheque Date</td>
            <td class="TableTitle" style="height: 15px">
                &nbsp;Bank Name</td>
            <td class="TableTitle" style="width: 100px; height: 15px;">
                &nbsp;Bank Branch Name</td>
            <td class="TableTitle" style="height: 15px">
                <strong>&nbsp;</strong> Account No</td>
            <td class="TableTitle" style="height: 15px">
            Account Holder</td>
        </tr>
        <tr>
            <td style="width: 15px; height: 40px;">
            </td>
            <td class="TableGrid" style="height: 40px">
                <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="6" SkinID="txtSkin" Width="69px"></asp:TextBox></td>
            <td class="TableGrid" style="height: 40px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid" style="height: 40px">
                <asp:DropDownList ID="ddlBankList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBankList_SelectedIndexChanged"
                    SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableGrid" style="width: 100px; height: 40px;">
                <asp:DropDownList ID="ddlBankBranchList" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableGrid" style="height: 40px">
                <asp:TextBox ID="txtAccountNo" runat="server" MaxLength="25" SkinID="txtSkin" Width="113px" ReadOnly="True"></asp:TextBox></td>
            <td class="TableGrid" style="height: 40px">
                <asp:TextBox ID="txtAccountHolderName" runat="server" MaxLength="25" SkinID="txtSkin"
                    Width="113px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td class="TableTitle">
                Cross On Cheque
            </td>
            <td class="TableTitle" colspan="4">
                &nbsp;Remark&nbsp;</td>
            <td class="TableGrid">
            </td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlIsBearer" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableGrid" colspan="4">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblAccountHead" runat="server" SkinID="LabelSkin" 
                                style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRemark" runat="server" SkinID="LabelSkin"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 105px">
                    <tr>
                        <td style="width: 100px; height: 24px">
                            <asp:Button ID="btnAddtoGrid" runat="server" BorderWidth="1px" Text="Add" Width="43px" AccessKey="A" /></td>
                        <td style="width: 100px; height: 24px">
                            <asp:Button ID="btnRemove" runat="server" BorderWidth="1px" Text="Remove" Width="55px" AccessKey="R" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7">
                &nbsp;Payment Add List</td>
        </tr>
        <tr>
            <td colspan="7">
             <div id="dv1"style="overflow: scroll; width: 915px; height: 150px">
                <table id="MainTab" class="GridViewStyle">
                    <tr>
                        <th class="TableGrid" style="height: 24px">
                            <input id="chkSelectAll" onclick="javascript:SelectAll();" type="checkbox" /></th>
                        <th class="TableGrid" style="height: 24px">
                            DetailID</th>
                        <th class="TableGrid" style="height: 24px">
                            Client</th>
                        <th class="TableGrid" style="height: 24px">
                            &nbsp;BillNo</th>
                        <th class="TableGrid" style="height: 24px">
                            &nbsp;VoucherDt</th>
                        <th class="TableGrid" style="height: 24px">
                            &nbsp;Amt</th>
                        <th class="TableGrid" style="height: 24px">
                            &nbsp;ST%</th>
                        <th class="TableGrid" style="height: 24px">
                            STAmt</th>
                        <th class="TableGrid" style="height: 24px">
                            TotalAmt</th>
                        <th class="TableGrid" style="height: 24px">
                            PaymentType</th>
                        <th class="TableGrid" style="height: 24px">
                            NOP</th>
                        <th class="TableGrid" style="height: 24px">
                            Recipient</th>
                        <th class="TableGrid" style="height: 24px">
                            Tds%</th>
                        <th class="TableGrid" style="height: 24px">
                            TdsAmt</th>
                        <th class="TableGrid" style="height: 24px">
                            &nbsp;PaymentAmt</th>
                        <th class="TableGrid" style="height: 24px">
                            ChequeIssueTo</th>
                        <th class="TableGrid" style="height: 24px">
                            ChequeNo</th>
                        <th class="TableGrid" style="height: 24px">
                            ChequeDt</th>
                        <th class="TableGrid" style="height: 24px">
                            AccountHolder</th>
                        <th class="TableGrid" style="height: 24px">
                            AccountNo</th>
                        <th class="TableGrid" style="height: 24px">
                            Bank</th>
                        <th class="TableGrid" style="height: 24px">
                            Branch</th>
                        <th style="height: 24px">
                        </th>
                        <th style="height: 24px">
                        </th>
                        <th style="height: 24px">
                        </th>
                    </tr>
                </table>
               
                </div>
            </td>
        </tr>
    </table>
    <table style="width: 770px">
        <tr>
            <td colspan="7">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 27px" class="TableTitle">
                <table>
                    <tr>
                        <td style="height: 24px">
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Save" Width="71px"
                    OnClick="btnSave_Click" AccessKey="S" />
                            <asp:Button ID="btnSaveNext" runat="server" BorderWidth="1px" 
                                Text="Save n Next" Width="90px" OnClick="btnSaveNext_Click" Height="24px" />
                            <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="61px" OnClick="btnCancel_Click" /></td>
                        <td style="height: 24px">
                            </td>
                        <td>
                            &nbsp;<asp:Button ID="btnBack" runat="server" BorderWidth="1px"  
                                OnClientClick="javascript:window.history.go(-1);return false;" Text="Back to Search"
                                Width="122px" /></td>
                        <td class="TableTitle" style="height: 24px">
                            &nbsp;<strong>Payment Amount</strong></td>
                        <td class="TableGrid" style="height: 24px">
                            <asp:Label ID="lblTotalPaymentAmount" runat="server" Font-Bold="False" SkinID="LabelSkin" Width="155px">0.00</asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
