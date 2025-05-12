<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="otp_authentication.aspx.cs" Inherits="ChangeManagement.otp_authentication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; font-family: math">Authentication</h1>
    <br />
    <div style="text-align: center">
        <div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <br />
    <br />
    <br />
    <div class="formbold-main-wrapper">
        <div class="formbold-form-step-1 active">

            <div class="formbold-input-flex">
                <div>
                    <label for="OTP" class="formbold-form-label">Enter OTP</label>
                    <asp:TextBox ID="txtOTP" runat="server" Width="181px" Height="30px" class="formbold-form-input"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnVerify" runat="server" Text="Verify" class="formbold-btn" OnClick="btnVerify_Click"/>
                </div>
            </div>
        </div>
    </div>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: math;
        }

        .formbold-main-wrapper {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 15px;
        }

        .formbold-input-flex {
            display: flex;
            gap: 20px;
            margin-bottom: 22px;
        }

            .formbold-input-flex > div {
                width: 50%;
            }

        .formbold-form-input {
            width: 100%;
            padding: 0px 17px;
            border-radius: 8px;
            border: 1px solid #DDE3EC;
            background: #FFFFFF;
            font-weight: 500;
            font-size: 16px;
            color: #536387;
            outline: none;
            resize: none;
        }

        .formbold-form-label {
            color: #07074D;
            font-weight: 500;
            font-size: 17px;
            line-height: 0px;
            display: block;
            margin-bottom: 7px;
            font-family: math;
        }

        .formbold-btn {
            display: flex;
            align-items: center;
            gap: 5px;
            font-size: 16px;
            border-radius: 20px;
            padding: 3px 70px;
            border: none;
            font-weight: 500;
            background-color: #ff5e14;
            color: white;
            cursor: pointer;
            margin-top: 7px;
        }

            .formbold-btn:hover {
                box-shadow: 0px 3px 8px rgba(0, 0, 0, 0.05);
            }

            .formbold-btn:hover {
                /* Your styles for the mouseover effect */
                /* For example, change background color */
                color: #060606;
                /* Or add a shadow */
                box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.2);
                /* Or scale the button */
                transform: scale(1.1);
            }
    </style>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
