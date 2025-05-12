<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="FE_SignatureAssignment.aspx.cs" Inherits="Administrator_FE_SignatureAssignment" Title="FE Sign Image Assignment" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function GetFE_Code()
    {
   // debugger;
           var lblEmployeeCode=document.getElementById("<%=lblEmployeeCode.ClientID%>");
           var ddlFENameList=document.getElementById("<%=ddlFENameList.ClientID%>");
           
           var EmployeeInfo=ddlFENameList.value;
            
                
            EmployeeInfo= EmployeeInfo.split(':');
            if (EmployeeInfo.length==2)
            {
                lblEmployeeCode.innerText=EmployeeInfo[1];
            }
            else
            {           
                lblEmployeeCode.innerText='';            
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
                &nbsp;<strong>FE Image Assignment </strong>
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
                &nbsp;FE Name Search
            </td>
            <td>
                <asp:TextBox ID="txtSearchFEName" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnSearchFE" runat="server" Text="Go" Width="33px" OnClick="btnSearchFE_Click" SkinID="btn" /></td>
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
            <td style="width: 100px">
                &nbsp;FE Name
            </td>
            <td>
                <asp:DropDownList ID="ddlFENameList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="lblEmployeeCode" runat="server" SkinID="lblSkin" Width="100px"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td colspan="2">
                <asp:RequiredFieldValidator ID="Rq_FEName" runat="server" ErrorMessage="Please select FE Name to continue." ControlToValidate="ddlFENameList" ValidationGroup="ValidateFE" InitialValue="--Select--"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
                &nbsp;FE Signature Image</td>
            <td colspan="3">
                <asp:FileUpload ID="FileUpload1" runat="server" SkinID="flup" Width="330px" Height="23px" /></td>
            <td colspan="2">
                <asp:RequiredFieldValidator ID="Rq_SignImages" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please FE Signature " ValidationGroup="ValidateFE"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 20px">
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
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnAdd" runat="server" Text="Add Images" OnClick="btnAdd_Click" SkinID="btn" ValidationGroup="ValidateFE" /></td>
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
                <asp:GridView ID="gv_FESignImageList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField HeaderText="UID" Visible="False" />
                        <asp:BoundField HeaderText="EMP_ID" Visible="False" />
                        <asp:BoundField HeaderText="EMPCode" DataField="EMPCode" />
                        <asp:BoundField DataField="FEName" HeaderText="FE Name" />
                        <asp:BoundField DataField="FE_SignImage" HeaderText="FE_SignImage" Visible="False" />
                        <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" Visible="False" />
                        <asp:BoundField DataField="ImageType" HeaderText="ImageType" />
                        <asp:TemplateField HeaderText="FE Image Signature">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="62px"
                                    Width="95px" BorderStyle="Solid" BorderWidth="0px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImagePath") %>'  />
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

