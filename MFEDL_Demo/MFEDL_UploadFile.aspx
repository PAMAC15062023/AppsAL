<%@ Page Language="C#" MasterPageFile="~/MFEDL.Master" AutoEventWireup="true" CodeBehind="MFEDL_UploadFile.aspx.cs" Inherits="MFEDL_Demo.MFEDL_UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<!DOCTYPE html>--%>

    <%--<head runat="server">--%>

    <link rel="shortcut icon" href="../favicon.ico" />
    <link rel="icon" type="image/gif" href="../animated_favicon1.gif" />
    <link href="manifest.json" rel="manifest" />
    <title>Muthoot Fincorp ED Loans</title>
    <link href="App_Assets/css/StyleSheet.css" rel="stylesheet" />
    <script src="ServiceWorker.js"></script>  


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
     <script src="Foundation/js/foundation.min.js" type="text/javascript"></script>  
    <link href="Foundation/css/foundation.min.css" rel="stylesheet" type="text/css" />  
<%--</head>--%>

<body>
    <%--<form id="form1" runat="server">--%>

  <div class="row">
      <div class="large-12 columns text-center">
  <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
   </div>
    </div>
 <div class="row">
      <div class="large-12 columns">
  <asp:Label ID="lblselect" runat="server" >Select File</asp:Label>
   </div>
    </div>
    <br />
 <div class="row">
      <div class="large-12 columns text-center">
  <asp:FileUpload ID="xslFileUpload" runat="server" />
   </div>
    </div>
       <br />   <br />   <br />   <br />

     <%--</form>--%>
</body>
</html>
    </asp:Content>
