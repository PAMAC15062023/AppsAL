<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="MenuMaster.aspx.cs" Inherits="Pages_MenuMaster" Title="Menu Master" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
  function Page_Load_Validation()
    {
        EnableDisableParentListControl();
        ValidateAddNew();
    }
    function ValidateDeleteMenuFromList()
    {
        var ReturnValue=true;
        var ErrorMessage="";
        
        var hdnMenuID=document.getElementById("<%=hdnMenuID.ClientID%>");
        
         
               
        
        return ReturnValue;
    }
    function EnableDisableParentListControl()
    {
        //debugger;
            var ddlIsHeader=document.getElementById("<%=ddlIsHeader.ClientID%>");
            var ddlParentList=document.getElementById("<%=ddlParentList.ClientID%>");
            var value=false; 
            if (ddlIsHeader.value=='True')
            {
                 value=true;
                 ddlParentList.selectedIndex=0;
            }          
                
                 ddlParentList.disabled=value ;
             
    }

    function ValidateAddNew()
    {
           var txtDisplayName=document.getElementById("<%=txtDisplayName.ClientID%>");
           var txtPosition=document.getElementById("<%=txtPosition.ClientID%>");
           var txtPagePath=document.getElementById("<%=txtPagePath.ClientID%>");
           var hdnMenuID=document.getElementById("<%=hdnMenuID.ClientID%>");
           var hdnMenuPath=document.getElementById("<%=hdnMenuPath.ClientID%>");
           
           var ddlIsHeader=document.getElementById("<%=ddlIsHeader.ClientID%>");
           var ddlIsActivate=document.getElementById("<%=ddlIsActivate.ClientID%>");
           var ddlBranchList=document.getElementById("<%=ddlBranchList.ClientID%>");
           var ddlParentList=document.getElementById("<%=ddlParentList.ClientID%>");
            
             
    
           txtDisplayName.value='';
           txtPosition.value='';
           txtPagePath.value='';          
           hdnMenuID.value=0;
           hdnMenuPath='';
           
           ddlIsHeader.selectedIndex=1;
           ddlIsActivate.selectedIndex=0;
           ddlBranchList.selectedIndex=0;
           ddlParentList.selectedIndex=0;
           
           EnableDisableParentListControl();
           return false; 
    }
        
</script>
    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5" >
                <asp:Label ID="lblMessage" runat="server" Visible="False" CssClass="ErrorMessage"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="BranchENtry" />
            
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;Menu Master</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                &nbsp;IsHeader (Is TopParent Menu)</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlIsHeader" runat="server" CssClass="dropdown" SkinID="ddlSkin">
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Selected="True" Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnMenuID" runat="server" Value="0" /><asp:HiddenField ID="hdnMenuPath" runat="server" Value="0" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                &nbsp;Parent List</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlParentList" runat="server" CssClass="dropdown" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                &nbsp;Display Name</td>
            <td colspan="3">
                <asp:TextBox ID="txtDisplayName" runat="server" ValidationGroup="BranchENtry" BorderWidth="1px" Width="269px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:RequiredFieldValidator ID="Rq_txtDisplayName" runat="server" ControlToValidate="txtDisplayName"
                    ErrorMessage="Display Name cannot be left blank!" ValidationGroup="BranchENtry" Width="16px">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                &nbsp;Page Path (Navigate URL)</td>
            <td colspan="3">
                <asp:TextBox ID="txtPagePath" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" Width="499px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                &nbsp;Activate</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown" SkinID="ddlSkin">
                    <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                &nbsp;Position</td>
            <td colspan="2">
                <asp:TextBox ID="txtPosition" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 178px">
                &nbsp;Branch Mapping</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlBranchList" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
                <asp:RequiredFieldValidator ID="Rq_Branch" runat="server" ControlToValidate="ddlBranchList"
                    ErrorMessage=" Branch not Selected!" InitialValue="--Select--" ValidationGroup="BranchENtry">?</asp:RequiredFieldValidator></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5" style="height: 31px">
                &nbsp;<asp:Button ID="btnSave" runat="server"   Text="Save Changes"
                    ValidationGroup="BranchENtry" Width="100px" OnClick="btnSave_Click" BorderWidth="1px" />
                <asp:Button ID="btnAddNew" runat="server"   Text="Add " Width="54px" OnClick="btnSave_Click" BorderWidth="1px" />
                <asp:Button ID="btnDelete" runat="server"   Text="Remove" Width="66px" OnClick="btnSave_Click" BorderWidth="1px" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" Width="800px">
                <asp:TreeView ID="MenuTreeView" runat="server" DataSourceID="XmlDataSource1" ShowLines="True" OnSelectedNodeChanged="MenuTreeView_SelectedNodeChanged" ExpandDepth="0">
                    <DataBindings>
                        <asp:TreeNodeBinding DataMember="MenuItem" TextField="Text"
                            ToolTipField="Tooltip" ValueField="Value" />
                    </DataBindings>
                </asp:TreeView>
                </asp:Panel>
                <asp:XmlDataSource ID="XmlDataSource1" runat="server" TransformFile="~/Pages/TransformXSLT.xsl"
                    XPath="MenuItems/MenuItem"></asp:XmlDataSource>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

