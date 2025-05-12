<%@ Page Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master" AutoEventWireup="true"
    CodeFile="Role_Master.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_Role_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

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
    <script type="text/javascript" language="javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

    </script>
    <style type="text/css">
        .form-group label {
            color: black;
        }

        .showname {
            color: Red;
            font-weight: bold;
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
    <script type="text/javascript">
        $.material.init();
    </script>
    <asp:HiddenField ID="hiddenResult" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Role Master</legend>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <div class="form-group">
                                        <asp:GridView ID="grdrole" runat="server" Style="background" class="table table-striped table-bordered table-hover table-responsive"
                                            AutoGenerateColumns="False" Width="780px" OnRowDataBound="grdrole_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <%--<input id="chkSelectAll" type="checkbox" />--%>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="UserID" HeaderText="Employee Code" />
                                                <asp:BoundField DataField="username" HeaderText="Employee Name" />
                                                <asp:BoundField DataField="DefaultRole" HeaderText="Default Role" />
                                                <asp:BoundField DataField="Role" HeaderText="Assigned Role" />
                                                <asp:TemplateField HeaderText="Change Role">
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UP_ddlrole" runat="server">
                                                            <ContentTemplate>
                                                        <asp:DropDownList ID="ddlrole" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlrole_SelectedIndexChanged">
                                                            <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Text="SFDC Screening" Value="tcfscreen"></asp:ListItem>
                                                            <asp:ListItem Text="Maker" Value="tcfmaker"></asp:ListItem>
                                                            <asp:ListItem Text="Author" Value="tcfauthor"></asp:ListItem>
                                                            <asp:ListItem Text="QC Team" Value="tcfReassignQC"></asp:ListItem>
                                                            <asp:ListItem Text="Indus D1 PL" Value="Indus_D1"></asp:ListItem>
                                                            <asp:ListItem Text="Indus D2 PL" Value="Indus_D2"></asp:ListItem>
                                                            <asp:ListItem Text="Indus QC PL" Value="Indus_QC"></asp:ListItem>
                                                            <asp:ListItem Text="Indus Transcription PL" Value="Indus_Transcript"></asp:ListItem>
                                                            <asp:ListItem Text="Indus D1 Credit" Value="IndusCredit_D1"></asp:ListItem>
                                                            <asp:ListItem Text="Indus D2 Credit" Value="IndusCredit_D2"></asp:ListItem>
                                                            <asp:ListItem Text="Indus QC Credit" Value="IndusCrdit_QC"></asp:ListItem>
                                                            <asp:ListItem Text="Indus Transcription Credit" Value="IndusCredi_Transcript"></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                                </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlrole" EventName="SelectedIndexChanged" />
                                                            </Triggers>
                                                            </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Button ID="BtnCancel" class="form-control btn-primary" runat="server" Text="Cancel"
                                    OnClick="BtnCancel_Click" />
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
