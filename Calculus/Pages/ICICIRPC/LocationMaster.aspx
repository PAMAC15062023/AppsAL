<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="LocationMaster.aspx.cs" Inherits="Pages_LOSTracker_LocationMaster" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript" language="javascript">
        function ClientValidate(source, arguments) {
            //alert(arguments.Value);
            if ((arguments.Value) == 0)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }

        function validate() {
            var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
            var ErrorMsg = "";
            var ReturnValue = true;
            var txthub = document.getElementById("<%=txthub.ClientID%>");
        var txtlocation = document.getElementById("<%=txtlocation.ClientID%>");

            if (txtlocation.value == '') {
                ErrorMessage = "Please enter The Location";
                ReturnType = false;
            }
            if (txthub.value == '') {
                ErrorMessage = "Please enter The Hub";

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
                        <td class="TableHeader" colspan="6">Location Master</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 317px;" class="TableTitle">PAMAC Location</td>
                        <td style="width: 317px;" class="TableGrid">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="134px">
                                <%--<asp:ListItem Value="36">CHANDIGARH</asp:ListItem>
                                <asp:ListItem Value="3">Delhi</asp:ListItem>
                                <asp:ListItem Value="37">JAIPUR</asp:ListItem>
                                <asp:ListItem Value="1">Mumbai</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 317px;" class="TableTitle">
                            <strong>Hub</strong></td>
                        <td style="width: 225px" class="TableGrid">
                            <asp:TextBox ID="txthub" runat="server" Height="21px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="width: 317px;" class="TableTitle">
                            <strong>Location</strong></td>
                        <td style="width: 225px;" class="TableGrid">
                            <asp:TextBox ID="txtlocation" runat="server" Height="21px"
                                SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 317px;" class="TableTitle">Is
            Active :</td>
                        <td style="width: 317px;" class="TableGrid">
                            <asp:DropDownList ID="ddlactive" runat="server" Width="134px">
                                <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 317px;" class="TableTitle">&nbsp;</td>
                        <td style="width: 225px" class="TableGrid">&nbsp;</td>
                        <td style="width: 317px;" class="TableTitle">&nbsp;</td>
                        <td style="width: 225px;" class="TableGrid">&nbsp;</td>
                    </tr>

                    <tr>
                        <td class="TableTitle" colspan="6">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="button"
                                OnClick="btnSubmit_Click" ValidationGroup="grpImport" SkinID="btnImport"
                                Text="Submit" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"
                Text="Update" Visible="False" />
                            &nbsp;&nbsp;
            <asp:Button ID="Btncancel" runat="server"
                Text="Cancel" OnClick="Btncancel_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="GridView1" runat="server"
                                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False"
                                OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand"
                                OnRowDeleting="GridView1_RowDeleting">
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
                                    <asp:BoundField DataField="HUB" HeaderText="Hub" />
                                    <asp:BoundField DataField="Spokelocations" HeaderText="Spokelocation" />
                                    <asp:BoundField DataField="Branchid" HeaderText="bid" />
                                    <asp:BoundField DataField="is_active" HeaderText="is_active" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableTitle" colspan="6">&nbsp;<br />
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

