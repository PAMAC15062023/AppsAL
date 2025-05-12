<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MFEDL_MenuPage.aspx.cs" Inherits="MFEDL_Demo.MFEDL_MenuPage" %>

<!DOCTYPE html>

<%--<html>
<head runat="server">
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
</head>
<body>
    <form id="form1" runat="server">

       <div class="row" style="border:2px solid white">
   
           <div class="row">
   <div class="large-12 columns">
      <asp:Label ID="lblUserName" runat="server" Font-Bold="True"></asp:Label>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
 
       <asp:LinkButton ID="lnkChangePassword" runat="server" Font-Bold="True" ToolTip="Change Password" 
           OnClick="lnkChangePassword_Click">Change Password</asp:LinkButton> 
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
        <asp:LinkButton ID="lnkLogOut" runat="server" Font-Bold="True" ToolTip="Log out" 
            OnClick="lnkLogOut_Click">Log out</asp:LinkButton>
   </div>
       <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>  
 
   </div>
 <br /><br />
   <div class="row">
 <div class="large-12 columns text-center">
      <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" font-size="Large" CssClass="column large-centered"></asp:Label>
   </div>
   </div>
             <br /><br />
     <div class="row">
      <div class="large-12 columns text-center">
  <asp:Label ID="Menu" runat="server" Font-Bold="True" font-size="Large"   Width="202px" >Menu</asp:Label>
   </div>
          </div>
       <br /><br />
<div class="row">
      <div class="large-12 columns text-center">
            <a href="MFEDL_UploadFile.aspx">Upload file format</a>
        </div>
          </div>   
     <br /><br />

<div class="row">
      <div class="large-12 columns text-center">
            <a href="MFEDL_Pre_LoginStage.aspx">Login stage</a>
        </div>
          </div>   
     <br /><br />
           <div class="row">
      <div class="large-12 columns text-center">
            <a href="MFEDL_Pre_TVR.aspx">TVR stage</a>
        </div>
          </div>   
     <br /><br />

           <div class="row">
      <div class="large-12 columns text-center">
              <a href="MFEDL_Pre_AppFinalStatus.aspx">App Final Ops Status Master</a>
        </div>
          </div>   
     <br /><br />

           <div class="row">
      <div class="large-12 columns text-center">
               <td align="center" valign="top" style="border-top: #990000 1px solid; font-size: 8pt; color: gray; font-family: Verdana, Tahoma; border-bottom-width: 1px; border-bottom-color: #990000; background-color: gainsboro;">
                        <span style="color: firebrick; font-size: 8pt; border-bottom-width: 1px; border-bottom-color: #990000; font-family: Verdana;">Developed by PAMAC IT Software Dept.</span></td>
        </div>
          </div>   
     <br /><br />
       </form>
</body>
</html>--%>

<%--<html lang="en">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial scale=1.0" />
        <title> Muthoot Fincorp ED Loans </title>
       
        <style>
            body 
            {
                font-family: Arial, Helvetica, sans-serif;
            }

            form
            {
            background-color:lightgray;
            border: 3px solid #f1f1f1;
            }

            .container {
                padding: 16px;
                position: relative;
            }

            .bottom-container 
            {
                font-weight:bold;  
                Font-Size:21px;
                align-content:center;
                margin-left:200px;
              /*background-color: #33C4FF;*/
              color:darkred;
              border-radius: 0px 0px 4px 4px;
            }

     
        </style>
    </head>
    <body style="width:100%; height:100%; left: 0.1em; top: 0.8em;  margin:0; align-content:center;">
        <form id="form1" runat="server">
            <div class="container">
                 <div class="row">
                      <div class="large-12 columns">
                            <asp:Label ID="lblUserName" runat="server" Font-Bold="True" align="center"  ></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  

                             <asp:LinkButton ID="lnkChangePassword" runat="server" Font-Bold="True" ToolTip="Change Password" 
                               OnClick="lnkChangePassword_Click" align="center" style=" margin-left: 550px; text-decoration:none; color:Highlight;">Change Password</asp:LinkButton> 
                          

                        
                       </div>
                 </div>   
                <div class="row">
                    <div class="large-12 columns">
                        <asp:LinkButton ID="lnkLogOut" runat="server" Font-Bold="True" style="text-decoration:none; color:Highlight;" ToolTip="Log out" 
                                OnClick="lnkLogOut_Click">Log out</asp:LinkButton>
                    </div>
                </div>
                <br/><br/>
                <div class="row">
                   <div class="large-12 columns" >  <%--class="large-12 columns
                        <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Size="28px" align="center" style="margin-left: 250px"  >Muthoot Fincorp ED Loans</asp:Label>
                    </div>
                </div>
                <br/><br/>
                <div class="row">
                    <div class="large-12 columns" >
                        <asp:Label ID="lblsubtitle" runat="server" Font-Bold="True"  Font-Size="22px" align="center" Style="margin-left:350px">Menu</asp:Label>
                    </div>
                </div>
                <br/>
                <div class="row">
                    <div class="large-12 columns" >
                         <a href="MFEDL_UploadFile.aspx" style="text-align:center; margin-left: 310px; font-size:20px;  color:Highlight; text-decoration:none;">Upload file format</a>
                    </div>
                </div>
                 <br/>
                <div class="row">
                    <div class="large-12 columns" >
                        <a href="MFEDL_Pre_LoginStage.aspx" style="text-align:center; margin-left: 330px; font-size:20px;  color:Highlight; text-decoration:none;">Login stage</a>
                    </div>
                </div>
                <br/>
                <div class="row">
                    <div class="large-12 columns" >
                        <a href="MFEDL_Pre_TVR.aspx" style="text-align:center; margin-left: 330px; font-size:20px;  color:Highlight; text-decoration:none;">TVR stage</a>
                    </div>
                </div>
                <br/>
                <div class="row">
                    <div class="large-12 columns" >
                        <a href="MFEDL_Pre_AppFinalStatus.aspx" style="text-align:center; margin-left: 270px; font-size:20px;  color:Highlight; text-decoration:none;">App Final Ops Status Master</a>
                    </div>
                </div>
                <br/><br/><br/><br/>
                <div class="row">
                    <div class="bottom-container"  > 
                        <asp:Label ID="lblBottomLine" runat="server" >Developed by PAMAC IT Software Dept.</asp:Label>
                    </div>
                </div>
                <br/>
            </div>
        </form>
    </body>
</html>--%>

<%--<html lang="en">
    <head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title></title>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <style>
            body
            {
                margin:0;
                font-family:Arial, Helvetica, sans-serif;
            }

            .topnav 
            {
               
                background-color:#333;
                height: 46px;
            }

            .topnav a 
            {
                float:left;
                display:block;
                color:#f2f2f2;
                text-align:center;
                padding:14px 16px;
                text-decoration:none;
                font-size:17px;
            }

            .topnav a:hover
            {
                background-color: #ddd;
                color:black;
            }

            .topnav a.active
            {
                background-color:#5499C7; /*#04AA6D;  green color*/
                color:white;
            }

            .topnav .icon
            {
                display: none;
            }

            @media screen and (max-width:600px)
            {
                .topnav a:not(:first-child) 
                {
                    display:none;
                }
                .topnav a.icon
                {
                    float:right;
                    display:block;
                }
            }

            @media screen and (max-width:60px)
            {
                .topnav.responsive{position:relative;}
                .topnav.responsive .icon
                {
                    position:absolute;
                    right:0;
                    top:0;
                }
                .topnav.responsive a
                {
                    float:none;
                    display:block;
                    text-align:left;
                }
            }

        </style>
    </head>
    <body style="left: 0.1em; top: 0.8em; width: 100%; height:100% ;  margin:0; ">
        <form runat="server" style="background-color:#5DADE2;">

            <div><br/><br/></div>
            <div style="padding-left:20px">
                <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Font-Size="20px"></asp:Label> 
                <br/>
                <asp:LinkButton ID="lnkChangePassword" runat="server" Font-Bold="True" ToolTip="Change Password" 
                               OnClick="lnkChangePassword_Click" align="center" style=" text-decoration:none; color:darkred;">Change Password</asp:LinkButton> 
                <br/>
                <asp:LinkButton ID="lnkLogOut" runat="server" Font-Bold="True" align="center" style="text-decoration:none; color:darkred;" ToolTip="Log out" 
                    OnClick="lnkLogOut_Click">Log out</asp:LinkButton>
            </div>
            <br/><br/>

            <div style="padding-left:16px" align="center">
               <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" font-size="22px" >Muthoot Fincorp ED Loans</asp:Label> <br/><br/>
             
            </div>
            <br/><br/>

            <div class="topnav" id="myTopnav">
               
                <a href="#Menu" class="active">Menu</a>
                <a href="MFEDL_UploadFile.aspx" >Upload file format</a>
                <a href="MFEDL_Pre_LoginStage.aspx">Login stage</a>
                <a href="MFEDL_Pre_TVR.aspx" >TVR stage</a>
                 <a href="MFEDL_Pre_AppFinalStatus.aspx" >App Final Ops Status Master</a>
                <a href="javascript:void(0);" class="icon" onclick="myFunction()">
                    <i class="fa fa-bars"></i>
                </a>
            </div>
            <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
            <script>
                function myFunction() {
                    var x = document.getElementById("myTopnav");
                    if (x.className === "topnav") {
                        x.className += " responsive";
                    } else {
                        x.className = "topnav";
                    }
                }
            </script>
            

             <div style="padding-left:16px" align="center">
               <asp:Label ID="Label1" runat="server" Font-Bold="True" font-size="Large" style="font-weight:bold; color:brown;">Developed by PAMAC IT Software Dept.</asp:Label>
             </div> 
            
           
            <br/>


            
        </form>
    </body>
</html>--%>


<html>
    <head>
        <title></title>
        <meta name="viewport" content="width=device-width,initial-scale=1.0">
        <style>
           * {box-sizing: border-box}
            body {font-family: Arial, Helvetica, sans-serif;}

            form {
            background-color:#E5E7E9;
            border: 3px solid #f1f1f1;
            }

            /* Style the tab */
            .tab {
              float: left;
              border: 1px solid #ccc;
              background-color:#333; /*#5DADE2 ;*/ /*#f1f1f1;*/
              
              width: 25%; /*30%*/
              height: 300px;
             
            }

            /* Style the buttons inside the tab */
            .tab a 
            {
                display: block;
                background-color: inherit;
                color: white;
                padding: 12px 5px;
                 width: 100%;
                 border: none;
                 outline: none;
                 text-align: left;
                 cursor: pointer;
                 transition: 0.3s;
                  font-size: 17px;
                  text-decoration:none;
            }

            /* Change background color of buttons on hover */
            .tab a:hover 
            {
              background-color: #ddd;
            }

            /* Create an active/current "tab button" class */
            .tab a.active 
            {
              background-color: #ccc;
            }

            /* Style the tab content */

        </style>
    </head>
    <body runat="server">
        <form id="form1" runat="server">
         <div style="padding-left:20px" runat="server">
                <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Font-Size="20px"></asp:Label> 
                <br/>
                <asp:LinkButton ID="lnkChangePassword" runat="server" Font-Bold="True" ToolTip="Change Password" 
                               OnClick="lnkChangePassword_Click"  style=" text-decoration:none; color:darkred; ">Change Password</asp:LinkButton> 
              
                <asp:LinkButton ID="lnkLogOut" runat="server" Font-Bold="True"  style="text-decoration:none; color:darkred; text-align:right; display: inline-block; width: 95%;" ToolTip="Log out" 
                    OnClick="lnkLogOut_Click">Log out</asp:LinkButton>
         </div>
         <br/><br/>

         <div style="padding-left:16px; padding-bottom:15px; background-color:#0759D5; color:white"  align="center"  >
               <br/>
               <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" font-size="24px"  >Muthoot Fincorp ED Loans</asp:Label> <br/>
             
            </div>
            

          <div class="tab" runat="server" style="height:396px" > <%--391px--%>
           <%--   <button class="tablinks" runat="server" onclick="MFEDL_UploadFile.aspx" > Upload file format</button><br/>
               <button class="tablinks" runat="server"  onclick="MFEDL_Pre_LoginStage.aspx" > Login stage </button><br/>
               <button class="tablinks" runat="server"  onclick="MFEDL_Pre_TVR.aspx" > TVR stage </button><br/>
               <button class="tablinks" runat="server"  onclick="MFEDL_Pre_AppFinalStatus.aspx" >App Final Ops Status Master </button><br/>--%>

               <%--<a href="#Menu" class="active">Menu</a><br/>--%>
                <a href="MFEDL_UploadFile.aspx" >Upload file format</a><br/>
                <a href="MFEDL_Pre_LoginStage.aspx">Login stage</a><br/>
                <a href="MFEDL_Pre_TVR.aspx" >TVR stage</a><br/>
                 <a href="MFEDL_Pre_AppFinalStatus.aspx" >App Final Ops Status Master</a><br/>
                <%--<a href="javascript:void(0);" class="icon" onclick="myFunction()">
                    <i class="fa fa-bars"></i>
                </a>--%>
          </div>  
         <%--<br/><br/> <br/><br/> <br/><br/> <br/><br/> <br/><br/> <br/><br/> <br/><br/> <br/><br/> <br/><br/> <br/><br/>--%>

      <%--  <script>
            function myFunction()
            {
                document.getElementById("defaultOpen").click();
            }
            
        </script>--%>
             <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
            <br /><br/><br/>
            
        <div style="padding-left:16px; background-color:#0759D5; padding-bottom:10px; padding-top:10px;" align="center" >
               <asp:Label ID="Label1" runat="server"  font-size="18px" style=" color:white;">Developed by PAMAC IT Software Dept.</asp:Label>
             </div>
        </form>
    </body>
</html>