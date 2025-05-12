<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="PDC_ChequeUpdation.aspx.cs" Inherits="Pages_ChequeProcessingNEW_PDC_ChequeUpdation" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js">     
    </script>

    <script language="javascript" type="text/javascript">

        function showDate(sender, args) {
            if (sender._textbox.get_element().value == "") {
                var todayDate = new Date();
                sender._selectedDate = todayDate;
            }
        }

        function checkDate(sender, args) {
            //debugger;
            var txtDepDate = document.getElementById("<%=txtDepDate.ClientID%>");
          var selectedDate = new Date();
          selectedDate = sender._selectedDate;
          var d = new Date();

          if (selectedDate.getDateOnly() < d.getDateOnly()) {
              alert("You cannot select a day earlier than today!");
              //              sender._selectedDate = new Date();
              // set the date back to the current date
              sender._textbox.set_Value(sender._selectedDate.format(sender._format))
              txtDepDate.focus();
          }
      }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <table style="width: 100%">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4">&nbsp;PDC Cheques Updation</td>
        </tr>
        <tr>
            <td class="TableGrid" colspan="4">&nbsp;</td>
        </tr>

        <tr>
            <td class="TableTitle" style="width: 20%">
                <strong>Location</strong></td>
            <td class="TableGrid" style="width: 26%">
                <asp:Label ID="lblLocation" runat="server"></asp:Label>
            </td>
            <td class="TableTitle" style="width: 20%">
                <strong>Client</strong></td>
            <td class="TableGrid">
                <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="TableTitle" style="width: 20%">
                <strong>Pickup Date</strong></td>
            <td class="TableGrid" style="width: 26%">
                <%--<asp:MaskedEditExtender ID="txtDepDate_MaskedEditExtender" runat="server" MaskType="Number" Mask="99/99/2013" Enabled="True"
                                    TargetControlID="txtDepDate">
                </asp:MaskedEditExtender>--%>
                <asp:TextBox ID="txtPickupDate" runat="server"></asp:TextBox>
            </td>
            <td class="TableTitle" style="width: 20%">
                <strong>Deposit Date</strong></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtDepDate" runat="server" CssClass="TEXTBOX"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" OnClientDateSelectionChanged="checkDate" Format="dd/MM/yyyy" OnClientShowing="showDate"
                    Enabled="True" TargetControlID="txtDepDate">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="4">
                <asp:Button ID="btnShowPDC" runat="server" OnClick="btnShowPDC_Click"
                    Text="Show PDC" />
                &nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="Update PDC"
                    OnClick="btnUpdate_Click" />&nbsp;
                <asp:Button ID="btnExport" runat="server" Text="Export to Excel"
                    Width="130px" OnClick="btnExport_Click" />
                &nbsp;
                <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="117px" Style="margin-bottom: 0px"
                    Width="253%">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0"
                        visible="true" style="width: 40%">
                        <tr>
                            <td>
                                <asp:GridView ID="grvPDCinfo" runat="server" Height="100px" Width="39%"
                                    EnableViewState="false">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>


</asp:Content>

