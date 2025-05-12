<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="OtherThanPettyCash_SubmitDetails.aspx.cs" Inherits="Pages_Calculus_OtherThanPettyCash_SubmitDetails"
    Title="CALCULUS OTP Submit Details" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>
    <script language="javascript" type="text/javascript">
    function Page_load_validation()
    {
        CalulateDepositAmount();
    }
    
    
        function CalulateDepositAmount()
        {
            var TotalAmount;
            var txtBillAmt=document.getElementById("<%=txtBillAmt.ClientID%>");                    
            var txtServiceTaxAmt=document.getElementById("<%=txtServiceTaxAmt.ClientID%>"); 
            var lblAmountDifference=document.getElementById("<%=lblAmountDifference.ClientID%>"); 
            var hdnDepositAmountDetails=document.getElementById("<%=hdnDepositAmountDetails.ClientID%>"); 
           
           
            var lblRequestedAmount=document.getElementById("<%=lblRequestedAmount.ClientID%>");                    
            var intRequestAmount=parseFloat(lblRequestedAmount.innerText);
            TotalAmount=Math.round(parseFloat(txtBillAmt.value)+parseFloat(txtServiceTaxAmt.value));
          
            lblAmountDifference.innerText=intRequestAmount-parseFloat(TotalAmount);
            hdnDepositAmountDetails.value=intRequestAmount-parseFloat(TotalAmount);
            
        }    
    
         function CalulateTax()
        {    
            var txtBillAmt=document.getElementById("<%=txtBillAmt.ClientID%>");                    
            var ddlServiceTax=document.getElementById("<%=ddlServiceTax.ClientID%>"); 
            var txtServiceTaxAmt=document.getElementById("<%=txtServiceTaxAmt.ClientID%>"); 
            var ErrorMessage="";
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
            var hdnServiceTaxAmount=document.getElementById("<%=hdnServiceTaxAmount.ClientID%>"); 
            
            
            if (txtBillAmt.value!='')
            {
                var regex1=/^\d{1,9}|[.]{1,1}|\d{1,2}$/;  //this is the pattern of regular expersion
                if(regex1.test(txtBillAmt.value)== false)
                {
                    ErrorMessage="Please Enter numeric to continue...!"; 
                    txtBillAmt.value='0.00' ;
                    //txtBillAmt.focus();   
                }
            }
                    if (ddlServiceTax.selectedIndex!=0)    
                    {
                        var Index=parseInt(ddlServiceTax.selectedIndex);
                        txtServiceTaxAmt.value=Math.round((parseFloat(txtBillAmt.value)* parseFloat(ddlServiceTax.options[Index].innerText))/100)
                    }
                    else
                    {
                         txtServiceTaxAmt.value=((parseFloat(txtBillAmt.value)* 0)/100)
                    }
             hdnServiceTaxAmount.value=txtServiceTaxAmt.value;
             lblMessage.innerText=ErrorMessage;
             CalulateDepositAmount();
        }
    
    function Validate_Save()
    {
        var txtClientName=document.getElementById("<%=txtClientName.ClientID%>");
        var txtBillNo=document.getElementById("<%=txtBillNo.ClientID%>");
        var txtBillDate=document.getElementById("<%=txtBillDate.ClientID%>");
        var txtBillAmt=document.getElementById("<%=txtBillAmt.ClientID%>");
        var txtDueAmount=document.getElementById("<%=txtDueAmount.ClientID%>");
        var txtMobile_TelNo=document.getElementById("<%=txtMobile_TelNo.ClientID%>");
        var txtPanNo=document.getElementById("<%=txtPanNo.ClientID%>");
        var txtServiceTaxAmt=document.getElementById("<%=txtServiceTaxAmt.ClientID%>");
        var txtServiceTaxRegNo=document.getElementById("<%=txtServiceTaxRegNo.ClientID%>");
        var ddlServiceTax=document.getElementById("<%=ddlServiceTax.ClientID%>");
        
        var lblAmountDifference=document.getElementById("<%=lblAmountDifference.ClientID%>");        
        var hdnDepositAmountDetails=document.getElementById("<%=hdnDepositAmountDetails.ClientID%>");
        var hdnDepositConfirmation=document.getElementById("<%=hdnDepositConfirmation.ClientID%>");
        var lblRequestedAmount=document.getElementById("<%=lblRequestedAmount.ClientID%>");
                
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");        
        var ReturnValue=true;
        var ErrorMessage="";   
                    
         if (txtClientName.value=='')
         {
            ErrorMessage='Please enter Client Name to continue!';
            ReturnValue=false;
         }
         else if (txtBillNo.value=='')
         {
            ErrorMessage='Please enter BillNo to continue!';
            ReturnValue=false;
         }
         else if (txtBillDate.value=='')
         {
            ErrorMessage='Please enter Bill Date to continue!';
            ReturnValue=false;
         }
         else if (txtBillAmt.value=='')
         {
            ErrorMessage='Please enter Bill Amount to continue!';
            ReturnValue=false;
         }
          else if (ddlServiceTax.selectedIndex==0)
         {
            ErrorMessage='Please enter Bill Amount to continue!';
            ReturnValue=false;
         }                
         else if ((parseFloat(txtBillAmt.value)+parseFloat(txtServiceTaxAmt.value))>parseFloat(lblRequestedAmount.innerText))
         {
            ErrorMessage='you can not enter bill amount more than requested amount!';
            ReturnValue=false;
         }
         CalulateDepositAmount();         
         
           
        if (ErrorMessage=="")
        {
             if(lblAmountDifference.innerText>0)
             {
                    var answer = confirm("Do want to deposit amount to Accounts?")
                    if (answer)
                    {    
                               
                        hdnDepositConfirmation.value='1';                    
                    }
                    else 
                    {
                        hdnDepositConfirmation.value='0';                    
                    }               

             }  
         }  
          
                  
         hdnDepositAmountDetails.value= lblAmountDifference.innerText;
         lblMessage.innerText=ErrorMessage;
         window.scroll(0,0);
         return ReturnValue;
    
    }
    
    </script>
    <table style="width: 848px">
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 21px" class="TableHeader">
                &nbsp;Other Than Petty Cash Submit Voucher Details</td>
        </tr>
        <tr>
            <td style="height: 6px">
            </td>
            <td class="TableTitle" style="width: 102px; height: 6px">
                &nbsp;TransactionID</td>
            <td class="TableGrid" colspan="5" style="height: 6px">
                <asp:Label ID="lblTransactionID" runat="server" SkinID="LabelSkin" Width="265px" Font-Bold="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 6px">
            </td>
            <td class="TableTitle" style="width: 102px; height: 6px">
                &nbsp;Cluster Name</td>
            <td class="TableGrid" style="height: 6px">
                <asp:Label ID="lblClusterName" runat="server"></asp:Label></td>
            <td class="TableTitle" style="width: 129px; height: 6px">
                &nbsp;Centre Name</td>
            <td class="TableGrid" style="width: 100px; height: 6px">
                <asp:Label ID="lblCentreName" runat="server"></asp:Label></td>
            <td class="TableTitle" style="width: 100px; height: 6px">
                &nbsp;Request By</td>
            <td class="TableGrid" style="width: 100px; height: 6px">
                <asp:Label ID="lblRequestBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 15px">
            </td>
            <td class="TableTitle" style="width: 102px; height: 15px">
                &nbsp;RequestAmount</td>
            <td class="TableGrid" style="height: 15px">
                <asp:Label ID="lblRequestedAmount" runat="server" SkinID="LabelSkin" Width="92px"></asp:Label></td>
            <td class="TableTitle" style="width: 129px; height: 15px">
                &nbsp;RequestDate</td>
            <td class="TableGrid" style="width: 100px; height: 15px">
                <asp:Label ID="lblRequestDate" runat="server"></asp:Label></td>
            <td class="TableTitle" style="width: 100px; height: 15px">
                &nbsp;Authorize By</td>
            <td class="TableGrid" style="width: 100px; height: 15px">
                <asp:Label ID="lblAuthorizeBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="TableTitle" style="width: 102px; height: 16px">
                &nbsp;Vertical</td>
            <td class="TableGrid" style="height: 16px">
                <asp:Label ID="lblVertical" runat="server"></asp:Label></td>
            <td class="TableTitle" style="width: 129px; height: 16px">
                &nbsp;Activity</td>
            <td class="TableGrid" style="width: 100px; height: 16px">
                <asp:Label ID="lblActivity" runat="server"></asp:Label></td>
            <td class="TableTitle" style="width: 100px; height: 16px">
                &nbsp;Product</td>
            <td class="TableGrid" style="width: 100px; height: 16px">
                <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 19px">
                &nbsp;Transfered Amount Details</td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 102px" class="TableTitle">
                &nbsp;Transfer Payment ID</td>
            <td class="TableGrid">
                <asp:Label ID="lblPaymentID" runat="server" SkinID="LabelSkin" Width="153px"></asp:Label></td>
            <td class="TableTitle">
                &nbsp;Authorize Date
            </td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblAuthorizeDate" runat="server" SkinID="LabelSkin" Width="132px"></asp:Label></td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;AuthorizeRemark</td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblAuthorizeRemark" runat="server" SkinID="LabelSkin" Width="180px"></asp:Label></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 102px" class="TableTitle">
                &nbsp;Transfer Amount</td>
            <td class="TableGrid">
                <asp:Label ID="lblTransferAmount" runat="server" SkinID="LabelSkin" Width="155px"></asp:Label></td>
            <td class="TableTitle">
                &nbsp;Transfer Date</td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblTransferDate" runat="server" SkinID="LabelSkin" Width="135px"></asp:Label></td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;Transfer by</td>
            <td style="width: 100px" class="TableGrid">
                <asp:Label ID="lblTransferBy" runat="server" SkinID="LabelSkin" Width="180px"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 15px">
                &nbsp;Voucher Details</td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 102px" class="TableTitle">
                &nbsp;Client Name</td>
            <td class="TableTitle">
                &nbsp;Bill No</td>
            <td class="TableTitle">
                &nbsp;Bill Date</td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;Amount</td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;Service Tax</td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;ST Amount</td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 102px" class="TableGrid">
                <asp:TextBox ID="txtClientName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtBillNo" runat="server" SkinID="txtSkin" Width="124px"></asp:TextBox></td>
            <td class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px">
                            <asp:TextBox ID="txtBillDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="62px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtBillAmt" runat="server" BorderWidth="1px" MaxLength="15" SkinID="txtSkin"
                    Width="72px">0.00</asp:TextBox></td>
            <td style="width: 100px" class="TableGrid">
                <asp:DropDownList ID="ddlServiceTax" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtServiceTaxAmt" runat="server" BorderWidth="1px" MaxLength="15"
                    ReadOnly="True" SkinID="txtSkin" Width="74px">0.00</asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 102px" class="TableTitle">
                &nbsp;ST Regn. No</td>
            <td class="TableTitle">
                &nbsp;Mobile No/ Tel No</td>
            <td class="TableTitle">
                &nbsp;Due Date</td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;Due Amount</td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;PanNo</td>
            <td class="TableTitle">
                &nbsp;Amount Deposit To Accounts</td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 102px; height: 24px;" class="TableGrid">
                <asp:TextBox ID="txtServiceTaxRegNo" runat="server" BorderWidth="1px" MaxLength="20"
                    SkinID="txtSkin" Width="82px"></asp:TextBox></td>
            <td class="TableGrid" style="height: 24px">
                <asp:TextBox ID="txtMobile_TelNo" runat="server" BorderWidth="1px" MaxLength="12"
                    SkinID="txtSkin" Width="82px"></asp:TextBox></td>
            <td class="TableGrid" style="height: 24px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtDuedate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="62px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img4" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDuedate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:TextBox ID="txtDueAmount" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="71px"></asp:TextBox></td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:TextBox ID="txtPanNo" runat="server" BorderWidth="1px" MaxLength="12" SkinID="txtSkin"
                    Width="71px"></asp:TextBox></td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:Label ID="lblAmountDifference" runat="server">0.00</asp:Label></td>
        </tr>
        <tr>
            <td style="height: 33px">
            </td>
            <td class="TableGrid" style="height: 33px">
                Upload&nbsp; Attachment
            </td>
            <td class="TableGrid" colspan="5" style="height: 33px">
                <asp:FileUpload ID="FileUpload1" runat="server" Height="23px" Width="490px" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td style="height: 32px" class="TableTitle" colspan="7">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="58px" OnClick="btnSave_Click" BorderWidth="1px" Height="22px" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" Width="62px" OnClick="btnCancel_Click" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td colspan="7"><asp:HiddenField ID="hdnTransactionID" runat="server" />
                <asp:HiddenField ID="hdnVerticalID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnActivityID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnProductID" runat="server" Value="0" /><asp:HiddenField ID="hdnServiceTaxAmount" runat="server" Value="0" /><asp:HiddenField ID="hdnDepositAmountDetails" runat="server" Value="0" /><asp:HiddenField ID="hdnDepositConfirmation" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 102px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 102px">
            </td>
            <td>
            </td>
            <td>
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
