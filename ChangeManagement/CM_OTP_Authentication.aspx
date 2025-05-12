<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CM_OTP_Authentication.aspx.cs" Inherits="ChangeManagement.CM_OTP_Authentication" %>

<!DOCTYPE html>

<html lang="en"> <%--xmlns="http://www.w3.org/1999/xhtml">--%>
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial scale=1.0" />
        
        <style>
            body
            {
                font-family:Arial, Helvetica, sans-serif;
                background-color:lightgray;
            }
            form
            {
                background-color:#0494AA;
                border: 3px solid #f1f1f1;
            }
            input[type=text], input[type=password], input[type=week]
            {
                width:100%;
                padding:12px 20px;
                margin: 8px 0;
                display:inline-block;
                border: 1px solid #ccc;
                box-sizing:border-box;
            }
            button
            {
                /*background-color:#04AA6D;*/
                color:white;
                padding:14px 20px;
                margin: 8px 0;
                border:none;
                cursor: pointer;
                width: 100%;
            }
            button:hover
            {
                opacity:0.8;
            }
            .cancelbtn 
            {
              width: auto;
              padding: 10px 18px;
              background-color: #f44336;
            }
            .imgcontainer
            {
              text-align: center;
              margin: 24px 0 12px 0;
            
            }
            img.login
            {
              width: /*25%;*/  20%;
              border-radius: 50%;  
            }
            .container 
            {
              padding:16px; 
              position:relative;
               
            }
            span.psw 
            {
              float: right;
              padding-top: 16px;
            }

            /* Change styles for span and cancel button on extra small screens */
            @media screen and (max-width: 300px) 
            {
              span.psw {
                 display: block;
                 float: none;
              }
              .cancelbtn {
                 width: 100%;
              }
            }
        </style>
</head>
<body style="left:0.1em; top:0.8em; width:100%; height:100%; margin:0;">
        <h2 style="text-align:center"> Authentication</h2>
        <form id="form1" runat="server">
            <div class="imgcontainer">
                <img src="logo.gif" alt="login" /> <%--class="login" >--%>
            </div>

            <div class="container">
                <div align="center" style="margin-left:0px; margin-right:120px; color:white;"> 
                    <asp:Label ID="lblOTP" runat="server" Text="Enter OTP"></asp:Label>
                </div>

                <div align="center">
                    <asp:Textbox ID="txtOTP"  runat="server" Text="" BorderWidth="1px" Font-Bold="false" visible="false" AutoCompleteType="Disabled" Height="25px" Width="200px" BorderColor="Black"  ></asp:Textbox> 
                </div>

                <div class="large-12 columns" align="center" style="margin-left:20px">
                    <asp:Button ID="btnVerify" class="button" runat="server" BorderWidth="1px" Font-Bold="False" OnClick="btnVerify_Click" Text="Verify" visible="false" Height="30px" Width="100px" BackColor="#07D5BF" Forecolor="white"  /> &nbsp;&nbsp;
                </div>

                <div class="large-12 columns" align="center" style="margin-left:20px">
                    <asp:LinkButton ID="lnkLoginAgain" runat="server" Font-Bold="false" Visible="False" ToolTip="Login Again" OnClick="lnkLoginAgain_Click">Login Again</asp:LinkButton>
                </div><br/>

                <div class="large-12 columns" align="center" style="margin-left:20px">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Height="16px" Visible="False" Width="100%" Font-Bold="True"></asp:Label>
                </div>
            </div>
              <div style="text-align:center;background-color: gainsboro; border-top: #990000 1px solid;">
                <asp:Label ID="lblBottom" runat="server"  Font-Size="15px" ForeColor="#990000">Developed by PAMAC IT Software Dept.</asp:Label>
            </div>
            <br/>
        </form>
    </body>
</html>