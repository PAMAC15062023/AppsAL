<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="GenerateMDBFile.aspx.cs" Inherits="Pages_ChequeProcessingNEW_GenerateMDBFile"
    Title="Generate MDB File" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>

    <script language="javascript" type="text/javascript">

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

        function Search_validate() {
            var returnValue = true;
            var btnSearch = document.getElementById("<%=btnSearch.ClientID%>");
            var ddlClientList = document.getElementById("<%=ddlClientList.ClientID%>");
            var txtPickupDate = document.getElementById("<%=txtPickupDate.ClientID%>");
            var selectedIndex = ddlClientList.selectedIndex;

            if (txtPickupDate.value == '') {
                returnValue = false;
                alert("Enter Pickup Date");
            }
            if (ddlClientList.selectedIndex = 0) {
                returnValue = false;
                alert('Select Client..')
            }
            return returnValue;
        }

        function checkSelected(chkSelect) {
            // debugger;
            var grvTransactionInfo = document.getElementById("<%=grvTransactionInfo.ClientID%>");
         var chkSelect1 = document.getElementById(chkSelect);

         var cell;
         for (i = 0; i <= grvTransactionInfo.rows.length - 1; i++) {
             cell = grvTransactionInfo.rows[i].cells[1];
             if (cell != null) {
                 for (j = 0; j < cell.childNodes.length; j++) {

                     if (cell.childNodes[j].type == "checkbox") {
                         if (cell.childNodes[j].checked == true) {
                             cell.childNodes[j].checked = false;
                         }


                     }
                 }
             }

         }


         chkSelect1.checked = true;



     }

     function Get_SelectedTransactionID(ID) {
         //   debugger;
         var grvTransactionInfo = document.getElementById("<%=grvTransactionInfo.ClientID%>");
        var hdnTransID = document.getElementById("<%=hdnTransID.ClientID%>");
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var ReturnValue = true;
        var ErrorMessage = '';


        var cell;
        for (i = 0; i <= grvTransactionInfo.rows.length - 1; i++) {
            cell = grvTransactionInfo.rows[i].cells[1];
            if (cell != null) {
                for (j = 0; j < cell.childNodes.length; j++) {

                    if (cell.childNodes[j].type == "checkbox") {
                        if (cell.childNodes[j].checked == true) {
                            //  debugger;   
                            if ((grvTransactionInfo.rows[i].cells[7].innerText == ' ') && (ID == 1)) {
                                ErrorMessage = "you cannot genearte deposit slip, please capture all cheques details!";
                                ReturnValue = false;
                            }
                            //if((grvTransactionInfo.rows[i].cells[9].innerText=='0')&&(ID==3))
                            //{
                            // ErrorMessage="All cheques captured!";
                            // ReturnValue=false;
                            //}

                            hdnTransID.value = grvTransactionInfo.rows[i].cells[2].innerText;

                            break;
                        }
                    }
                }
            }

        }



        if (hdnTransID.value == '') {
            ErrorMessage = "Please select atleast one record to continue!";
            ReturnValue = false;

        }
        lblMessage.innerText = ErrorMessage;
        window.scroll(0, 0);
        return ReturnValue;

    }


    function switchViews(obj, row) {
        //debugger;
        var div = document.getElementById(obj);
        var img = document.getElementById('img' + obj);

        if (div.style.display == "none") {
            div.style.display = "inline";
            if (row == 'alt') {
                img.src = "../Calculus/Images/minus.png";
                mce_src = "../Calculus/Images/minus.png";
            }
            else {
                img.src = "../Calculus/Images/minus.png";
                mce_src = "../Calculus/Images/minus.png";
            }
            img.alt = "Close to view other customers";
        }
        else {
            div.style.display = "none";
            if (row == 'alt') {

                img.src = "../Calculus/Images/plus.png";
                mce_src = "../Calculus/Images/plus.png";
            }
            else {
                img.src = "../Calculus/Images/plus.png";
                mce_src = "../Calculus/Images/plus.png";

            }
            img.alt = "Expand to show Transactions";
        }
    }

    </script>
    <table style="width: 907px">
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 22px">&nbsp;Generate MDB File Search</td>
        </tr>
        <tr>
            <td style="width: 1px"></td>
            <td class="TableTitle" style="width: 100px"><strong>Location</strong></td>
            <td class="TableGrid" style="width: 201px">
                <asp:Label ID="lblLocation" runat="server"></asp:Label>
            </td>
            <td class="TableTitle" style="width: 100px"><strong>Client</strong></td>
            <td class="TableGrid" colspan="3">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlClientList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 1px">&nbsp;</td>
            <td class="TableTitle" style="width: 100px"><strong>PickupDate</strong></td>
            <td class="TableGrid" style="width: 201px">
                <table cellpadding="0" cellspacing="0" style="width: 87px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtPickupDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">&nbsp;</td>
                        <td style="width: 100px; height: 22px">
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle" style="width: 100px"><strong>Deposit Date</strong></td>
            <td class="TableGrid" colspan="3">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtDepositdate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="70px"></asp:TextBox>
                            &nbsp;<img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnTransID" runat="server" />
                <asp:HiddenField ID="hdnPendingCount" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 34px">&nbsp;
                <asp:Button ID="btnSearch" runat="server" BorderWidth="1px"
                    Text="Search" OnClick="btnSearch_Click" />&nbsp;<asp:Button ID="btnClear" runat="server" BorderWidth="1px"
                        OnClick="btnClear_Click" Text="Clear" /></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 10px">&nbsp; Generate MDB File View</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="overflow: scroll; width: 840px; height: 199px">
                    <%--  <asp:GridView ID="grvTransactionInfo" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataKeyNames="BatchNo" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                        PageSize="20">--%><asp:GridView ID="grvTransactionInfo" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" DataKeyNames="BatchNo" Font-Size="8pt"
                            PageSize="20">
                            <Columns>
                                <%--     <asp:TemplateField>
    <HeaderTemplate>
        <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);" />
    </HeaderTemplate>
        <ItemTemplate>
        <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)" />
        </ItemTemplate>
        </asp:TemplateField>--%>
                                <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" SortExpression="BatchNo" />
                                <asp:BoundField DataField="BranchName" HeaderText="BranchName" SortExpression="BranchName" />
                                <asp:BoundField DataField="ClientName" HeaderText="ClientName" SortExpression="ClientName" />
                                <asp:BoundField DataField="ChequePickeupDate" HeaderText="ChequePickeupDate" SortExpression="ChequePickeupDate" />
                                <asp:BoundField DataField="ChequeDepositDate" HeaderText="ChequeDepositDate" SortExpression="ChequeDepositDate" />
                                <asp:BoundField DataField="TotalCount" HeaderText="TotalCount" />
                                <asp:BoundField DataField="Pending" HeaderText="Pending" />
                                <%--<asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("AutoNo") %>' style="display: none; position: relative; left: 15px;">
                                                <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="BatchNo"
                                                    EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                    GridLines="Horizontal" Width="80%">
                                                    <Columns>
                                                        <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
                                                        <asp:BoundField DataField="DropBox_Code" HeaderText="DropBox Code" />
                                                        <asp:BoundField DataField="DropBox_Name" HeaderText="DropBox Name" />
                                                        <asp:BoundField DataField="TotalCount" HeaderText="ChequeCounts" />
                                                        <asp:BoundField DataField="CaptureCount" HeaderText="CaptureCount" />
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
                            </asp:TemplateField>--%>
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
            <td class="TableTitle" colspan="7" style="height: 30px">&nbsp;&nbsp;<asp:Button ID="btnGenerateMDB" runat="server" BorderWidth="1px" OnClick="btnGenerateMDB_Click" Visible="false"
                Text="Generate MDB" Width="107px" />&nbsp;<asp:Button ID="btnClose" runat="server"
                    BorderWidth="1px" OnClick="btnClose_Click" Text="Close" Width="65px" /></td>
        </tr>
        <tr>
            <td style="width: 3px"></td>
            <td style="width: 100px"></td>
            <td style="width: 201px"></td>
            <td style="width: 100px"></td>
            <td style="width: 96px"></td>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
            <td style="width: 28px"></td>
        </tr>
    </table>
</asp:Content>
