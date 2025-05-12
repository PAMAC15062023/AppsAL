<%@ Page Language="C#" MasterPageFile="CC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="CC_CaseEntry.aspx.cs"  Inherits="CC_CC_CaseEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
function ValidateTextLength(DisplayName, ControlName, xLength)
{
    if (ControlName.value.length > parseInt(xLength))
    {
         alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
         ControlName.focus();   
    }      
}

</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
  <fieldset ><legend class="FormHeading">Credit Card Case Entry</legend>
<table border="0" cellpadding="1" cellspacing="0" width="100%" id="TABLE1">
    <tr>
        <td colspan="9" ><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td>
            Case Type</td>
        <td >
        :</td>
        <td>
        <asp:DropDownList SkinID="ddlSkin" ID="ddCaseType" runat="server">
        <asp:ListItem>Fresh</asp:ListItem>
        <asp:ListItem>Redu</asp:ListItem>
        <asp:ListItem>RCC</asp:ListItem>
        </asp:DropDownList></td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
<tr>
    <td>REF No</td>
    <td >:</td>
    <td><asp:TextBox id="txtRefNo" runat="server" SkinID="txtSkin" MaxLength="50" Columns="30"></asp:TextBox></td>
    <td>Recv Date</td>
    <td>:</td>
    <td><asp:TextBox id="txtRecDate" runat="server" SkinID="txtSkin" MaxLength="10" Columns="8"></asp:TextBox>
    <IMG id="imgRecDate" 
onclick="popUpCalendar(this, document.all.<%=txtRecDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
alt="Calendar" src="../../Images/SmallCalendar.gif" /></td>
    <td>Recv Time</td>
    <td>:</td>
    <td><asp:TextBox id="txtRecTime" runat="server" SkinID="txtSkin" MaxLength="5" Columns="8"></asp:TextBox>
    <asp:DropDownList id="ddlTimeType" runat="server" SkinID="ddlSkin">
        <asp:ListItem>AM</asp:ListItem>
        <asp:ListItem>PM</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
    <tr>
        <td>
            Title</td>
        <td >
            :</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" SkinID="txtSkin" Columns="10"></asp:TextBox>
        </td>
        <td >
            First Name</td>
        <td>
            :</td>
        <td >
            <asp:TextBox ID="txtFirstNm" runat="server" MaxLength="50" SkinID="txtSkin" Columns="30"></asp:TextBox></td>
        <td>
            Middle Name</td>
        <td>
           :</td>
        <td>
            <asp:TextBox ID="txtMiddleNm" runat="server" MaxLength="50" SkinID="txtSkin" Columns="30"></asp:TextBox></td>
    </tr>
    <tr>
    <td> Last Name</td>
    <td>:</td>
    <td><asp:TextBox ID="txtLastNm" runat="server" MaxLength="50" SkinID="txtSkin" Columns="30"></asp:TextBox>
            </td>
    <td>DOB</td>
    <td>:</td>
    <td> <asp:TextBox ID="txtDOB" runat="server" MaxLength="50" SkinID="txtSkin" Columns="12"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.gif" /></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
        <td>
            Verification Type</td>
        <td>
            :</td>
        <td colspan="7">
            <asp:CheckBoxList ID="chkCaseVerification" SkinID="chkListSkin" runat="server" RepeatDirection="Horizontal" ></asp:CheckBoxList></td>
    </tr>
    <tr>
        <td style="height: 16px">
            </td>
        <td   >
        </td>
        <td >
        </td>
        <td  >
        </td>
        <td  >
        </td>
        <td  >
        </td>
        <td >
        </td>
        <td >
        </td>
        <td >
        </td>
    </tr>
    <tr>
        <td colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px;">
            Residence Detail</td>
    </tr>
    <tr>
        <td>
            Address1</td>
        <td>
            :</td>
        <td colspan="7" >
            <asp:TextBox ID="txtResAdd1" runat="server" MaxLength="100" SkinID="txtSkin" Columns="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td >
            Address2</td>
        <td>
            :</td>
        <td colspan="7">
        <asp:TextBox SkinID="txtSkin" ID="txtResAdd2" runat="server" Columns="100" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Address3</td>
        <td>
            :</td>
        <td colspan="7">
        <asp:TextBox SkinID="txtSkin" ID="txtResAdd3" runat="server" Columns="100" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            City</td>
        <td >
            :</td>
        <td>
            <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td  >
            State</td>
        <td >
            :</td>
        <td>
            <asp:TextBox ID="txtResState" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td>
        Pin</td>
        <td>
        :</td>
        <td>
        <asp:TextBox ID="txtResPin" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            Res Land Mark</td>
        <td >
            :</td>
        <td>
            <asp:TextBox ID="txtLandMark" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox>
            </td>
        <td >
            Res. Phone</td>
        <td >
            :</td>
        <td>
            <asp:TextBox ID="txtResPhone" runat="server" MaxLength="50"  SkinID="txtSkin"></asp:TextBox></td>
        <td>
            Mobile</td>
        <td>
            :</td>
        <td>
        <asp:TextBox ID="txtResMob" SkinID="txtSkin" MaxLength="50" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
        </td>
        <td >
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px;">
            Office Detail</td>
    </tr>
    <tr>
    <td>Office Name</td>
    <td>:</td>
    <td colspan="7"><asp:TextBox ID="txtOffName" SkinID="txtSkin" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            Address1</td>
        <td>
            :</td>
        <td colspan="7" >
            <asp:TextBox ID="txtOffAdd1" runat="server"  MaxLength="100" Columns="100"  SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            Address2</td>
        <td>
            :</td>
        <td colspan="7">
            <asp:TextBox ID="txtOffAdd2" runat="server" Columns="100" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td >
            Address3</td>
        <td>
            :</td>
        <td  colspan="7">
            <asp:TextBox ID="txtOffAdd3" runat="server" Columns="100" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
          
            
    </tr>
    <tr>
        <td >
            City</td>
        <td >
            :</td>
        <td >
            <asp:TextBox ID="txtOffCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td>
            State</td>
        <td>
            :</td>
        <td >
           <asp:TextBox ID="txtOffState" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td>
        Pin</td>
        <td >
        :</td>
        <td>
        <asp:TextBox ID="txtOffPin" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td  >
            Off. Phone</td>
        <td  >
            :</td>
        <td  >
            <asp:TextBox ID="txtOffPhone" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td  >
            Off. Extn</td>
        <td  >
            :</td>
        <td >
            <asp:TextBox ID="txtOffExtn" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
        <td  >
            Occupation</td>
        <td  >
            :</td>
        <td><asp:TextBox ID="txtOccupation" SkinID="txtSkin" runat="server" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Designation</td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtDesgn" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td>
            Department
        </td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtDept" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td>
            Priority</td>
        <td >
            :</td>
        <td><asp:TextBox ID="txtOffPriority" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>Region</td>
    <td>:</td>
    <td colspan="7"><asp:TextBox ID="txtregion" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
    <td>SPL Instruction</td>
    <td>:</td>
    <td colspan="7"><asp:TextBox ID="txtSplInst" runat="server" Columns="50" MaxLength="255" SkinID="txtSkin" onkeyPress="ValidateTextLength('Remark', this, 255);" TextMode="MultiLine" ></asp:TextBox></td>
    </tr>
    
    <tr>
        <td >
           </td>
        <td >
        </td>
        <td >
        </td>
        <td >
        </td>
        <td >
        </td>
        <td >
        </td>
        <td >
        </td>
        <td >
        </td>
        <td  >
        </td>
    </tr>
    <tr>
        <td  colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px;" >
         Permanent Address</td>
         </tr>
         <tr>
        <td>
           Address1</td>
        <td>
        :</td>
        <td  colspan="7" style="height: 26px" >
         <asp:TextBox ID="txtPmtAdd1" runat="server"  MaxLength="100" Columns="100"  SkinID="txtSkin"></asp:TextBox></td>
        
    </tr>
    <tr>
        <td >
            Address2</td>
        <td  >
        :</td>
        <td colspan="7"  >
        <asp:TextBox ID="txtPmtAdd2" runat="server"  MaxLength="100" Columns="100"  SkinID="txtSkin"></asp:TextBox></td>
        
    </tr>
    <tr>
    <td >
    Address3</td>
    <td  >
        :</td>
    <td colspan="7">
    <asp:TextBox ID="txtPmtAdd3" runat="server"  MaxLength="100" Columns="100"  SkinID="txtSkin"></asp:TextBox></td>
    
    </tr>
    <tr>
    <td>City</td>
    <td>:</td>
    <td><asp:TextBox  SkinID="txtSkin" ID="txtPmtCity" runat="server" MaxLength="50"></asp:TextBox></td>
    <td>
       State</td>
    <td>
        :</td>
    <td><asp:TextBox  SkinID="txtSkin" ID="txtPmtState" runat="server" MaxLength="50"></asp:TextBox></td>
    <td> Pin</td>
    <td>:</td>
    <td><asp:TextBox  SkinID="txtSkin" ID="txtPmtpin" runat="server" MaxLength="10"></asp:TextBox></td>
    </tr>
    <tr>
    <td >
        Phone</td>
    <td >
        :</td>
    <td ><asp:TextBox  SkinID="txtSkin" ID="txtPmtPhone" runat="server" MaxLength="30"></asp:TextBox></td>
    <td >
        LandMark</td>
    <td>
        :</td>
    <td ><asp:TextBox SkinID="txtSkin" ID="txtPmtLand" runat="server" MaxLength="50"></asp:TextBox></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
    
    <td ></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
        <td colspan="9" align="center">
            <asp:Button ID="btnSubmit" runat="server"  SkinID="btnSubmitSkin" Text="Submit" ValidationGroup="grpValidate" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin"
                Text="Cancel" OnClick="btnCancel_Click" /></td>
    </tr>
    <tr>
    <td colspan="9"></td>
    
    </tr>
    <tr>
        <td colspan="9" style="height: 16px">
        <asp:SqlDataSource ID="sdsCreditCard" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT REF_NO, CASE_REC_DATETIME, TITLE, (isnull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as NAME, DOB, RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY,RES_STATE, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE,MOBILE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT,OCCUPATION,PRIORITY,REGION,SPL_INSTRUCTION,PMT_ADD_LINE_1,PMT_ADD_LINE_2,PMT_ADD_LINE_3,PMT_CITY,PMT_STATE,PMT_PINCODE,PMT_LANDMARK,PMT_PHONE FROM CPV_CC_CASE_DETAILS"
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                       
                    </asp:SqlDataSource>
                    <asp:RegularExpressionValidator ID="revReceived" runat="server" ControlToValidate="txtRecDate"
                            Display="None" ErrorMessage="Please enter valid date format for Received date."
                            SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter valid time format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvRecDate" runat="server" ErrorMessage="Please enter Received date." ControlToValidate="txtRecDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <%--<asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                            Display="None" ErrorMessage="Please enter Date of birth." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>--%>
                        <asp:RequiredFieldValidator ID="rfvRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter Received time." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
        </td>
    </tr>
    <tr>
        <td colspan="9" >
        </td>
    </tr>
   </table>
</fieldset>
</td></tr>
</table>
</asp:Content>

