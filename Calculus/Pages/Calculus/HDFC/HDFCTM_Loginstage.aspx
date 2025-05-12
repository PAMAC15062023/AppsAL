<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="HDFCTM_Loginstage.aspx.cs" Inherits="Pages_Calculus_HDFC_HDFCTM_Loginstage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="width: 900px;">
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>

    <table style="width: 900px;">
        <tr>
            <td>
                <asp:Label ID="lblFTNR" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="OrangeRed"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblFTR" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Magenta" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblAlreadyDisbursed" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="DarkBlue"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblLock" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Blue"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblHold" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblALREADYFTNR" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Maroon"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTotalCount" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="DarkGreen"></asp:Label>
            </td>
        </tr>
        </table>
    <table style="width: 900px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:GridView ID="GridLoginStage" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                            <HeaderTemplate>
                                <input id="chkSelectAll" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect"  runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Font-Bold="True" OnClick="lnkEdit_Click">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ApplicationID" HeaderText="Application ID" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="UploadDate" HeaderText="Recieved Case Datetime" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="FileStatus" HeaderText="File Status" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

    <asp:Panel ID="Panel1" runat="server" Visible="false" >
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="Label6" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Assigned Datetime</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtAssignedDatetime" Width="150px" runat="server" Enabled="false" ></asp:TextBox>

                </td>
                <td class="TableTitle" style="height: 27px" colspan="2">
                    <asp:Label ID="Label9" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Customer Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="10">
                    <asp:TextBox ID="txtCustomerName" Width="200px" runat="server" MaxLength="500" Enabled="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="Label8" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Application ID</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtApplicationID" Width="150px" MaxLength="500" runat="server" Enabled="false"></asp:TextBox>
                </td>


                <td class="TableTitle" style="height: 27px" colspan="2">
                    <asp:Label ID="Label7" runat="server" Width="140" Font-Size="10" Height="20" Style="text-align: center;">Status<span style="color : red"> *</span></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="10">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="147" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>

                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="Label2" runat="server" Width="140" Font-Size="10" Height="20" Style="text-align: center;">Reason<span style="color : red"> *</span> </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlReason" runat="server" Width="147" OnSelectedIndexChanged="ddlReason_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="2">
                    <asp:Label ID="Label1" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Remarks<span style="color : red"> *</span></asp:Label>
                </td>
                <td class="TableTitle" style="height: 37px" colspan="20">
                    <asp:TextBox ID="txtRemarks" Width="400px" runat="server" MaxLength="500" TextMode="Multiline" Rows="5" Enabled="false"></asp:TextBox>
                </td>
            </tr>
        </table>

         <br />
        <br />
        <table style="width: 900px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save And Continue" OnClick="btnSaveAndContinue_Click"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px"  />&nbsp;
                    <asp:Button ID="btnSaveAndExit" runat="server" Text="Save And Exit" BorderColor="#400000" OnClick="btnSaveAndExit_Click"
                        BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" OnClick="btnBack_Click"
                        BorderWidth="1px" Font-Bold="False" Width="105px"  />
                </td>
            </tr>
        </table>
    </asp:Panel>

     <asp:HiddenField ID="hdnEmployeeCode" runat="server" />
    <asp:HiddenField ID="hdnEmployeeName" runat="server" />
    <asp:HiddenField ID="hdnReferenceID" runat="server" />
    <asp:HiddenField ID="hdnUploadDate" runat="server" />
    <asp:HiddenField ID="hdnAssignedto" runat="server" />
    <asp:HiddenField ID="hdnFileStatus" runat="server" />
    
</asp:Content>

