<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master" AutoEventWireup="true" CodeFile="QCTracker.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_QCTracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--Start of JS--%>
    <script type="text/javascript" src="assets/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/timepicki.js"></script>
    <%--Start of css--%>
    <link rel="stylesheet" type="text/css" href="assets/jquery-ui-1.12.1/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="css/timepicki.css">
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#lstDocumentStage').multiselect({
                includeSelectAllOption: true,
                enableClickableOptGroups: true,
                maxHeight: 500,
                enableFiltering: true

            });
        });
    </script>
    <script language="Javascript" type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }


        $(document).ready(function () {
            debugger;
            var result = document.getElementById("<%=hiddenResult.ClientID %>").value.toString();

            if (result != null) {
                if (result.length > 0) {
                    displayDialog(result);
                }

            }
        });
        function displayDialog(result) {
            if (result != null) {
                var message = "";
                message = result;
                $("#dialog-message").append(message);
                $("#dialog-message").dialog({
                    modal: true,
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");

                            document.getElementById("<%=hiddenResult.ClientID %>").value = "";
                         }
                     }
                 });
             }

         }
    </script>
    <asp:HiddenField ID="hiddenResult" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend class="showname">QC Tracker</legend>
                    <br />
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive" style="overflow-x: visible !important;">
                                    <div class="form-group">
                                        <asp:GridView ID="grdCases" runat="server" class="table table-striped table-bordered table-hover table-responsive"
                                            AutoGenerateColumns="False" OnRowDataBound="grdCases_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click">Start</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Webtop_Id" HeaderText="WebTop No" />
                                                <asp:BoundField DataField="FinnOneApplication_Number" HeaderText="Application No" />
                                                <asp:BoundField DataField="Screen_User" HeaderText="Screening Name/ID" />
                                                <asp:BoundField DataField="QCScreen_User" HeaderText="Screening QC Name/ID" />
                                                <asp:BoundField DataField="Maker_User" HeaderText="Maker Name/ID" />
                                                <asp:BoundField DataField="Author_User" HeaderText="Author Name/ID" />
                                                <asp:BoundField DataField="QCSCREEN_INPROCTIME" HeaderText="QC Process Date" />
                                                <asp:TemplateField HeaderText="Is Error">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlError" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlError_SelectedIndexChanged" AutoPostBack="true">
                                                           <%-- <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="NoError">No Error</asp:ListItem>
                                                            <asp:ListItem Value="Error">Error</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Document Stage">
                                                    <ItemTemplate>
                                                        <asp:ListBox ID="lstDocumentStage" runat="server" SelectionMode="Multiple" ClientIDMode="Static" Visible="false">
                                                            <asp:ListItem>1st Cheque</asp:ListItem>
                                                            <asp:ListItem>Applicant Live Photograph</asp:ListItem>
                                                            <asp:ListItem>Application Form</asp:ListItem>
                                                            <asp:ListItem>CLI Form</asp:ListItem>
                                                            <asp:ListItem>Delivery Order</asp:ListItem>
                                                            <asp:ListItem>Demand Promissory note and declaration from customer (vernacular declaration)</asp:ListItem>
                                                            <asp:ListItem>First EMI Cheque (Two Cheque Require)</asp:ListItem>
                                                            <asp:ListItem>HDF/CLI Form</asp:ListItem>
                                                            <asp:ListItem>IHO Form</asp:ListItem>
                                                            <asp:ListItem>Invoice</asp:ListItem>
                                                            <asp:ListItem>KYC</asp:ListItem>
                                                            <asp:ListItem>NACH</asp:ListItem>
                                                            <asp:ListItem>NACH Mandate ((Details should match with PDC)</asp:ListItem>
                                                            <asp:ListItem>Sanction Letter</asp:ListItem>
                                                            <asp:ListItem>Terms & Condition Form</asp:ListItem>
                                                        </asp:ListBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarks" runat="server" Height="30px"
                                                            SkinID="txtSkin" TextMode="MultiLine" Visible="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="AUTHOR_FINALDATE" HeaderText="Disbursement Date" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkCompleteNext" runat="server" Font-Bold="True" OnClick="lnkCompleteNext_Click">Complete & New</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkCompleteExit" runat="server" Font-Bold="True" OnClick="lnkCompleteExit_Click">Complete & Exit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:HiddenField ID="hdnWebTop" runat="server" />
                                        <asp:HiddenField ID="hdnCaseNo" runat="server" />
                                        <asp:HiddenField ID="hdnStartStatus" runat="server" />
                                        <asp:HiddenField ID="hdnError" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Button ID="btncancel" class="form-control btn-primary" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <!-- Dialog start -->
    <div id="dialog-message">
    </div>
</asp:Content>

