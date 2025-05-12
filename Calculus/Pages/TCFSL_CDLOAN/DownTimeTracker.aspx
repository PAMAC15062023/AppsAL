<%@ Page Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master" AutoEventWireup="true"
    CodeFile="DownTimeTracker.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_DownTimeTracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--Start of JS--%>
    <script type="text/javascript" src="assets/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/timepicki.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/buttons/1.3.1/js/buttons.colVis.min.js" type="text/javascript"></script>
    <script src="Datetime/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <%--Start of css--%>
    <link href="Datetime/css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="Datetime/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" type="text/css" href="assets/jquery-ui-1.12.1/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="css/timepicki.css">
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
    <style type="text/css">
        .form-group label {
            color: black;
        }

        .btn {
            box-shadow: 1px 2px 5px #000000;
            margin-right: 0px;
        }
    </style>
    <script type="text/javascript">
        $.material.init();
    </script>
    <script type="text/javascript">
        $(function () {
            var dateFormat = "dd MM yyyy - hh:ii";
            from = $("#<%=txtStrtdate.ClientID%>")
                 .datetimepicker({
                     changeMonth: true,
                     changeYear: true,
                     dateFormat: "dd MM yyyy - hh:ii"
                 })
                 .on("change", function () {
                     to.datetimepicker("option", "minDate", getDate(this));
                 }),
               to = $("#<%=txtTillDate.ClientID%>").datetimepicker({
                   changeMonth: true,
                   changeYear: true,
                   dateFormat: "dd MM yyyy - hh:ii"
               })
               .on("change", function () {
                   from.datetimepicker("option", "maxDate", getDate(this));
               });

            function getDate(element) {
                var date;
                try {
                    date = $.datetimepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }


        });
    </script>
    <%--    <script type="text/javascript">

        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $('#<%=txtStrtdate.ClientID%>').datepicker({
                dateFormat: 'yy-mm-dd'
            });
            $('#<%=txtTillDate.ClientID%>').datepicker({
                dateFormat: 'yy-mm-dd'
            });

        });
       
    </script>
    <script type="text/javascript">

        $(function () {
            $('#<%=txtStrttime.ClientID%>').timepicki();
            $('#<%=txtTillTime.ClientID%>').timepicki();
        });
       
    </script>--%>
    <script type="text/javascript" language="javascript">
        function UpperLetter(ID) {
            //            debugger
            ID.value = ID.value.toUpperCase();
        }
        function checkNumeric(textBox) {
            var textBox = document.getElementById(txtlosno);
            if (isNaN(textBox.value)) {
                alert("-Please provide a numeric value.");
                textBox.value = "";
                return false;
            }
        }
    </script>
    <asp:HiddenField ID="hiddenResult" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Down Time Tracker<br />
                    </legend>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="CaseNo">
                                    System :</label>
                                <asp:DropDownList ID="ddlSystem" class="form-control" data-toggle="collapse" runat="server"
                                    AutoPostBack="false">
                                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Finnone">Finnone</asp:ListItem>
                                    <asp:ListItem Value="SFDC">SFDC</asp:ListItem>
                                    <asp:ListItem Value="WebTop">WebTop</asp:ListItem>
                                    <asp:ListItem Value="InternalServer">Internal Server</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-4">
                                <label for="salesdate">
                                    StartTime Date</label>
                                <asp:TextBox ID="txtStrtdate" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label for="cpadate">
                                    TillTime Date</label>
                                <asp:TextBox ID="txtTillDate" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- <div class="row">
                        <div class="form-group">
                            <div class="col-md-4">
                                <label for="salestime">
                                    StartTime :</label>
                                <asp:TextBox ID="txtStrttime" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label for="cpatime">
                                    TillTime :</label>
                                <asp:TextBox ID="txtTillTime" class="form-control" name="txtTime" runat="server"  autocomplete="off"> </asp:TextBox>
                            </div>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="CaseNo">
                                    Remark :</label>
                                <asp:TextBox ID="txtRemark" class="form-control" runat="server" onkeyup="UpperLetter(this);" TextMode="MultiLine" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:Button ID="btnSave" class="btn btn-primary hoverable" runat="server"
                                    Text="Save" ValidationGroup="ValidateALL" OnClick="btnSave_Click" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="Button1" class="btn btn-primary hoverable" runat="server"
                                Text="Cancel" OnClick="Button1_Click" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <%--end container--%>
    <!-- Dialog start -->
    <div id="dialog-message">
    </div>
</asp:Content>
