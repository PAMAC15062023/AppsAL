<%@ Page Title="Untitled Page"  Language="C#" MasterPageFile="~/Pages/Hero_Housing/MasterPage.master" AutoEventWireup="true" CodeFile="DataEntry.aspx.cs" Inherits="Pages_Hero_Housing_DataEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">

        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>


         <asp:Panel ID="Panel1" runat="server" BackColor="lightblue" BorderStyle="Double" BorderColor="DarkGreen" BorderWidth= "5">

         <center><asp:Label ID="label1" runat="server" BackColor="ButtonShadow" BorderColor="Bisque" Font-Bold="true"></asp:Label>

           <asp:Timer ID="timer1" runat="server" Interval="1000"></asp:Timer>

        </center>

        </asp:Panel>

        </ContentTemplate>

        </asp:UpdatePanel>



    <table style="width: 100%">

        <tr>
            <td>
                <asp:GridView ID="grdlos" runat="server" AutoGenerateColumns="False" 
                    Height="16px" Width="750px" CssClass="mGrid" 
                    >
                    <Columns>
                        <asp:BoundField DataField="Loan_App_No" HeaderText="ApplicationNo" />
                        <asp:BoundField DataField="Application_Form_Number" 
                            HeaderText="Application From No" />
                        <asp:BoundField DataField="Product_Scheme" HeaderText="Product_Scheme" />
                        <asp:BoundField DataField="Transaction_Type" HeaderText="Transaction_Type" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                    <asp:ListItem>FTNR</asp:ListItem>
                                    <asp:ListItem>Hold</asp:ListItem>
                                   
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Height="30px" SkinID="txtSkin" 
                                    TextMode="MultiLine" Width="217px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleted" onclick="lnkCompleted_Click" runat="server" Font-Bold="True" Width="140px">Complete & New Assign</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCompleteExit" runat="server"  Font-Bold="True" 
                                    Width="140px" onclick="lnkCompleteExit_Click1">Complete & Exit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 25px">
                <asp:Button ID="btncancel" runat="server" 
                    Text="Cancel" onclick="btncancel_Click"   />
            &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

