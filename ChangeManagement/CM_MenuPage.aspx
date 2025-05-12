<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="CM_MenuPage.aspx.cs" Inherits="ChangeManagement.CM_MenuPage" %> <%--MasterPageFile="~/ChangeManagement.master"--%>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="Calender.gif"
        Height="32px" Width="47px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 9%">
            <tr>
                <td style="width: 100px; height: 20px; text-align: center">
                    <asp:Label ID="lblMonth" runat="server" Font-Bold="True" ForeColor="White" Text="Sep"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center">
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True" Text="17"></asp:Label></td>
            </tr>
            
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table style="font-size: 8pt; color: gray; font-family: Verdana; text-align: left">
        <tbody>
            <tr>
                <td style="text-align: left; width: 130px;">&nbsp; &nbsp;&nbsp;
                </td>
                <td style="text-align: left"></td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle" style="text-align: left; width: 130px;">&nbsp;
                    User</td>
                <td class="TableGrid" style="text-align: left">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
        </tbody>
    </table>
    &nbsp;
    <marquee><SPAN>&nbsp;<asp:Label id="Label1" runat="server" ForeColor="Gray" Font-Size="7pt" Font-Names="Verdana" Text="[Please Select Your Desire Operation From Menu]"></asp:Label></SPAN></marquee>
    <br />
</asp:Content>--%>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="Calender.gif"
        Height="32px" Width="47px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 9%">
            <tr>
                <td style="width: 100px; height: 20px; text-align: center">
                    <asp:Label ID="lblMonth" runat="server" Font-Bold="True" ForeColor="White" Text="Sep"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center">
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True" Text="17"></asp:Label></td>
            </tr>
            
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table style="font-size: 8pt; color: gray; font-family: Verdana; text-align: left">
        <tbody>
            <tr>
                <td style="text-align: left; width: 130px;">&nbsp; &nbsp;&nbsp;
                </td>
                <td style="text-align: left"></td>
            </tr>
            <tr>
                <td class="GridViewPagerStyle" style="text-align: left; width: 130px;">&nbsp;
                    User</td>
                <td class="TableGrid" style="text-align: left">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr style="color: #808080">
                <td class="GridViewPagerStyle" style="text-align: left; width: 130px;">&nbsp;
                    Branch</td>
                <td class="TableGrid" style="text-align: left">
                    <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
          
        </tbody>
    </table>
    &nbsp;
    <marquee><SPAN>&nbsp;<asp:Label id="Label1" runat="server" ForeColor="Gray" Font-Size="7pt" Font-Names="Verdana" Text="[Please Select Your Desire Operation From Menu]"></asp:Label></SPAN></marquee>
    <br />
</asp:Content>--%> <%--//comment on 23/10/2024--%>

<!DOCTYPE html>

<html>
<head runat="server">
    <link rel="shortcut icon" href="../favicon.ico" />
    <link rel="icon" type="image/gif" href="../animated_favicon1.gif" />
    <title>Internal Audit Application</title>
    <link href="App_Assets/css/StyleSheet.css" rel="stylesheet" />


    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        .navbar {
            overflow: hidden;
            background-color: gainsboro;
            border: 1px solid;
        }

            .navbar a {
                float: left;
                font-size: 16px;
                color: black;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

        .dropdown {
            float: left;
            overflow: hidden;
        }

            .dropdown .dropbtn {
                font-size: 15px;
                border: none;
                outline: none;
                color: black;
                /*padding: 14px 16px;*/
                background-color: inherit;
                font-family: inherit;
                margin: 0;
            }

            .navbar a:hover, .dropdown:hover .dropbtn {
                background-color: #0089ff;
            }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            /*min-width: 160px;*/
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

            .dropdown-content a {
                float: none;
                color: black;
                padding: 1px 19px;
                text-decoration: none;
                display: block;
                text-align: left;
                border: 1px solid;
                font-size: small;
            }

                .dropdown-content a:hover {
                    background-color: #ddd;
                }

        .dropdown:hover .dropdown-content {
            display: block;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="font-size: 8pt; width: 867px; font-family: Verdana, Tahoma; border-bottom-width: thin; border-bottom-color: #990033; height: 500px;">
                <tr>
                    <td align="left" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="1300px">
                        <td colspan="5" style="font-weight: bold; font-size: 20pt; color: blue; font-family: Verdana, Tahoma; background-color: gainsboro; border-top: gold thin solid;">&nbsp; &nbsp;&nbsp;&nbsp;<span><asp:Image ID="Image1" runat="server" ImageUrl="Calc.jpg" /></span>
                            <asp:Label ID="lblWelcome" runat="server" Font-Bold="True"> Change Management </asp:Label>
                        </td>

                    <tr>
                        <td>
                            <table cellspacing="0" border="0" cellpadding="2" width="100%">
                                <tr>
                                    <td style="height: 17px">
                                        <asp:Label ID="lblUserName" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="right" style="height: 17px">&nbsp;&nbsp;<asp:LinkButton
                                        ID="lnkChangePassword" runat="server" Font-Bold="True" ToolTip="Change Password" OnClick="lnkChangePassword_Click">Change Password</asp:LinkButton>
                                        &nbsp;&nbsp;
                                        &nbsp;&nbsp;<asp:LinkButton
                                            ID="lnkLogOut" runat="server" Font-Bold="True" ToolTip="Log out" OnClick="lnkLogOut_Click">Log out</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </td>
                    </tr>
            </table>

            <div class="navbar">
                <div class="dropdown">
                    <button class="dropbtn">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Menu 
      <i class="fa fa-caret-down"></i>
                    </button>
                    <div class="dropdown-content">
                        <table>
                            <tr id="CR_Initiation" runat="server" visible="false">
                                <td>
                                    <a href="CM_CR-Initiation.aspx">CR Initiation</a>
                                   <%-- <a href="CM_CR-Initiation_MIS_Report.aspx">CR Initiation MIS Report</a>--%>
                                    <a href="CM_MIS_Report.aspx">MIS Report</a>
                                </td>
                            </tr>
                            <tr id="VH_Approval" runat="server" visible="false">
                                <td>
                                     <a href="CM_VH_Approval.aspx">VH Approval</a>
                                     <%--<a href="CM_VH_MIS_Report.aspx">VH MIS Report</a>--%>
                                    <a href="CM_MIS_Report.aspx">MIS Report</a>
                                </td>
                            </tr>
                            <tr id="Reviewer" runat="server" visible="false">
                                <td>
                                    <a href="CM_Reviewer_Approval.aspx">Reviewer Approval</a>
                                    <%--<a href="CMˍReviewer_MIS_Report.aspx">Reviewer MIS Report</a>--%>
                                    <a href="CM_MIS_Report.aspx">MIS Report</a>
                                 </td>   
                            </tr>
                            <tr id="DevelopmentActivities" runat="server" visible="false">
                                <td>
                                    <a href="CM_Development_Activities.aspx">Development Activities</a>
                                    <%--<a href="CM_Development_MIS_Report.aspx">Development MIS Report</a>--%>
                                    <a href="CM_MIS_Report.aspx">MIS Report</a>
                                 </td>   
                            </tr>
                            <tr id="ProductManager" runat="server" visible="false">
                                <td>
                                    <a href="CM_PM_Approval.aspx">Product Manager Approval</a>
                                    <a href="CM_MIS_Report.aspx">MIS Report</a>
                                </td>   
                            </tr>
                            <tr id="Supervisor" runat="server" visible="false"> <%--add on 25/11/2024--%>
                                <td>
                                    <a href="CM_UserMaster.aspx">User Master</a>
                                    <a href="CM_MIS_Report.aspx">MIS Report</a>
                                </td>   
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <table style="width: 863px">
                <tr>
                    <td align="left" style="text-align: right" valign="top">
                        <asp:Label ID="lblMasterFileInfo" runat="server" Font-Bold="False" ForeColor="Maroon"></asp:Label></td>
                </tr>

                <tr>
                    <td align="left" valign="top" class="dropbtn">
                        <%--<asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">--%>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <%--</asp:ContentPlaceHolder>--%>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" style="border-top: #990000 1px solid; font-size: 8pt; color: gray; font-family: Verdana, Tahoma; border-bottom-width: 1px; border-bottom-color: #990000; background-color: gainsboro;">
                        <span style="color: firebrick; font-size: 8pt; border-bottom-width: 1px; border-bottom-color: #990000; font-family: Verdana;">Developed by PAMAC IT Software Dept.</span></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>