<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/IncidentTracker.Master" AutoEventWireup="true" CodeBehind="IT_ReturnFromApprover.aspx.cs" Inherits="IncidentTracker.Pages.IT_ReturnFromApprover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>

    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font-family: Arial;
        }

        .modal {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 91px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 73px;
                width: 90px;
            }

        .style1 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #000000;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 41px;
        }

        .style2 {
            border: 1px solid dimgray;
            background-color: lightgrey;
            font-family: Verdana, Tahoma;
            color: #333300;
            font-size: 8pt;
            background-image: url('../Images/bgr.gif');
            height: 41px;
        }

        .style3 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #000000;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            width: 64px;
            height: 9px;
        }

        .style4 {
            border: 1px solid dimgray;
            background-color: lightgrey;
            font-family: Verdana, Tahoma;
            color: #333300;
            font-size: 8pt;
            background-image: url('../Images/bgr.gif');
            width: 135px;
            height: 9px;
        }

        .style5 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #000000;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 32px;
            width: 234px;
        }

        .style6 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #000000;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 34px;
            width: 234px;
        }

        .style7 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #000000;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 8px;
            width: 234px;
        }

        .style8 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #000000;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 17px;
            width: 234px;
        }

        .style9 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #000000;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            width: 18%;
            height: 11px;
        }

        .style10 {
            border: 1px solid dimgray;
            background-color: lightgrey;
            font-family: Verdana, Tahoma;
            color: #333300;
            font-size: 8pt;
            background-image: url('../Images/bgr.gif');
            height: 11px;
        }

        .style11 {
            border: 1px solid dimgray;
            background-color: lightgrey;
            font-family: Verdana, Tahoma;
            color: #333300;
            font-size: 8pt;
            background-image: url('../Images/bgr.gif');
            height: 28px;
            width: 151px;
        }

        .style12 {
            border: 1px solid dimgray;
            background-color: lightgrey;
            font-family: Verdana, Tahoma;
            color: #333300;
            font-size: 8pt;
            background-image: url('../Images/bgr.gif');
            height: 26px;
            width: 151px;
        }

        .style13 {
            border: 1px solid dimgray;
            background-color: lightgrey;
            font-family: Verdana, Tahoma;
            color: #333300;
            font-size: 8pt;
            background-image: url('../Images/bgr.gif');
            height: 27px;
            width: 151px;
        }

        .auto-style1 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 51px;
            width: 705px;
        }

        .auto-style2 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 27px;
            width: 268435424px;
        }

        .auto-style3 {
            width: 693px;
            height: 64px;
        }

        .auto-style4 {
            border: 1px solid #808080;
            font-size: 8pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            white-space: no-wrap;
            height: 27px;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>

    <table style="width: 1207px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">Return From Approver</span>
            </td>
        </tr>
    </table>

    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SrNo" HeaderText="SrNo" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IncidentNumber" HeaderText="IncidentNumber" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IncidentDateTime" HeaderText="IncidentDateTime" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IncidentReportedBy" HeaderText="IncidentReportedBy" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IncidentReportingUnit" HeaderText="IncidentReportingUnit" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IncidentDateTimeOfReporting" HeaderText="IncidentDateTimeOfReporting" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Severity" HeaderText="Severity" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IncidentReportedVia" HeaderText="IncidentReportedVia" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ImpactCost" HeaderText="ImpactCost" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ReviewAndClosureDate" HeaderText="ReviewAndClosureDate" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ApproverStatus" HeaderText="ApproverStatus" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ApproverRemarks" HeaderText="ApproverRemarks" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 1207px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000"
                        OnClick="btnBack_Click" BorderWidth="1px" Font-Bold="False" Width="105px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
