<%@ Page Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master" AutoEventWireup="true"
    CodeFile="DailyTracker.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_DailyTracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/buttons/1.3.1/js/buttons.colVis.min.js" type="text/javascript"></script>
    <script src="Datetime/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="Datetime/css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="Datetime/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#tblContent').DataTable({
                "ordering": false,
                dom: 'Bfrtip',
                buttons: [
            {
                extend: 'excel',
                title: 'Report',
                exportOptions: {
                    columns: [0, ':visible']
                }
            }
                ],
                stateSave: true
            });

            $('a.toggle-vis').on('click', function (e) {
                e.preventDefault();

                // Get the column API object
                var column = table.column($(this).attr('data-column'));

                // Toggle the visibility
                column.visible(!column.visible());
            });
        });

    </script>
    <script type="text/javascript">
        $(function () {
            var dateFormat = "dd/mm/yy";
            from = $("#<%=textFromDate.ClientID%>")
                 .datepicker({
                     changeMonth: true,
                     changeYear: true,
                     dateFormat: "dd/mm/yy"
                 })
                 .on("change", function () {
                     to.datepicker("option", "minDate", getDate(this));
                 }),
               to = $("#<%=textToDate.ClientID%>").datepicker({
                   changeMonth: true,
                   changeYear: true,
                   dateFormat: "dd/mm/yy"
               })
               .on("change", function () {
                   from.datepicker("option", "maxDate", getDate(this));
               });

            function getDate(element) {
                var date;
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }


        });
    </script>
    <%--<script type="text/javascript">
        $(function () {
            var dateFormat = "dd MM yyyy - hh:ii";
            from = $("#<%=textFromDate.ClientID%>")
                 .datetimepicker({
                     changeMonth: true,
                     changeYear: true,
                     dateFormat: "dd MM yyyy - hh:ii"
                 })
                 .on("change", function () {
                     to.datetimepicker("option", "minDate", getDate(this));
                 }),
               to = $("#<%=textToDate.ClientID%>").datetimepicker({
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
    </script>--%>
    <script type="text/javascript">
        function displayDialog(result) {
            if (result != null) {
                var message = "";
                if (result == "success") {
                    message = "<P> Data saved successfully </P>";
                } else {
                    message = result;
                }
                $("#dialog-message").append(message);
                $("#dialog-message").dialog({
                    modal: true,
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");
                            afterSubmit();
                        }
                    }
                });
            }
        }


    </script>
    <style type="text/css">
        .sign {
            padding-top: 40px;
            color: #009688;
            font-family: 'Ubuntu', sans-serif;
            font-weight: bold;
            font-size: 23px;
        }
    </style>
    <style type="text/css">
        .little-big-header {
            font-size: 1.0rem;
            margin: 0;
            color: #009688;
            text-align: center;
        }
    </style>
    <style type="text/css">
        .submit {
            border-radius: 5em;
            color: #fff;
            background: linear-gradient(to right, #009688, #009688);
            border: 0;
            padding-left: 50px;
            padding-right: 40px;
            padding-bottom: 10px;
            padding-top: 10px;
            font-family: 'Ubuntu', sans-serif;
            margin-left: 35%;
            font-size: 13px;
            box-shadow: 0 0 20px 1px rgba(0, 0, 0, 0.04);
        }

        .style1 {
            width: 192px;
        }

        .style2 {
            width: 192px;
            height: 22px;
        }

        .style3 {
            height: 22px;
            width: 148px;
        }

        .style4 {
            width: 212px;
        }

        .style5 {
            width: 148px;
        }

        .style6 {
            width: 68px;
        }
    </style>
    <div class="container">
        <asp:HiddenField ID="result" runat="server" />
        <div class="main">
            <p class="sign" align="center">
                Daily Tracker MIS
            </p>
            <br />
            <br />
            <div class="col-md-12 col-sm-12">
                <div class="row">
                    <label class="col-md-2 col-sm-2">
                        From Upload Date:</label>
                    <div class="col-md-2 col-sm-2">
                        <asp:TextBox ID="textFromDate" autocomplete="off" class="form-control" placeholder="Enter From Date here..."
                            runat="server" />
                    </div>
                    <label class="col-md-2 col-sm-2">
                        To Upload Date:
                    </label>
                    <div class="col-md-2 col-sm-2">
                        <asp:TextBox ID="textToDate" autocomplete="off" class="form-control" placeholder="Enter To Date here..."
                            runat="server" />
                    </div>
                    <div class="col-md-2 col-sm-2">
                        <asp:Button ID="Button1" class="form-control btn-primary" type="submit" runat="server"
                            OnClick="Button1_Click" Text="Search" Width="80px" />
                        <asp:Button ID="btncancel" class="form-control btn-primary" runat="server" Text="Cancel"
                            Width="80px" OnClick="btncancel_Click" />
                        <%--<asp:Button ID="btnsubmit" type="submit" value="Sign in" runat="server" Text="Search"
                            class="submit" align="middle" OnClick="btnsubmit_Click" />--%>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="col-md-12 col-sm-12">
                        <div class="container" style="overflow-x: auto;">
                            <table id="tblContent" class="table table-striped table-hover table-bordered">
                                <thead>
                                    <tr>
                                        <th class="style1">Screening Status
                                        </th>
                                        <th class="style4">Status as on (Time)
                                        </th>
                                        <th class="style1">Maker Status
                                        </th>
                                        <th class="style5">Status as on (Time)
                                        </th>
                                        <th class="style1">Author Status
                                        </th>
                                        <th class="style6">Status as on (Time)
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="style1">Total Screening Completed
                                        </td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenCom" runat="server"></asp:Label>
                                        </td>
                                        <td class="style1">Maker Completed
                                        </td>
                                        <td class="style5">
                                            <asp:Label ID="lblMKR" runat="server"></asp:Label>
                                        </td>
                                        <td class="style1">Author Completed
                                        </td>
                                        <td class="style6">
                                            <asp:Label ID="lblATH" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening Reject
                                        </td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenRej" runat="server"></asp:Label>
                                        </td>
                                        <td class="style1">Hold - System Issue
                                        </td>
                                        <td class="style5">
                                            <asp:Label ID="lblMKRHold" runat="server"></asp:Label>
                                        </td>
                                        <td class="style1">Hold - System Issue
                                        </td>
                                        <td class="style6">
                                            <asp:Label ID="lblAHld" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening Approved</td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenAppr" runat="server"></asp:Label>
                                        </td>
                                        <td class="style2">Maker Pending
                                        </td>
                                        <td class="style3">
                                            <asp:Label ID="lblMKRPend" runat="server"></asp:Label>
                                        </td>
                                        <td class="style1">Author Pending
                                        </td>
                                        <td class="style6">
                                            <asp:Label ID="lblAPend" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening Hold</td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenHold" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening Pending Cases</td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenRemain" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">&nbsp;</td>
                                        <td class="style4">&nbsp;</td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <th class="style1">Screening 
                                            QC Status
                                        </th>
                                        <th class="style4">Status as on (Time)
                                        </th>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>

                                    <tr>
                                        <td class="style1">Total Screening QC Completed</td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenQCCom" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Re-initiated Cases
                                        </td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenReinit" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Initiated Cases&nbsp;
                                        </td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreeninit" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening QC Reject</td>
                                        <td class="style4">
                                            <asp:Label ID="lblQCRej" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening QC Approved</td>
                                        <td class="style4">
                                            <asp:Label ID="lblQCapp" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Pending for Finone</td>
                                        <td class="style4">
                                            <asp:Label ID="lblScreenPend" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening QC Hold</td>
                                        <td class="style4">
                                            <asp:Label ID="lblQCHld" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                    <tr>
                                        <td class="style1">Screening QC Pending Cases</td>
                                        <td class="style4">
                                            <asp:Label ID="lblQCRemn" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td class="style5"></td>
                                        <td></td>
                                        <td class="style6"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="dialog-message">
        </div>
    </div>
    <%--end container--%>
    <%--<script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>--%>
</asp:Content>
