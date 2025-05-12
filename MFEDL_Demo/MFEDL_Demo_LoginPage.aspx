<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MFEDL_Demo_LoginPage.aspx.cs" Inherits="MFEDL_Demo.MFEDL_Demo_LoginPage" %>

<!DOCTYPE html>

<html lang="en">
<%--xmlns="http://www.w3.org/1999/xhtml"--%>
<head runat="server">

    <%--   <script src="Foundation/js/foundation.min.js" type="text/javascript"></script>  
    <link href="Foundation/css/foundation.min.css" rel="stylesheet" type="text/css" />  
    <style type="text/css">
        .auto-style1 {
            margin-left: 0em;
            margin-right: 0px;
            width: 200%;
			height: 40px;
           
            
        }
       .auto-style2 {
            margin-left: 2em;
            width:100%;
            font-size:46px;
            
        }
         /* .auto-style3 {
            margin-left: 20px;
            height :40px;
        }*/
    </style>--%>

    <!--code start by Rutu 27/11/23-->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" />
    <%--integrity="sha512-z3gLpd7yknf1YoNbCzqRKc4qyor8gaKU1qmn+CShxbuBusANI9QpRohGBreCFkKxLhei6S9CQXFEbbKuqLg0DA==" 
        crossorigin="anonymous" referrerpolicy="no-referrer" />  <%--//6.4.2----%>    <%--<link rel="stylesheet" href="./style.css"> --%>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat&display=swap" rel="stylesheet">
    <title>THIS</title>
    <%--<style>
        * {
            box-sizing:border-box;
        }

        .menu
        {
            float:left;
            width:20%;
            text-align:center;
        }

        .main 
        {
            float:left;
            width:50%;
            padding:0 20px;
            
        }

        .right 
        {
            background-color:#e5e5e5;
            float:left;
            width:20%;
            padding:15px;
            margin-top:7px;
            text-align:center;
        }

        @media only screen and (max-width:620px)
        {
             /* For mobile phones: */
               .main
              {
                width: 100%;
              }
        }
        .bullet {
            margin-left: 0px;
        }
    </style> <!--code end by Rutu 27/11/23-->--%>
    <%--<style>
        *{
            margin:0;
            padding:0;
            box-sizing:border-box;
            font-family:'Montserrat',sans-serif;
            color:#303433;
        }

        body
        {
            min-height:100vh;
            width:100%;
            display:grid;
            grid-template-columns: 1fr 1fr;
        }

        section
        {
            display:flex;
            justify-content:center;
            align-items:center;
        }

        section.side
        {
            background:url(./login_img.jfif) no-repeat;
            background-size:100% 102%;
        }

        .side img
        {
            width:50%;
            max-width:50%;
        }

        .login-container
        {
            max-width:450px;
            padding:24px;
            display:flex;
            flex-direction:column;
            align-items:center;
        }

        .title
        {
            text-transform:uppercase;
            font-size:3em;
            font-weight:bold;
            text-align:center;
            letter-spacing:1px;
        }

        .separator 
        {
            width:150px;
            height:4px;
            background-color:#843bc7;
            margin:24px;
        }

        .login-form
        {
            width:100%;
            display:flex;
            flex-direction:column;
        }

        .form-control 
        {
            width:100%;
            position:relative;
            margin-bottom:24px;
        }

        input, 
        button {
            border:none;
            outline:none;
            background-color:red;
            border-radius:30px;
            font-size:1.1em;
        }

        input
        {
            width:100%;
            background:#e6e6e6;
            color:#333;
            letter-spacing:0.5px;
            padding:14px 64px;
        }

        input ~ i
        {
            position:absolute;
            left:32px;
            top:50%;
            transform:translateY(-50%);
            color:#888;
            transition:color 0.4s;
        }

        input:focus ~ i
        {
            color: #843bc7;
        }

        button.Login
        {
            color: #fff;
            padding: 14px 64px;
            width: 32px auto;
            text-transform: uppercase;
            letter-spacing:2px;
            font-weight:bold;
            background-image: linear-gradient(to right, #8b33c5, #15a0el);
            cursor:pointer;
            transition:opacity 0.4s;
        }

        button.Login:hover
        {
            opacity:0.9;
        }

        @media (max-width:780px)
        {
            body{
                display:flex;
                justify-content:center;
                align-items:center;
            }
            .side{
                display:none;
            }
        }
    </style>--%>

    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        form {
            background-color: lightgray;
            border: 3px solid #f1f1f1;
        }



        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        button {
            background-color: #04AA6D;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
        }

            button:hover {
                opacity: 0.8;
            }

        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.login {
            width: 25%;
            border-radius: 50%;
        }

        .container {
            padding: 16px;
            position: relative;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
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

<body style="left: 0.1em; top: 0.8em; width: 100%; height: 100%; margin: 0;">

    <%-- <div class="row">   </div>
    <form id="form1" runat="server"  class="main" style="background-color:lightgray; height: 350px; "> 
    
        <div class="row"> 
           <div class="large-12 columns " style="vertical-align: middle;height:1.8em; text-transform: uppercase; font-weight: bold; text-align: center; text-indent: 3px;" ;>           
               <b style="text-decoration: underline; vertical-align: middle; "> LOGIN Page</b>
            </div>      
       </div>
       <br />

       <div class="large-12 columns"  align="left-Center" style="margin-left: 220px" >
           <asp:Label ID="lblUserName" runat="server" Text="UserName" ></asp:Label>
       </div>

       <div class="row">
           <div class="large-12 columns " align="center">
                 <asp:TextBox ID="txtUserName" runat="server" placeholder="User ID " Height="20px" Width="200px"></asp:TextBox>
            </div>
        </div>
        <br />


        <div class="large-12 columns" align="left" style="margin-left: 220px">
           <asp:Label ID="lblPassword" runat="server" Text="Password" ></asp:Label>
        </div>
   
       <div class="row">
           <div class="large-12 columns" align="center">
                 <asp:TextBox ID="txtPassword" runat="server" placeholder="Password"  Height="20px" Width="200px" TextMode="Password" ></asp:TextBox>
           </div>
       </div>
       <br/>
       <br/>

       <div class="large-12 columns" align="center">
          <asp:Button ID="btnLogin" runat="server" BorderWidth="1px" Font-Bold="False"  Text="Login" OnClick="btnLogin_Click"  Height="30px" Width="200px"  />
       </div>
       <br />

       <div class="row" align="center" style="Height:20px; Width:200px; margin-left: 225px;"> </div>

       <div align="left" style="width: 200px; margin-left: 220px">
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Height="20px" Visible="False"  Font-Bold="True" Width="400px"></asp:Label>
        </div>
    </form>--%>
    <%--<section class="side">
        <img src="./login_img" alt="">
    </section>

    <section class="main">
        <div class="login-container">
            <p class="title"> Login Page </p>
        </div>
        <div class="separator"></div>
       
 
        <form class="login-form">
            <div class="form-control"> <input type="text" placeholder="UserName" ><i class="fas fa-user"></i></div>
            <div class="form-control"> <input type="password" placeholder="Password" ><i class="fas fa-lock"></i></div>
            <button class="Login">Login</button>
        </form>
    </section>--%>

    <h2>Login Form</h2>

    <form id="form1" runat="server">
        <div class="imgcontainer">
            <img src="log_img.png" alt="login" class="login">
        </div>
        <div class="container">
            <%-- <label for="uname"><b>Username</b></label>
    <input type="text" id="UserName" runat="server" placeholder="Enter Username" name="txtUserName" required >--%>

            <div align="center" style="margin-left: 0px; margin-right: 120px">
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
            </div>

            <div align="center">

                <%-- <asp:label ID="lblUserName" runat="server" Text="UserName"></asp:label> &nbsp;&nbsp;&nbsp;--%>

                <asp:TextBox ID="txtUserName" runat="server" BorderWidth="1px" Font-Bold="False" Text="" Height="5px" Width="200px" BorderColor="Black"></asp:TextBox>

            </div>

            <div align="center" style="margin-left: 0px; margin-right: 110px">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; 
            </div>

            <%--<label for="psw"><b>Password</b></label>
     <input type="password" id="Password" runat="server" placeholder="Enter Password" name="txtPassword" required >--%>


            <div align="center">

                <%--<asp:label ID="lblPassword" runat="server" Text="Password"></asp:label> &nbsp;&nbsp;&nbsp;&nbsp; --%>

                <asp:TextBox ID="txtPassword" runat="server" BorderWidth="1px" Font-Bold="False" TextMode="Password" Text="" Height="5px" Width="200px" BorderColor="Black"></asp:TextBox>

            </div>
            <br />

            <%--    <button type="submit" onclick="btnLogin_Click">Login</button>
      <script>
          function btnLogin_Click()
        {
        alert('Button Clcked');
        }
      </script>--%>

            <div class="large-12 columns" align="center" style="margin-left: 20px">
                <asp:Button ID="btnLogin" runat="server" BorderWidth="1px" Font-Bold="False" Text="Login" OnClick="btnLogin_Click" Height="30px" Width="100px" BackColor="LightGreen" />
                &nbsp;&nbsp;
          <%-- <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Font-Bold="False"  Text="Cancel"  Height="30px" Width="100px" BackColor="Red"  /> --%>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Height="16px" Visible="False" Width="100%" Font-Bold="True"></asp:Label>
            </div>

            <%--<label>
      <input type="checkbox" checked="checked" name="remember" > Remember me   <%--style="margin-left: 600px"--
    </label>--%>
        </div>

        <%-- <div class="container" style="background-color:#f1f1f1" >
    <button type="button" class="cancelbtn" >Cancel</button>
    <span class="psw">Forgot <a href="#">password?</a></span>
  </div>--%>

        <%--   <div class="large-12 columns" align="center" style="margin-left: 40px">
           <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Font-Bold="False"  Text="Cancel"  Height="30px" Width="100px" BackColor="Red"  /> 
      </div>--%>
    </form>

</body>
</html>



<%--<div>
        </div>--%>     <%--   <table border="0" cellspacing="0" style="width: 728px">
            <tr>
                <td style="width: 214px" align="center">
                    <td style="width: 513px">&nbsp;
         <table cellpadding="0" cellspacing="0"
                        style="width: 600px; background-image: url('LoginScreen.jpg'); height: 204px; background-repeat: no-repeat;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <table cellpadding="2" cellspacing="1">
                                    <tr>
                                        <td colspan="6" style="height: 26px">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13px; height: 31px;"></td>
                                        <td style="height: 31px; width: 9px"></td>
                                        <td style="height: 31px; width: 133px"></td>
                                        <td style="height: 31px"></td>
                                        <td style="width: 14px; text-align: center; height: 31px;"></td>
                                        <td style="width: 6px; height: 31px;"></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 13px; height: 22px;">&nbsp;&nbsp;
                                        </td>
                                        <td style="width: 9px; height: 22px"></td>
                                        <td style="width: 133px; height: 22px; color: #FFFFFF;">
                                            <b style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; User ID</b>
                                        </td>
                                        <td style="height: 22px">
                                            <%--<asp:Label runat="server">User ID</asp:Label>--%>                  <%--                          <asp:TextBox ID="txtUserName" runat="server" SkinID="txtSkin"
                                                Style="margin-left: 0px" Width="104px" autofocus="true"></asp:TextBox>
                                        </td>
                                        <td style="width: 14px; text-align: center; height: 22px;">
                                            <asp:RequiredFieldValidator ID="rqUserName" runat="server"
                                                ControlToValidate="txtUserName" ToolTip="Enter User Name" Width="2px">?</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 6px; height: 22px;"></td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="width: 13px"></td>
                                        <td style="width: 9px"></td>
                                        <td style="width: 133px; color: #FFFFFF;">
                                            <b style="text-align: center">&nbsp; &nbsp; &nbsp; Password</b>
                                        </td>
                                        <td>--%>                                         <%-- <asp:Label runat="server">Password</asp:Label>--%>                        <%--                    <asp:TextBox ID="txtPassword" runat="server" SkinID="txtSkin"
                                                TextMode="Password" Width="105px"></asp:TextBox>
                                        </td>
                                        <td style="width: 14px; text-align: center;">
                                            <asp:RequiredFieldValidator ID="Rq_Password" runat="server"
                                                ControlToValidate="txtPassword" ToolTip="Enter password'" Width="15px">?</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 6px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13px; height: 32px;"></td>
                                        <td style="width: 9px; height: 32px"></td>
                                        <td style="width: 133px; height: 32px; color: #FFFFFF;">
                                            <b style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>
                                        </td>
                                        
                                    </tr>

                                    <tr>
                                        <td style="width: 13px; height: 33px;"></td>
                                        <td style="height: 33px; width: 9px; text-align: left;">&nbsp;</td>
                                        <td style="height: 33px; width: 133px; text-align: center;">
                                            <asp:Button ID="btnLogin" runat="server" BorderWidth="1px" CssClass="button"
                                                Font-Bold="False" Height="29px" Text="Login"  Width="100px"
                                               OnClick="btnLogin_Click"  />
                                        </td>
                                        <td style="height: 33px; text-align: center;">
                                            <asp:LinkButton ID="lkbtnforgotPassword" runat="server" ForeColor="Yellow"
                                                 CausesValidation="false">Forgot Password</asp:LinkButton>
                                        </td>
                                        <td style="width: 14px; height: 33px;"></td>
                                        <td style="width: 6px; height: 33px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13px; height: 25px"></td>
                                        <td style="height: 25px; width: 9px;"></td>
                                        <td colspan="4" style="height: 25px;"></td>
                                        <td style="height: 25px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">&nbsp;</td>
                                        <td style="text-align: left">&nbsp;</td>
                                        <td colspan="4" style="text-align: left">&nbsp;</td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 100px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 133px"></td>
                            <td style="height: 133px">&nbsp;
                  
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Height="16px"
                            Visible="False" Width="100%" Font-Bold="True"></asp:Label>
                    </table>--%><%--    </form>
</body>
</html>--%>

