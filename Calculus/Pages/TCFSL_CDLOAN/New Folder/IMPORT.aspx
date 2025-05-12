<%@ Page Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master" AutoEventWireup="true"
    CodeFile="IMPORT.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_IMPORT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--Start of JS--%>
    <script type="text/javascript" src="assets/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/timepicki.js"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/buttons.colVis.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <script src="js/menu.js" type="text/javascript"></script>
    <%--Start of css--%>
    <link rel="stylesheet" type="text/css" href="assets/jquery-ui-1.12.1/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="css/timepicki.css">
    <link rel="stylesheet" href="css/jquery-ui.css">
    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
    <link href="css/Menu.css" rel="stylesheet" type="text/css" />
    <script language="Javascript" type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }


        $(document).ready(function () {
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
    <script  language="Javascript" type="text/javascript">
        $('#xslFileUpload').filestyle({
            buttonName: 'btn-danger',
            buttonText: ' File selection'
        });                      
</script>
    <style type="text/css">
        .form-group label
        {
            color: black;
        }
        .btn
        {
            box-shadow: 1px 2px 5px #000000;
        }
    </style>
    <script type="text/javascript">
        $.material.init();
    </script>
    <asp:HiddenField ID="hiddenResult" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <br />
        <br />
        <div class="row" id="import">
            <div class="col-md-12">
                <fieldset>
                    <legend>Import Data</legend>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Import File Format:</label>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnsmaple" class="btn btn-primary hoverable" runat="server" Text="Download"
                                    ValidationGroup="ValidateALL" onclick="btnsmaple_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                      <div class="row">
                      <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Import Type:</label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlType" class="form-control" runat="server" SkinID="ddlSkin">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="SFDC">SFDC</asp:ListItem>
                                            <asp:ListItem Value="Bank">Bank</asp:ListItem>
                                        </asp:DropDownList>
                            </div>
                        </div>
                      </div>
                    <br />
                    <br />
                    <div class="row">
                        
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Select File :</label>
                            </div>
                            <div class="col-md-3">
                             <%--<input id="inputFile3" multiple="" type="file" />--%>
                                <asp:FileUpload ID="xslFileUpload" class="btn btn-color btn-rounded float-left"  runat="server" />
                                    
                            
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:Button ID="btnImport" class="btn btn-primary hoverable" runat="server" Text="Import"
                                    ValidationGroup="ValidateALL" OnClick="btnImport_Click" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnCancel" class="btn btn-primary hoverable" runat="server" Text="Cancel"
                                    OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <div id="dialog-message">
    </div>
</asp:Content>
