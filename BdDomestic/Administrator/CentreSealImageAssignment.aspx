<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="CentreSealImageAssignment.aspx.cs" Inherits="CentreSealImageAssignment" Title="Centre PAMAC Seal Image Assignment" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function GetCenter_Code()
    {
   // debugger;
           var lblCentreCode=document.getElementById("<%=lblCentreCode.ClientID%>");
           var ddlCentreList=document.getElementById("<%=ddlCentreList.ClientID%>");
           
           var CentreCodeInfo=ddlCentreList.value;
            
                
            CentreCodeInfo= CentreCodeInfo.split(':');
            if (CentreCodeInfo.length==2)
            {
                lblCentreCode.innerText=CentreCodeInfo[1];
            }
            else
            {           
                lblCentreCode.innerText='';            
            }
            
    
    }
</script>
    <table>
        <tr>
            <td colspan="7" style="height: 1px">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidateFE" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 20px">
                &nbsp;<strong>Centre Pamac-Seal Image Assignment </strong>
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 26px;">
            </td>
            <td style="width: 119px;">
                &nbsp;Centre Seach</td>
            <td>
                <asp:TextBox ID="txtSearchCentreName" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnSearchCentre" runat="server" Text="Go" Width="33px" OnClick="btnSearchCentre_Click" SkinID="btn" /></td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 119px">
                &nbsp;Centre Name
            </td>
            <td>
                <asp:DropDownList ID="ddlCentreList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="lblCentreCode" runat="server" SkinID="lblSkin" Width="100px"></asp:Label></td>
            <td colspan="3">
                <asp:RequiredFieldValidator ID="Rq_FEName" runat="server" ErrorMessage="Please select Centre from Centre List" ControlToValidate="ddlCentreList" ValidationGroup="ValidateFE" InitialValue="--Select--">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 119px">
                &nbsp;Centre PamacSeal Image</td>
            <td colspan="3">
                <asp:FileUpload ID="FileUpload1" runat="server" SkinID="flup" Width="330px" Height="23px" /></td>
            <td colspan="2">
                <asp:RequiredFieldValidator ID="Rq_SignImages" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please Select Pamac Centre Image!" ValidationGroup="ValidateFE">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 119px">
                &nbsp;</td>
            <td colspan="3">
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 119px">
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
            <td style="width: 20px; height: 20px;">
            </td>
            <td style="width: 119px; height: 20px;">
                <asp:Button ID="btnAdd" runat="server" Text="Add Images" OnClick="btnAdd_Click" SkinID="btn" ValidationGroup="ValidateFE" Height="21px" Width="132px" /></td>
            <td style="width: 100px; height: 20px;">
                </td>
            <td style="width: 100px; height: 20px;">
            </td>
            <td style="width: 100px; height: 20px;">
            </td>
            <td style="width: 100px; height: 20px;">
            </td>
            <td style="width: 100px; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 16px;">
            </td>
            <td colspan="5" style="height: 16px">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Vertical" Width="100%">
                <asp:GridView ID="gv_CentreImageList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField HeaderText="CENTRE ID" Visible="False" DataField="Centre_Code" />
                        <asp:BoundField HeaderText="Centre Name" DataField="Centre_Name" />
                        <asp:BoundField DataField="CENTRE_PAMACSEAL" HeaderText="CENTRE_PAMACSEAL" Visible="False" />
                        <asp:BoundField DataField="Image_Path" HeaderText="ImagePath" Visible="False" />
                        <asp:TemplateField HeaderText="CENTRE PAMACSEAL">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="78px"
                                    Width="83px" BorderStyle="Solid" BorderWidth="0px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Image_Path") %>'  />
                            </ItemTemplate>                            
                        </asp:TemplateField>
              
                    </Columns>
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                </asp:GridView>
                </asp:Panel>
                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;&nbsp;
                <asp:Button ID="btnUploadAll" runat="server" Text="Upload All" OnClick="btnUploadAll_Click" SkinID="btn" Width="104px" />&nbsp;
                <asp:Button ID="btnClose" runat="server" Text="Close" SkinID="btn" OnClick="btnClose_Click" Width="57px" /></td>
        </tr>
    </table>
</asp:Content>

