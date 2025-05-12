<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="OtherChequeDataEntry.aspx.cs" Inherits="Pages_ChequeProcessingNEW_OtherBank"
    Title="Cheque Capture " StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">     
    </script>
    <script language="javascript" type="text/javascript"> 
    
             
        function Disable_UserControls(Value)
        {
            var ddlInstrumentType=document.getElementById("<%=ddlInstrumentType.ClientID%>");                              
             
            var txtChequeNo=document.getElementById("<%=txtChequeNo.ClientID%>"); 
            var txtChequeAmt=document.getElementById("<%=txtChequeAmt.ClientID%>");                              
            var txtChequeDate=document.getElementById("<%=txtChequeDate.ClientID%>");                                          
            var txtCardNo=document.getElementById("<%=txtCardNo.ClientID%>");                              
            var txtMICRCode=document.getElementById("<%=txtMICRCode.ClientID%>"); 
            var txtAcountNo=document.getElementById("<%=txtAcountNo.ClientID%>");

            var txtBank = document.getElementById("<%=txtBank.ClientID%>");
            var txtBranch=document.getElementById("<%=txtBranch.ClientID%>");
            var txtCity = document.getElementById("<%=txtCity.ClientID%>");
            var btnSave = document.getElementById("<%=btnSave.ClientID%>");

            ddlInstrumentType.disabled=Value;
            ddlSignature.disabled=Value;
//          ddlReasonList.disabled=Value;
            txtChequeNo.disabled=Value;            
            txtChequeAmt.disabled=Value;
            txtChequeDate.disabled=Value;            
            txtCardNo.disabled=Value;
            txtMICRCode.disabled=Value;
            txtAcountNo.disabled = Value;
            txtBank.disabled = Value;
            txtBranch.disabled = Value;
            txtCity.disabled = Value;
            btnSave.disabled = Value;
            
            
//            txtTransactionCode.disabled=Value;            
//            txtContactNo.disabled=Value;
//            txtReceiptNo.disabled=Value;
//            txtRemark.disabled=Value;
//            
            
        
        }



        function Get_DropBoxDetails(evt) {

            evt = (evt) ? evt : ((event) ? event : null);
            var ddlDropBoxList = document.getElementById("<%=ddlDropBoxList.ClientID%>");

            if (evt != null) {
                if (evt.keyCode == 13) {
                    evt.keyCode = 9;
                }
            }
            var ErrorMessage = "";
            //var ddlDropBoxList=document.getElementById("<%=ddlDropBoxList.ClientID%>");       
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var lblDropBoxName = document.getElementById("<%=lblDropBoxName.ClientID%>");
            var btnCancel = document.getElementById("<%=btnCancel.ClientID%>");

            var lblTotalChqueCapture = document.getElementById("<%=lblTotalChqueCapture.ClientID%>");
            var hdnTransactionDetailID = document.getElementById("<%=hdnTransactionDetailID.ClientID%>");

            var Value = false;

            var SelectIndex = parseInt(ddlDropBoxList.selectedIndex);

            var strDropBoxDetails = '';
            var strRowDetails = "";

            if (ddlDropBoxList.selectedIndex != 0) {
                strDropBoxDetails = ddlDropBoxList.value;
                strRowDetails = strDropBoxDetails.split('|', strDropBoxDetails.length);
                lblDropBoxName.innerText = strRowDetails[1];
                lblTotalChqueCapture.innerText = strRowDetails[3] + " of " + strRowDetails[2];

                if ((strRowDetails[3] == strRowDetails[2]) && (hdnTransactionDetailID.value == '0')) {
                    Value = true;
                    //                            ErrorMessage='All Cheques Captured for selected drop box!!';
                    alert('All Cheques Captured for selected drop box!!');
                    //                            ddlDropBoxList.focus();//nnnnnn
                    btnCancel.focus();
                }
                else {
                    Value = false;
                }
            }
            else {
                lblDropBoxName.innerText = '';
                lblTotalChqueCapture.innerText = '';
                Value = true;
                ErrorMessage = 'Please select valid dropbox to continue!';
                //                        alert('Please select valid dropbox to continue!');
            }

            lblMessage.innerText = ErrorMessage;
            Disable_UserControls(Value);

        }
     
        
          
        function Validate_Save()
        {
             
            var ErrorMessage=''; 
            var returnValue=true;
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");                                        
            var ddlDropBoxList=document.getElementById("<%=ddlDropBoxList.ClientID%>");
            var ddlInstrumentType=document.getElementById("<%=ddlInstrumentType.ClientID%>");                             
            var txtCardNo=document.getElementById("<%=txtCardNo.ClientID%>");
            var txtAcountNo=document.getElementById("<%=txtAcountNo.ClientID%>");
            var ddlSignature=document.getElementById("<%=ddlSignature.ClientID%>");
            var strDropBoxDetails='';        
            var strRowDetails="";
            var hdnTransactionDetailID=document.getElementById("<%=hdnTransactionDetailID.ClientID%>");
          
            strDropBoxDetails=ddlDropBoxList.value; 
            strRowDetails=strDropBoxDetails.split('|', strDropBoxDetails.length); 

            
            
            if (ddlDropBoxList.selectedIndex==0)
            {
                returnValue=false;
                ErrorMessage='Please select Valid Dropbox to continue!';
                ddlDropBoxList.focus();
            }
            else if ((strRowDetails[3]== strRowDetails[2])&&(hdnTransactionDetailID.value=='0'))
            {    
                returnValue=false;
                ErrorMessage='All Cheques captured for selected Dropbox!';
                ddlDropBoxList.focus();
            }
            else 
            {
                if  (ddlInstrumentType.selectedIndex==0)
                {
                    returnValue=false;
                    ErrorMessage='Please select Intrument Type to continue!';
                    ddlInstrumentType.focus();
                }
                if (txtCardNo.value=='')
                {
                    returnValue=false;
                    ErrorMessage='Please Enter Card No to continue!';
                    txtCardNo.focus(); 
                }
                if (ddlSignature.selectedIndex==0)
                {   
                    returnValue=false;
                    ErrorMessage='Please select Signature on Cheque to continue!';
                    ddlSignature.focus();                 
                }
            }
            lblMessage.innerText=ErrorMessage;
            return returnValue; 
        }   
 
       function Get_DropBoxDetails()
        {
            var ErrorMessage="";
            var ddlDropBoxList=document.getElementById("<%=ddlDropBoxList.ClientID%>");       
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");                              
            var lblDropBoxName=document.getElementById("<%=lblDropBoxName.ClientID%>");       
            var lblDropCount=document.getElementById("<%=lblDropCount.ClientID%>");       
            var lblTotalChqueCapture=document.getElementById("<%=lblTotalChqueCapture.ClientID%>");       
            var hdnTransactionDetailID=document.getElementById("<%=hdnTransactionDetailID.ClientID%>");
          
            var Value=false;   
             
            var SelectIndex=parseInt(ddlDropBoxList.selectedIndex);                        

            var strDropBoxDetails='';        
            var strRowDetails="";   
                       

            if (ddlDropBoxList.selectedIndex!=0)   
            { 
                strDropBoxDetails=ddlDropBoxList.value; 
                strRowDetails=strDropBoxDetails.split('|', strDropBoxDetails.length);                 
                lblDropBoxName.innerText=strRowDetails[1];                
                lblTotalChqueCapture.innerText=strRowDetails[3]+ " of " +strRowDetails[2]; 
                
                if ((strRowDetails[3]== strRowDetails[2])&&(hdnTransactionDetailID.value=='0'))
                {
                    Value=true;
                    ErrorMessage='All Cheques Captured for selected drop box!!';
                    ddlDropBoxList.focus();
                }
                else
                {
                    Value=false;
                }
            } 
            else            
            {
                lblDropBoxName.innerText='';
               //lblDropCount.innerText='';
                lblTotalChqueCapture.innerText=''; 
                Value=true;
                ErrorMessage='Please select valid dropbox to continue!';
            }  
            lblMessage.innerText=ErrorMessage;
            Disable_UserControls(Value);
        }
        
        
    </script>

    <table>
        <tr>
            <td colspan="8" style="height: 15px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 21px">
                &nbsp;&nbsp; 
                <asp:Label ID="lblChequeCategory" runat="server"></asp:Label>
                Bank
                Cheque Data Entry
            </td>
        </tr>
        <tr>
            <td style="height: 28px">
                &nbsp;</td>
            <td class="TableTitle" style="height: 28px">
                &nbsp;<strong>Batch No </strong>
            </td>
            <td class="TableGrid" style="width: 100px; height: 28px;">
                <asp:TextBox ID="txtBatchNo" runat="server" BorderWidth="1px" ReadOnly="True" Width="158px"
                    SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle" style="height: 28px">
                &nbsp;<strong>BatchDate</strong></td>
            <td class="TableGrid" colspan="2" style="height: 28px">
                &nbsp;<asp:Label ID="lblBatchDate" runat="server" Width="70px" SkinID="LabelSkin"></asp:Label></td>
            <td style="width: 100px; height: 28px;" class="TableTitle">
                &nbsp;No Of Cheque Captured</td>
            <td class="TableGrid" style="width: 100px; height: 28px;">
                <asp:Label ID="lblNoOfCheque" runat="server" Width="70px" SkinID="LabelSkin"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 35px">
            </td>
            <td class="TableTitle" style="height: 35px">
                &nbsp;Drop Box Code</td>
            <td style="width: 100px; height: 35px;" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                            <asp:DropDownList ID="ddlDropBoxList" runat="server" SkinID="ddlSkin">
                            </asp:DropDownList></td>
                        <td style="width: 100px; height: 20px;">
                            <asp:Label ID="lblDropCount" runat="server" Width="35px"></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="height: 35px">
                &nbsp;DropBoxName</td>
            <td class="TableGrid" colspan="2" style="height: 35px">
                &nbsp;<asp:Label ID="lblDropBoxName" runat="server" Width="234px" SkinID="LabelSkin"></asp:Label></td>
            <td style="width: 100px; height: 35px;" class="TableTitle">
                DropBoxChequeCaptured
            </td>
            <td class="TableGrid" style="width: 100px; height: 35px;">
                <asp:Label ID="lblTotalChqueCapture" runat="server" Width="70px" SkinID="LabelSkin"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">
                &nbsp;Card and Personal Details</td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;InstrumentType</td>
            <td class="TableGrid" style="width: 100px;">
                <asp:DropDownList ID="ddlInstrumentType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                    <asp:ListItem>DD</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableTitle">
                &nbsp;CheuqeNo</td>
            <td class="TableGrid">
                <asp:TextBox ID="txtChequeNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="74px" MaxLength="6"></asp:TextBox></td>
            <td class="TableTitle" style="width: 45px">
                &nbsp;ChequeAmt</td>
            <td style="width: 100px;" class="TableGrid">
                <asp:TextBox ID="txtChequeAmt" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="99px"></asp:TextBox></td>
            <td style="width: 100px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;ChequeDate</td>
            <td style="width: 100px" class="TableGrid">
                <table cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;ChequeCaptureUser &nbsp;</td>
            <td class="TableGrid">
                &nbsp;<asp:Label ID="lblChequeCapturedByUser" runat="server" SkinID="LabelSkin" Width="70px"></asp:Label></td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;<strong>Card No. *</strong></td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtCardNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px" MaxLength="16"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;Card Amount</td>
            <td class="TableGrid">
                &nbsp;<asp:Label ID="lblCardAmount" runat="server" SkinID="LabelSkin" Width="71px"></asp:Label></td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 1px">
            </td>
            <td class="TableTitle" style="height: 1px">
                &nbsp;<strong>MICRCode *</strong></td>
            <td class="TableGrid" style="width: 100px; height: 1px;">
                <asp:TextBox ID="txtMICRCode" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px" MaxLength="9"></asp:TextBox></td>
            <td class="TableTitle" style="height: 1px">
                &nbsp;Bank</td>
            <td class="TableGrid" style="height: 1px">
                <asp:TextBox ID="txtBank" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 1px; width: 45px;">
                &nbsp;Branch</td>
            <td class="TableGrid" colspan="2" style="height: 1px">
                <asp:TextBox ID="txtBranch" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="TableTitle">
                &nbsp;Account No</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtAcountNo" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="120px" MaxLength="16"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;City</td>
            <td class="TableGrid" colspan="4">
                <asp:TextBox ID="txtCity" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;Signature</td>
            <td class="TableGrid" style="width: 100px; height: 24px">
                <asp:DropDownList ID="ddlSignature" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableTitle" style="height: 24px">
                &nbsp;</td>
            <td class="TableGrid" style="height: 24px" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="8" style="height: 38px">
                &nbsp;&nbsp;
              
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" OnClick="btnSave_Click"
                    Text="Save" Width="59px" />&nbsp;<asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnBackToSearch" runat="server" BorderWidth="1px" Text="Back to Search" OnClick="btnBackToSearch_Click" Width="119px" /></td>
        </tr>
        <tr>
            <td colspan="8"><asp:HiddenField ID="hdnDate" runat="server" />
                <asp:HiddenField ID="hdnTransactionDetailID" runat="server" /><asp:HiddenField ID="hdnChequeStaus" runat="server" />
                <asp:HiddenField ID="hdnMICRDetails" runat="server" />
                <asp:HiddenField ID="hdnEntryStart" runat="server" /><asp:HiddenField ID="hdnDepositDate" runat="server" /><asp:HiddenField ID="hdnchequeCategory" runat="server" Value="0" /><asp:HiddenField ID="hdnIsSuspenseCheque" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 45px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
