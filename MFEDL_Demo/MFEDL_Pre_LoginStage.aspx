<%@ Page Language="C#" MasterPageFile="~/MFEDL.Master" AutoEventWireup="true" CodeBehind="MFEDL_Pre_LoginStage.aspx.cs" Inherits="MFEDL_Demo.MFEDL_Pre_LoginStage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="manifest.json" rel="manifest" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>       
         <script src="ServiceWorker.js"></script>  

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
        function DisableDelete(e) {
            var code;
            if (!e) var e = window.event; // some browsers don't pass e, so get it from the window
            if (e.keyCode) code = e.keyCode; // some browsers use e.keyCode
            else if (e.which) code = e.which;  // others use e.which

            if (code == 8 || code == 46)
                return false;
        }
        function disallowDelete(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            alert(charCode);
            // return true;

        };

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

    <table style="width: 688px;">
        <tr>
            <td>
                <span style="font-size: 13pt; font-weight: bold;">Login Stage</span>
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
                                <HeaderTemplate>
                                    <input id="chkSelectAll" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationID" HeaderText="Application ID" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NeoCustID" HeaderText="Neo Cust ID" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="LoanAmount" HeaderText="Loan Amount" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="InQueueStatus" HeaderText="In-Queue Status" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="RequestType" HeaderText="Request Type" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="LastUpdated" HeaderText="Last Updated" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="SourceBranchCode" HeaderText="Source Branch Code" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="BranchName" HeaderText="Branch Name" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AREA" HeaderText="Area" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Region" HeaderText="Region" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Zone" HeaderText="Zone" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AMNAME" HeaderText="AMNAME" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AMMailID" HeaderText="AMMailID" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="RMName" HeaderText="RMName" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="RMMailID" HeaderText="RMMailID" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <table style="width: 688px;">
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Application Id</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtAPSID" Width="150px" runat="server" Enabled="false"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CO-Applicant Name</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtCOApplicantName" Width="150px" runat="server" Enabled="True"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Login Status</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlLoginStatus" runat="server" Width="150px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlLoginStatus_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <table style="width: 500px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Panel runat="server" ID="plDiscrepancy">
                        <%--<div id="DIV2" runat="server" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; overflow: auto; border-left: darkgray 1px solid; width: 1200px; border-bottom: darkgray 1px solid; height: 140px">--%>
                        <h4>Add Discrepancy</h4>
                        <table class="GridViewStyle">
                            <tr>
                                <td class="TableTitle" style="height: 27px" colspan="4">
                                    <asp:Label runat="server" Width="140" Font-Size="10" Height="20" Style="text-align: center;">Discrepancy</asp:Label>
                                </td>
                                <td class="TableTitle" style="height: 27px" colspan="4">
                                    <asp:DropDownList ID="ddlDiscrepancy" runat="server" AutoPostBack="true" Width="147"></asp:DropDownList>
                                </td>
                                <td class="TableTitle" style="height: 27px" colspan="2">
                                    <asp:Label ID="lblDiscrepancyRemarks" runat="server" Width="140" Font-Size="10" Height="20" Style="text-align: center;">Discrepancy Remarks</asp:Label>
                                </td>
                                <td class="TableTitle" style="height: 27px" colspan="2">
                                    <asp:TextBox ID="txtDiscrepancyRemarks" runat="server" Width="140"></asp:TextBox>
                                </td>
                                <td class="TableTitle" style="height: 27px" colspan="4">
                                    <asp:Label ID="lblFTNRStatus" runat="server" Width="140" Font-Size="10" Height="20" Style="text-align: center;" Visible="false">FTNR Status</asp:Label>
                                </td>
                                <td class="TableTitle" style="height: 27px" colspan="4">
                                    <asp:DropDownList ID="ddlFTNRStatus" runat="server" Width="147" Visible="false"></asp:DropDownList>
                                </td>
                                <td class="TableTitle" colspan="4">
                                    <asp:Button ID="btnAdddis" runat="server" BorderWidth="1px" CssClass="Button"
                                        Text="Add to Grid" ToolTip="Add selected to grid" Width="100px" AccessKey="A" OnClick="btnAdddis_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>

        <asp:Panel runat="server" ID="plLoginHold" Width="685px">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style1" colspan="4">

                        <h4>Login Hold Remark</h4>s
                        <table class="GridViewStyle">
                            <tr>
                                <td class="auto-style4" colspan="2">
                                    <asp:Label ID="lblLoginholdRemark" runat="server" Width="150px" Font-Size="10pt" Height="20px" Style="text-align: center;">Remark</asp:Label>
                                </td>
                                <td class="auto-style2" colspan="2">
                                    <asp:TextBox ID="txtLoginholdRemark" runat="server" Width="507px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </asp:Panel>


        <%--<table>
            <tr>
                <td>
                    <div id="FTNRResolved" runat="server" visible="false">
                        <asp:Label runat="server" Width="140" Font-Size="10" Height="20" Style="text-align: center;">FTNR Resolved Date</asp:Label>
                        <asp:TextBox ID="txtFTNRResolvedDate" runat="server" Width="140"></asp:TextBox>
                        <asp:Label runat="server" Width="140" Font-Size="10" Height="20" Style="text-align: center;">FTNR Resolved Remarks</asp:Label>
                        <asp:TextBox ID="txtFTNRResolvedRemarks" runat="server" Width="140"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>--%>

        <br />
        <br />

        <div id="DIV1" runat="server">
        </div>

        <%--<div id="DIV1" runat="server" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; overflow: auto; border-left: darkgray 1px solid; width: 1200px; border-bottom: darkgray 1px solid; height: 160px">
            <h4>Discripancy List</h4>
            <table id="MainTab" class="GridViewStyle">
                <tr>
                    <th class="TableGrid">
                        <input id="chkSelectAll" onclick="javascript: SelectAll();" type="checkbox" />
                    </th>
                    <th class="TableGrid">Category
                    </th>
                    <th class="TableGrid">&nbsp;SubCategory
                    </th>
                    <th class="TableGrid">Observation
                    </th>
                    <th class="TableGrid">FTNRStatus
                    </th>
                    <th class="TableGrid">Remarks
                    </th>
                </tr>
            </table>
        </div>--%>

        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="gvdis" runat="server" Width="800px" AutoGenerateColumns="false" DataKeyNames="DiscrepancyID,FTNRStatus">
                        <Columns>
                            <asp:TemplateField HeaderText="SrNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Discrepancy" HeaderText="Discrepancy" />
                            <asp:BoundField DataField="DiscrepancyRemark" HeaderText="Discrepancy Remark" />
                            <asp:BoundField DataField="FTNRStatus" HeaderText="FTNRStatus" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnEdit" Text="Edit" runat="server" OnClick="lkbtnEdit_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <br />
        <br />
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save And Continue"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSaveAndContinue_Click" />&nbsp;
                    <asp:Button ID="btnSaveAndExit" runat="server" Text="Save And Exit" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnSaveAndExit_Click" />&nbsp;
                   <asp:Button ID="btngotoTVR" runat="server" Text="Go To TVR" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btngotoTVR_Click" />&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnBack_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:HiddenField ID="hdnDataDetails" runat="server" />
    <asp:HiddenField ID="hfDiscrepancyText" runat="server" />

    <asp:HiddenField ID="hfR_edit" runat="server" />
    <asp:HiddenField ID="hdfloginstatu" runat="server" />

    <asp:HiddenField ID="hdgvIDs" runat="server" />

</asp:Content>

