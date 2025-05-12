<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="LocationMaster.aspx.cs" Inherits="Pages_JFS_LocationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function ClientValidate(source, arguments) {
//            alert(arguments.Value);
            if ((arguments.Value) == 0)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }

        function validate() {
            var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
            var ErrorMsg = "";
            var ReturnValue = true;

            var txtlocation = document.getElementById("<%=txtlocation.ClientID%>");

            if (txtlocation.value == '') {
                ErrorMessage = "Please enter The Location";
                ReturnType = false;
            }

            window.scrollTo(0, 0);
            lblMsgXls.innerText = ErrorMsg;
            return ReturnValue;
        }


        function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
 

    </script>
    <table style="width: 688px;">
        <%--height: 66px--%>
        <tr>
            <td style="width: 691px;">
                <table style="width: 686px; height: 113px;">
                    <tr>
                        <td class="TableHeader" style="width: 642px;">
                            &nbsp;
                        </td>
                        <td class="TableHeader" style="width: 577px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            Location Master</td>
                        <td class="TableHeader" colspan="4" style="width: 690px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 642px;">
                            &nbsp;
                        </td>
                        <td style="width: 577px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                        <td colspan="4" style="width: 690px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 642px;" class="TableTitle">
                            PAMAC Location
                        </td>
                        <td style="width: 577px;" class="TableGrid">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="134px">
                              
                                <asp:ListItem Value="34">INDORE</asp:ListItem>
                                <asp:ListItem Value="1">MUMBAI</asp:ListItem>
                                <asp:ListItem Value="40">LUCKNOW</asp:ListItem>
                                <asp:ListItem Value="11">KOLKATTA</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 317px;" class="TableTitle">
                            <strong>Location</strong>
                        </td>
                        <td style="width: 225px;" class="TableGrid">
                            <asp:TextBox ID="txtlocation" runat="server" Height="21px" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" colspan="6">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                ValidationGroup="grpImport" SkinID="btnImport" Text="Submit" />&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update"
                                Visible="False" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Btncancel" runat="server" Text="Cancel" OnClick="Btncancel_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="GridView1" runat="server" 
                                AutoGenerateColumns="False" 
                                OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkdeleteEmp" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                CommandName="Delete" OnClientClick="return DeleteItem()"><img src="../Images/del3.jpeg" alt="Delete" style="border:0" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                CommandName="Edit1"><img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="PMSLocation" HeaderText="PMSLocation" />
                                    <asp:BoundField DataField="Spokelocations" HeaderText="Spokelocation" />
                                    <asp:BoundField DataField="Branchid" HeaderText="bid" Visible="false" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" colspan="6">
                            &nbsp;<br />
                            <br />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
