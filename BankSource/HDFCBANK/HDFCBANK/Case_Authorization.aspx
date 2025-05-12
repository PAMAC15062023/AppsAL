<%@ page language="C#" masterpagefile="~/HDFCBANK/HDFCBANK/MasterPage.master" autoeventwireup="true" inherits="HDFC_HDFC_Case_Authorization, App_Web_case_authorization.aspx.513d3bc3" title="Untitled Page" theme="SkinFile" viewStateEncryptionMode="Always" %>
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

<script language="JAVASCRIPT" type="text/javascript"> 



        function CheckAll() 
        {
        
     
        
        chequeBoxSelectedCount = 0;
        var gvFEAssignmentCases = document.getElementById("<%=gvFEAssignmentCases.ClientID%>");
        var chkSelectAll = document.getElementById('chkSelectAll');
        var cell;
        for (i = 0; i <= gvFEAssignmentCases.rows.length - 1; i++) 
        {
            cell = gvFEAssignmentCases.rows[i].cells[0];
            if (cell != null) 
            {
                for (j = 0; j < cell.childNodes.length; j++) 
                {

                    if (cell.childNodes[j].type == "checkbox") 
                    {
                        cell.childNodes[j].checked = chkSelectAll.checked;
                        chequeBoxSelectedCount = chequeBoxSelectedCount + 1;
                    }
                }
            }

        }

    }
       </script>
 
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

<fieldset ><legend class="FormHeading"> Case Authorization </legend>
    <table>
        <tr>
            <td colspan="8" style="height: 26px" title="PAMAC Online">
 <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 106px; height: 26px">
                Client Name :</td>
            <td style="width: 250px; height: 26px">
                <asp:DropDownList ID="ddlclientname" runat="server" SkinID="ddlSkin" AutoPostBack="True" OnSelectedIndexChanged="ddlclientname_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 26px">
                Date :</td>
            <td colspan="3" style="height: 26px">
        <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>
            <td align="center" colspan="2" style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 106px; height: 26px">
                Verification Type :</td>
            <td style="width: 250px; height: 26px">
                <asp:DropDownList ID="ddlType" runat="server" OnDataBound="ddlType_DataBound" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Value="1">Residence Address</asp:ListItem>
                                                    <asp:ListItem Value="2">Office address</asp:ListItem>
                                                     <asp:ListItem Value="2">Current account CPV</asp:ListItem>
                    <asp:ListItem>--Select--</asp:ListItem>
               
                </asp:DropDownList></td>
            <td style="width: 100px; height: 26px">
                Applicant Name :</td>
            <td style="width: 100px; height: 26px">
                <asp:TextBox ID="txtCustName" runat="server" SkinID="txtSkin" MaxLength="200"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
                </td>
            <td style="width: 100px; height: 26px">
                <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="FEAssign" /></td>
            <td align="center" colspan="2" style="height: 26px">
                </td>
        </tr>
        <tr>
            <td style="height: 26px" colspan="8">
                <asp:Label ID="lblerror" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="8" rowspan="7">
    <asp:Button ID="btnAssign" runat="server" SkinId="btn" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" Text="Okay" Width="122px" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="BtnReject" runat="server" OnClick="BtnReject_Click"
                    Text="Reject" Width="127px" SkinID="btn" />
        <asp:GridView ID="gvFEAssignmentCases" runat="server" OnPageIndexChanging="gvFEAssignmentCases_PageIndexChanging" Width="100%" OnSorting="gvFEAssignmentCases_Sorting" SkinID="gridviewSkin">           
            <Columns>
                <asp:TemplateField>
                <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox ID="chkCaseId" runat="server" /><asp:HiddenField ID="hidCaseId" runat="server"
                        Value='<%# DataBinder.Eval(Container.DataItem, "Case ID") %>' />
                   </ItemTemplate>
               </asp:TemplateField>
            </Columns>
          
        </asp:GridView>
    <asp:Button ID="btnAssign1" runat="server" SkinId="btn" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" Text="Okay" Width="122px" Visible="False" /></td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
    </fieldset>
    &nbsp; &nbsp;&nbsp;
        <asp:HiddenField ID="hdnVerificatioTypeID" runat="server" />
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:RequiredFieldValidator ID="Rfvddlclient" runat="server"
        ControlToValidate="ddlclientname" Display="None" ErrorMessage="Please Select Client Name"
        InitialValue="0" ValidationGroup="FEAssign"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="FEAssign" />
    &nbsp; &nbsp;&nbsp;
      

    
</asp:Content>


