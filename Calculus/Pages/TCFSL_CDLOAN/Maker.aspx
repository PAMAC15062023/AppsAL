<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master"
    AutoEventWireup="true" CodeFile="Maker.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_Maker" %>

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
    <style type="text/css">
        .form-group label
        {
            color: black;
        }
        .showname
        {
            color: Red;
            font-weight: bold;
        }
        .table > tbody > tr > th
        {
            background: #80deea;
        }
    </style>
    <script language="Javascript" type="text/javascript">
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
    <asp:HiddenField ID="HdnWIPStatus" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Maker&nbsp; Form</legend>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <fieldset>
                                        <div class="form-group">
                                            <asp:GridView ID="grddata"  AutoGenerateColumns="False"  runat="server" CssClass="table table-striped table-bordered table-responsive"
                                                CaptionAlign="Top">
                                                <Columns>
                                                    <asp:BoundField DataField="Case Number" HeaderText="Case Number" />
                                                    <asp:BoundField DataField="Customer Name" HeaderText="Customer Name" />
                                                    <asp:BoundField DataField="Webtop Number" HeaderText="Webtop Number" />
                                                    <asp:BoundField DataField="Branch name" HeaderText="Branch name" />
                                                    <asp:BoundField DataField="Requested Loan Amount" HeaderText="Requested Loan Amount" />
                                                    <asp:BoundField DataField="Last Modified Date" HeaderText="Last Modified Date" />
                                                    <%--<asp:BoundField DataField="FinnOneApplication_Number" HeaderText="FinnOneApplication_Number" />--%>
                                                    <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="row">
                                            <div class="hidWrapper">
                                                <div class="col-md-4">
                                                    <asp:HiddenField ID="Hdnwebtop" runat="server" />
                                                    <asp:HiddenField ID="hdncaseno" runat="server" />
                                                    <asp:HiddenField ID="hdnfnno" runat="server" />
                                                    <asp:HiddenField ID="hdnDisStatus" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <div class="form-group">
                                        <asp:GridView ID="grdlos" runat="server" Style="background" class="table table-striped table-bordered table-hover table-responsive"
                                            AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                       <%-- <input id="chkSelectAll" type="checkbox" />--%>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkWIP" OnClick="lnkWIP_Click" runat="server" Font-Bold="True">Start</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="Stage_Status" HeaderText="Case Type" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="#b26a00"/>
                                                <asp:BoundField DataField="wipstatus" HeaderText="Status" />
                                                <asp:BoundField DataField="Case_Number" HeaderText="Case_Number" />
                                                <asp:BoundField DataField="FinnOneApplication_Number" HeaderText="FinnOneApplication Number" />
                                                <asp:BoundField DataField="Webtop_Id" HeaderText="Webtop_Id" />
                                                <%--    <asp:BoundField DataField="FinnOneApplication_Number" HeaderText="FinnOneApplication_Number" />--%>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Approved</asp:ListItem>
                                                            <asp:ListItem Value="Hold">Hold-System Issue</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Add Discripancy">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtdiscripancy" runat="server" onkeyup="UpperLetter(this);" Height="30px"
                                                            SkinID="txtSkin" TextMode="MultiLine" Visible="false"></asp:TextBox>
                                                        <asp:Button ID="btnAddDiscripancy" OnClick="btnAddDiscripancy_Click" runat="server"
                                                            BorderWidth="1px" Text="Add" Visible="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Remark">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtremark" runat="server" Visible="false" autocomplete="off" onkeyup="UpperLetter(this);"
                                                            Height="30px" Width="90px" SkinID="txtSkin" TextMode="SingleLine"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkComplete" runat="server" Font-Bold="True" OnClick="lnkComplete_Click">Complete</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField />
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
                                <asp:Button ID="lnkCompleteQC" Visible="false" class="form-control btn-primary" 
                                    runat="server" Text="CompleteBackQC"
                                    OnClick="lnkCompleteQC_Click" />
                            </div>
                        <div class="col-md-2">
                                <asp:Button ID="lnkCompleteNext" Visible="false" class="form-control btn-primary" runat="server" Text="CompleteNext"
                                    OnClick="lnkCompleteNext_Click" />
                            </div>
                        <div class="col-md-2">
                                <asp:Button ID="lnkCompleteExit" Visible="false"  class="form-control btn-primary" runat="server" Text="CompleteExit"
                                    OnClick="lnkCompleteExit_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btncancel" class="form-control btn-primary" runat="server" Text="Cancel"
                                    OnClick="btncancel_Click" />
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
                <div class="table-responsive">
                    <fieldset>
                        <div class="form-group">
                            <asp:GridView ID="GridDiscripancy" CssClass="table table-striped table-bordered table-responsive"
                                CaptionAlign="Top"  Caption='<table border="1" width="100%" class="TestCssStyle" cellpadding="0" cellspacing="0" bgcolor="yellow";><tr><td>Discripancy</td></tr></table>' runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%-- <input id="chkSelectAll" type="checkbox" />--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkresolve" runat="server" OnClick="lnkresolve_click1" Font-Bold="true"
                                                Width="40px">resolve</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="Case_Number" HeaderText="Case_Number" />
                                    <asp:BoundField DataField="Finno" HeaderText="FinnOne Application Number" />
                                    <asp:BoundField DataField="Discripancy" HeaderText="Discripancy Details" />
                                <asp:BoundField DataField="Dis_Id" HeaderText="ID" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="row">
                            <div class="hidWrapper">
                                <div class="col-md-4">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <div id="dialog-message">
    </div>
</asp:Content>
