<%@ Page Language="C#" MasterPageFile="~/Pages/HeroHousing/sample.master" AutoEventWireup="true"
    CodeFile="Superadmin.aspx.cs" Inherits="Pages_HeroHousing_Superadmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
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
    <style type="text/css">
        .form-group label {
            color: black;
        }

        .table > tbody > tr > th {
            background: #80deea;
        }

        <script type="text/javascript" > $(document).ready(function () {
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
        }); </script >
    </style>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        $.material.init();
    </script>
    <asp:HiddenField ID="hiddenResult" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Superadmin</legend>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-6">
                                <label for="Heading" style="font-size: larger; font-weight: bold; color: #078478; padding-left: 157px;">
                                    SEARCH BY CENTRE</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label for="Heading" style="font-size: larger; font-weight: bold; color: #078478; padding-left: 157px;">
                                    ASSING DATA ENTRY/CAM</label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Location</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UP_ddllocation" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="ddllocation" class="form-control" runat="server" SkinID="ddlSkin"
                                    OnSelectedIndexChanged="ddllocation_SelectedIndexChanged" AutoPostBack="true">
                                   <%-- <asp:ListItem Value="1">Mumbai</asp:ListItem>
                                    <asp:ListItem Value="3">Delhi</asp:ListItem>--%>
                                </asp:DropDownList>
                                        </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllocation" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Changed Location</label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlChangelocation" class="form-control" runat="server" SkinID="ddlSkin">
                                    <%--<asp:ListItem Value="1">Mumbai</asp:ListItem>
                                    <asp:ListItem Value="3">Delhi</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                </label>
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Roll</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRoll" class="form-control" runat="server" SkinID="ddlSkin"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlRoll_SelectedIndexChanged">
                                            <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Data Entry</asp:ListItem>
                                            <asp:ListItem Value="2">CAM</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlRoll" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    User Name</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlUserlist" class="form-control" runat="server" SkinID="ddlSkin"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Process Queue</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlQueueDE" class="form-control" Visible="false" runat="server"
                                            SkinID="ddlSkin" AutoPostBack="True" OnSelectedIndexChanged="ddlQueueDE_SelectedIndexChanged">
                                            <%--<asp:ListItem Value="1">--Select--</asp:ListItem>
                                            <asp:ListItem Value="Data_Entry">Data Entry</asp:ListItem>
                                            <asp:ListItem Value="Data_EntryHold">Hold</asp:ListItem>
                                            <asp:ListItem Value="CAM">CAM</asp:ListItem>
                                            <asp:ListItem Value="CAM_Hold">Hold</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlQueueDE" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                </label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:Button ID="btnlocation" class="form-control btn-primary" runat="server" Text="Changed Location"
                                    ValidationGroup="ValidateALL" Width="128px" AutoPostBack="True" OnClick="btnlocation_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:Button ID="btnsumbit" class="form-control btn-primary" runat="server" Text="Assign"
                                    ValidationGroup="ValidateALL" Width="126px" AutoPostBack="True" OnClick="btnsumbit_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:Button ID="btncancel" class="form-control btn-primary" runat="server" Text="Cancel"
                                    Width="123px" AutoPostBack="True" OnClick="btncancel_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:HiddenField ID="HdnCase" runat="server" />
                                <asp:HiddenField ID="HdnWeb" runat="server" />
                                <asp:HiddenField ID="HdnAppno" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <br />
    <table>
        <tr>
            <td>
                <asp:Panel ID="pnlExport" runat="server" Height="313px" ScrollBars="Both">
                    <table id="tblContent" runat="server" visible="true" style="margin-left: 145px; width: 1127px;">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdlos" runat="server" Style="background" class="table table-striped table-bordered table-hover table-responsive"
                                            Width="1127px" AllowSorting="True" OnSorting="grdlos_Sorting">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <%--<div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:Panel ID="Panel1" runat="server" Height="313px" ScrollBars="Both" Width="900px">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdlos" runat="server" Style="background" class="table table-striped table-bordered table-hover table-responsive"
                                                Width="910px"  AllowSorting="True"  onsorting="grdlos_Sorting">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:ValidationSummary ID="ValidationSummary1" class="form-control" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="validenrty" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="hidWrapper">
                            <div class="col-md-4">
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>--%>
    <!-- Dialog start -->
    <div id="dialog-message">
    </div>
    <meta http-equiv="refresh" content="180" />
</asp:Content>
