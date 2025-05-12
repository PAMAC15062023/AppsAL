<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="DS_SearchView.aspx.cs" Inherits="Pages_ChequeProcessingNEW_DS_SearchView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">     
    </script>

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
                alert('the Number is too big to covert');
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
    <%--<script type = "text/javascript">

    function Check_Click(objRef) {

        //Get the Row based on checkbox

        var row = objRef.parentNode.parentNode;

        if (objRef.checked) {

            //If checked change color to Aqua

            row.style.backgroundColor = "aqua";

        }

        else {

            //If not checked change back to original color

            if (row.rowIndex % 2 == 0) {

                //Alternating Row Color

                row.style.backgroundColor = "#C2D69B";

            }

            else {

                row.style.backgroundColor = "white";

            }

        }



        //Get the reference of GridView

        var GridView = row.parentNode;



        //Get all input elements in Gridview

        var inputList = GridView.getElementsByTagName("input");



        for (var i = 0; i < inputList.length; i++) {

            //The First element is the Header Checkbox

            var headerCheckBox = inputList[0];



            //Based on all or none checkboxes

            //are checked check/uncheck Header Checkbox

            var checked = true;

            if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                if (!inputList[i].checked) {

                    checked = false;

                    break;

                }

            }

        }

        headerCheckBox.checked = checked;



    }

    function checkAll(objRef) {

        var GridView = objRef.parentNode.parentNode.parentNode;

        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {

            //Get the Cell To find out ColumnIndex

            var row = inputList[i].parentNode.parentNode;

            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                if (objRef.checked) {

                    //If the header checkbox is checked

                    //check all checkboxes

                    //and highlight all rows

                    row.style.backgroundColor = "aqua";

                    inputList[i].checked = true;

                }

                else {

                    //If the header checkbox is checked

                    //uncheck all checkboxes

                    //and change rowcolor back to original

                    if (row.rowIndex % 2 == 0) {

                        //Alternating Row Color

                        row.style.backgroundColor = "#C2D69B";

                    }

                    else {

                        row.style.backgroundColor = "white";

                    }

                    inputList[i].checked = false;

                }

            }

        }

    }

    function MouseEvents(objRef, evt) {

        var checkbox = objRef.getElementsByTagName("input")[0];

        if (evt.type == "mouseover") {

            objRef.style.backgroundColor = "orange";

        }

        else {

            if (checkbox.checked) {

                objRef.style.backgroundColor = "aqua";

            }

            else if (evt.type == "mouseout") {

                if (objRef.rowIndex % 2 == 0) {

                    //Alternating Row Color

                    objRef.style.backgroundColor = "#C2D69B";

                }

                else {

                    objRef.style.backgroundColor = "white";

                }

            }

        }

    }
</script>--%>
    <table style="width: 99%">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 38%">&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4">Deposit Slip Search View</td>
            <td class="TableHeader" style="width: 38%">&nbsp;</td>
        </tr>
        <tr>
            <td class="TableGrid" style="width: 1%">&nbsp;</td>
            <td class="TableTitle" style="width: 11%"><strong>Location</strong></td>
            <td class="TableGrid" style="width: 295px">
                <asp:Label ID="lblLocation" runat="server"></asp:Label>
            </td>
            <td class="TableTitle" style="width: 14%"><strong>Client</strong> </td>
            <td class="TableGrid" style="width: 38%">
                <asp:DropDownList ID="ddlClientList" runat="server" CssClass="dropdown"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlClientList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TableGrid" style="width: 1%">&nbsp;</td>
            <td class="TableTitle" style="width: 11%"><strong>Pickup Date</strong></td>
            <td class="TableGrid" style="width: 295px">
                <table>
                    <tr>
                        <td style="width: 128px">
                            <asp:TextBox ID="txtPickupdate" runat="server" CssClass="TEXTBOX"></asp:TextBox>
                        </td>
                        <td style="width: 17px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="width: 14%"><strong>Deposit Date</strong></td>
            <td class="TableGrid" style="width: 38%">
                <table style="width: 289px">
                    <tr>
                        <td style="width: 128px">
                            <asp:TextBox ID="txtDepositdate" runat="server" CssClass="TEXTBOX"></asp:TextBox>
                        </td>
                        <td style="width: 17px">
                            <img id="Img3" alt="Calendar"
                                onclick="popUpCalendar(this, document.all.<%=txtDepositdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="TableGrid" style="width: 1%">&nbsp;</td>
            <td class="TableGrid" colspan="4"></td>
        </tr>
        <tr>
            <td class="TableGrid" style="width: 1%">&nbsp;</td>
            <td class="TableGrid" colspan="4">
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search"
                    OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td class="TableGrid" style="height: 125px"></td>
            <td class="GridViewStyle" colspan="4" style="height: 125px">
                <asp:GridView ID="grvBatchDetailsnew" runat="server" Height="100px" Width="39%"
                    EnableViewState="false">
                    <RowStyle CssClass="GridViewRowStyle" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                </asp:GridView>
                <div style="overflow: scroll; width: 840px; height: 100px">
                    <%--   <asp:Panel runat="server" ID="pnlGrid" CssClass="TableGrid" ScrollBars="Vertical" >
                    --%><asp:GridView ID="grvBatchDetails" runat="server" AutoGenerateColumns="False"
                        EnableViewState="false"
                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataKeyNames="BatchNo" Font-Size="8pt"
                        PageSize="20">
                        <%--<RowStyle CssClass="GridViewRowStyle" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                        <Columns>

                            <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" SortExpression="BatchNo" />
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" SortExpression="BranchName" />
                            <asp:BoundField DataField="ClientName" HeaderText="ClientName" SortExpression="ClientName" />
                            <asp:BoundField DataField="ChequePickeupDate" HeaderText="ChequePickeupDate" SortExpression="ChequePickeupDate" />
                            <asp:BoundField DataField="ChequeDepositDate" HeaderText="ChequeDepositDate" SortExpression="ChequeDepositDate" />
                            <asp:BoundField DataField="TotalCount" HeaderText="TotalCount" />
                            <asp:BoundField DataField="Pending" HeaderText="Pending" />

                        </Columns>
                        <RowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#330099" />
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                            ForeColor="#FFFFCC" />


                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td class="TableGrid" style="width: 1%">&nbsp;</td>
            <td class="TableGrid" colspan="4">
                <asp:Button ID="btnDraft" runat="server" OnClick="btnDraft_Click"
                    Text="Draft Deposit Slip" Width="260px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                    Text="Cancel" Width="58px" CausesValidation="False" />
                <asp:Panel runat="server" ID="pnlButtons" CssClass="TableGrid" Visible="False" Width="900px">
                    <asp:Button ID="btnGenerateDS" runat="server" OnClick="btnGenerateDS_Click"
                        Text="Generate Deposit Slip" Width="259px" />
                    <asp:Button ID="btnGenerateDepositSlipGrandSummary" runat="server"
                        Text="Generate DepositSlip Grand Summary"
                        OnClick="btnGenerateDepositSlipGrandSummary_Click" Width="364px" />&nbsp;
                    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Generate Deposit Slip PDC ONLY" Width="220px" />
                    &nbsp;
                </asp:Panel>
            </td>
            <tr>
                <td class="TableGrid" style="width: 1%">&nbsp; </td>
                <td class="TableGrid" colspan="4">
                    <asp:HiddenField ID="hdnAccountNo" runat="server" />
                    <asp:HiddenField ID="hdnPendingCount" runat="server" />
                    <asp:HiddenField ID="HdnDsCount" runat="server" />
                    <asp:HiddenField ID="rupees" runat="server" />
                    <asp:HiddenField ID="summaryrupees" runat="server" />
                    <asp:HiddenField ID="wordValue" runat="server" />
                </td>
            </tr>
    </table>

</asp:Content>

