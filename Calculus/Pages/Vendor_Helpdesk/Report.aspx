

<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report.aspx.cs" StylesheetTheme="SkinFile" Inherits="Pages_Helpdesk_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<table style="width: 100%; height: 544px;">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4" style="height: 22px">
                HelpDesk
            </td>
        </tr>
        <tr>
            <td style="width: 68px">
                <strong>Status</strong>
            </td>
            <td style="width: 13px">
                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="Masterbody" Height="16px"
                    SkinID="ddlSkin" Width="119px">
                    <asp:ListItem Value="0">--All--</asp:ListItem>
                    <asp:ListItem>Open</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Close</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 30px">
                <strong>Location</strong>:
            </td>
            <td>
                <asp:DropDownList ID="ddlbranch" runat="server" Height="16px" SkinID="ddlSkin" Width="130px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 68px">
                &nbsp;
            </td>
            <td style="width: 13px">
                <asp:Button ID="btnsearch" runat="server" Text="Search" Width="94px" OnClick="btnsearch_Click" />
            </td>
            <td style="width: 30px">
                &nbsp;<asp:Button ID="btnExporttoExcel" runat="server" BorderColor="Black" BorderWidth="1px"
                    OnClick="btnExporttoExcel_Click" Text="Export" Width="94px" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="90px" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 68px">
                &nbsp;
            </td>
            <td style="width: 13px">
                &nbsp;
            </td>
            <td style="width: 30px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid">
                    <Columns>
                        <asp:BoundField DataField="branchname" HeaderText="Branch" />
                        <asp:BoundField DataField="ticketno" HeaderText="Ticket Number" />
                        <asp:BoundField DataField="Date" HeaderText="Ticket Date" />
                        <asp:BoundField DataField="Username" HeaderText="Requested By" />
                        <asp:BoundField DataField="department" HeaderText="Department" />
                        <asp:BoundField DataField="problemtypename" HeaderText="Problem Name" />
                        <asp:BoundField DataField="problemdetailsname" HeaderText="Problem Details" />
                        <asp:BoundField DataField="remark" HeaderText="Remark" />
                        <asp:BoundField DataField="ticketStatus" HeaderText="Status" />
                        <asp:BoundField DataField="AssignedBy" HeaderText="Assigned By" />
                        <asp:BoundField DataField="AssignedTo" HeaderText="Assigned To" />
                        <asp:BoundField DataField="TAT" HeaderText="TAT(Days)" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>--%><%-- <table style="width: 100%">
        <tr>
            <td style="width: 187px" class="TableTitle">
                vender name</td>
            <td colspan="3" class="TableGrid">
                            <asp:DropDownList ID="ddlvendersearch" runat="server" Height="22px" 
                    Width="120px" AutoPostBack="True"
                                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" 
                    Style="margin-left: 0px" SkinID="ddlSkin">
                                
                             
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txt" runat="server" SkinID="txtSkin"></asp:TextBox>
                <asp:Button ID="search" runat="server" onclick="search_Click" Text="Search" />
            </td>
        </tr>
        <tr>
            <td style="width: 187px; height: 26px" class="TableTitle">
                New vender name</td>
            <td colspan="3" style="height: 26px" class="TableGrid">
                                <asp:TextBox ID="txtvender" runat="server"></asp:TextBox>
                            </td>
        </tr>
        <tr>
            <td style="width: 187px; height: 33px" class="TableTitle">
                vender provider
            </td>
            <td colspan="3" style="height: 33px" class="TableGrid">
                                <asp:TextBox ID="txtprovider" runat="server"></asp:TextBox>
                                </td>
        </tr>
        <tr>
            <td style="width: 187px; height: 38px" class="TableTitle">
                vender&nbsp; sevices</td>
            <td colspan="3" style="height: 38px" class="TableGrid">
                                <asp:TextBox ID="txtservices" runat="server"></asp:TextBox>
                            </td>
        </tr>
        <tr>
            <td style="width: 187px" class="TableTitle">
                &nbsp;</td>
            <td colspan="3" class="TableTitle">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 187px; height: 31px" class="TableGrid">
                <asp:Button ID="btnupdate" runat="server" onclick="btnupdate_Click" 
                    Text="Update" />
            </td>
            <td style="height: 31px; width: 12px" class="TableGrid">
                &nbsp;<asp:Button ID="btnadd" runat="server" Text="ADD" 
                    onclick="btnadd_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td style="height: 31px; width: 173px" class="TableGrid">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnreset" runat="server"  Text="Reset" 
                    onclick="btnreset_Click" />
                &nbsp;</td>
            <td style="height: 31px" class="TableGrid">
                &nbsp;
                <asp:Button ID="btncle" runat="server"  Text="Cancle" onclick="btncle_Click" />
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 187px">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />


    --%>





    <br />
    <asp:Panel ID="pnlcat" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        &nbsp;<table style="width: 100%">
            <tr>
                <td style="width: 236px" class="TableTitle">
                    &nbsp;&nbsp; &nbsp;Select Category</td>
                <td class="TableGrid">
                    <asp:DropDownList ID="ddlselectedcat" runat="server" Height="29px" 
                        SkinID="ddlSkin" Width="123px" 
                        onselectedindexchanged="ddlselectedcat_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>New Vender Entry</asp:ListItem>
                           <asp:ListItem>Upadate Vender</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlSearchMaster" runat="server">
        <table style="width: 100%; height: 29px">
            <tr>
                <td class="TableTitle" style="width: 236px">
                    &nbsp; &nbsp; Search Vender Name</td>
                <td>
                    &nbsp;&nbsp;<asp:DropDownList ID="ddlvendersearch" runat="server" Height="25px" 
                        onselectedindexchanged="ddlvendersearch_SelectedIndexChanged" 
                        Width="113px" SkinID="ddlSkin">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="search" runat="server" onclick="search_Click1" Text="search" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridSearchMaster" runat="server" AutoGenerateColumns="False"  
            SkinID="gridviewSkin" Width="891px" 
            onrowcommand="GridSearchMaster_RowCommand" 
            onrowediting="GridSearchMaster_RowEditing" >
                        <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditTele" runat="server">Edit</asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                             
                            <asp:BoundField DataField="vender_name" HeaderText="vender name"/>
                            <asp:BoundField DataField="vender_prob_provider" HeaderText="vender provider"/>
                            <asp:BoundField DataField="vender_services" HeaderText="vender services"/>
                           </Columns>
                    </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlData" runat="server" Height="187px">
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 100px; height: 28px;" class="TableTitle">
                    Vender Name
                </td>
                <td class="TableGrid" style="height: 28px">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 17px; width: 100px" class="TableTitle">
                    Vender Providers</td>
                <td style="height: 17px" class="TableGrid">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtPro" runat="server" SkinID="txtSkin"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px" class="TableTitle">
                    Vender Services</td>
                <td class="TableGrid">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtServices" runat="server" SkinID="txtSkin"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 100px; height: 17px">
                </td>
                <td class="TableTitle" style="height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnAdd" runat="server" Text="ADD" onclick="BtnAdd_Click" />
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnUpdate" runat="server" 
                        Text="Update" onclick="BtnUpdate_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Button ID="BtnReset" runat="server" onclick="BtnReset_Click" 
                        Text="Reset" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnCancle" runat="server"  
                        Text="Cancle" onclick="BtnCancle_Click1" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <br />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <br />
    <br />





</asp:Content>
