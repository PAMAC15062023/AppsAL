<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/IncidentTracker.Master" AutoEventWireup="true" CodeBehind="IT_IncidentTicketsMaker.aspx.cs" Inherits="IncidentTracker.Pages.IT_IncidentTicketsMaker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script language="javascript" type="text/javascript" src="../App_Assets/js/popcalendar.js"> </script>

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


        function SetFocus(objid) {


            console.log(document.getElementById(objid).focus());

        }

        function TDate() {

            var IncidentDateTime = document.getElementById("<%=txtIncidentDateAndTime.ClientID%>").value;
            var ReportingDateTime = document.getElementById("<%=txtIncidentDateAndTimeOfReporting.ClientID%>").value;
            var StartDateTime = document.getElementById("<%=txtRootCauseAnalysisStartDateTime.ClientID%>").value;
            var EndDateTime = document.getElementById("<%=txtRootCauseAnalysisEndDateTime.ClientID%>").value;

            var date = new Date();
            var current_date = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
            var current_time = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
            var ToDate = current_date + " " + current_time;

            if (Date.parse(IncidentDateTime) > Date.parse(ToDate)) {
                document.getElementById("<%=txtIncidentDateAndTime.ClientID%>").value = '';
                alert("You Cannot Select Date Time Greater Than Current Date Time....! ");
                return false;
            }

            if (Date.parse(ReportingDateTime) > Date.parse(ToDate)) {
                document.getElementById("<%=txtIncidentDateAndTimeOfReporting.ClientID%>").value = '';
                alert("You Cannot Select Date Time Greater Than Current Date Time....! ");
                return false;
            }

            if (Date.parse(StartDateTime) > Date.parse(ToDate)) {
                document.getElementById("<%=txtRootCauseAnalysisStartDateTime.ClientID%>").value = '';
                alert("You Cannot Select Date Time Greater Than Current Date Time....! ");
                return false;
            }

            if (Date.parse(EndDateTime) > Date.parse(ToDate)) {
                document.getElementById("<%=txtRootCauseAnalysisEndDateTime.ClientID%>").value = '';
                alert("You Cannot Select Date Time Greater Than Current Date Time....! ");
                return false;
            }


            return true;
        }
    </script>

    <style>
        .TableTitle {
            font-size: 1pt;
            color: #333333;
            font-family: Verdana, Tahoma;
            background-color: #C0C0C0;
            border-right: #660000 1px solid;
            border-top: #660000 1px solid;
            border-left: #660000 1px solid;
            border-bottom: #660000 1px solid;
            white-space: no-wrap;
            border-color: #808080;
        }
    </style>

    <table style="width: 965px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">&nbsp;&nbsp;Generate&nbsp; Incidents &nbsp;Ticket</span>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblIncidentNumber" runat="server" Width="250px"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UP_ddlUserName" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table style="width: 688px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Incident Date & Time</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtIncidentDateAndTime" runat="server" TextMode="DateTimeLocal" autoClose="true"
                            onchange="TDate()" BorderWidth="1px" SkinID="txtSkin" Width="228px"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Incident Reported By</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtIncidentReportedBy" runat="server" Width="228px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Incident Reporting Unit</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlIncidentReportingUnit" AutoPostBack="true" runat="server" Width="231px"></asp:DropDownList>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="247px" Font-Size="10" Height="20" Style="text-align: center;">Incident Date & Time Of Reporting</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtIncidentDateAndTimeOfReporting" runat="server" TextMode="DateTimeLocal" autoClose="true"
                            onchange="TDate()" BorderWidth="1px" SkinID="txtSkin" Width="233px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Incident Reported  Via</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlIncidentReportedVia" runat="server" AutoPostBack="true" Width="231px">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                            <asp:ListItem Text="Phone" Value="Phone"></asp:ListItem>
                            <asp:ListItem Text="F2F" Value="F2F"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Incident Reported To</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtIncidentReportedTo" runat="server" Width="230px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Incident Reported To Unit</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlIncidentReportedToUnit" AutoPostBack="true" runat="server" Width="231px"></asp:DropDownList>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Incident Description</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtIncidentDescription" runat="server" Width="230px"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Severity</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlSeverity" runat="server" AutoPostBack="true" Width="231px">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Critical" Value="Critical"></asp:ListItem>
                            <asp:ListItem Text="High" Value="High"></asp:ListItem>
                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                            <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Users / BU impacted</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtUsersBUimpacted" runat="server" Width="230px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Impact Cost</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlImpactCost" AutoPostBack="true" runat="server" Width="231px">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <%--<asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Root Cause Analysis Date</asp:Label>--%>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <%--<asp:TextBox ID="txtRootCauseAnalysisDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="230px"
                             oncopy="return false" onpaste="return false" autocomplete="off"></asp:TextBox>
                        <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRootCauseAnalysisDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../Images/SmallCalendar.gif" style="width: 17px; height: 16px" />--%>
                    </td>
                </tr>
            </table>
            <table style="width: 688px;">
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Root Cause Analysis Start Date Time</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtRootCauseAnalysisStartDateTime" runat="server" TextMode="DateTimeLocal" autoClose="true"
                            onchange="TDate()" BorderWidth="1px" SkinID="txtSkin" Width="228px"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="247px" Font-Size="10" Height="20" Style="text-align: center;">Root Cause Analysis End Date Time</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtRootCauseAnalysisEndDateTime" runat="server" TextMode="DateTimeLocal" autoClose="true"
                            onchange="TDate()" BorderWidth="1px" SkinID="txtSkin" Width="234px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 688px;">
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Root/Reason For Incident</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtRootReasonForIncident" runat="server" Width="222px"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="247px" Font-Size="10" Height="20" Style="text-align: center;">Remidial Action</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtRemidialAction" runat="server" Width="230px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 688px;">
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="222px" Font-Size="10" Height="20" Style="text-align: center;">Result Of Remedial Action</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtResultOfRemedialAction" runat="server" Width="222px"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="247px" Font-Size="10" Height="20" Style="text-align: center;">Long Term Solution</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtLongTermSolution" runat="server" Width="230px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table style="width: 965px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" OnClick="btnBack_Click"
                        BorderWidth="1px" Font-Bold="False" Width="150px" />&nbsp;
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
