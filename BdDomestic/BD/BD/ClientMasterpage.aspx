<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BD/BD/BDMasterPage.master" CodeFile="ClientMasterpage.aspx.cs" Inherits="BD_BD_ClientMasterpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<head>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 171px;
        }

        .auto-style3 {
            width: 304px;
        }

        .auto-style4 {
            width: 116px;
        }
    </style>
</head>


 <fieldset><legend class="legend"></legend>
 <table class="auto-style1">
        <tr>
            <td class="auto-style2">Client Code :</td>
            <td class="auto-style3">
                <asp:TextBox id="textclientcode" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">Client Name :</td>
            <td>
                <asp:TextBox id="textclientname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" ,align="center"></td>
            <td>
                
                    <asp:Button ID="btnInsert" type="submit" runat="server" Text="Save"
                            OnClick="btnInsert_Click"  />

        <asp:Label ID="labelerror" runat="server" Text="" Visible="false"></asp:Label>
                <%--<asp:Button id="btnInsert" Text="Save"  runat="server" OnClick="btnInsert" Width="96px"/>--%></td>
        </tr>
    </table></fieldset>
    </asp:Content>