<%@ Page Language="C#" MasterPageFile="~/Pages/HeroHousing/sample.master" AutoEventWireup="true"
    CodeFile="Case_Reversal.aspx.cs" Inherits="Pages_HeroHousing_Case_Reversal" %>

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
    </style>
    <script type="text/javascript" language="javascript">
        function UpperLetter(ID) {
            //            debugger
            ID.value = ID.value.toUpperCase();
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

    </script>
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
                    <legend>Case Reversal</legend>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Location</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddllocation" class="form-control" runat="server" SkinID="ddlSkin"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged">
                                            <%--<asp:ListItem Value="1">Mumbai</asp:ListItem>
                                            <asp:ListItem Value="3">Delhi</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Case Reverse Stage</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRoll" class="form-control" runat="server" SkinID="ddlSkin"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlRoll_SelectedIndexChanged">
                                            <%--<asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                                            <%--<asp:ListItem Value="1">Data Entry</asp:ListItem>
                                            <asp:ListItem Value="2">CAM</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                                    Application No.</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtremark" class="form-control" autocomplete="off" runat="server" Height="30px" onkeyup="UpperLetter(this);"
                                            SkinID="txtSkin" Width="217px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    User Name</label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlUserlist" class="form-control" runat="server" SkinID="ddlSkin"
                                            AutoPostBack="True">
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
                                <asp:Button ID="btnSearch" class="form-control btn-primary" runat="server" Text="Search"
                                    ValidationGroup="ValidateALL" Width="126px" AutoPostBack="True" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:Button ID="btnsumbit" class="form-control btn-primary" runat="server" Text="Assign"
                                    ValidationGroup="ValidateALL" Width="126px" AutoPostBack="True" OnClick="btnsumbit_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
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
                                            <asp:GridView ID="grdlos" runat="server" Style="background" class="table table-striped table-bordered table-hover table-responsive"
                                                Width="910px">
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
    <meta http-equiv="refresh" content="180" />
</asp:Content>
