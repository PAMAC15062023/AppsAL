<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="GenerateDepositSlip.aspx.cs" Inherits="Pages_ChequeProcessingNEW_GenerateDepositSlip"
    Title="Generate Deposit Slip" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


  <script language="javascript" type="text/javascript">
    function Convert() {
        var ReturnValue = true;
        var rVal = document.getElementById("<%=rupees.ClientID%>").value;
        var wordValue = document.getElementById("<%=wordValue.ClientID%>")

       rVal = Math.floor(rVal);
    var rup = new String(rVal); rupRev = rup.split(""); actualNumber = rupRev.reverse();
    if (Number(rVal) >= 0) { } else {
        alert('Number cannot be converted');
        return false;
    }
    if (Number(rVal) == 0) {
        document.getElementById('wordValue').innerHTML = rup + '' + 'Rupees Zero Only';
        return false;
    } if (actualNumber.length > 9) {
        alert('the Number is too big to covertes');
        return false;
    }
    var numWords = ["Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"];
    var numPlace = ['Ten', ' Eleven', ' Twelve', ' Thirteen', ' Fourteen', ' Fifteen', ' Sixteen', ' Seventeen', ' Eighteen', ' Nineteen']; var tPlace = ['dummy', ' Ten', ' Twenty', ' Thirty', ' Forty', ' Fifty', ' Sixty', ' Seventy', ' Eighty', ' Ninety'];
    var numWordsLength = rupRev.length; var totalWords = ""; var numtoWords = new Array(); 
    var finalWord = ""; j = 0;
    for (i = 0; i < numWordsLength; i++) {
        switch (i) {
            case 0: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; }
                else { numtoWords[j] = numWords[actualNumber[i]]; } numtoWords[j] = numtoWords[j] + ' Only'; break; case 1: CTen(); break; case 2: if (actualNumber[i] == 0) { numtoWords[j] = ''; } else if (actualNumber[i - 1] != 0 && actualNumber[i - 2] != 0) { numtoWords[j] = numWords[actualNumber[i]] + ' Hundred and'; } else { numtoWords[j] = numWords[actualNumber[i]] + ' Hundred'; } break; case 3: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; } else { numtoWords[j] = numWords[actualNumber[i]]; } if (actualNumber[i + 1] != 0 || actualNumber[i] > 0) { numtoWords[j] = numtoWords[j] + " Thousand"; } break; case 4: CTen(); break; case 5: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; } else { numtoWords[j] = numWords[actualNumber[i]]; } if (actualNumber[i + 1] != 0 || actualNumber[i] > 0) { numtoWords[j] = numtoWords[j] + " Lakh"; } break; case 6: CTen(); break; case 7: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; } else { numtoWords[j] = numWords[actualNumber[i]]; } numtoWords[j] = numtoWords[j] + " Crore"; break; case 8: CTen(); break; default: break;
        } j++;
    } function CTen() { if (actualNumber[i] == 0) { numtoWords[j] = ''; } else if (actualNumber[i] == 1) { numtoWords[j] = numPlace[actualNumber[i - 1]]; } else { numtoWords[j] = tPlace[actualNumber[i]]; } } numtoWords.reverse(); for (i = 0; i < numtoWords.length; i++) { finalWord += numtoWords[i]; }

    wordValue.value = finalWord;

    return ReturnValue;
}

function ConvertSummary() {
    var ReturnValue = true;

    var rVal = document.getElementById("<%=summaryrupees.ClientID%>").value;
    var wordValue = document.getElementById("<%=wordValue.ClientID%>")

    rVal = Math.floor(rVal);
    var rup = new String(rVal); rupRev = rup.split(""); actualNumber = rupRev.reverse();
    if (Number(rVal) >= 0) { } else {
        alert('Number cannot be converted');
        return false;
    }
    if (Number(rVal) == 0) {
        document.getElementById('wordValue').innerHTML = rup + '' + 'Rupees Zero Only';
        return false;
    } if (actualNumber.length > 9) {
        alert('the Number is too big to covertes');
        return false;
    }
    var numWords = ["Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"];
    var numPlace = ['Ten', ' Eleven', ' Twelve', ' Thirteen', ' Fourteen', ' Fifteen', ' Sixteen', ' Seventeen', ' Eighteen', ' Nineteen']; var tPlace = ['dummy', ' Ten', ' Twenty', ' Thirty', ' Forty', ' Fifty', ' Sixty', ' Seventy', ' Eighty', ' Ninety'];
    var numWordsLength = rupRev.length; var totalWords = ""; var numtoWords = new Array();
    var finalWord = ""; j = 0;
    for (i = 0; i < numWordsLength; i++) {
        switch (i) {
            case 0: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; }
                else { numtoWords[j] = numWords[actualNumber[i]]; } numtoWords[j] = numtoWords[j] + ' Only'; break; case 1: CTen(); break; case 2: if (actualNumber[i] == 0) { numtoWords[j] = ''; } else if (actualNumber[i - 1] != 0 && actualNumber[i - 2] != 0) { numtoWords[j] = numWords[actualNumber[i]] + ' Hundred and'; } else { numtoWords[j] = numWords[actualNumber[i]] + ' Hundred'; } break; case 3: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; } else { numtoWords[j] = numWords[actualNumber[i]]; } if (actualNumber[i + 1] != 0 || actualNumber[i] > 0) { numtoWords[j] = numtoWords[j] + " Thousand"; } break; case 4: CTen(); break; case 5: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; } else { numtoWords[j] = numWords[actualNumber[i]]; } if (actualNumber[i + 1] != 0 || actualNumber[i] > 0) { numtoWords[j] = numtoWords[j] + " Lakh"; } break; case 6: CTen(); break; case 7: if (actualNumber[i] == 0 || actualNumber[i + 1] == 1) { numtoWords[j] = ''; } else { numtoWords[j] = numWords[actualNumber[i]]; } numtoWords[j] = numtoWords[j] + " Crore"; break; case 8: CTen(); break; default: break;
        } j++;
    } function CTen() { if (actualNumber[i] == 0) { numtoWords[j] = ''; } else if (actualNumber[i] == 1) { numtoWords[j] = numPlace[actualNumber[i - 1]]; } else { numtoWords[j] = tPlace[actualNumber[i]]; } } numtoWords.reverse(); for (i = 0; i < numtoWords.length; i++) { finalWord += numtoWords[i]; }

    wordValue.value = finalWord;

    return ReturnValue;
}

      </script>

  <script language="javascript" type="text/javascript" src="../toword.js">
  </script>

  <script language="javascript" type="text/javascript">
    
        function Validate_GenerateDepositSlip()
        {
            
            var ReturnValue=true;
            var ErrorMessage="";
            var hdnTotalChequeCaptureCount=document.getElementById("<%=hdnTotalChequeCaptureCount.ClientID%>");
            var hdnTotalChequeCount=document.getElementById("<%=hdnTotalChequeCount.ClientID%>");
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        
            if ((hdnTotalChequeCount.value!="")&&(hdnTotalChequeCaptureCount.value!=""))
            {
                if (hdnTotalChequeCount.value!=hdnTotalChequeCaptureCount.value)
                {
                    ErrorMessage="You Can not Generate Deposit Slip, Please capture all cheques!";
                    ReturnValue=false;
                }        
            }
            else
            {
                    ErrorMessage=" Please capture all cheques!";
                    ReturnValue=false;
            
            }
            lblMessage.innerText=ErrorMessage;
            return ReturnValue;
        }
    
    </script>

  <table>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 19px">
                &nbsp;Generate Deposit Slip</td>
        </tr>
        <tr>
            <td style="width: 13px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;" class="TableTitle">
                &nbsp;Batch No</td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:TextBox ID="txtBatchNo" runat="server" BorderWidth="1px" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 24px;" class="TableTitle">
                &nbsp;Batch Date</td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:Label ID="lblBatchDate" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 24px;" class="TableTitle">
                &nbsp;Client Name</td>
            <td style="width: 100px; height: 24px;" class="TableGrid">
                <asp:Label ID="lblClientName" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 19px">
            </td>
            <td class="TableTitle" style="width: 100px; height: 19px">
                &nbsp;ChequePickupdate</td>
            <td class="TableGrid" style="width: 100px; height: 19px">
                <asp:Label ID="lblChequePickupdate" runat="server"></asp:Label>
            </td>
            <td class="TableTitle" style="width: 100px; height: 19px">
                &nbsp;Deposit Date</td>
            <td class="TableGrid" style="width: 100px; height: 19px">
                <asp:Label ID="lblChequeDepositSlip" runat="server"></asp:Label></td>
            <td class="TableTitle" style="width: 100px; height: 19px">
                &nbsp;Total Cheques</td>
            <td class="TableGrid" style="width: 100px; height: 19px">
                <asp:Label ID="lblTotalChequeCount" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8">
                &nbsp;Drop Box Details</td>
        </tr>
        <tr>
            <td style="width: 13px; height: 186px">
            </td>
            <td colspan="7" style="height: 186px">
                <div style="overflow: scroll; width: 775px; height: 248px">
                    <asp:GridView ID="grv_DropboxDetails" runat="server" BackColor="White" BorderColor="#CC9966"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px;" class="TableTitle" colspan="8">
                &nbsp;<asp:Button ID="btnGenerateDepositSlip" runat="server" BorderWidth="1px" Text="Generate Deposit Slip"
                    Width="148px" OnClick="btnGenerateDepositSlip_Click" />
                &nbsp;<asp:Button ID="btnGenerateDepositSlipGrandSummary" runat="server" 
                    BorderWidth="1px" Text="Generate DepositSlip Grand Summary"
                    Width="230px" OnClick="btnGenerateDepositSlipGrandSummary_Click1" />
                &nbsp;<asp:Button ID="btnBacktoSearch" runat="server" BorderWidth="1px" Text="Back to Search"
                    Width="113px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="68px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:HiddenField ID="hdnTotalChequeCount" runat="server" />
                <asp:HiddenField ID="hdnTotalChequeCaptureCount" runat="server" />
                <asp:HiddenField ID="HdnLocation" runat="server" />
                <asp:HiddenField ID="rupees" runat="server" />
                &nbsp;<asp:HiddenField ID="wordValue" runat="server" />
                <asp:HiddenField ID="summaryrupees" runat="server" />
                <asp:HiddenField ID="HdnAccountNoT" runat="server" />
            &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HDnSlipNo" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnAccountNo" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnDs11Count" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnNO" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnDsCount" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnInstrumentType" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
