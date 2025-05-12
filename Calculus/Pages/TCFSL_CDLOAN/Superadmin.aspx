<%@ Page Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master" AutoEventWireup="true"
    CodeFile="Superadmin.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_Superadmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <%--Start of JS--%>
    <script type="text/javascript" src="assets/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/timepicki.js"></script>
    <%--Start of css--%>
    <link rel="stylesheet" type="text/css" href="assets/jquery-ui-1.12.1/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="css/timepicki.css">
    <style type="text/css">
        .form-group label {
            color: black;
        }

        .table > tbody > tr > th {
            background: #80deea;
        }
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
                    <legend>Superadmin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <table border="1px solid" class="table table-striped table-bordered table-hover table-responsive" width="910px">
                                    <tr>
                                        <td colspan="7" style="text-align: center; font-weight: bold;">Out of TAT Pendency Counter </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">QC</td>
                                        <td style="text-align: center;">QC Hold</td>
                                        <td style="text-align: center;">QC Pending For FinnOne</td>
                                        <td style="text-align: center;">Maker</td>
                                        <td style="text-align: center;">Maker Hold</td>
                                        <td style="text-align: center;">Author</td>
                                        <td style="text-align: center;">Author Hold</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; font-weight: bold; color: Red; font-size: large;">
                                            <asp:Label ID="lblQCCount" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; font-weight: bold; color: Red; font-size: large;">
                                            <asp:Label ID="lblQCHoldCount" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; font-weight: bold; color: Red; font-size: large;">
                                            <asp:Label ID="lblQCPendingFinnOneCount" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; font-weight: bold; color: Red; font-size: large;">
                                            <asp:Label ID="lblMakerCount" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; font-weight: bold; color: Red; font-size: large;">
                                            <asp:Label ID="lblMakerHoldCount" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; font-weight: bold; color: Red; font-size: large;">
                                            <asp:Label ID="lblAuthorCount" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; font-weight: bold; color: Red; font-size: large;">
                                            <asp:Label ID="lblAuthorHoldCount" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>

                                <asp:Timer ID="pendencyTimer" runat="server" OnTick="pendencyTimer_Tick"
                                    Interval="5000">
                                </asp:Timer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </legend>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Location</label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddllocation" class="form-control" runat="server" SkinID="ddlSkin">
                                    <%--<asp:ListItem Value="1">Mumbai</asp:ListItem>
                                    <asp:ListItem Value="2">Pune</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:HiddenField ID="HdnCase" runat="server" />
                                <asp:HiddenField ID="HdnWeb" runat="server" />
                                <asp:HiddenField ID="HdnAppno" runat="server" />
                            </div>
                            <div class="col-md-3">
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
                                    SFDC/WEBTOP</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlapptyp" class="form-control" runat="server" SkinID="ddlSkin"
                                            OnSelectedIndexChanged="ddlapptyp_SelectedIndexChanged" AutoPostBack="True">
                                            <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="QC">Screening</asp:ListItem>
                                            <asp:ListItem Value="2">FINONE Maker</asp:ListItem>
                                            <asp:ListItem Value="3">FINONE Author</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Process Queue</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlQueue" class="form-control" runat="server" SkinID="ddlSkin"
                                            OnSelectedIndexChanged="ddlQueue_SelectedIndexChanged" AutoPostBack="True">                                           
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    User Name</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>                                       
                                        <asp:DropDownList ID="ddlUserlist" class="form-control" runat="server" SkinID="ddlSkin"
                                            Style="height: 22px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Button ID="btnsumbit" class="form-control btn-primary" runat="server" Text="Assign"
                                    ValidationGroup="ValidateALL" Width="80px" OnClick="btnsumbit_Click" AutoPostBack="True" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btncancel" class="form-control btn-primary" runat="server" Text="Cancel"
                                    Width="80px" OnClick="btncancel_Click" AutoPostBack="True" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnExport" class="form-control btn-primary" runat="server" Text="Export"
                                    Width="80px" OnClick="btnExport_Click" AutoPostBack="True" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
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
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCount" runat="server" Visible="false" BackColor="#FFCC00" Font-Bold="true" Text="Label"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:Panel ID="Panel1" runat="server" Height="313px" ScrollBars="Both" Width="900px">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdlos" runat="server" OnRowDataBound="grdlos_RowDataBound" Style="background"
                                                class="table table-striped table-bordered table-hover table-responsive" Width="910px" AllowSorting="True" OnSorting="grdlos_Sorting">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <%--<input id="chkSelectAll" type="checkbox" />--%>
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
    </div>
    <!-- Dialog start -->
    <div id="dialog-message">
    </div>
    <%--<meta http-equiv="refresh" content="180" />--%>
</asp:Content>
