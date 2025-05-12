<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="CC_OverallCaseStatus.aspx.cs" Inherits="CPV_CC_CC_OverallCaseStatus"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function PreventCharacterToAdd(id)
{
getControlsId = document.getElementById(id);
if(getControlsId.value.length > 199)
{
getControlsId.value = getControlsId.value.substring( 0, 199 );
return false;
}
}
</script>

<table cellpadding="0" cellspacing="0" border="0" width="99%">
<tr>
<td style="padding-left:10px">
<fieldset>
<legend class="FormHeading">Overall Case Status</legend>
<table cellpadding="0" cellspacing="0" border="0" width="99%">
<tr>
<td><b>From Date :</b>
</td>
<td><asp:TextBox id="txtFromDate" runat="Server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
 <img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
</td>
<td><b>To Date :</b></td>
<td>
<asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
<img id="imgToDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
</td>
<td>
<asp:Button ID="btnSearch" ValidationGroup="grpSend" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click"/>
</td>
</tr>
<tr>
<td colspan="5">
<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="669px"></asp:Label>
</td>
</tr>
</table>
<table cellpadding="0" cellspacing="0" border="0" width="99%">
<tr>
<td>
    <asp:GridView ID="gvOverallStatus" SkinID="gridviewSkin" DataKeyNames="CASE_ID,Overall_Status_ID"  runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvOverallStatus_RowCancelingEdit"  OnRowDataBound="gvOverallStatus_RowDataBound" OnRowEditing="gvOverallStatus_RowEditing" OnRowUpdating="gvOverallStatus_RowUpdating" OnPageIndexChanging="gvOverallStatus_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="Case ID">
                <EditItemTemplate>
                    <asp:Label ID="lblCaseID" runat="server"  Width="109px" Text='<%# Bind("CASE_ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCaseIDItem" runat="server" Text='<%# Bind("CASE_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Applicant Name">
                <EditItemTemplate>
                   <asp:Label ID="lblAppName" runat="server"  Width="109px" Text='<%# Bind("Applicant_Name") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Applicant_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ref No">
                <EditItemTemplate>
                    <asp:Label ID="lblRefNo" runat="server"  Width="109px" Text='<%# Bind("REF_NO") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("REF_NO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Overall Status">
            <ItemStyle Width="15%" /> 
                <EditItemTemplate> 
                    <asp:DropDownList ID="ddlOverallStatus" SkinID="ddlSkin" runat="server" DataValueField="CASE_STATUS_ID"  DataTextField="STATUS_CODE"  Width="128px"   >
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblOverallStatus" runat="server" Text='<%# Bind("STATUS_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Overall Comments">
            <ItemStyle Width="20%"/>
                <EditItemTemplate>
                    <asp:TextBox ID="txtOverallComments" SkinID="txtSkin" TextMode="MultiLine"  runat="server" Text='<%# Bind("Overall_comments") %>' Width="215px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblOverallComments"  runat="server" Text='<%# Bind("Overall_comments") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit Overall Status">
                                  <ItemTemplate>                    
                                    <asp:LinkButton ID="lnkEditStatus" CommandName="Edit" Text="Edit Status" runat="server"></asp:LinkButton>
                                  </ItemTemplate>               
                                  <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdateStatus" CommandName="Update" Text="Update" runat="server" ></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancelStatus" CommandName="Cancel" Text="Cancel" runat="server"></asp:LinkButton>                                    
                                  </EditItemTemplate>
                                  <ItemStyle VerticalAlign="Top" Width="20%" />
         </asp:TemplateField>   
        </Columns>
    </asp:GridView>
</td>
</tr>
<asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate" Display="None" 
    ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True" 
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"  ValidationGroup="grpSend"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate" Display="None" 
    ErrorMessage="Please enter valid Time Format for To Date" SetFocusOnError="True" 
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="grpSend"></asp:RegularExpressionValidator><asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="List" ShowMessageBox="True" 
    ShowSummary="False" ValidationGroup="grpSend" /> 
 
</table>
</fieldset>
 
</td>
</tr>
</table>
</asp:Content>

