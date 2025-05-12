<%@ Page Language="C#" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="KYC_CaseEntry.aspx.cs" Inherits="KYC_KYC_CaseEntry"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">

function ClientValidate(source, arguments)
   {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
   }
 function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 49)
     {
       getControlsId.value = getControlsId.value.substring( 0, 49 );            
       return false;
     }          
   }
   
   
function checkNumeric(textBox) 
{
    var textBox = document.getElementById(textBox); 
    if(isNaN(textBox.value)) 
    {
        alert("-Please provide a numeric value."); 
        textBox.value=""; 
        return false; 
    }
}
</script>

<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset ><legend class="FormHeading">KYC Case Entry</legend>
<table style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    </td>
                    <td>
                        <table id="tblCreditCardCaseEntry" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
                        <tr><td align="center"></td></tr>
                            <tr>
                                <td>
                                    <table id="tblPerDtl" width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td colspan="8">
                                                <asp:Label ID="lblMsg" runat="server" CssClass="LabelError" Visible="False" SkinID="lblError"></asp:Label></td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="width: 92px" >
                                                REF No</td>
                                            <td >
                                                <asp:TextBox ID="txtRefNo" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td >
                                                Recv Date</td>
                                            <td  >
                                                <asp:TextBox ID="txtRecDate" runat="server" MaxLength="11" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtRecDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]</td>
                                            <td >
                                                Recv Time</td>
                                            <td colspan="3" >
                                                <asp:TextBox ID="txtRecTime" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
                                                <asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>[hh:mm]
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 92px" >
                                                Title</td>
                                            <td>
                                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                First Name</td>
                                            <td >
                                                <asp:TextBox ID="txtFirstNm" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td >
                                                Middle Name</td>
                                            <td>
                                                <asp:TextBox ID="txtMiddleNm" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td >
                                                Last Name</td>
                                            <td >
                                                <asp:TextBox ID="txtLastNm" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 92px">
                                                Verification Type</td>
                                            <td>
                                                <asp:DropDownList ID="ddlVeriType" runat="server" DataSourceID="sdsVeriType" DataTextField="VERIFICATION_TYPE_CODE"
                                                    DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlVeriType_DataBound" SkinID="ddlSkin">
                                                </asp:DropDownList></td>
                                                <td>DOB</td>
                                               <td colspan="5">
                                                <asp:TextBox ID="txtDOB" runat="server" MaxLength="11" SkinID="txtSkin"></asp:TextBox>
                                                <img alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                [dd/MM/yyyy]</td>
                                        </tr>
                                    </table>
                                    <table id="tblResDtl" width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr><td colspan="4" class="txtBold" style="background-color:#D0D5D8; height: 16px;" align="center">Residence Detail</td></tr>
                                        <tr>
                                            <td>
                                                Address1</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtResAdd1" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="277px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd1')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd1');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Address2</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtResAdd2" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="276px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd2')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd2');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Address3</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtResAdd3" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="276px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd3')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd3');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                City</td>
                                            <td>
                                                <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                Pin</td>
                                            <td>
                                                <asp:TextBox ID="txtResPin" runat="server" MaxLength="10" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtResPin');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Res Land Mark</td>
                                            <td>
                                                <asp:TextBox ID="txtLandMark" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                Res Phone</td>
                                            <td>
                                                <asp:TextBox ID="txtResPhone" runat="server" MaxLength="50" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtResPhone');"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    <table id="tblOfficeDtl" width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr><td colspan="4" class="txtBold" style="background-color:#D0D5D8; height: 16px;" align="center">Office Detail</td></tr>
                                        <tr>
                                            <td >
                                                Address1</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtOffAdd1" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="275px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd1')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd1');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td >
                                                Address2</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtOffAdd2" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="275px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd2')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd2');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td >
                                                Address3</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtOffAdd3" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="274px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd3')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd3');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td >
                                                City</td>
                                            <td>
                                                <asp:TextBox ID="txtOffCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                Pin</td>
                                            <td>
                                                <asp:TextBox ID="txtOffPin" runat="server" MaxLength="10" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtOffPin');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Off. Phone</td>
                                            <td>
                                                <asp:TextBox ID="txtOffPhone" runat="server" MaxLength="50" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtOffPhone');"></asp:TextBox></td>
                                            <td>
                                                Off. Extn</td>
                                            <td>
                                                <asp:TextBox ID="txtOffExtn" runat="server" MaxLength="10" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtOffExtn');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Designation</td>
                                            <td>
                                                <asp:TextBox ID="txtDesgn" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                Department</td>
                                            <td>
                                                <asp:TextBox ID="txtDept" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Occupation</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtOccupation" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td><br /></td></tr>
                            <tr>
                            <td align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="grpValidate" SkinID="btnSubmitSkin" />
                                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" SkinID="btncancelskin" /></td>
                            </tr>
                             
                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
      <tr>
          <td>
          </td>
          <td>
             </td>
          <td>
          </td>
      </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:SqlDataSource ID="sdsKYC" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT REF_NO, CASE_REC_DATETIME, TITLE, (FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME) as NAME, DOB, RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT FROM CPV_CC_CASE_DETAILS"
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                       
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sdsVeriType" runat="server" SelectCommand ="Select [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER 
               WHERE VERIFICATION_TYPE_ID IN(1,2,19) AND (PARENT_TYPE_CODE = 'VV')" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
               <asp:CustomValidator ID="valVeriType" runat="server" ControlToValidate="ddlVeriType"
                                                    Display="None" ErrorMessage="Please select Verification Type" SetFocusOnError="True" ClientValidationFunction="ClientValidate" ValidationGroup="grpValidate"></asp:CustomValidator>&nbsp;
                        <asp:RegularExpressionValidator ID="revReceived" runat="server" ControlToValidate="txtRecDate"
                            Display="None" ErrorMessage="Please enter valid date format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter valid time format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvRecDate" runat="server" ErrorMessage="Please enter Received date." ControlToValidate="txtRecDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter Received time." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
                    </td>
                    <td >
                    </td>
                </tr>
               
               
            </table>
            </fieldset>
</td></tr></table>
            

</asp:Content>



