<%@ Page Language="C#" MasterPageFile="CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_TC_ManuAssign.aspx.cs" Inherits="CPV_CC_CC_TC_ManuAssign" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
function vaidation(source, arguments)
{

var gvID=document.getElementById("<%=gvFEAssignmentCases.ClientID %>");
var length=gvID.rows.length;
var i;
var nCount="Y";
for(i=1;i<length;i++)
{

if( document.getElementById(gvID.rows[i].cells[0].firstChild.id).checked )
{

nCount="N";
break;
}

}
if(nCount=="Y")
{
arguments.IsValid=false;
}
else
{
arguments.IsValid=true;
}
}
 
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Tele Caller Mannual Assignment</legend>
 <table border="0" cellpadding="1" cellspacing="0" width="100%">   
    <tr><td><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td></tr> 
    <tr><td style="height: 4px">
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr><%--
        <td style="height: 24px" >From Pincode</td><td style="width: 2px; height: 24px;">:</td><td style="height: 24px">
        <asp:DropDownList ID="ddlFromPin" runat="server" DataSourceID="sdsPincode" DataTextField="PINCODE" DataValueField="PINCODE" OnDataBound="ddlFromPin_DataBound" SkinID="ddlSkin">
        </asp:DropDownList></td>
        <td style="height: 24px" >To Pincode</td><td style="width: 2px; height: 24px;">:</td><td style="height: 24px"><asp:DropDownList ID="ddlToPin" runat="server" DataSourceID="sdsPincode" DataTextField="PINCODE" DataValueField="PINCODE" OnDataBound="ddlToPin_DataBound" SkinID="ddlSkin">
        </asp:DropDownList></td>
        <td style="height: 24px">
                <asp:Button ID="btnSearchFE" runat="server" SkinID="btnSearchSkin" OnClick="btnSearchFE_Click" /></td>--%>
        <td style="height: 24px" >Tele Caller Name<span style="color:Red;">*</span></td><td style="width: 2px; height: 24px;">:</td><td style="height: 24px; width: 461px;">
            <asp:DropDownList ID="ddlTc" runat="server" DataSourceID="sdsFE" DataTextField="FULLNAME" DataValueField="Emp_id" SkinID="ddlSkin" Width="288px" >
            </asp:DropDownList></td>   
            <td align="right" style="height: 24px"><asp:Button ID="btnAssign" runat="server" Text="Assign Cases" ValidationGroup="vgrpFE" OnClick="btnAssign_Click" Font-Bold="True" /></td>         
        </tr>
    </table></td></tr>  
    <tr><td>        
        <asp:GridView ID="gvFEAssignmentCases" runat="server" DataSourceID="sdsGV" Width="100%" SkinID="gridviewSkin" OnDataBound="gvFEAssignmentCases_DataBound">           
            <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                </HeaderTemplate>

                <ItemTemplate>
                    <asp:CheckBox ID="chkCaseId" runat="server" /><asp:HiddenField ID="hidCaseId" runat="server"
                        Value='<%# DataBinder.Eval(Container.DataItem, "CaseID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </td></tr>
    <%--<tr><td align="right"><asp:Button ID="btnAssign1" runat="server" SkinId="btnAssingSkin" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" /></td></tr>--%>
    </table>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Button ID="Button1" runat="server" Text="Assign Cases" ValidationGroup="vgrpFE" OnClick="btnAssign_Click" Font-Bold="True" /></fieldset>
    </td></tr>
</table>
     <asp:SqlDataSource ID="sdsVeriType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
     SelectCommand="SELECT VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER WHERE (VERIFICATION_TYPE_ID IN (4, 3)) AND (PARENT_TYPE_CODE = 'TV')"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsPincode" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT FPM.PINCODE FROM FE_PINCODE_MAPPING AS FPM INNER JOIN FE_VW AS FV ON FPM.FE_ID = FV.EMP_ID WHERE (FV.CENTRE_ID = ?) ORDER BY FPM.PINCODE">
            <SelectParameters>
                <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" ></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsFE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT FULLNAME, Emp_id FROM EMPLOYEE_MASTER WHERE (DESIGNATION_ID = '8') AND (DOL IS NULL OR DOL=' ') AND (CENTRE_ID = ?) ORDER BY FULLNAME">
        <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                            
        </SelectParameters> 
        </asp:SqlDataSource>
        
        <asp:HiddenField ID="hdnVerificatioTypeID" runat="server" />
        <asp:SqlDataSource ID="sdsSearchFE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID where ([Centre_ID]=?) order by FULLNAME ">
         <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                            
        </SelectParameters> 
        </asp:SqlDataSource>
        <%--<asp:RegularExpressionValidator ID="revDate" runat="server" ErrorMessage="Please enter valid date format for Date" Display="None" SetFocusOnError="True" ValidationGroup="FEAssign" ControlToValidate="txtDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>--%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="FEAssign" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup='vgrpFE' />
        <%--<asp:RequiredFieldValidator ID="rfvFE" runat="server" ErrorMessage="Please select FE to assign" ControlToValidate="ddlFE" Display="None" SetFocusOnError="True" ValidationGroup="vgrpFE"></asp:RequiredFieldValidator>--%>
        <script type="text/javascript" language="javascript">
            <!--
               function ChangeCheckBoxState(id, checkState)
               {
                  var cb = document.getElementById(id);
                  if (cb != null)
                     cb.checked = checkState;
               }
               function ChangeAllCheckBoxStates(checkState)
               {
                  // Toggles through all of the checkboxes defined in the CheckBoxIDs array
                  // and updates their value to the checkState input parameter
                  if (CheckBoxIDs != null)
                  {
                     for (var i = 0; i < CheckBoxIDs.length; i++)
                        ChangeCheckBoxState(CheckBoxIDs[i], checkState);
                  }
               }
            -->
        </script>

    <asp:CustomValidator ID="valgv" runat="server" ClientValidationFunction="vaidation"
        Display="None" ErrorMessage="Please select at least one Case. " SetFocusOnError="True"
        ValidationGroup="vgrpFE"></asp:CustomValidator>
</asp:Content>


