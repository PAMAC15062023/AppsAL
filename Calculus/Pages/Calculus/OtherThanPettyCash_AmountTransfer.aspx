<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="OtherThanPettyCash_AmountTransfer.aspx.cs" Inherits="Pages_Calculus_OtherThanPettyCash_AmountTransfer" Title="PAMAC Other Than Petty Cash Amount Transfer" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>

    <script language="javascript" type="text/javascript" >
        
      function Page_load_validation()
        {
            Validate_PaymentType();
            Validate_BankBranchList();
             
             
        }
   function Validate_BankBranchList()
    {
         
         var ddlBankBranchList=document.getElementById("<%=ddlBankBranchList.ClientID%>");
         var txtAccountNo=document.getElementById("<%=txtTransferAccountNo.ClientID%>");
         var txtAccountHolderName=document.getElementById("<%=txtAccountHolderName.ClientID%>");
         var hdnAccountNo=document.getElementById("<%=hdnAccountNo.ClientID%>");
         var hdnAccountHolderName=document.getElementById("<%=hdnAccountHolderName.ClientID%>");
        
         
         var Index=ddlBankBranchList.selectedIndex;           
         
         if (ddlBankBranchList.selectedIndex!=0)
         {
                var valueAssign=ddlBankBranchList.value;
                var strRowDetails="";
                strRowDetails=valueAssign.split('|', valueAssign.length);                 
                
                txtAccountNo.value=strRowDetails[2];
                txtAccountHolderName.value=strRowDetails[1]; 
                
                hdnAccountNo.value=strRowDetails[2];
                hdnAccountHolderName.value=strRowDetails[1]; 
         }         
         else
         {
                txtAccountNo.value="";
                txtAccountHolderName.value="";
                hdnAccountNo.value="";
                hdnAccountHolderName.value="";
         }
    
    }   
        
       function Validate_ChequePrint()
      {
      
        var ddlIsChequePrint=document.getElementById("<%=ddlIsChequePrint.ClientID%>");
        var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>");
        var txtChequeDate=document.getElementById("<%=txtCheuqeDate.ClientID%>");  
        var Img1=document.getElementById("Img1");   
        var ddlIsBearer=document.getElementById("<%=ddlIsBearer.ClientID%>");  
     
        if (ddlIsChequePrint.selectedIndex==1)
        {
             txtChequeNo.value="000000"; 
             txtChequeNo.disabled=true;
             txtChequeDate.value="01/01/1900"; 
             txtChequeDate.disabled=true;
             Img1.disabled=true;
             ddlIsBearer.disabled=false;
        }
        else 
        {
            //txtChequeNo.value="";            
            //txtChequeDate.value="";
            ddlIsBearer.selectedIndex=2;
            txtChequeNo.disabled=false;            
            ddlIsBearer.disabled=true;
            txtChequeDate.disabled=false; 
            Img1.disabled=false;
            
        }
        
       }    
    
        function Validate_PaymentType()
        {
            var ddlPaymentType=document.getElementById('<%=ddlPaymentType.ClientID%>');
          
            var ErrorMessage="";
            var lblErrorMessage=document.getElementById("<%=lblErrorMessage.ClientID%>"); 
            var lblChequeIssueTo=document.getElementById("<%=lblChequeIssueTo.ClientID%>"); 
            var lblChequeNo=document.getElementById("<%=lblChequeNo.ClientID%>"); 
            var lblChequeDate=document.getElementById("<%=lblChequeDate.ClientID%>");  
        
            if (ddlPaymentType.selectedIndex==0)
            {
                ErrorMessage="Please select Payment Type to continue!";               
            }
            else
            {
            
                if (ddlPaymentType.selectedIndex==1)
                {
                       lblChequeIssueTo.innerText="Cheque Isssue To"; 
                       lblChequeNo.innerText="Cheque No"; 
                       lblChequeDate.innerText="Cheque Date";      
                }
                else if (ddlPaymentType.selectedIndex==2)
                {
                       lblChequeIssueTo.innerText="Online Transfer To"; 
                       lblChequeNo.innerText="Transaction No"; 
                       lblChequeDate.innerText="Transafer Date";              
                }    
                            
            }
            
            var ddlIsChequePrint=document.getElementById("<%=ddlIsChequePrint.ClientID%>");            
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
            window.scrollBy(0,0);
            lblErrorMessage.innerText=ErrorMessage;
        } 
        
        function Validate_Save()
        {
            
            var lblErrorMessage='';
            var ReturnValue=true;
            var ddlPaymentType=document.getElementById("<%=ddlPaymentType.ClientID%>");            
            var txtChequeIssue=document.getElementById("<%=txtChequeIssue.ClientID%>");            
            var lblAmount=document.getElementById("<%=lblAmount.ClientID%>");            
            
            var ddlIsChequePrint=document.getElementById("<%=ddlIsChequePrint.ClientID%>");            
            var ddlIsBearer=document.getElementById("<%=ddlIsBearer.ClientID%>");            
            var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>");          
           
            var txtCheuqeDate=document.getElementById("<%=txtCheuqeDate.ClientID%>");            
            var ddlBankList=document.getElementById("<%=ddlBankList.ClientID%>");            
            var ddlBankBranchList=document.getElementById("<%=ddlBankBranchList.ClientID%>");            
            var txtAccountHolderName=document.getElementById("<%=txtAccountHolderName.ClientID%>");            
            var txtTransferAccountNo=document.getElementById("<%=txtTransferAccountNo.ClientID%>");   
            var lblError=document.getElementById("<%=lblErrorMessage.ClientID%>");   
            var varChqNo=txtChequeNo.value;
           
           if (ddlPaymentType.selectedIndex==0)
           {
                ReturnValue=false;
                lblErrorMessage='Please select PaymentType to continue!';
                ddlPaymentType.focus();
           
           }
           if (ddlIsChequePrint.selectedIndex==0)
           {
                ReturnValue=false;
                lblErrorMessage='Please select Cheque Print Details to continue!';
                ddlIsChequePrint.focus();
           }
           if (ddlIsBearer.selectedIndex==0)
           {
                ReturnValue=false;
                lblErrorMessage='Please select Cross cheque Selection to continue!';
                ddlIsBearer.focus();
           }
            if (ddlBankList.selectedIndex==0)
           {
                ReturnValue=false;
                lblErrorMessage='Please select Bank to continue!';
                ddlBankList.focus();
           }           
           if (ddlBankBranchList.selectedIndex==0)
           {
                ReturnValue=false;
                lblErrorMessage='Please select Bank-Branch  to continue!';
                ddlBankBranchList.focus();
           }
           
           if (txtChequeIssue.value=='')
           {
                ReturnValue=false;
                lblErrorMessage='Please Enter Cheque Issue to continue!';
                txtChequeIssue.focus();
           }
           
            if (txtChequeNo.value=='')
           {
                ReturnValue=false;
                lblErrorMessage='Please Enter ChequeNo to continue!';
                txtChequeIssue.focus();
           }
           else
           {
                if (varChqNo.length<6)
                {
                    ReturnValue=false;
                    lblErrorMessage='Please Enter valid ChequeNo to continue!';
                    txtChequeNo.focus();
                } 
           }
            
           if (txtCheuqeDate.value=='')
           {
                ReturnValue=false;
                lblErrorMessage='Please Enter Cheque Date to continue!';
                txtCheuqeDate.focus();
           }
           if (txtAccountHolderName.value=='')
           {
                ReturnValue=false;
                lblErrorMessage='Please check Account Holder Name is Blank!';
                txtAccountHolderName.focus();
           }
           if (txtTransferAccountNo.value=='')
           {
                ReturnValue=false;
                lblErrorMessage='Please check Account No Name is Blank!';
                txtTransferAccountNo.focus();
           }
           
           window.scrollBy(0,0);
           lblError.innerText=lblErrorMessage;
           
           return ReturnValue;           
           
        }    
    
    </script>
    <table style="width: 780px">
        <tr>
            <td colspan="7">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="ErrorMessage" SkinID="LabelSkin"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 15px" class="TableHeader">
                &nbsp;Other Than Petty Cash Amount Transfer</td>
        </tr>
        <tr>
            <td style="width: 11px; height: 6px">
            </td>
            <td class="TableTitle" style="height: 6px">
                &nbsp;Payment ID</td>
            <td class="TableGrid" colspan="5" style="height: 6px">
                &nbsp;<asp:Label ID="lblPaymentID" runat="server" SkinID="LabelSkin" Width="359px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 6px;">
            </td>
            <td style="height: 6px;" class="TableTitle">
                &nbsp;Cluster Name</td>
            <td style="width: 100px; height: 6px;" class="TableGrid">
                <asp:Label ID="lblClusterName" runat="server"></asp:Label></td>
            <td style="width: 129px; height: 6px;" class="TableTitle">
                &nbsp;Centre Name</td>
            <td style="width: 95px; height: 6px;" class="TableGrid">
                <asp:Label ID="lblCentreName" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 6px;" class="TableTitle">
                &nbsp;Request By</td>
            <td style="width: 100px; height: 6px;" class="TableGrid">
                <asp:Label ID="lblRequestBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 15px;">
            </td>
            <td class="TableTitle" style="height: 15px">
                &nbsp;Transaction ID</td>
            <td style="width: 100px; height: 15px;" class="TableGrid">
                <asp:Label ID="lblTransactionID" runat="server" Width="171px"></asp:Label></td>
            <td style="width: 129px; height: 15px;" class="TableTitle">
                &nbsp;Requested Amount</td>
            <td style="width: 95px; height: 15px;" class="TableGrid">
                <asp:Label ID="RequestedAmount" runat="server"></asp:Label></td><td style="width: 100px; height: 15px;" class="TableTitle">
                &nbsp;Authorize By</td>
            <td style="width: 100px; height: 15px;" class="TableGrid">
                <asp:Label ID="lblAuthorizeBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 16px;">
            </td>
            <td class="TableTitle" style="height: 16px">
                &nbsp;Vertical</td>
            <td style="width: 100px; height: 16px;" class="TableGrid">
                <asp:Label ID="lblVertical" runat="server"></asp:Label></td>
            <td style="width: 129px; height: 16px;" class="TableTitle">
                &nbsp;Activity</td>
            <td style="width: 95px; height: 16px;" class="TableGrid">
                <asp:Label ID="lblActivity" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 16px;" class="TableTitle">
                &nbsp;Product</td>
            <td style="width: 100px; height: 16px;" class="TableGrid">
                <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 16px;">
                &nbsp;</td>
            <td class="TableTitle" style="height: 16px">
                &nbsp;Account Head&nbsp;</td>
            <td style="width: 100px; height: 16px;" class="TableGrid">
                <asp:Label ID="lblAccountHead" runat="server"></asp:Label></td>
            <td style="width: 129px; height: 16px;" class="TableTitle">
                &nbsp;Remark&nbsp;</td>
            <td style="height: 16px;" class="TableGrid" colspan="3">
                <asp:Label ID="lblRemark" runat="server" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7">
                &nbsp; OTP Amount Transfer Details</td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td class="TableTitle">
                &nbsp;OTP Request
            </td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Payment Type</td>
            <td class="TableTitle" style="width: 129px">
                &nbsp;Amount</td>
            <td class="TableTitle" style="width: 95px">
                &nbsp;<asp:Label ID="lblChequeIssueTo" runat="server" Text="ChequeIssueTo"></asp:Label></td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Cheque Print</td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Cross On Cheque</td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlOTPRequest" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableGrid" style="width: 100px">
                <asp:DropDownList ID="ddlPaymentType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">ByCheuqe</asp:ListItem>
                    <asp:ListItem Value="2">ByOnlineTransfer</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableGrid" style="width: 129px">
                &nbsp;<asp:Label ID="lblAmount" runat="server" SkinID="LabelSkin"></asp:Label></td>
            <td style="width: 95px" class="TableGrid">
                <asp:TextBox ID="txtChequeIssue" runat="server" MaxLength="25" SkinID="txtSkin" Width="133px"></asp:TextBox></td>
            <td style="width: 100px" class="TableGrid">
                <asp:DropDownList ID="ddlIsChequePrint" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px" class="TableGrid">
                <asp:DropDownList ID="ddlIsBearer" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 23px;">
            </td>
            <td class="TableTitle" style="height: 23px">
                &nbsp;<asp:Label ID="lblChequeNo" runat="server" Text="Cheque No" Width="94px"></asp:Label></td>
            <td class="TableTitle" style="width: 100px; height: 23px;">
                &nbsp;<asp:Label ID="lblChequeDate" runat="server" Text="Cheque Date" Width="104px"></asp:Label></td>
            <td class="TableTitle" style="width: 129px; height: 23px;">
                &nbsp;Bank Name</td>
            <td class="TableTitle" style="width: 95px; height: 23px;">
                &nbsp;Branch Name</td>
            <td class="TableTitle" style="width: 100px; height: 23px;">
                &nbsp;Account Holder
            </td>
            <td class="TableTitle" style="width: 100px; height: 23px;">
                &nbsp;Account No</td>
        </tr>
        <tr>
            <td style="width: 11px; height: 22px">
            </td>
            <td class="TableGrid" style="height: 22px">
                <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="6" SkinID="txtSkin" Width="81px"></asp:TextBox></td>
            <td class="TableGrid" style="width: 100px; height: 22px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtCheuqeDate" runat="server" BorderWidth="1px"
                                SkinID="txtSkin" Width="67px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 95px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCheuqeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
                            src="../ChequeProcessing/SmallCalendar.png" style="width: 19px;
                                height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableGrid" style="width: 129px; height: 22px">
                <asp:DropDownList ID="ddlBankList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBankList_SelectedIndexChanged"
                    SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableGrid" style="width: 95px; height: 22px">
                <asp:DropDownList ID="ddlBankBranchList" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableGrid" style="height: 22px">
                &nbsp;<asp:TextBox ID="txtAccountHolderName" runat="server" MaxLength="25" SkinID="txtSkin" Width="121px" ReadOnly="True"></asp:TextBox></td>
                 <td class="TableGrid" style="height: 22px">
                &nbsp;<asp:TextBox ID="txtTransferAccountNo" runat="server" MaxLength="25" SkinID="txtSkin" Width="109px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 33px" class="TableTitle">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Save" Width="59px" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" OnClick="btnCancel_Click" />
                    &nbsp;
                     <asp:Button ID="btnSaveNext" runat="server" BorderWidth="1px" Text="Save n Next" Width="80px" OnClick="btnSaveNext_Click" />&nbsp;<asp:Button
                    ID="Button2" runat="server" BorderWidth="1px" Text="Cancel" OnClick="btnCancel_Click" />
                    &nbsp;
                <asp:Button
                    ID="btnBackToSearch" runat="server" BorderWidth="1px" Text="Back to Search" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnTransactionID" runat="server" /><asp:HiddenField ID="hdnPaymentID" runat="server" /><asp:HiddenField ID="hdnBranchID" runat="server" /><asp:HiddenField ID="hdnAccountNo" runat="server" />
                <asp:HiddenField ID="hdnAccountHolderName" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

