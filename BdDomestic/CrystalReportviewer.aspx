<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile"  CodeFile="CrystalReportviewer.aspx.cs" Inherits="CrystalReportviewer"  %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PAMAC Online</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tblMain" cellpadding="0" cellspacing="0" width="100%" >
    <tr>
    <td align="right">
        <asp:Button ID="btnBack"  runat="server" SkinID="btnbackskin" OnClick="btnBack_Click"   /><br />        
    </td>
    </tr>
    <tr>
    <td align="left">
        &nbsp;<CR:CrystalReportViewer ID="crViewer" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" DisplayGroupTree="False" />
        <asp:Label ID="lblMsg" runat="server" Visible="false" SkinID="lblErrorMsg"></asp:Label>
    
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
