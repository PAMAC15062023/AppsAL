<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Pages/HeroHousing/sample.master"  CodeFile="CAM.aspx.cs" Inherits="Pages_HeroHousing_CAM" %>

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
        .table-responsive
        {
            font-size: 15px;
        }
        .showname
        {
            font-size: 15px;
            color: Maroon;
        }
        .testCssStyle
        {
            font-weight: bold;
            color: #1f5ca9;
            background-color: #c5d4e6;
            table-layout: auto;
            border-collapse: separate;
            border-right: gray thin solid;
            border-top: gray thin solid;
            border-left: gray thin solid;
            border-bottom: gray thin solid;
        }
        .Hide
        {
            display: none;
        }
    </style>
    <script language="Javascript" type="text/javascript">
        $("input[id*='txtProduct']").bind('paste', function (e) {
            $(this).attr("maxlength", "1000")
        });
        $("input[id*='txtProduct']").on("input", function () {
            $(this).attr("maxlength", "0")
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
                    <legend class="showname">CAM</legend>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <fieldset>
                                        <div class="form-group">
                                            <asp:GridView ID="grddata" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-responsive"
                                                CaptionAlign="Top">
                                                <Columns>
                                                    <asp:BoundField DataField="Loan_App_No" HeaderText="Loan_App_No" />
                                                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                    <asp:BoundField DataField="Customer_Customer_Name" HeaderText="Customer_Customer_Name" />
                                                    <asp:BoundField DataField="Sub_Stage_Start_Time" HeaderText="Sub_Stage_Start_Time" />
                                                    <asp:BoundField DataField="Segment" HeaderText="Segment" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="row">
                                            <div class="hidWrapper">
                                                <div class="col-md-4">
                                                    <asp:HiddenField ID="hdncaseno" runat="server" />
                                                    <asp:HiddenField ID="HdnWIPStatus" runat="server" />
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
                                            AutoGenerateColumns="False" OnRowDataBound="grdlos_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:linkbutton ID="lnkWIP" runat="server" OnClick="lnkWIP_Click" AutoPostBack="true"
                                                            Font-Bold="True">Start</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Case_Type" HeaderText="Case_Type" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="#b26a00" />
                                                <asp:BoundField DataField="wipstatus" HeaderText="Status" />
                                                <asp:BoundField DataField="Loan_App_No" HeaderText="Loan_App_No" />
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                            <%--<asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="Approved">Complete</asp:ListItem>
                                                            <asp:ListItem Value="Hold">Hold-System Issue</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Add Discripancy">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtdiscripancy" runat="server" onkeyup="UpperLetter(this);" Height="30px"
                                                            SkinID="txtSkin" TextMode="MultiLine" Visible="false"></asp:TextBox>
                                                        <asp:Button ID="btnAddDiscripancy" runat="server" OnClick="btnAddDiscripancy_Click"
                                                            AutoPostBack="true" BorderWidth="1px" Text="Add" Visible="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remark">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtremark" runat="server" Height="30px"  onkeyup="UpperLetter(this);"  SkinID="txtSkin" TextMode="MultiLine"
                                                            Width="217px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkCompleteNext" runat="server" OnClick="lnkCompleteNext_Click" AutoPostBack="true" Font-Bold="True" Visible="false">Complete & New</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkCompleteExit" runat="server" OnClick="lnkCompleteExit_Click" AutoPostBack="true" Font-Bold="True" Visible="false">Complete & Exit</asp:LinkButton>
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
                                CaptionAlign="Top" Caption='<table border="1" width="100%" class="TestCssStyle" cellpadding="0" cellspacing="0" bgcolor="yellow";><tr><td>Discripancy</td></tr></table>'
                                runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <%--<HeaderTemplate>
                                            <input id="chkSelectAll" type="checkbox" />
                                        </HeaderTemplate>--%>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkresolve" runat="server" OnClick="lnkresolve_click1" AutoPostBack="true" Font-Bold="true" Width="40px">resolve</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="Dis_Id" HeaderText="ID" />--%>
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="Appno" HeaderText="Appno" />
                                    <%--<asp:BoundField DataField="Sub_Stage_Start_Time" HeaderText="Sub_Stage_Start_Time" />--%>
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
    <!-- Dialog start -->
    <div id="dialog-message">
    </div>
</asp:Content>
