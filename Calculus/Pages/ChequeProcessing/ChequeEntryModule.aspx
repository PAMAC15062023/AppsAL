<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChequeEntryModule.aspx.cs" Inherits="Pages_ChequeProcessing_ChequeEntryModule"
    Title="Cheque Entry" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" class="TableHeader">
                &nbsp;Scan Cheque Caputure
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 215px">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" Width="800px">
                    <asp:Image ID="Image1" runat="server" Height="250px" Width="773px" /></asp:Panel>
                <a href="../../Pages/ChequeProcessing/RenderImage.aspx"></a>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="800px">
                    <table>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="TableTitle">
                                Assign Date</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtAssignDate" runat="server" Font-Size="Small" MaxLength="10" Width="113px"
                                    SkinID="txtSkin"></asp:TextBox></td>
                            <td style="width: 100px">
                                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAssignDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../SmallCalendar.gif" style="width: 19px; height: 18px" /></td>
                            <td style="width: 100px" class="TableTitle">
                                Sr No</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtIndex" runat="server" SkinID="txtSkin">0</asp:TextBox></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Button ID="btnGenerate" runat="server" Text="Show Image" OnClick="btnGenerate_Click" /></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 17px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Close" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>

</asp:Content>
