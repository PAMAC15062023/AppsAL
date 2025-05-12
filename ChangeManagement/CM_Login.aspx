<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CM_Login.aspx.cs" Inherits="ChangeManagement.CM_Login" %>

<%--<html lang="en">
    <head runat="server">
        <title> Login </title>
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
        <h2 style="text-align:center"> Login </h2>
        <form id="form1" runat="server">
            <div class="imgcontainer">
                <img src="logo.gif" alt="login" /> <%--class="login" >--
            </div>

            <div class="container">
                <div align="center" style="margin-left:0px; margin-right:150px; color:white;"> 
                    <asp:Label ID="lblUserId" runat="server" Text="User ID"></asp:Label>
                </div>

                <div align="center">
                    <asp:Textbox ID="txtUserName"  runat="server" Text="" BorderWidth="1px" Font-Bold="false" Height="5px" Width="200px" BorderColor="Black"  ></asp:Textbox> 
                </div>

                <div align="center" style="margin-left:0px; margin-right:110px; color:white;"> 
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; 
                </div>

                <div align="center">
                    <asp:textbox ID="txtPassword" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Height="5px" Width="200px" BorderColor="Black" TextMode="Password"></asp:textbox>  
                </div>
                
                 <div align="center" style="margin-left:40px;margin-right: 0px;color:white;"> 
                    <asp:Image ID="imgCaptcha"  width="200px" Height="60px"  runat="server" CssClass="captcha-image" BorderWidth="1px" BorderColor="Black" ImageUrl="CM_GenerateCaptcha.aspx"/>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="refresh_icon.jpg" />
            
                 </div>
                    <div  align="center">&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Please Enter above Captcha" ForeColor="White"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; 
                </div>
                
                <div align="center"> 
                    <asp:textbox ID="txtCaptcha" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Height="5px" Width="200px" BorderColor="Black" TextMode="Password"></asp:textbox>  
                   
                </div>

                <br/>

                <div class="large-12 columns" align="center" style="margin-left:20px">
                    <asp:Button ID="btnLogin" class="button" runat="server" BorderWidth="1px" Font-Bold="False" Text="Login"  Height="30px" Width="100px" OnClick="btnLogin_Click" BackColor="#07D5BF" Forecolor="white"  /> &nbsp;&nbsp;
                    <asp:LinkButton ID="lkbtnforgotPassword" runat="server" CausesValidation="false" OnClick="lkbtnforgotPassword_Click" ForeColor="Red">Forgot Password</asp:LinkButton>
                </div>

                <div class="large-12 columns" align="center" style="margin-left:20px">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Height="16px" Visible="False" Width="100%" Font-Bold="True"></asp:Label>
                </div>
            </div>
              <div style="text-align:center;background-color: gainsboro; border-top: #990000 1px solid;">
                <asp:Label ID="lblBottom" runat="server"  Font-Size="15px" ForeColor="#990000">Developed by PAMAC IT Software Dept.</asp:Label>
            </div>
        </form>
    </body>
</html>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Change Management</title>
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <link href="Content/CSS/CustomeStyle.css" rel="stylesheet" type="text/css" />
        <!-- Tell the browser to be responsive to screen width -->
        <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
        <!-- Bootstrap 3.3.7 -->
        <link rel="stylesheet" href="Content/bower_components/bootstrap/dist/css/bootstrap.min.css"/>
        <!-- Font Awesome -->
        <link rel="stylesheet" href="Content/bower_components/font-awesome/css/font-awesome.min.css"/>
        <!-- Ionicons -->
        <link rel="stylesheet" href="Content/bower_components/Ionicons/css/ionicons.min.css"/>
        <!-- Theme style -->
        <link rel="stylesheet" href="Content/dist/css/AdminLTE.min.css"/>
        <!-- iCheck -->
        <link rel="stylesheet" href="Content/plugins/iCheck/square/blue.css"/>
        <!-- Google Font -->
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
        <style> /*add content 24/06/2024*/
            .captcha-image 
            {
            border: 1px solid #ccc; /* Example border style: 1px solid gray */
            padding: 5px; /* Optional: Add padding around the image */
            }
            .captcha-icon
            {
                /*background: url(captcha.png) no-repeat;
                padding-left: 18px;
                border:1px solid #ccc;*/
            }
        </style>
    </head>

    <body class="hold-transition login-page">
        <div class="login-box">
            <div class="login-logo"><b><i> Change Management </i></b> </div>
            <div class="login-box-body">
                <p class="login-box-msg"><b>Sign in to start your Session</b></p>
                <form runat="server" method="post">
                    <div class="form-group has-feedback">
                        <div runat="server" id="divInvalidLoginNameError">
                            <asp:Label ID="lblUserName" runat="server" Visible="false"><i class="fa fa-times-circle-o">Invalid User Name !</i></asp:Label>
                            <asp:TextBox ID="txtUserName" runat="server" Text="" class="form-control" placeholder="User Name" ClientIDMode="Static" autocomplete="off" ></asp:TextBox> <%--style="margin-left: 3px" Width="134px"--%>
                            <asp:RequiredFieldValidator ID="UserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserName" Text="Enter User Name" CssClass="Required"></asp:RequiredFieldValidator>
                            <span class="glyphicon glyphicon-user form-control-feedback"></span>
                        </div>
                    </div>
                    <div class="form-group has-feedback">
                        <div runat="server" id="divInvalidPasswordError">
                            <asp:Label ID="lblInvalidPassword" runat="server" Visible="false"><i class="fa fa-times-circle-o">Invalid Password !</i></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server"  class="form-control" placeholder="Password"
                                TextMode="Password" ClientIDMode="Static" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Password" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" Text="Enter Password" CssClass="Required"></asp:RequiredFieldValidator>
                            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                            
                        </div>
                    </div>
                    <%--<div align="center" style="margin-left:40px;margin-right: 0px;color:white;"> 
                    <asp:Image ID="imgCaptcha"  width="200px" Height="60px"  runat="server" CssClass="captcha-image" BorderWidth="1px" BorderColor="Black" ImageUrl="CM_GenerateCaptcha.aspx"/>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="refresh_icon.jpg" />
            
                 </div>
                    <div  align="center">&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Please Enter above Captcha" ForeColor="White"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; 
                </div>--%>
                   <div class="form-group has-feedback"> 
                        <asp:Image ID="imgCaptcha"  width="90px" Height="35px"  runat="server" CssClass="captcha-image" ImageUrl="CM_GenerateCaptcha.aspx"/>
                       <%-- <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>--%>
                        <asp:TextBox ID="txtCaptcha" runat="server" class="form-control"  placeholder="Captcha" ClientIDMode="Static"></asp:TextBox>
                      <span class="glyphicon glyphicon-captcha form-control-feedback"></span>
                          <span style="position: absolute; right: 10px; top: 70%; transform: translateY(-50%);">
                             <img src="captcha.png" alt="CAPTCHA Icon" style="height: 20px; width: auto;"/>
                        </span> 
                    </div>
                    <%--<div class="form-group has-feedback">
                        <div runat="server" id="div1">
                            <asp:Label ID="lblBranch" runat="server" Visible="false"><i class="fa fa-times-circle-o">Select Branch!</i></asp:Label>
                            <asp:DropDownList ID="ddlBranch" runat="server"  class="form-control" placeholder="Branch" 
                                ClientIDMode="Static" ></asp:DropDownList>
                        </div>
                    </div>--%>
                    <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
                    <div class="row">
                        <div class="col-xs-4">
                            <asp:Button ID="btnLogin" runat="server" Text="Sign In" class="btn btn-primary btn-block btn-flat" OnClick="btnLogin_Click" ></asp:Button> <%--OnClick="btnLogin_Click" /--%>
                          </div>
                        <div class="col-xs-4">
                            <asp:LinkButton ID="lkbtnforgotPassword" runat="server"  OnClick="lkbtnforgotPassword_Click" CausesValidation="false" ForeColor="Red" >Forgot Password</asp:LinkButton>
                        </div>
                   </div>
                </form>
            </div>
        </div>
        <!-- /.login-box -->
        <!-- jQuery 3 -->
        <script src="../Content/bower_components/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap 3.3.7 -->
        <script src="../Content/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
         <!-- iCheck -->
        <script src="../Content/plugins/iCheck/icheck.min.js"></script>
        <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });
        </script>
    </body>
</html>