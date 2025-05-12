<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/HeroHousing/sample.master" CodeFile="MIS.aspx.cs" Inherits="Pages_HeroHousing_MIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/buttons/1.3.1/js/buttons.colVis.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#tblContent').DataTable({
                dom: 'Bfrtip',
                buttons: [
             {
                 extend: 'copy',

                 exportOptions: {
                     columns: [0, ':visible']
                 }
             },
            {
                extend: 'excel',
                title: 'Report',
                exportOptions: {
                    columns: [0, ':visible']
                }
            },
             {
                 extend: 'pdf',
                 title: 'Report',
                 exportOptions: {
                     columns: [0, ':visible']
                 }
             },

             {
                 extend: 'print',
                 title: 'Report',
                 exportOptions: {
                     columns: [0, ':visible']
                 }
             }


            , 'colvis'
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
                 }),
               to = $("#<%=textToDate.ClientID%>").datepicker({
                   changeMonth: true,
                   changeYear: true,
                   dateFormat: "dd/mm/yy"
               });

            $("#<%=textFromDate.ClientID%>").on("keyup change", function () {
                var a = prompt("Enter the time as hh-mm-ss", "00:00:00");
                var date = $("#<%=textFromDate.ClientID%>").val();
                $("#<%=textFromDate.ClientID%>").val(date + " " + a)
            });

            $("#<%=textToDate.ClientID%>").on("keyup change", function () {
                var b = prompt("Enter the time as hh-mm-ss", "00:00:00");
                var date1 = $("#<%=textToDate.ClientID%>").val();
                $("#<%=textToDate.ClientID%>").val(date1 + " " + b)
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
    </style>
    <div class="container">
        <asp:HiddenField ID="result" runat="server" />
        <div class="main">
            <p class="sign" align="center">
                Genrate MIS
            </p>
            <div class="col-md-12 col-sm-12">
                <label class="col-md-1 col-sm-1">
                    Select MIS</label>
                <div class="col-md-3 col-sm-3">
                    <asp:DropDownList ID="ddlMIS" runat="server" class="form-control " AutoPostBack="true">
                        <%--<asp:ListItem Value="HeroHousing_MIS_SP">MIS</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>
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
                        <asp:Button ID="Button1" class="form-control btn-primary" type="submit" runat="server" OnClick="Button1_Click" Text="Export" Width="80px" />
                        <asp:Button ID="btncancel" class="form-control btn-primary" runat="server" Text="Cancel"
                            Width="80px" OnClick="btncancel_Click" />
                        <%--<asp:Button ID="btnsubmit" type="submit" value="Sign in" runat="server" Text="Search"
                            class="submit" align="middle" OnClick="btnsubmit_Click" />--%>
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
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="pnlExport" runat="server" Height="200px" ScrollBars="Horizontal" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvExportReport" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
